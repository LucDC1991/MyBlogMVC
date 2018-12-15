using MyBlogMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id=1)
        {
            DataAccess da = new DataAccess();
            var list = da.LoadData(id);
            ViewBag.page = (id + 1).ToString();
            return View(list);
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

        [HttpGet]
        public ActionResult PostArticle()
        {
            return View();
        }

        [HttpPost,ValidateInput(false)]
        public ActionResult PostArticle(Post post)
        {
            post.user = new User();
            post.postedDate = DateTime.Now.ToLongDateString();
            post.user.userId = 1;
            new DataAccess().PostArticle(post);
            return RedirectToAction("Index");
        }

        public ActionResult PostDetail(int id)
        {
            var post = new DataAccess().getPostDetail(id);
            return View(post);
        }

        
    }
}