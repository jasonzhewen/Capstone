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
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //var currentUser = manager.FindById(User.Identity.GetUserId());
            //int id = currentUser.UserInfo.Id;

            //PersonalDetails pd = new PersonalDetails();
            //pd.firstName = PersonalDetailsModelClient.firstName;
            //pd.lastName = PersonalDetailsModelClient.lastName;
            //pd.profession = PersonalDetailsModelClient.profession;
            //pd.contactNumber = PersonalDetailsModelClient.contactNumber;
            //pd.currentCity = PersonalDetailsModelClient.currentCity;
            //pd.currentCountry = PersonalDetailsModelClient.currentCountry;
            //pd.dateOfBirth = Convert.ToDateTime(PersonalDetailsModelClient.dateOfBirth);
            //pd.imageUrl = PersonalDetailsModelClient.imageUrl;
            //pd.UserInfoID = id;
            PersonalDetailsBusinessLayer pdBal = new PersonalDetailsBusinessLayer();
            pdBal.UpdatePersonalDetails(PersonalDetailsModelClient);
        }

        [Authorize]
        public ActionResult ShowBackgroundInfo()
        {
            return PartialView();
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
            return Json(GetBackgroundInfo(id,false), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult CurrentPositionPartial()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return PartialView(GetBackgroundInfo(id, true));
        }

        public BackgroundInfoListViewModel GetBackgroundInfo(int? id, Boolean isCurrentPosition)
        {
            BackgroundInfoListViewModel backgroundInfoList = new BackgroundInfoListViewModel();
            List<BackgroundInfoViewModel> backgroundInfoes = new List<BackgroundInfoViewModel>();
            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection sqlcon = new SqlConnection(ConnString))
                {
                    if (sqlcon.State == System.Data.ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }
                    SqlCommand cmd = null;
                    cmd = new SqlCommand("select * from tblBackgroundInfo where UserId = '" + id + "' ORDER BY EndDate ASC ", sqlcon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BackgroundInfoModel backgroundInfo = new BackgroundInfoModel();
                            backgroundInfo.type = Convert.ToInt32(dr["Type"]);
                            backgroundInfo.title = Convert.ToString(dr["Title"]);
                            backgroundInfo.startDate = Convert.ToDateTime(dr["StartDate"]);
                            backgroundInfo.endDate = Convert.ToDateTime(dr["EndDate"]);
                            backgroundInfo.description = Convert.ToString(dr["Description"]);

                            BackgroundInfoViewModel backgroundInfoView = new BackgroundInfoViewModel();
                            backgroundInfoView.type = backgroundInfo.type;
                            backgroundInfoView.title = backgroundInfo.title;
                            backgroundInfoView.duration = backgroundInfo.startDate.ToString("yyyy-MM-dd") + " - " + backgroundInfo.endDate.ToString("yyyy-MM-dd");
                            backgroundInfoView.endDate = backgroundInfo.endDate.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            backgroundInfoView.description = backgroundInfo.description;

                            backgroundInfoes.Add(backgroundInfoView);
                        }
                    }
                    else
                    {
                        BackgroundInfoViewModel backgroundInfoViewEmpty = new BackgroundInfoViewModel();
                        var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                        var currentUser = manager.FindById(User.Identity.GetUserId());
                        DateTime registerDate = currentUser.UserInfo.RegisterDate;
                        backgroundInfoViewEmpty.title = "Welcome to OmniDrome";
                        backgroundInfoViewEmpty.duration = registerDate.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        backgroundInfoViewEmpty.endDate = registerDate.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        backgroundInfoViewEmpty.description = "You come to us at this day! If you see this, which means you do not have any information with us.";
                        backgroundInfoes.Add(backgroundInfoViewEmpty);
                    }
                        backgroundInfoList.backgroundInfoListViewModel = backgroundInfoes;                  
                }
            }
            catch
            {
            }
            return backgroundInfoList;
        }
    }
}