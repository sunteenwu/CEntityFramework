using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CEntityFrame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Dataload();
        }

        public void Dataload()
        {
            using (var db = new DataContext())
            {
                if (db.Reports != null)
                {
                    ReportSources.ItemsSource = db.Reports.ToList();
                }

            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new DataContext())
            {
                List<Report> Reports;
                Reports = db.Reports.Include(report => report.Schedules)
                                    .ThenInclude(schedule => schedule.Descriptions)
                                .ToList();
                var report2 = Reports[0];
                db.Reports.Remove(report2);
                db.SaveChanges();
            }
            Dataload();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Description description = new Description();
            description.DescriptionId = Guid.NewGuid();
            description.Content = "my content";

            Schedule schedule = new Schedule();
            schedule.ScheduleId = Guid.NewGuid();
            schedule.Title = "my schedule";
            schedule.Descriptions = new List<Description>();
            schedule.Descriptions.Add(description);

            Report report = new Report();
            report.ReportId = Guid.NewGuid();
            report.Name = TxtReportName.Text;
            report.Schedules = new List<Schedule>();
            report.Schedules.Add(schedule);

            using (var db = new DataContext())
            {
                db.Reports.Add(report);
                db.SaveChanges();
            }

            Dataload();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //List<Report> Reports;
            //using (var db = new DataContext())
            //    Reports = db.Reports.Include(report => report.Schedules)
            //                        .ThenInclude(schedule => schedule.Descriptions)
            //                    .ToList();
            //using (var db = new DataContext())
            //{
            //    List<Report> Reports;
            //    Reports = db.Reports.Include(report1 => report1.Schedules)
            //                        .ThenInclude(schedule => schedule.Descriptions)
            //                    .ToList();
            //    var report = Reports[1];
            //    report.Name = "updated report";
            //    report.Schedules.ElementAt(0).Descriptions.ElementAt(0).Content = "updated content";
            //    db.Reports.Update(report);
            //    db.SaveChanges();

            //}


            //// this throws DbUpdateConcurrencyException because no rows are affected.

            using (var db = new DataContext())
            {
                List<Report> Reports;
                Reports = db.Reports.Include(report1 => report1.Schedules)
                                    .ThenInclude(schedule => schedule.Descriptions)
                                .ToList();
                var report = Reports[0];

                Description newDescription = new Description();
                newDescription.DescriptionId = Guid.NewGuid();
                newDescription.Content = "new content";

                Schedule newSchedule = new Schedule();
                newSchedule.ScheduleId = Guid.NewGuid();
                newSchedule.Title = "new schedule";
                newSchedule.Descriptions = new List<Description>();
                newSchedule.Descriptions.Add(newDescription);
                report.Schedules.Add(newSchedule);
                db.Reports.Update(report);
                db.SaveChanges();
            }

            Dataload();
        }
    }
}
