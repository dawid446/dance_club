using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dance_club.Models
{
    public class ActivitiesViewModel
    {
        public List<Titles> Title { get; set; }
        public Employees Employees { get; set; }

        public int TitleID { get; set; }
        public string Name{ get; set; }

        public int[] titleList { get; set; }
    }
}