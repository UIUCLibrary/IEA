using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IllinoisExpertsManualAdditions.Models
{
    public partial class IRCContext : DbContext
    {
        public IRCContext()
        {
        }

        public IRCContext(DbContextOptions<IRCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExpertsAddition> ExpertsAdditions { get; set; }
        public virtual DbSet<FacultyAppointmentsCrosswalk> FacultyAppointmentsCrosswalks { get; set; }
        public virtual DbSet<IrcPt05Org> IrcPt05Orgs { get; set; }
        public virtual DbSet<IrcPt0Faculty> IrcPt0Faculties { get; set; }
        public virtual DbSet<IrcPt1Job> IrcPt1Jobs { get; set; }
        public virtual DbSet<IrcPt2Urbprev> IrcPt2Urbprevs { get; set; }

        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=lib-mssql-misc;Database=IRC;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ExpertsAddition>(entity =>
            {
                entity.HasKey(e => e.Netid);

                entity.Property(e => e.Netid)
                    .HasMaxLength(50)
                    .HasColumnName("netid");

                entity.Property(e => e.Dateadded)
                    .HasColumnType("date")
                    .HasColumnName("dateadded")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<FacultyAppointmentsCrosswalk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Faculty_Appointments_Crosswalk");

                entity.Property(e => e.CleanTitle).HasMaxLength(255);

                entity.Property(e => e.JobDetlTitle)
                    .HasMaxLength(255)
                    .HasColumnName("JOB_DETL_TITLE");
            });

            modelBuilder.Entity<IrcPt05Org>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("irc_pt0.5_orgs");

                entity.Property(e => e.AdminCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_CD");

                entity.Property(e => e.CampusCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS_CD");

                entity.Property(e => e.CollCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COLL_CD");

                entity.Property(e => e.DeptCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_CD");

                entity.Property(e => e.OrgTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ORG_TITLE");

                entity.Property(e => e.Organizationid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZATIONID");

                entity.Property(e => e.Pt05id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pt05id");

                entity.Property(e => e.Pulldate)
                    .HasColumnType("date")
                    .HasColumnName("pulldate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchoolCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SCHOOL_CD");
            });

            modelBuilder.Entity<IrcPt0Faculty>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("irc_pt0_faculty");

                entity.Property(e => e.EdwPersId).HasColumnName("EDW_PERS_ID");

                entity.Property(e => e.Externallyauthenticated)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXTERNALLYAUTHENTICATED");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Netid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NETID");

                entity.Property(e => e.Personid)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("PERSONID");

                entity.Property(e => e.Ppn)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PPN");

                entity.Property(e => e.Profiled)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROFILED");

                entity.Property(e => e.Pt0id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pt0id");

                entity.Property(e => e.Pulldate)
                    .HasColumnType("date")
                    .HasColumnName("pulldate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Visibility)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IrcPt1Job>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("irc_pt1_jobs");

                entity.Property(e => e.CampusCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAMPUS_CD");

                entity.Property(e => e.CollCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COLL_CD");

                entity.Property(e => e.DeptCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_CD");

                entity.Property(e => e.EdwPersId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EDW_PERS_ID");

                entity.Property(e => e.Firstmiddlename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTMIDDLENAME");

                entity.Property(e => e.Grp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GRP");

                entity.Property(e => e.Grpdesc)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("GRPDESC");

                entity.Property(e => e.HmCampus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HM_CAMPUS");

                entity.Property(e => e.HmDept)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HM_DEPT");

                entity.Property(e => e.JobDetlEmpeeClsCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DETL_EMPEE_CLS_CD");

                entity.Property(e => e.JobDetlFte)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DETL_FTE");

                entity.Property(e => e.JobDetlPayPerdSal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DETL_PAY_PERD_SAL");

                entity.Property(e => e.JobDetlPosnClsCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DETL_POSN_CLS_CD");

                entity.Property(e => e.JobDetlTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DETL_TITLE");

                entity.Property(e => e.PersFname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERS_FNAME");

                entity.Property(e => e.PersLname)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("PERS_LNAME");

                entity.Property(e => e.PersMname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERS_MNAME");

                entity.Property(e => e.Pt1id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pt1id");

                entity.Property(e => e.Pulldate)
                    .HasColumnType("date")
                    .HasColumnName("pulldate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SchoolCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SCHOOL_CD");

                entity.Property(e => e.Uin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UIN");
            });

            modelBuilder.Entity<IrcPt2Urbprev>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("irc_pt2_urbprev");

                entity.Property(e => e.Appointment)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("APPOINTMENT");

                entity.Property(e => e.EdwPersId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EDW_PERS_ID");

                entity.Property(e => e.Enddate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Organization)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZATION");

                entity.Property(e => e.Pt2id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pt2id");

                entity.Property(e => e.Pulldate)
                    .HasColumnType("date")
                    .HasColumnName("pulldate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Startdate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Uin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UIN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
