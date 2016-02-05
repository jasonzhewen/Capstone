using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class PersonalDetails
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactNumber { get; set; }
        public string profession { get; set; }
        public string currentCity { get; set; }
        public string currentCountry { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string imageUrl { get; set; }
        public int UserInfoID { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}