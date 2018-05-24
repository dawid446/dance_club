using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dance_club.Models
{
    public class Employees_Titles
    {
        [Key]
        public int EmployeeTitleID { get; set; }

        public int TitleID { get; set; }
        [ForeignKey("TitleID")]
        public virtual Titles Titles { get; set; }


        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employees Employees { get; set; }
    }
}