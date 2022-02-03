using IllinoisExpertsManualAdditions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IllinoisExpertsManualAdditions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var ret = new Addition();

            ret.Netids = getNetids();

            return View(ret);
        }

        public IActionResult ProcessIds(string netids)
        {
            bool dups = false;
            if (netids != null)
            {
                string[] lines = netids.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                    );

                using (var context = new IRCContext())
                {
                    var existingnetids = (from n in context.ExpertsAdditions select n.Netid);

                    foreach (var item in lines)
                    {
                        ExpertsAddition ea = new ExpertsAddition();
                        ea.Netid = item;
                        ea.Dateadded = DateTime.UtcNow;

                        if (!existingnetids.Contains(item))
                        {
                            context.ExpertsAdditions.Add(ea);
                            context.SaveChanges();
                        }
                        else
                        {
                            dups = true;
                        }
                        TempData["msg"] = "NetId(s) added.";

                        if (dups == true)
                        {
                            TempData["msg"] += " Some netids already existed in the ID List.";
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public List<ExpertsAddition> getNetids()
        {
            var netids = new List<ExpertsAddition>();
            using (var context = new IRCContext())
            {
                netids = (from n in context.ExpertsAdditions
                          orderby n.Dateadded descending
                          select n).ToList();
            }
            return netids;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
