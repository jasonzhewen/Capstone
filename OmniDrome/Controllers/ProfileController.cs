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
            if (backInfoes.Count == 0)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                DateTime registerDate = currentUser.UserInfo.RegisterDate;
                BackgroundInfoViewModel bi = new BackgroundInfoViewModel();
                bi.title = "Welcome to OmniDrome";
                bi.type = 0;
                bi.duration = registerDate.ToString("yyyy-MM-dd") + " - ";
                bi.endDate = registerDate.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                bi.description = "You come to us at this day! If you see this, which means you do not have any information with us.";
                backgroundInfoes.Add(bi);
            }
            else
            {
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
        public List<BackgroundInfo> GetBackgroundInfo(int? id, Boolean isCurrentPosition)
        {
            BackgroundInfoBusinessLayer bibl = new BackgroundInfoBusinessLayer();
            List<BackgroundInfo> BackgroundInfoes = bibl.GetBackgroundInfoByID(id, isCurrentPosition);
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

        //DREAMJOB STARTS HERE
        //add dream job
        public ActionResult GetTitles()
        {
            return PartialView();
        }

        public ActionResult GetTenTitles(string searchStringClient)
        {
            GovDbBusinessLayer gv = new GovDbBusinessLayer();
            List<Title> titleList = gv.GetTitles(searchStringClient);
            if (String.IsNullOrEmpty(searchStringClient))
            {
                Title t = new Title();
                t.Titl = "no title is selected";
                titleList.Add(t);
            }

            return Json(titleList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSuggestedDuties(int NocCode)
        {
            GovDbBusinessLayer gv = new GovDbBusinessLayer();
            List<Duty> dutyList = gv.GetDutiesForTitle(NocCode);
            return Json(dutyList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRequirements(int NocCode)
        {
            GovDbBusinessLayer gv = new GovDbBusinessLayer();
            List<Requirement> requirementList = gv.GetRequirementsForTitle(NocCode);
            return Json(requirementList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public void AddDreamJobDetails(DreamJob DreamJobClient)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            DreamJob dj = new DreamJob();
            dj.UserInfoID = id;
            dj.companyName = DreamJobClient.companyName;
            dj.position = DreamJobClient.position;
            dj.startDate = DreamJobClient.startDate;
            dj.description = DreamJobClient.description;

            DreamJobBusinessLayer djBal = new DreamJobBusinessLayer();
            djBal.InsertDreamJobDetails(dj);
        }

        //get view of dream job
        [Authorize]
        public ActionResult ShowDreamJob()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult CtrlGetDreamJob()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            DreamJobBusinessLayer drjobdb = new DreamJobBusinessLayer();
            return Json(drjobdb.GetDreamJobByID(id), JsonRequestBehavior.AllowGet);
        }

        //delete dream job
        [HttpPost]
        [Authorize]
        public void DeleteDreamJobInfo(int? id)
        {
            DreamJobBusinessLayer drjobdb = new DreamJobBusinessLayer();
            drjobdb.DeleteDreamJobByID(id);
        }

        //edit dream job
        [HttpPost]
        [Authorize]
        public void UpdateDreamJob(DreamJob DreamJobClient)
        {
            DreamJobBusinessLayer drjobdb = new DreamJobBusinessLayer();
            drjobdb.UpdateDreamJobById(DreamJobClient);
        }
    }
}