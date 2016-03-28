
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int PostToID { get; set; }
        public int PostFromID { get; set; }
        public String PostText { get; set; }
        public DateTime PostDate { get; set; }
        public int UserInfoID { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}