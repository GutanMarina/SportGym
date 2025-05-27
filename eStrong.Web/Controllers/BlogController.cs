using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using eStrong.BusinessLogic;
using eStrong.BusinessLogic.BlStruct;
using eStrong.BusinessLogic.Interfaces;
using eStrong.Domain.Entities;
using eStrong.Web.Models.Blog;

namespace eStrong.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlog _blog;
        public BlogController ()
        {
            var bl = new BusinessLogicManager();
            _blog = bl.GetBlogBL();
        }
        // GET: Blog
        public ActionResult Index(string search)
        {
            List<BlogDbTable> blogs = new List<BlogDbTable>();
            blogs = _blog.GetAllBlogs();

            if (!string.IsNullOrEmpty(search))
            {
                blogs = _blog.GetBlogsBySearchQuery(search, blogs);
            }

                var blogList = new List<BlogData>();
            foreach(var blog in blogs)
            {
                var blogInfo = new BlogData
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Description = blog.Description,
                    Date = blog.Date,
                    Image = blog.Image
                };
                blogList.Add(blogInfo);
            }
            return View(blogList);
        }
        public ActionResult BlogDetails(int blogId)
        {
            var blog = _blog.GetBlogById(blogId);

            var blogData = new BlogInfo
            {
                Date = blog.Date,
                Description = blog.Description,
                Title = blog.Title,
                Image = blog.Image,
                Text = blog.Text
            };

            return View(blogData);
        }
        
    }
}