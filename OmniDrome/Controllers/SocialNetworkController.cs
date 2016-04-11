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
        public ActionResult SocialNetwork(String firstName)
        {
            Posts(firstName);
            return View();
        }

        public ActionResult FriendList()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return PartialView(GetFriendsCtrl(id));
        }

        public ActionResult Posts(string firstName)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;
            return PartialView(GetAllPosts(id, firstName));
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

        [HttpPost]
        [Authorize]
        public void RemoveFriend(int requesiFromId)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;

            FriendsBusinessLayer fbl = new FriendsBusinessLayer();
            fbl.RejectFriend(id, requesiFromId);
        }


        [HttpPost]
        [Authorize]
        public void UpdateFriendRequest()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            int id = currentUser.UserInfo.Id;


            FriendsBusinessLayer fbl = new FriendsBusinessLayer();
            fbl.UpdateFriendRequestById(id);

        }

        [Authorize]
        public List<PostsViewModel> GetAllPosts(int id, string un)
        {
            FriendsBusinessLayer fbl = new FriendsBusinessLayer();
            return fbl.GetPostsList(id,un);
        }

        [Authorize]
        public void AddPost(String txt)
        {
            if (txt != null && txt != "")
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                int id = currentUser.UserInfo.Id;
                Post p = new Post();
                p.PostToID = id;
                p.PostFromID = id;
                p.UserInfoID = id;
                p.PostText = txt;
                p.PostDate = DateTime.Now;
                FriendsBusinessLayer fbl = new FriendsBusinessLayer();
                fbl.InsertPost(p);
            }
        }
    }
}