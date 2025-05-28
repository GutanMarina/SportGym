
using System;
using System.Web;
using System.Web.Mvc;
using eStrong.BusinessLogic.BlStruct;
using eStrong.BusinessLogic.Interfaces;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Model.User;
using eStrong.Web.Models.Login;


namespace eStrong.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BusinessLogicBL();
            _session = bl.GetSessionBL();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserDataLogin login)  //entitate front
        {
            if (ModelState.IsValid)
            {

                var user = new UserLoginDTO //entitatea din back uLoginData. 
                {
                    Username = login.Username,
                    Password = login.Password
                };

                user.LastIp = Request.UserHostAddress;
                user.LastLogin = DateTime.Now;

                var userLogin = _session.UserDataLogin(user);
                if (userLogin == null)
                {
                    TempData["ErrorMessage"] = "The Username or Password is incorrect!";
                    RedirectToAction("Index", "Login");
                }


                if (userLogin!=null)
                {
                    Session["Username"] = login.Username;
                    Session["User"] = userLogin;

                    HttpCookie cookie = _session.GenCookie(login.Username);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home", new { succes = true });
                }
                else
                {
                    
                    return RedirectToAction("Index", "Login", new { error = true });
                }
            }
            else
            {
          
                return RedirectToAction("Index", "Login", new { error = true });

            }
        } 
    } 
}
