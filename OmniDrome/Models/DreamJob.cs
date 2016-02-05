using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class DreamJob
    {
        public int ID { get; set; }
        public string companyName { get; set; }
        public string position { get; set; }
        public DateTime startDate { get; set; }
        public string description { get; set; }
        public int UserInfoID { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}