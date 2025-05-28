using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eStrong.BusinessLogic.Interfaces;
using eStrong.BusinessLogic;
using eStrong.Web.Models.Blog;

namespace eStrong.Web.Controllers
{

    public class ManagementController : Controller
    {
        private readonly IBlog _blog;
        public ManagementController()
        {
            var bl = new BusinessLogicManager();
            _blog = bl.GetBlogBL();
        }

        // GET: Management
        public ActionResult Index()
        {
            var blogs = _blog.GetAllBlogs();
            var blogList = new List<BlogData>();
            foreach (var blog in blogs)
            {
                var blogInfo = new BlogData
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Description = blog.Description,
                    Image = blog.Image
                };
                blogList.Add(blogInfo);
            }
            return View(blogList);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}