using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmniDrome.Models
{
    public class Requirement
    {
        [Key]
        public int RequirementID { get; set; }
        public string Req { get; set; }
        public int NocCode { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}