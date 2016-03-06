using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OmniDrome.Models;
using OmniDrome.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniDrome.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {          
            return View("Profile");
        }

        [Authorize]
        public ActionResult ShowInfo()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult AddInfo()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult EditInfo()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult GetInfoData()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return Json(GetPersonalDetails(id), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public PersonalDetailsViewModel GetPersonalDetails(int? id)
        {
            PersonalDetailsViewModel personalDetailsViewModel = new PersonalDetailsViewModel();
            personalDetailsViewModel.personalDetailsModel = new Models.PersonalDetailsModel();
            PersonalDetailsBusinessLayer pdBal = new PersonalDetailsBusinessLayer();
            PersonalDetails pd = pdBal.GetPersonalDetailsByID(id);
            if (pd == null)
            {
            }
            else
            {
                personalDetailsViewModel.personalDetailsModel.ID = pd.ID;
                personalDetailsViewModel.personalDetailsModel.firstName = pd.firstName;
                personalDetailsViewModel.personalDetailsModel.lastName = pd.lastName;
                personalDetailsViewModel.personalDetailsModel.contactNumber = pd.contactNumber;
                personalDetailsViewModel.personalDetailsModel.profession = pd.profession;
                personalDetailsViewModel.personalDetailsModel.currentCity = pd.currentCity;
                personalDetailsViewModel.personalDetailsModel.currentCountry = pd.currentCountry;
                personalDetailsViewModel.personalDetailsModel.dateOfBirth = pd.dateOfBirth.ToString("yyyy-MM-dd");
                personalDetailsViewModel.personalDetailsModel.imageUrl = pd.imageUrl;
                if (personalDetailsViewModel.personalDetailsModel.imageUrl == null)
                {
                    personalDetailsViewModel.personalDetailsModel.imageUrl = "/Images/PersonalImages/no-Image.png";
                }
            }

            return personalDetailsViewModel;
        }

        [HttpPost]
        [Authorize]
        public void AddPersonalInfo(PersonalDetailsModel PersonalDetailsModelClient)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;

            PersonalDetails pd = new PersonalDetails();
            pd.firstName = PersonalDetailsModelClient.firstName;
            pd.lastName = PersonalDetailsModelClient.lastName;
            pd.profession = PersonalDetailsModelClient.profession;
            pd.contactNumber = PersonalDetailsModelClient.contactNumber;
            pd.currentCity = PersonalDetailsModelClient.currentCity;
            pd.currentCountry = PersonalDetailsModelClient.currentCountry;
            pd.dateOfBirth = Convert.ToDateTime(PersonalDetailsModelClient.dateOfBirth);
            pd.imageUrl = PersonalDetailsModelClient.imageUrl;
            pd.UserInfoID = id;
            PersonalDetailsBusinessLayer pdBal = new PersonalDetailsBusinessLayer();
            pdBal.InsertPersonalDetails(pd);
        }

        [HttpPost]
        [Authorize]
        public void UpdatePersonalInfo(PersonalDetails PersonalDetailsModelClient)
        {
            PersonalDetailsBusinessLayer pdBal = new PersonalDetailsBusinessLayer();
            pdBal.UpdatePersonalDetails(PersonalDetailsModelClient);
        }

        [Authorize]
        public ActionResult ShowBackgroundInfo()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult TimeLinePartial()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return PartialView(GetBInfo(id, false));
        }

        public BackgroundInfoListViewModel GetBInfo(int? id, Boolean isCurrentPosition)
        {
            BackgroundInfoListViewModel backgroundInfoList = new BackgroundInfoListViewModel();
            List<BackgroundInfoViewModel> backgroundInfoes = new List<BackgroundInfoViewModel>();
            List<BackgroundInfo> backInfoes = GetBackgroundInfo(id, isCurrentPosition);
            foreach (BackgroundInfo bi in backInfoes)
            {
                BackgroundInfoViewModel backgroundInfoView = new BackgroundInfoViewModel();
                backgroundInfoView.ID = bi.ID;
                backgroundInfoView.type = bi.type;
                backgroundInfoView.title = bi.title;
                backgroundInfoView.duration = bi.startDate.ToString("yyyy-MM-dd") + " - " + bi.endDate.ToString("yyyy-MM-dd");
                backgroundInfoView.endDate = bi.endDate.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                backgroundInfoView.description = bi.description;
                backgroundInfoes.Add(backgroundInfoView);
            }
            backgroundInfoList.backgroundInfoListViewModel = backgroundInfoes;
            return backgroundInfoList;
        }

        [Authorize]
        public ActionResult AddBackgroundInfo()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult EditBackgroundInfo()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult GetBackgroundInfoData()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            List<BackgroundInfo> backInfoes = GetBackgroundInfo(id,false);
            return Json(backInfoes, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public List<BackgroundInfo> GetBackgroundInfo(int? id, Boolean isCurrentPosition)
        {
            BackgroundInfoBusinessLayer bibl = new BackgroundInfoBusinessLayer();
            List<BackgroundInfo> BackgroundInfoes = bibl.GetBackgroundInfoByID(id, isCurrentPosition);
            if (BackgroundInfoes == null)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                DateTime registerDate = currentUser.UserInfo.RegisterDate;
                BackgroundInfo bi = new BackgroundInfo();
                bi.title = "Welcome to OmniDrome";
                bi.startDate = registerDate;
                bi.endDate = registerDate;
                bi.description = "You come to us at this day! If you see this, which means you do not have any information with us.";
                BackgroundInfoes.Add(bi);
            }
            return BackgroundInfoes;
        }

        [HttpPost]
        [Authorize]
        public void AddBackgroundInfo(BackgroundInfo BackgroundInfoClient)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            BackgroundInfo bi = new BackgroundInfo();
            bi.UserInfoID = id;
            bi.title = BackgroundInfoClient.title;
            bi.type = BackgroundInfoClient.type;
            bi.startDate = BackgroundInfoClient.startDate;
            bi.endDate = BackgroundInfoClient.endDate;
            bi.description = BackgroundInfoClient.description;
            bi.isCurrentPosition = false;
            BackgroundInfoBusinessLayer biBal = new BackgroundInfoBusinessLayer();
            biBal.InsertBackgroundInfo(bi);
        }

        [HttpPost]
        [Authorize]
        public ActionResult GetBackgroundInfoByInfoID(int? id)
        {
            BackgroundInfoBusinessLayer biBal = new BackgroundInfoBusinessLayer();          
            return Json(biBal.GetBackgroundInfoByInfoID(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public void UpdateBackgroundInfo(BackgroundInfo BackgroundInfoClient)
        {
            BackgroundInfoBusinessLayer biBal = new BackgroundInfoBusinessLayer();
            biBal.UpdateBackgroundInfo(BackgroundInfoClient);
        }

        [HttpPost]
        [Authorize]
        public void DeleteBackgroundInfo(int? id)
        {
            BackgroundInfoBusinessLayer biBal = new BackgroundInfoBusinessLayer();
            biBal.DeleteBackgroundInfoByID(id);
        }

        [Authorize]
        public ActionResult CurrentPosition()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult AddCurrentPosition()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult EditCurrentPosition()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult DoneCurrentPosition()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult GetCurrentPosition()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            BackgroundInfo currentP = GetCurrentPositionData(id, true);
            return Json(currentP, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public BackgroundInfo GetCurrentPositionData(int? id, Boolean isCurrentPosition)
        {
            CurrentPositionBusinessLayer cpbl = new CurrentPositionBusinessLayer();
            BackgroundInfo currentPosition = cpbl.GetCurrentPositionByID(id, isCurrentPosition);
            return currentPosition;
        }

        [HttpPost]
        [Authorize]
        public void AddCurrentPositionData(BackgroundInfo BackgroundInfoClient)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            BackgroundInfo bi = new BackgroundInfo();
            bi.UserInfoID = id;
            bi.title = BackgroundInfoClient.title;
            bi.endDate = new DateTime(2013,02,08);
            bi.startDate = BackgroundInfoClient.startDate;
            bi.description = BackgroundInfoClient.description;
            bi.isCurrentPosition = true;
            CurrentPositionBusinessLayer cpBal = new CurrentPositionBusinessLayer();
            cpBal.InsertCurrentPosition(bi);
        }

        [HttpPost]
        [Authorize]
        public void UpdateCurrentPosition(BackgroundInfo CurrentPositionClient)
        {
            CurrentPositionBusinessLayer cpbl = new CurrentPositionBusinessLayer();
            cpbl.UpdateCurrentPosition(CurrentPositionClient);
        }
    }
}