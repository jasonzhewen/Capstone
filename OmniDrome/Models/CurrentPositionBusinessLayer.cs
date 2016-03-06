using OmniDrome.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmniDrome.Models
{
    public class CurrentPositionBusinessLayer
    {
        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();

        public BackgroundInfo GetCurrentPositionByID(int? id, Boolean isCP)
        {
            BackgroundInfo cP = new BackgroundInfo();
            if (id == null)
            {
                return null;
            }
            var peo = db.BackgroundInfoes
                    .Where(b => b.UserInfoID == id && b.isCurrentPosition == isCP)
                    .FirstOrDefault();

            if (peo == null)
            {
                return null;
            }
            else
            {
                cP.endDate = peo.endDate;
                cP.startDate = peo.startDate;
                cP.ID = peo.ID;
                cP.type = peo.type;
                cP.isCurrentPosition = peo.isCurrentPosition;
                cP.title = peo.title;
                cP.description = peo.description;
                cP.UserInfoID = peo.UserInfoID;
            }
            return cP;
        }

        public void InsertCurrentPosition([Bind(Include = "ID,type,title,startDate,endDate,description,isCurrentPosition,UserInfoID")] BackgroundInfo backgroundInfo)
        {
            db.BackgroundInfoes.Add(backgroundInfo);
            db.SaveChanges();
        }

        public void UpdateCurrentPosition([Bind(Include = "ID,type,title,startDate,endDate,description,isCurrentPosition,UserInfoID")] BackgroundInfo backgroundInfo)
        {
            db.Entry(backgroundInfo).State = EntityState.Modified;
            db.Entry(backgroundInfo).Property("UserInfoID").IsModified = false;
            db.SaveChanges();
        }

    }
}