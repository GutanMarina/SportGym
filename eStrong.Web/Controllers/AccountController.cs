﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eStrong.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Logout()
        {
            Session.Clear();
            if (Request.Cookies["X-KEY"] != null)
            {
                var cookie = new HttpCookie("X-KEY")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}