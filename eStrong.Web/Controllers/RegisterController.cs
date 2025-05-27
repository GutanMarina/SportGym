using eStrong.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using eStrong.BusinessLogic.Core;
using eStrong.BusinessLogic.Interfaces;
using eStrong.BusinessLogic.DBModel;
using eStrong.Web.Models.Register;
using eStrong.Domain.Enums;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Model;
using eStrong.BusinessLogic.BlStruct;



namespace eStrong.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;
        public RegisterController()
        {
            var bl = new BusinessLogicBL();
            _session = bl.GetSessionBL();
        }


        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegister model)
        {
            if (ModelState.IsValid)
            {

                var userData = new UDbTable
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    RegistrationDateTime = DateTime.Now,
                    RegistrationIp = Request.UserHostAddress,
                    LastLogin = DateTime.Now, // Inițializare corectă
                    Level = URole.User // Setare rol implicit
                };

                _session.UserRegister(userData); // Metoda doar salvează userul

                return RedirectToAction("Register");
            }

            return View(model);
        }

    }
}