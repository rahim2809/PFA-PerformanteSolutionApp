using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanteSolutionAppUI.Areas.Admin.Controllers 
{
    public class ManageEditionController : Controller 
    {
        private EditionBs objBs1;
        private RawSqlQueryBs objBs2; 

        public ManageEditionController()
        {
            objBs1 = new EditionBs();
            objBs2 = new RawSqlQueryBs(); 
        }

        /******************************** "Editions" CONTAIN ALL EDITIONS ********************************/

        // GET: Admin/EditionManagement  
        public ActionResult Editions()
        {

            var EdtionVM = objBs2.EditionListAdmin();
            
            return View(EdtionVM);
        }

        [HttpPost]
        public ActionResult Editions(string searchTxt)
        {

            var EdtionVM = objBs2.EditionListAdmin();

            if (searchTxt != null)
            {
                EdtionVM = objBs2.SearchForEditionsListAdmin(searchTxt);
            }

            return View(EdtionVM);
        }

        /******************************** "OnEdition" Activate An Edition ********************************/

        public ActionResult OnEdition(int id)
        {
            string actif = "TRUE";

            objBs2.OnOROffEdition(id, actif);

            return RedirectToAction("Editions");
        }

        /******************************** "OffEdition" Unctivate An Edition ********************************/

        public ActionResult OffEdition(int id)
        {
            string actif = "FALSE";

            objBs2.OnOROffEdition(id, actif);

            return RedirectToAction("Editions");
        }

        public ActionResult DeleteEdition(int id)
        {
            objBs1.Delete(id);
            return RedirectToAction("Editions");
        }

        /******************************** "DetailEdition" Detail ********************************/

        public ActionResult DetailEdition(int id)
        {
            var edition = objBs1.GetById(id);

            return View(edition);
        }

        /******************************** "ValidateEdition" VALIDATE AN EVENT ********************************/

        public ActionResult ValidateEdition(int id)
        {
            var edition = objBs1.GetById(id);
            edition.Statut = "Validated";
            objBs1.Update(edition);
            return RedirectToAction("Editions");
        }



    }
}