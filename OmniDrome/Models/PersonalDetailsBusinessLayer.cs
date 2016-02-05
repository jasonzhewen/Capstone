using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmniDrome.DataAccessLayer;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;

namespace OmniDrome.Models
{
    public class PersonalDetailsBusinessLayer
    {
        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();

        public PersonalDetails GetPersonalDetailsByID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var peo = db.PersonalInfoes
                    .Where(b => b.UserInfoID == id)
                    .FirstOrDefault();
            PersonalDetails personalDetails = peo;
            if (personalDetails == null)
            {
                return null;
            }
            return personalDetails;
        }

        public void InsertPersonalDetails([Bind(Include = "ID,firstName,lastName,contactNumber,profession,currentCity,currentCountry,dateOfBirth,imageUrl,UserInfoID")] PersonalDetails personalDetails)
        {
            db.PersonalInfoes.Add(personalDetails);
            db.SaveChanges();
        }

        public void UpdatePersonalDetails([Bind(Include = "ID,firstName,lastName,contactNumber,profession,currentCity,currentCountry,dateOfBirth,imageUrl")] PersonalDetails personalDetails)
        {
            db.Entry(personalDetails).State = EntityState.Modified;
            db.Entry(personalDetails).Property("UserInfoID").IsModified = false;
            db.SaveChanges();
        }
    }
}