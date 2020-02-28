using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class WebMVCDetStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }
        public string School_Code { get; set; }
        public string School_Name { get; set; }
    }
}