using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OmniDrome.Models;
using OmniDrome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniDrome.Controllers
{
    public class SocialNetworkController : Controller
    {
        [Authorize]
        public ActionResult SocialNetwork()
        {
            return View();
        }

        public ActionResult FriendList()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return PartialView(GetFriendsCtrl(id));
        }

        public ActionResult Posts()
        {
            return PartialView();
        }

        public ActionResult FriendRequest()
        {
            return PartialView();
        }

        [Authorize]
        public FriendListViewModel GetFriendsCtrl(int id)
        {
            FriendListViewModel fvm = new FriendListViewModel();
            FriendsBusinessLayer fbl = new FriendsBusinessLayer();
            List<PersonalDetails> f = fbl.getAllFriends(id);
            fvm.friendListViewModel = f;
            return fvm;
        }

        [Authorize]
        public ActionResult GetFriendsListCtrl()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return View();

        }

        [Authorize]
        [HttpPost]
        public JsonResult GetFriendsListCtrl(string searchFriendText)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;

            FriendsBusinessLayer fbl = new FriendsBusinessLayer();
            return Json(fbl.getListOfFriends(searchFriendText, id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public void AddFriendRequest(Friend f)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            Friend amigo = new Friend();
            amigo.RequestFrom = id;
            amigo.RequestDate = DateTime.Now;
            amigo.RequestMessage = f.RequestMessage;
            amigo.RequestStatus = "undefined";
            amigo.MeOnLine = false;
            amigo.FriendOnLine = false;
            amigo.UserInfoID = f.UserInfoID;
            FriendsBusinessLayer fbl = new FriendsBusinessLayer();
            fbl.InsertFriendRequest(amigo);
        }

        [Authorize]
        public int GetYourFriendsRequests()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            FriendsBusinessLayer fbl = new FriendsBusinessLayer();
            return fbl.GetFriendsRequstNumber(id);
        }

        [Authorize]
        public List<FriendRequestPersonViewModel> GetListOfFriendsRequests(int id)
        {
            FriendsBusinessLayer fbl = new FriendsBusinessLayer();
            return fbl.GetRequestList(id);
        }
        [Authorize]
        public ActionResult getRequests()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return PartialView("FriendRequest",GetListOfFriendsRequests(id));
        }


    }
}