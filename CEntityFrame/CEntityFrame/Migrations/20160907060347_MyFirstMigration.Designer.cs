using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CEntityFrame;

namespace CEntityFrame.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160907060347_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("CEntityFrame.Description", b =>
                {
                    b.Property<Guid>("DescriptionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<Guid>("ScheduleId");

                    b.HasKey("DescriptionId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Description");
                });

            modelBuilder.Entity("CEntityFrame.Report", b =>
                {
                    b.Property<Guid>("ReportId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ReportId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("CEntityFrame.Schedule", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ReportId");

                    b.Property<string>("Title");

                    b.HasKey("ScheduleId");

                    b.HasIndex("ReportId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("CEntityFrame.Description", b =>
                {
                    b.HasOne("CEntityFrame.Schedule", "Schedule")
                        .WithMany("Descriptions")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CEntityFrame.Schedule", b =>
                {
                    b.HasOne("CEntityFrame.Report", "Report")
                        .WithMany("Schedules")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
