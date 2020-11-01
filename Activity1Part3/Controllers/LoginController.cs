using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using Activity1Part3.Services.utilities;
using NLog;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
        

        //put item in the log
        
        // GET: Login
        public ActionResult Index()
        {
            
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel model) {

            MyLogger.GetInstance().Info("Entering the login controller. Login Method");
            // Validate the Form POST 
           
            try
            {
                if (!ModelState.IsValid)
                    return View("Login");
                SecurityService service = new SecurityService();


                bool status = service.Authenticate(model);

                if (status)
                {
                    Session["user"] = model;
                    MyLogger.GetInstance().Info("Exit login controller. Login was successful!");
                    return View("LoginPassed", model);
                }
                else
                {
                    Session.Clear();
                    MyLogger.GetInstance().Info("Exit login controller. Login failed!");
                    return View("LoginFailed");
                }

            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Exception!" + e.Message);
                return Content("Exception in login " + e.Message);

            }

        

        }
        [CustomAuthoization]
        public ActionResult Protected()
        {
            return Content("Private Information. Only logged in users should have access to this information!");
        }


    }
}