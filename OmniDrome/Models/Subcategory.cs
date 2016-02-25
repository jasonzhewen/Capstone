using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class Subcategory
    {
         [Key]
        public int NocCode { get; set; }
        public string Subcat { get; set; }

        public int MainCategoryID { get; set; }

        public virtual MainCategory MainCategory { get; set; }

        public virtual ICollection<Duty> Duty { get; set; }
        public virtual ICollection<Requirement> Requirement { get; set; }

        public virtual ICollection<Title> Title { get; set; }
    }
}