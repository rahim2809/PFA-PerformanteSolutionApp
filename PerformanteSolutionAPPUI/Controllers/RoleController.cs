using BLL;
using BOL;
using Microsoft.AspNet.Identity.Owin;
using PerformanteSolutionAppUI.Models;
using PerformanteSolutionAPPUI;
using PerformanteSolutionAPPUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace PerformanteSolutionAppUI.Controllers
{
    public class RoleController : Controller
    {
        private RawSqlQueryBs objBs2;

        private ApplicationRoleManager _roleManager; 
        private ApplicationUserManager _userManager;
         
        public RoleController() 
        {
            objBs2 = new RawSqlQueryBs();
        }

        public RoleController( ApplicationRoleManager roleManager, ApplicationUserManager userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }







        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
            
                list.Add(new RoleViewModel(role));
            
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var exist= RoleManager.RoleExistsAsync(model.Name).Result;
            if (exist==false)
            {
                var role = new ApplicationRole() { Name = model.Name };
                await RoleManager.CreateAsync(role);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("RoleExist", "Ce role existe");
                return View();
            }

            
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.UpdateAsync(role);

            return View(new RoleViewModel(role));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = new ApplicationRole() { Name = model.Name };
            await RoleManager.UpdateAsync(role);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AssignRole()
        {
            ViewBag.Roles = RoleManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AssignRole(FormCollection form)
        {
            string user = form["txtUserName"];
            string role = form["Name"];

            var isExist = IsUserExist(user);
            if (!isExist)
            {
                ModelState.AddModelError("UserExist", " User does not Exist ");
                return View();
            }

            else
            {
                AspNetUser MyUser = objBs2.GetUserByName(user);
                await UserManager.AddToRoleAsync(MyUser.Id, role);
                return RedirectToAction("Index");
            }

        }

        [NonAction]
        public bool IsUserExist(string login)
        {
            using (PerformanteSolutionDBEntities db = new PerformanteSolutionDBEntities())
            {
                var v = db.AspNetEvents.Where(a => a.Login == login).FirstOrDefault();
                return v != null;
            }
        }

    }
}