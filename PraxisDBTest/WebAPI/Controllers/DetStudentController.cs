using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DetStudentController : ApiController
    {
        private PraxisDBModel db = new PraxisDBModel();
        
        public IHttpActionResult GetTables()
        {
            List<Student> std = db.Students.ToList();
            List<School> sch = db.Schools.ToList();
            List<Grade> gra = db.Grades.ToList();

            var req = from st in std
                      join sc in sch on st.SchoolID equals sc.SchoolID into tblA
                      from sc in tblA.DefaultIfEmpty()
                      join gr in gra on sc.SchoolID equals gr.SchoolID into tblB
                      from gr in tblB.DefaultIfEmpty()
                      where st.SchoolID == sc.SchoolID && gr.SchoolID == sc.SchoolID && st.GradeID == gr.GradeID
                      orderby sc.SchoolName, st.Surname
                      select new DetStudent
                      {
                          Name = st.Name + ' ' + st.Surname,
                          DOB = st.DateofBirth.ToString(),
                          Gender = st.Gender,
                          Grade = gr.GradeName,
                          School_Code = sc.SchoolID,
                          School_Name = sc.SchoolName
                      };

            //var req = from st in db.Students
            //          join sc in db.Schools on st.SchoolID equals sc.SchoolID
            //          join gr in db.Grades on st.GradeID equals gr.GradeID
            //          where st.SchoolID == sc.SchoolID && st.GradeID == gr.GradeID && gr.SchoolID == sc.SchoolID
            //          select new DetStudent()
            //          {
            //              Name = st.Name + ' ' + st.Surname,
            //              DOB = (st.DateofBirth).ToString(),
            //              Gender = st.Gender,
            //              Grade = gr.GradeName,
            //              School_Code = sc.SchoolID,
            //              School_Name = sc.SchoolName
            //          };

            return Ok(req);
        }
    }
}
