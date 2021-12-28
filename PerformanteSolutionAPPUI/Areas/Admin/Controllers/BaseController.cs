using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PerformanteSolutionAppUI.Areas.ProfessionalUser.Controllers
{

    public class BaseController : Controller
    {

        public string CurrentBaseUrl => $"{Request.Url.Scheme}://{Request.Url.Authority}";

        #region Get current userId

        public string CurrentAppUser()
        {
            return User.Identity.GetUserId();
        }
        public string CurrentUserId
        {
            get { return User.Identity.GetUserId(); }
            set { CurrentUserId = value; }
        }
        #endregion

        public bool IsAdmin
        {
            get
            {
                return User.IsInRole("Admin");
            }
        }

        public bool IsProfessional
        {
            get
            {
                return User.IsInRole("Professional");
            }
        }
    }
}