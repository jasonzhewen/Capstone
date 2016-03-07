using OmniDrome.DataAccessLayer;
using OmniDrome.Models;
using OmniDrome.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OmniDrome.Controllers
{
    public class DBoardController : Controller
    {
        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();
        // GET: DBoard
        public ActionResult Index()
        {

            return View();
        }

        [ChildActionOnly]
        public ActionResult DashBoard_Users()
        {

            var backgroundInfoes = db.BackgroundInfoes.Include(b => b.UserInfo);
            return View(backgroundInfoes.ToList());
        }

        //Data that is to be displayed in th Pie Chrt
        public JsonResult GetPieChartData()
        {

            var data = new[] { new { Name = "IT", Value = 25000 }, 
                                new { Name = "Pharma", Value = 5418 },
                                new { Name = "Technician", Value = 8457 },
                                new { Name = "Teachers", Value = 12457 },
                                new { Name = "Others", Value = 874 },};

            return Json(data);
        }

       [ChildActionOnly]
        public ActionResult DashboardItem_SalesPie()
        {
            return View();
        }


       
        //this is used with User Infoes table
        [ChildActionOnly]
       public ActionResult UserInfoTable()
       {
           //var userInfoes = db.UserInfoes.Include(b => b.UserInfo);
           //return View(UserInfoes.ToList());
           var userInfos = db.UserInfoes;
           return View(userInfos.ToList());
       }
       //summ
       //public ActionResult MyChartOwn(int? page)
       //{
       //    var model = new ChartViewModel
       //    {
       //        Chart = GetChart()
       //    };
       //    return View(model);
       //}
       private Chart GetChart()
       {
           return new Chart(600, 400, ChartTheme.Blue)
               .AddTitle("Number of website readers")
               .AddLegend()
               .AddSeries(
                   name: "WebSite",
                   chartType: "Pie",
                   xValue: new[] { "Digg", "DZone", "DotNetKicks", "StumbleUpon" },
                   yValues: new[] { "150000", "180000", "120000", "250000" });

       }


    }
}