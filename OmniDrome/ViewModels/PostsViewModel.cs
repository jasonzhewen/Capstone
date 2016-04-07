using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.ViewModels
{
    public class PostsViewModel
    {
        public int UserInfoID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string imageUrl { get; set; }
        public string PostText { get; set; }
        public DateTime PostDate { get; set; }
    }
}