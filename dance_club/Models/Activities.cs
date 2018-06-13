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

        [Required]
        [Display(Name = "Nazwa zajęć")]
        public String Name { get; set; }
        [Display(Name = "Opis")]
        public String Description { get; set; }

        [Display(Name = "Rozpoczęcie zajęć")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm tt}")]
        public DateTime Act_Start { get; set; }

        [Display(Name = "Zakończenie zajęć")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm tt}")]
        public DateTime Act_End { get; set; }

        [Display(Name = "Cena zajęć(zł)")]
        public int Price { get; set; }
        public bool User { get; set; }
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID ")]
        public virtual Employees Employees { get; set; }

        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID ")]
        public virtual Categories Categories { get; set; }

        public virtual ICollection<Users_Activities> Users_Activities { get; set; }
    }
}