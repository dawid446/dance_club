using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dance_club.Models
{
    public class CalendarViewModel
    {
       
        public int ActivityID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

    
        public DateTime Act_Start { get; set; }

       
        public DateTime Act_End { get; set; }

       
    }
}