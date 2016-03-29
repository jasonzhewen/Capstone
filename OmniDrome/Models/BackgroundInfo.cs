using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class BackgroundInfo
    {
        public int ID { get; set; }
        public int type { get; set; }
        public string title { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }
        public Boolean isCurrentPosition { get; set; }
        public int UserInfoID { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updatedDate { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}