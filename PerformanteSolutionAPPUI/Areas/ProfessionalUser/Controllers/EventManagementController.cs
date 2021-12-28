using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
namespace PerformanteSolutionAppUI.Areas.ProfessionalUser.Controllers
{
    public class EventManagementController : BaseController 
    { 

        private EventBs objBs1;
        private RawSqlQueryBs objBs2; 
         
        public EventManagementController()
        {
            objBs1 = new EventBs();
            objBs2 = new RawSqlQueryBs();
        }


 /************************* "CreateEvent" OR CREATE NEW EVENT" LINKED TO  View ********************************/

        // GET: ProfessionalUser/Event 
        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();

        }


        [HttpPost]
        public ActionResult CreateEvent(AspNetEvent userEvent)
        {
            

            if (ModelState.IsValid)
            {
                #region //Login exist already
                var isExist = IsLoginExist(userEvent.Login);
                if (isExist)
                {
                    ModelState.AddModelError("LoginExist", "Event Login Exist Already");
                    return View(userEvent);
                }
                #endregion

                #region Save to Database
                userEvent.UserId = CurrentUserId;
                userEvent.Statut = "NotValidatedYet";

                objBs1.Insert(userEvent);
                #endregion
    
                return RedirectToAction("ProEventsList", "EventManagement");

            }

            

   
            return View(userEvent);
        }





        /************************* "ProEventsList" Pro Event List LINKED TO  View ********************************/

        [HttpGet]
        public ActionResult ProEventsList()
        {
            string message = null;

            var Events = objBs2.GetProEvents(CurrentUserId);
            

            ViewBag.Message = message;  
            return View(Events);
        }

        [HttpPost]
        public ActionResult ProEventsList(string searchTxt)
        {
            string message = null;

            var Events = objBs2.GetProEvents(CurrentUserId);
            

            if(searchTxt != null)
            {
                Events = objBs2.SearchForProEvents(CurrentUserId, searchTxt);
            }

            ViewBag.Message = message;
            return View(Events);
        }

        /************************* "EditEvent" OR Edit AN Event LINKED TO  View ********************************/

        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            var myEvent = objBs1.GetById(id);

            return View(myEvent);

        }

        [HttpPost]
        public ActionResult EditEvent(AspNetEvent userEvent)
        {
            

            if (ModelState.IsValid)
            {

                //#region //Login exist already
                //var isExist = IsLoginExist(userEvent.Login);
                //if (isExist)
                //{
                //    ModelState.AddModelError("LoginExist", "Another Event has this login");
                //    return View(userEvent);
                //}
                //#endregion



                #region Save to Database
                userEvent.UserId = CurrentUserId;
                userEvent.Statut = "NotValidatedYet";

                objBs1.Update(userEvent);
                #endregion

                return RedirectToAction("ProEventsList", "EventManagement");

            }

            else
            {
                return View(userEvent);
            }


            

        }

        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
           
            objBs1.Delete(id);

            return RedirectToAction("ProEventsList", "EventManagement");

        }

        [NonAction]
        public bool IsLoginExist(string login)
        {
            using (PerformanteSolutionDBEntities db = new PerformanteSolutionDBEntities())
            {
                var v = db.AspNetEvents.Where(a => a.Login == login).FirstOrDefault();
                return v != null;
            }
        }

    }

}