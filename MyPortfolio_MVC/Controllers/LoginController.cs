using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyPortfolioDbEntities1 db = new MyPortfolioDbEntities1 ();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            var values = db.TblAdmins.FirstOrDefault(x=> x.Email==model.Email && x.Password == model.Password);
            if (values == null)
            {
                ModelState.AddModelError("","Email veya Şifre hatalı");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(values.Email, false);

            
            Session["email"] = values.Email;
            return RedirectToAction("Index","Category");

        }
    }
}