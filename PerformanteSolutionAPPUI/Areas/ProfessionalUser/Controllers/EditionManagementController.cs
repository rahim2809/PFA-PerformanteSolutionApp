using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanteSolutionAppUI.Areas.ProfessionalUser.Controllers    
{
    public class EditionManagementController : BaseController   
    {

        private EditionBs objBs1;
        private RawSqlQueryBs objBs2;
         
        public EditionManagementController() 
        {
            objBs1 = new EditionBs();
            objBs2 = new RawSqlQueryBs();
        }



        /******************************** "CreateEdition" CREATE NEW EDITION FOR GIVEN EVENT ********************************/

        [HttpGet]
        public ActionResult CreateEdition(int id)   // Create New Edition of an Event form
        {
            AspNetEdition edition = new AspNetEdition()
            {
                EvId = id
            };
            return View(edition);

        }
                           
        [HttpPost]
        public ActionResult CreateEdition(AspNetEdition edition)   // Create New Edition of an Event post
        {
            if (ModelState.IsValid)
            {

                #region //Edition exist already
                var isExistEdition = IsEditionExist(edition.NomEdition, edition.EventId);
                if (isExistEdition)
                {
                    ModelState.AddModelError("EditionExist", "Une edition a deja ce nom pour cet evenement");
                    return View(edition);
                }

                #endregion

                string fileName = Path.GetFileNameWithoutExtension(edition.fichierImage.FileName);
                string extension = Path.GetExtension(edition.fichierImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                edition.EventPhoto1 = "~/ImgEdition/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/ImgEdition/"), fileName);
                edition.fichierImage.SaveAs(fileName);




                #region Save to Database
                edition.EventId = edition.EvId;
                edition.Actif = "FALSE";
                edition.Statut = "NotValidatedYet";
                objBs1.Insert(edition);
                #endregion

                return RedirectToAction("ProEventsList", "EventManagement");
            }

            return View(edition);
        }



/************************* "EventListEditions" OR ALL EDITIONS FOR A GIVEN EVENT BY ID LINKED TO "ValidatedEventList" View ********************************/
        [HttpGet]
        public ActionResult EventListEditions(int id)   // 
        {
           
           

            var Editions = objBs2.GetEventEditions(id);


            return View(Editions);

        }

        [HttpPost]
        public ActionResult EventListEditions(int id, string searchTxt)   //  
        {

            var Editions = objBs2.GetEventEditions(id);

            if (searchTxt != null)
            {
                Editions = objBs2.SearchForEventEditionsList(id, searchTxt);
            }


            return View(Editions);

        }


        /******************************** "EditEdition" OR EDIT AN EDITION LINKED TO "EventListEditions" View ********************************/

        [HttpGet]
        public ActionResult EditEdition(int id)
        {
            var edition = objBs1.GetById(id);
            edition.EvId = edition.EventId;
            edition.PhotoPath = edition.EventPhoto1;

            return View(edition);

        }


        [HttpPost]
        public ActionResult EditEdition(AspNetEdition edition)
        {

            if (ModelState.IsValid)
            {

                #region //Edition exist already
                var isExistEdition = IsEditionExist(edition.NomEdition, edition.EventId);
                if (isExistEdition)
                {
                    ModelState.AddModelError("EditionExist", "Une edition a deja ce nom pour cet evenement");
                    return View(edition);
                }

                #endregion

                if(edition.fichierImage != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(edition.fichierImage.FileName);
                    string extension = Path.GetExtension(edition.fichierImage.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    edition.EventPhoto1 = "~/ImgEdition/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/ImgEdition/"), fileName);
                    edition.fichierImage.SaveAs(fileName);
                }

                else
                {
                    edition.EventPhoto1 = edition.PhotoPath;
                }
               


                #region Save to Database

                edition.EventId = edition.EvId;
                edition.Actif = "FALSE";
                edition.Statut = "NotValidatedYet";

                objBs1.Update(edition);
                #endregion

                return RedirectToAction("ProEventsList", "EventManagement");

            }

            return View(edition);

            

        }

        /******************************** "DeleteEdition" OR DELETE AN EDITION LINKED TO "EventListEditions" View ********************************/


        public ActionResult DeleteEdition(int id)
        {
            objBs1.Delete(id);

            return RedirectToAction("ProEventsList", "EventManagement");
        }



        /******************************** "ProEventsEditions" ProEventsEditions ********************************/



        public ActionResult ProEventsEditions()
        {

            var EdtionVM = objBs2.EditionListPro(CurrentUserId);

            return View(EdtionVM);
        }

        [HttpPost]
        public ActionResult ProEventsEditions(string searchTxt)
        {

            var EdtionVM = objBs2.EditionListPro(CurrentUserId);

            if (searchTxt != null)
            {
                EdtionVM = objBs2.SearchForEditionsListPro(CurrentUserId, searchTxt);
            }

            return View(EdtionVM);
        }


        /******************************** "DetailEdition" Detail ********************************/

        public ActionResult DetailEdition(int id)
        {
            var edition = objBs1.GetById(id);

            return View(edition);
        }



        /******************************** "NonAction" NonAction METHODS TO CHECK IF EVENT LOGIN AND EDITION NAME EXIST ON DB ********************************/



        [NonAction]
        public bool IsLoginExist(string login)
        {
            using (PerformanteSolutionDBEntities db = new PerformanteSolutionDBEntities())
            {
                var v = db.AspNetEvents.Where(a => a.Login == login).FirstOrDefault();
                return v != null;
            }
        }


        [NonAction]
        public bool IsEditionExist(string EditionName, int id)
        {
            using (PerformanteSolutionDBEntities db = new PerformanteSolutionDBEntities())
            {
                var v = db.AspNetEditions.Where(a => a.NomEdition == EditionName && a.EventId==id).FirstOrDefault();
                return v != null;
            }
        }
    }
}