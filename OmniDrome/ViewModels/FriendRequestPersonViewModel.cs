using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.ViewModels
{
    public class FriendRequestPersonViewModel
    {
        public string imageUrl { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string profession { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestMessage { get; set; }
        public int UserInfoID { get; set; }
        public int RequestFrom { get; set; }
    }
}