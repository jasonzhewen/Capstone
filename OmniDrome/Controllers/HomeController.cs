using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using LinkedIn.Api.Client.Owin;
using LinkedIn.Api.Client.Owin.Profiles;
using System.Threading.Tasks;

namespace OmniDrome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";
            var am = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = am.FindById(this.User.Identity.GetUserId());
            var claim = user.Claims.ToList().Where(m => m.ClaimType == "LinkedIn_AccessToken").SingleOrDefault();

            var client = new LinkedInApiClient(HttpContext.GetOwinContext().Request, claim.ClaimValue);
            var profileApi = new LinkedInProfileApi(client);
            var userProfile = await profileApi.GetBasicProfileAsync();
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}