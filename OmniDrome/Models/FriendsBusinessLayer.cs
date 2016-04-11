using OmniDrome.DataAccessLayer;
using OmniDrome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniDrome.Models
{
    public class FriendsBusinessLayer
    {

        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();

        public List<PersonalDetails> suggestedFriendsList = new List<PersonalDetails>();
        //list friends

        public List<PersonalDetails> getListOfFriends(string searchFriends, int? id)
        {
            var friendsList = from f in db.PersonalInfoes
                              where f.UserInfoID != id && (f.firstName.ToLower().Contains(searchFriends.ToLower()) ||
                              f.lastName.ToLower().Contains(searchFriends.ToLower()))
                              select f;

            if (!String.IsNullOrEmpty(searchFriends))
            {

                friendsList = friendsList.Take(10);
                friendsList = friendsList.OrderByDescending(f => f.firstName);
            }
            foreach (PersonalDetails pdet in friendsList)
            {
                PersonalDetails person = new PersonalDetails();
                person.ID = pdet.ID;
                person.firstName = pdet.firstName;
                person.lastName = pdet.lastName;
                person.contactNumber = pdet.contactNumber;
                person.profession = pdet.profession;
                person.currentCity = pdet.currentCity;
                person.currentCountry = pdet.currentCountry;
                person.dateOfBirth = pdet.dateOfBirth;
                person.imageUrl = pdet.imageUrl;
                person.UserInfoID = pdet.UserInfoID;
                suggestedFriendsList.Add(person);
            }
            if (suggestedFriendsList == null)
            {
                return null;
            }
            return suggestedFriendsList;
        }

        public void InsertFriendRequest([Bind(Include = "FriendshipID,RequestFrom,RequestDate,RequestMessage,RequestStatus,MeOnline,FriendOnline,UserInfoID")] Friend friend)
        {
            if (db.Friends.Any(o => o.RequestFrom == friend.RequestFrom)) return;
            db.Friends.Add(friend);
            db.SaveChanges();
        }

        public List<PersonalDetails> getAllFriends(int id)
        {
            List<PersonalDetails> fl = new List<PersonalDetails>();
            
            var friendsList = (from p in db.PersonalInfoes 
                               from f in db.Friends
                               where f.UserInfoID == id
                               && p.UserInfoID == f.RequestFrom
                               && f.RequestStatus == "Accepted" 
                               select p).ToList();

            foreach (PersonalDetails pdet in friendsList)
            {
                fl.Add(pdet);
            }
            if (fl == null)
            {
                return null;
            }
            return fl;
        }

        public int GetFriendsRequstNumber(int id)
        {
            var numberRequests = db.Friends.Where(x => x.RequestStatus == "undefined" && x.UserInfoID == id)
                .Select(i => new FriendNumberRequests { RequestFrom = i.RequestFrom, RequestStatus = i.RequestStatus, UserInfoID = i.UserInfoID }).Distinct().Count();
            //var nuberRequests = db.Friends.Select(i => i.RequestFrom, i=>i.RequestStatus,i=>i.UserInfoID).
            int result = Convert.ToInt32(numberRequests);
            return result;
        }

        public List<FriendRequestPersonViewModel> GetRequestList(int id)
        {
            //var numberRequests = db.Friends.
            //    Where(x => x.RequestStatus == "undefined" && x.UserInfoID == id).OrderByDescending(x => x.RequestDate);
            //FriendRequestPersonListViewModel frlvm = new FriendRequestPersonListViewModel();
            List<FriendRequestPersonViewModel> lfrvm = new List<FriendRequestPersonViewModel>();
            var listrequest = (from p in db.PersonalInfoes
                               from f in db.Friends
                               where f.UserInfoID == id
                               && p.UserInfoID == f.RequestFrom
                               && f.RequestStatus == "undefined"
                               select new { p.imageUrl, p.firstName, p.lastName, p.profession, f.RequestMessage, f.RequestDate, f.UserInfoID, f.RequestFrom }).ToList();



            foreach (var f in listrequest)
            {
                FriendRequestPersonViewModel frvm = new FriendRequestPersonViewModel();
                frvm.firstName = f.firstName;
                frvm.lastName = f.lastName;
                frvm.RequestDate = f.RequestDate;
                frvm.RequestMessage = f.RequestMessage;
                frvm.imageUrl = f.imageUrl;
                frvm.profession = f.profession;
                frvm.UserInfoID = f.UserInfoID;
                frvm.RequestFrom = f.RequestFrom;
                lfrvm.Add(frvm);
            }

            return lfrvm;

        }

        public void UpdateFriendRequestById(int id)
        {

            var updateRequest = db.Friends.Where(x => x.UserInfoID == id);
            foreach (Friend f in updateRequest)
            {
                f.RequestStatus = "Accepted";
            }

            db.SaveChanges();
        }



        public List<PostsViewModel> GetPostsList(int id, string un)
        {
            List<PostsViewModel> lpvm = new List<PostsViewModel>();
            //var listposts = new List<>();
            if (un == null || un == "")
            {
               var listposts = (from p in db.PersonalInfoes
                             from f in db.Friends
                             from t in db.Posts
                             where f.UserInfoID == id
                             && f.RequestStatus == "Accepted"
                             && p.UserInfoID == f.RequestFrom
                             && p.UserInfoID == t.UserInfoID
                             select new { p.imageUrl, p.firstName, p.lastName, t.PostText, t.PostDate, t.UserInfoID }).ToList();
               foreach (var po in listposts)
               {
                   PostsViewModel pvm = new PostsViewModel();
                   pvm.firstName = po.firstName;
                   pvm.lastName = po.lastName;
                   pvm.imageUrl = po.imageUrl;
                   pvm.PostDate = po.PostDate;
                   pvm.PostText = po.PostText;
                   pvm.UserInfoID = po.UserInfoID;
                   lpvm.Add(pvm);
               }
            }
            else
            {
                var listposts = (from p in db.PersonalInfoes
                             from f in db.Friends
                             from t in db.Posts
                             where f.UserInfoID == id
                             && f.RequestStatus == "Accepted"
                             && p.UserInfoID == f.RequestFrom
                             && p.UserInfoID == t.UserInfoID
                             && p.firstName == un
                             select new { p.imageUrl, p.firstName, p.lastName, t.PostText, t.PostDate, t.UserInfoID }).ToList();
                foreach (var po in listposts)
                {
                    PostsViewModel pvm = new PostsViewModel();
                    pvm.firstName = po.firstName;
                    pvm.lastName = po.lastName;
                    pvm.imageUrl = po.imageUrl;
                    pvm.PostDate = po.PostDate;
                    pvm.PostText = po.PostText;
                    pvm.UserInfoID = po.UserInfoID;
                    lpvm.Add(pvm);
                }
            }
            return lpvm;
        }

        public void InsertPost([Bind(Include = "PostID,PostToID,PostFromID,PostText,PostDate,UserInfoID")] Post p)
        {
            db.Posts.Add(p);
            db.SaveChanges();
        }

        public void RejectFriend(int? id, int requestId)
        {

            var request = db.Friends.Where(x => x.UserInfoID == id && x.RequestFrom == requestId);
            foreach (Friend f in request)
            {
                db.Friends.Remove(f);

            }
            db.SaveChanges();
        }
    }
}