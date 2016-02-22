using OmniDrome.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniDrome.Models
{
    public class BackgroundInfoBusinessLayer
    {

        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();

        public List<BackgroundInfo> GetBackgroundInfoByID(int? id , Boolean isCP)
        {
            List<BackgroundInfo> bInfoes = new List<BackgroundInfo>();
            if (id == null)
            {
                return null;
            }
            var peo = db.BackgroundInfoes
                    .Where(b => b.UserInfoID == id && b.isCurrentPosition == isCP);
            //var peo = (from BackgroundInfo in db.BackgroundInfoes select new { Id = obj.Id, Name = obj.Name });
            foreach (BackgroundInfo bi in peo)
            {
                BackgroundInfo b = new BackgroundInfo();
                b.description = bi.description;
                b.endDate = bi.endDate;
                b.startDate = bi.startDate;
                b.title = bi.title;
                b.type = bi.type;
                b.UserInfoID = bi.UserInfoID;
                b.ID = bi.ID;
                bInfoes.Add(b);
            }
            
            if (bInfoes == null)
            {
                return null;
            }
            return bInfoes;
        }

        public BackgroundInfo GetBackgroundInfoByInfoID(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var peo = db.BackgroundInfoes
                    .Where(b => b.ID == id).FirstOrDefault();
            BackgroundInfo bi = new BackgroundInfo();

            if (bi == null)
            {
                return null;
            }
            else
            {
                bi.ID = peo.ID;
                bi.title = peo.title;
                bi.type = peo.type;
                bi.startDate = peo.startDate;
                bi.endDate = peo.endDate;
                bi.description = peo.description;
                bi.isCurrentPosition = peo.isCurrentPosition;
                bi.UserInfoID = peo.UserInfoID;
                return bi;
            }         
        }

        public void InsertBackgroundInfo([Bind(Include = "ID,type,title,startDate,endDate,description,isCurrentPosition,UserInfoID")] BackgroundInfo backgroundInfo)
        {
            db.BackgroundInfoes.Add(backgroundInfo);
            db.SaveChanges();
        }

        public void UpdateBackgroundInfo([Bind(Include = "ID,type,title,startDate,endDate,description,isCurrentPosition,UserInfoID")] BackgroundInfo backgroundInfo)
        {
            db.Entry(backgroundInfo).State = EntityState.Modified;
            //db.Entry(personalDetails).Property("UserInfoID").IsModified = false;
            db.SaveChanges();
        }

        public void DeleteBackgroundInfoByID(int? id)
        {
            if (id == null)
            {
                //return null;
            }
            BackgroundInfo backgroundInfo = db.BackgroundInfoes.Find(id);
            db.BackgroundInfoes.Remove(backgroundInfo);
            db.SaveChanges();
        }
    }
}