using OmniDrome.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class GovDbBusinessLayer
    {
        private PersonalInfoERPDAL db = new PersonalInfoERPDAL();
        public  List<Title> suggestedTitlesList = new List<Title>();

       public List<Duty> suggestedDuties = new List<Duty>();
        public List<Requirement> suggestedRequirements = new List<Requirement>();

        public List<Title> GetTitles(string searchstring)
        {
            
             
            var titles = (from t in db.Titles 
                         select t);

            if (!String.IsNullOrEmpty(searchstring))
            {
                
                titles = titles.Where(t => t.Titl.ToUpper().Contains(searchstring.ToUpper())).Take(10);
                titles = titles.OrderByDescending(t => t.Titl);            
            }
            //if (String.IsNullOrEmpty(searchstring))
            //{
            //    Title t = new Title();
            //    t.Titl = "no title is selected";
            //    suggestedTitlesList.Add(t);
            //}
           
         
            foreach (Title gvTitle in titles)
            {
                Title myTitle = new Title();
                myTitle.TitleID = gvTitle.TitleID;
                myTitle.Titl = gvTitle.Titl;
                myTitle.NocCode = gvTitle.NocCode;
                suggestedTitlesList.Add(myTitle);
            }

            


            if (suggestedTitlesList == null)
            {
                return null;
            }
            return suggestedTitlesList;


        }


        public List<Duty> GetDutiesForTitle(int NocCode)
        {

            var result = db.Duties
                    .Where(b => b.NocCode == NocCode).Take(2);


            foreach (Duty duty in result)
            {
                Duty d = new Duty();
                d.Titl = duty.Titl;
                d.TitleID = duty.TitleID;
                d.NocCode = duty.NocCode;
                suggestedDuties.Add(d);
            }

            if (suggestedDuties == null)
            {
                return null;
            }
            return suggestedDuties;

        }

        public List<Requirement>GetRequirementsForTitle(int NocCode)
        {
            var result = db.Requirements
                         .Where(r => r.NocCode == NocCode).Take(1);

            foreach(Requirement req in result)
            {
                Requirement r = new Requirement();
                r.RequirementID = req.RequirementID;
                r.Req = req.Req;
                r.NocCode = req.NocCode;

                suggestedRequirements.Add(r);

            }
            if (suggestedRequirements == null)
            {
                return null;
            }
            return suggestedRequirements;
        }

        
    }
}