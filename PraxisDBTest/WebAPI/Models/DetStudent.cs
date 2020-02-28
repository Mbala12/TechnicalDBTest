using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DetStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }
        public string School_Code { get; set; }
        public string School_Name { get; set; }
    }
}