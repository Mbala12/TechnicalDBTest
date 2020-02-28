using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class DetStudentController : Controller
    {
        // GET: DetStudent
        public ActionResult Index()
        {
            IEnumerable<WebMVCDetStudent> stList;
            HttpResponseMessage response = GBVariables.WebApiClient.GetAsync("DetStudent").Result;
            stList = response.Content.ReadAsAsync<IEnumerable<WebMVCDetStudent>>().Result;
            return View(stList);
        }
    }
}