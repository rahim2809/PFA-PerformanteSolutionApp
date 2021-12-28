using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanteSolutionAppUI.Areas.Admin.Controllers 
{
    public class AdminController : BaseController
    { 
        
        private EventBs objBs1;
        private RawSqlQueryBs objBs2;
        private ContactUBs objBs3;

        public AdminController()
        { 
            objBs1 = new EventBs();
            objBs2 = new RawSqlQueryBs(); 
            objBs3 = new ContactUBs();
        }


        /******************************** "Index" CONTAIN ALL NOT VALIDATED EVENTS ********************************/

        // GET: Admin/Admin
        public ActionResult Events()
        {

            string message = null;

            var Events = objBs1.GetAll();
            

            ViewBag.Message = message;
            return View(Events);
        }

        [HttpPost]
        public ActionResult Events(string searchTxt)
        {

            string message = null;

            var Events = objBs1.GetAll();
            

            if (searchTxt != null)
            {
                Events = objBs2.SearchForEventsAdmin(searchTxt);
            }

            ViewBag.Message = message;
            return View(Events);
        }

        


        /******************************** "ValidateEvent" VALIDATE AN EVENT ********************************/

        public ActionResult ValidateEvent(int id)
        {
            var MyEvent=objBs1.GetById(id);
            MyEvent.Statut = "Validated";
            objBs1.Update(MyEvent);
            return RedirectToAction("Events");
        }

        /******************************** "UnValidateEvent" VALIDATE AN EVENT  && Disable All related Editions ********************************/

        public ActionResult UnValidateEvent(int id)
        {
            string actif = "FALSE";
            string statut = "NotValidatedYet";

            objBs2.OffEventEditions(id, statut ,actif);

            var MyEvent = objBs1.GetById(id);
            MyEvent.Statut = "NotValidatedYet"; 
            objBs1.Update(MyEvent);
            return RedirectToAction("Events");
        }

        /******************************** "DeleteEvent" DELETE AN EVENT ********************************/


        public ActionResult DeleteEvent(int id)
        {
            objBs1.Delete(id);
            return RedirectToAction("Events");
        }


        

        public ActionResult Messages()
        {

            var Messages = objBs3.GetAll();

            return View(Messages);
        }

        public ActionResult DeleteMessage(int id)
        {
            objBs3.Delete(id);
            return RedirectToAction("Messages");
        }

    }
}