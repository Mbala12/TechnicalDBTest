using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class WebMVCStudent
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Surname")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please enter your Date Of Birth")]
        public Nullable<System.DateTime> DateofBirth { get; set; }

        [Required(ErrorMessage = "Please select your Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select your School ")]
        public string SchoolID { get; set; }

        [Required(ErrorMessage = "Please enter your Grade")]
        public string GradeID { get; set; }

    }
}