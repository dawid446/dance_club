using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dance_club.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name="Imię")]
        public String Name { get; set; }
        [Display(Name = "Nazwisko")]
        public String Surname { get; set; }
        public char Gender { get; set; }
        [Display(Name = "Data zatrudnienia")]
        public DateTime Hire_date { get; set; }
        [Display(Name = "Data urodzenia")]
        public DateTime Birth_date { get; set; }

     
        public virtual ICollection<Employees_Titles> Employees_Titles { get; set; }
        public virtual ICollection<Activities> Activities { get; set; }
    }
}