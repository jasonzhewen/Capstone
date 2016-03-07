using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OmniDrome.DataAccessLayer;
using System.Data.Entity;
using System.Web.Mvc;

namespace OmniDrome.Models
{
    public class DreamJobBusinessLayer
    {
        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();

        public DreamJob GetDreamJobByID(int? id)
        {
            DreamJob dreamj = new DreamJob();

            if (id == null)
            {
                return null;
            }
            var peo = db.DreamJobs
                    .Where(b => b.UserInfoID == id)
                    .FirstOrDefault();


            if (peo == null)
            {
                return null;
            }
            else {
                dreamj.ID = peo.ID;
                dreamj.companyName = peo.companyName;
                dreamj.position = peo.position;
                dreamj.startDate = peo.startDate;
                dreamj.description = peo.description;
                dreamj.UserInfoID = peo.UserInfoID;

            }

            //if (dreamj == null)
            //{
            //    return null;
            //}
            return dreamj;
        }

        public void InsertDreamJobDetails([Bind(Include = "ID,companyName,position,startDate,description,UserInfoID")] DreamJob dreamJob)
        {
            db.DreamJobs.Add(dreamJob);
            db.SaveChanges();
        }
        public void UpdateDreamJobById([Bind(Include = "ID,companyName,position,startDate,description,UserInfoID")] DreamJob dreamJob)
        {
            db.Entry(dreamJob).State = EntityState.Modified;
            db.Entry(dreamJob).Property("UserInfoID").IsModified = false;
            db.SaveChanges();
        }

        public void DeleteDreamJobByID(int? id)
        {


            DreamJob dj = db.DreamJobs.Find(id);
            db.DreamJobs.Remove(dj);
            db.SaveChanges();



        }
    }
}