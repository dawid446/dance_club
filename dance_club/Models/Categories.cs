using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dance_club.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        public String Name { get; set; }

        public virtual ICollection<Activities> Activities { get; set; }

    }
}