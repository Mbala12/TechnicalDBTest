using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<WebMVCStudent> stList;
            HttpResponseMessage response = GBVariables.WebApiClient.GetAsync("Student").Result;
            stList = response.Content.ReadAsAsync<IEnumerable<WebMVCStudent>>().Result;
            return View(stList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new WebMVCStudent());
            else
            {
                HttpResponseMessage response = GBVariables.WebApiClient.GetAsync("Student/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<WebMVCStudent>().Result);
            }
              
        }

        [HttpPost]
        public ActionResult AddOrEdit(WebMVCStudent std)
        {
            if(std.StudentID == 0)
            {
                HttpResponseMessage response = GBVariables.WebApiClient.PostAsJsonAsync("Student", std).Result;
                TempData["SuccessMessage"] = "Student "+ (std.Name +" " + std.Surname) +" has been successfully added";

            }
            else
            {
                HttpResponseMessage response = GBVariables.WebApiClient.PutAsJsonAsync("Student/"+std.StudentID, std).Result;
                TempData["SuccessMessage"] = "Student " + (std.Name + " " + std.Surname) + " has been successfully updated";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GBVariables.WebApiClient.DeleteAsync("Student/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "A Student has been successfully deleted";
            return RedirectToAction("Index");
        }
    }
}