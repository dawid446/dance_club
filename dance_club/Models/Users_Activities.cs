using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dance_club.Models
{
    public class Users_Activities
    {
        [Key]
        public int UserActivityID { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }


        public int ActivityID { get; set; }
        [ForeignKey("ActivityID")]
        public virtual Activities Activities { get; set; }
    }
}