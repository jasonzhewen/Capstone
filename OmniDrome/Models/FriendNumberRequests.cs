using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class FriendNumberRequests
    {
        public int RequestFrom { get; set; }
        //public DateTime RequestDate { get; set; }

        public String RequestStatus { get; set; }

        public int UserInfoID { get; set; }
    }
}