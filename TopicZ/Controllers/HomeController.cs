using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using TopicZ.ViewModel;
using TopicZ.ViewModel;

namespace TopicZ.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
           
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel _user)
{

            if (ModelState.IsValid)
            {

                using (var db = new TopicZContext())
                {
                    Member member = new Member();
                    member = db.Members.ToList().Find(x => x.MemberEmail == _user.Email);
                    if (member != null)
                    {
                        if (member.MemberPassword == _user.Password)
                        {
                            Session["Email"] = _user.Email;
                            Session["Password"] = _user.Password;
                            return RedirectToAction("Index", "LoggedIn");

                        }
                        else
                        {
                            ModelState.AddModelError("", "Fel lösenord");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User finns ej");
                    }

                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterModel _user)
        {

            if (ModelState.IsValid)
            {

                using (var db = new TopicZContext())
                {
                    db.Members.Add(new Member() { MemberName = _user.Name, MemberEmail = _user.Email, MemberPassword = _user.Password, MemberDateTime = DateTime.UtcNow });
                    db.SaveChanges();
                }

                return RedirectToAction("Login");
            }
            return View();
        }




        public JsonResult CheckUserName(string Email)
        {
            var result = true;
            using (var db = new TopicZContext())
            {
                if (db.Members.ToList().Find(x => x.MemberEmail == Email) != null)
                {
                    result = false;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}