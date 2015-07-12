using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;
using ReactDemo.Models;

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<Comment> _comments;

        static HomeController()
        {
            _comments = new List<Comment>
            {
                new Comment
                {
                    Author = "Daniel Lo Nigro",
                    Text = "Hello ReactJS.NET World!"
                },
                new Comment
                {
                    Author = "Pete Hunt",
                    Text = "This is one comment"
                },
                new Comment
                {
                    Author = "Jordan Walke",
                    Text = "This is *another* comment"
                },
            };
        }
        
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            _comments.Add(comment);
            return Content("Success :)");
        }

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}