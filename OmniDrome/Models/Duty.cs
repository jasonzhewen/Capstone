using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class Duty
    {
        [Key]
        public int TitleID { get; set; }
        public string Titl { get; set; }
        public int NocCode { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}