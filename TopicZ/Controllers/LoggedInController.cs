using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopicZ.ViewModel;


namespace TopicZ.Controllers
{
    public class LoggedInController : Controller
    {
        // GET: LoggedIn

        [HttpGet]
        public ActionResult Index()
        {

            if (Session["Email"] != null)
            {
                LoggedInIndexViewModel model = new LoggedInIndexViewModel();
                return View(model);
            }

            return RedirectToAction("Login", "Home");
        }
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
        public ActionResult LogOut()
        {
            //FormsAuthentication.SignOut();

            Session["Email"] = null;
            Session["Password"] = null;
            return RedirectToAction("Login", "Home");

        }


        [HttpGet]
        public ActionResult CreateTopic()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateTopic(CreateTopicModel _model)
        {
            using (var db = new TopicZContext())
            {

                if (ModelState.IsValid)
                {
                    if (Session["Email"] != null)
                    {
                        //Så länge kontot existerar

                        int autherId = db.Members.ToList().Find(x => x.MemberEmail == Session["Email"].ToString()).MemberId;
                        db.Topics.Add(new Topic { AuthorId = autherId, TopicHeadline = _model.TopicHeader, TopicDateTime = DateTime.UtcNow });
                        db.SaveChanges();

                        return RedirectToAction("Index", "LoggedIn");

                    }

                    return RedirectToAction("Login", "Home");

                }

            }

            return View();
        }




        [NonAction]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            LoggedInLayoutViewModel layoutModel = new LoggedInLayoutViewModel();

            using (var db = new TopicZContext())
            {
                if (Session["Email"] != null)
                {

                    ViewBag.LayoutModel = new LoggedInLayoutViewModel()
                    {
                        Name = db.Members.ToList().Find(x => x.MemberEmail == Session["Email"].ToString()).MemberName
                    };
                }
                else
                {
                    filterContext.Result = RedirectToAction("Login", "Home");

                }

            }
        }
    }
}


