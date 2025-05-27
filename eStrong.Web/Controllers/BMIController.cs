using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eStrong.BusinessLogic;
using eStrong.BusinessLogic.Interfaces;
using eStrong.Domain.Model.BMI;
using eStrong.Web.Models.BMI;

namespace eStrong.Web.Controllers
{
    public class BMIController : BaseController
    {
        private readonly IBmi _bmi;
        private readonly ISession _session;
        public BMIController ()
        {
            var bl = new BusinessLogicManager();
            _bmi = bl.GetBmiBL();
            _session = bl.GetSessionBL();
        }
        // GET: BMI
        public ActionResult Index()

        {
            SessionStatus();
            var model = new BmiViewModel();

            if (TempData["BmiResult"] != null)
            {
                model.BmiResult = (decimal)TempData["BmiResult"];
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalculateBMI(BmiViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bmiData = new BMICalculate
                {
                    Height = model.BmiData.Height,
                    Weight = model.BmiData.Weight,
                    Gender = model.BmiData.Gender,
                    Age = model.BmiData.Age
                };

                var bmiResult = _bmi.CalculateBMI(bmiData);
                bmiData.BMI = bmiResult;

                var cookie = Request.Cookies["X-KEY"]?.Value;
                var user = _session.GetUserByCookie(cookie);

                if (user == null)
                {
                    return RedirectToAction("Index", "Login"); 
                }

                var result = _bmi.SaveBmi(bmiData, user.Id);
                var bmiUserResult = _bmi.BmiResult(user.Id);

                if (result)
                {
                    TempData["BmiResult"] = bmiUserResult;
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", new { error = true });
                }
                
            }

            return RedirectToAction("Index", new { error = true });
        }

    }
}