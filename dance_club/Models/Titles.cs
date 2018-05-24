using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dance_club.Models
{
    public class Titles
    {
        [Key]
        public int TitleID { get; set; }
        public String Name { get; set; }

        public virtual ICollection<Employees_Titles> Employees_Titles { get; set; }
    }

}