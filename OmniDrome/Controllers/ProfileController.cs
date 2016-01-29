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
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return View("Profile" , GetPersonalDetails(id));
        }

        [Authorize]
        public ActionResult TimeLinePartial()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;          
            return PartialView(GetBackgroundInfo(id, false));
        }

        [Authorize]
        public ActionResult CurrentPositionPartial()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return PartialView(GetBackgroundInfo(id, true));
        }

        public PersonalDetailsViewModel GetPersonalDetails(int? id)
        {
            PersonalDetailsViewModel personalDetailsViewModel = new PersonalDetailsViewModel();
            personalDetailsViewModel.personalDetailsModel = new Models.PersonalDetailsModel();
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
                    cmd = new SqlCommand("select * from tblDetailsPersonal where UserId = '" + id + "' ", sqlcon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            personalDetailsViewModel.personalDetailsModel.firstName = Convert.ToString(dr["FirstName"]);
                            personalDetailsViewModel.personalDetailsModel.lastName = Convert.ToString(dr["LastName"]);
                            personalDetailsViewModel.personalDetailsModel.contactNumber = Convert.ToString(dr["ContactNumber"]);
                            personalDetailsViewModel.personalDetailsModel.profession = Convert.ToString(dr["Profession"]);
                            personalDetailsViewModel.personalDetailsModel.currentCity = Convert.ToString(dr["CurrentCity"]);
                            personalDetailsViewModel.personalDetailsModel.currentCountry = Convert.ToString(dr["CurrentCountry"]);
                            personalDetailsViewModel.personalDetailsModel.dateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]).ToString("yyyy-MM-dd");
                            personalDetailsViewModel.personalDetailsModel.imageUrl = Convert.ToString(dr["ImageUrl"]);
                            if (personalDetailsViewModel.personalDetailsModel.imageUrl == null)
                            {
                                personalDetailsViewModel.personalDetailsModel.imageUrl = "~/Images/PersonalImages/no-Image.png";
                            }
                        }
                    }
                    else
                    {
                        personalDetailsViewModel.personalDetailsModel.firstName = "";
                        personalDetailsViewModel.personalDetailsModel.lastName = "";
                        personalDetailsViewModel.personalDetailsModel.contactNumber = "";
                        personalDetailsViewModel.personalDetailsModel.profession = "";
                        personalDetailsViewModel.personalDetailsModel.currentCity = "";
                        personalDetailsViewModel.personalDetailsModel.currentCountry = "";
                        personalDetailsViewModel.personalDetailsModel.dateOfBirth = "";
                        personalDetailsViewModel.personalDetailsModel.imageUrl = "~/Images/PersonalImages/no-Image.png";
                    }
                }
            }
            catch
            {
            }
            return personalDetailsViewModel;
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