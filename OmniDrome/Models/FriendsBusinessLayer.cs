using OmniDrome.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class FriendsBusinessLayer
    {

        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();

        public List<PersonalDetails> suggestedFriendsList = new List<PersonalDetails>();
        //list friends

        public List<PersonalDetails> getListOfFriends(string searchFriends)
        {
            var friendsList = from f in db.PersonalInfoes
                              where f.firstName.ToLower().Contains(searchFriends.ToLower()) || 
                              f.lastName.ToLower().Contains(searchFriends.ToLower())
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
    }
}