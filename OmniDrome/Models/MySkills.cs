using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class MySkills
    {
        public int ID { get; set; }
        public string skill { get; set; }
        public int UserInfoID { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}