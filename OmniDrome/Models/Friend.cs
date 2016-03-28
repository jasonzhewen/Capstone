using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class Friend
    {
        [Key]
        public int FriendshipID { get; set; }
        public int RequestFrom { get; set; }
        public DateTime RequestDate { get; set; }
        public String RequestMessage { get; set; }
        public String RequestStatus { get; set; }
        public Boolean MeOnLine { get; set; }
        public Boolean FriendOnLine { get; set; }
        public int UserInfoID { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}