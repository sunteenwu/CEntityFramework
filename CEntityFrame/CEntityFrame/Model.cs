using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntityFrame
{
    public class Report
    {
        public Guid ReportId { get; set; }
        public string Name { get; set; }
        public List<Schedule> Schedules { get; set; }
    }

    public class Schedule
    {
        public Guid ScheduleId { get; set; }
        public string Title { get; set; }
        public List<Description> Descriptions { get; set; }

        // FK
        public Guid ReportId { get; set; }
        public Report Report { get; set; }
    }

    public class Description
    {
        public Guid DescriptionId { get; set; }
        public string Content { get; set; }

        // FK
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }

    public class DataContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=mydbname.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .HasMany(report => report.Schedules)
                .WithOne(schedule => schedule.Report);
            modelBuilder.Entity<Schedule>()
                .HasOne(schedule => schedule.Report)
                .WithMany(report => report.Schedules)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Description>()
                .HasOne(description => description.Schedule)
                .WithMany(schedule => schedule.Descriptions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
