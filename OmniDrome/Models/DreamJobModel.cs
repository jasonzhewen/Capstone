using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class DreamJobModel
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string dreamJob { get; set; }
        public string pathToSuccess { get; set; }
        public DateTime dateToAchieve { get; set; }
        public string workProgress { get; set; }
    }
}