using BLL;
using BOL;
using BOL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PerformanteSolutionAPPUI.Controllers
{
    public class HomeController : Controller 
    {

        private ContactUBs objBs1;
        private RawSqlQueryBs objBs2;

        public HomeController()
        {
            objBs2 = new RawSqlQueryBs();
            objBs1 = new ContactUBs();
        }

        public ActionResult Index()
        {
            var VM = objBs2.CommingEventEdition();

            return View(VM);
        }

        public ActionResult About()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(AspNetContactU contact)
        {
            if (ModelState.IsValid)
            {
                objBs1.Insert(contact);

                ModelState.Clear();
                return View();
            }

            return View();

        }

        public ActionResult Services()
        {

            return View();
        }
    }
}