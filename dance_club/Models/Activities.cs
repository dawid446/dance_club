using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dance_club.Models
{
    public class Activities
    {
        [Key]
        public int ActivityID { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }

        public DateTime Act_Start { get; set; }
        public DateTime Act_End { get; set; }

        public int Price { get; set; }

        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID ")]
        public virtual Employees Employees { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID ")]
        public virtual Categories Categories { get; set; }

        public virtual ICollection<Users_Activities> Users_Activities { get; set; }
    }
}