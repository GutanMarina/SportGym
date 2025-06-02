using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eStrong.BusinessLogic.Interfaces;
using eStrong.BusinessLogic;
using eStrong.Web.Models.Blog;
using eStrong.Domain.Entities;
using System.IO;
using eStrong.Web.Filtres;

namespace eStrong.Web.Controllers
{
    [AdminAuthorize]
    public class ManagementController : Controller
    {
        private readonly IBlog _blog;
        private readonly IAdminSession _adminSession;
        public ManagementController()
        {
            var bl = new BusinessLogicManager();
            _blog = bl.GetBlogBL();
            _adminSession = bl.GetAdminSessionBL();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBlog(BlogManagement blog, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/UploadedImages"), fileName);
                    ImageFile.SaveAs(path);
                    blog.Image = "~/UploadedImages/" + fileName;
                }
                else
                {
                    blog.Image = "~/UploadedImages/placeholder.jpg"; // imagine implicită
                }

                var blogCreate = new BlogDbTable
                {
                    Title = blog.Title,
                    Description = blog.Description,
                    Text = blog.Text,
                    Image = blog.Image,
                    Date=DateTime.Now
                };
                var result = _adminSession.CreateBlog(blogCreate);
                if (result)
                    return RedirectToAction("Index", "Management", new { succes = true });
                else return RedirectToAction("CreateBlog", "Management", new { error = true });
            }
            else
            {
                return RedirectToAction("CreateBlog", "Management", new { error = true });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var result = _adminSession.DeleteBlog(id);
            if (result)
                return RedirectToAction("Index", "Management", new { succes = true });
            else return RedirectToAction("Index", "Management", new { error = true });
        }

        public ActionResult Edit(int id)
        {
            var blog = new BlogManagement
            {
                Id = id
            };
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBlog(BlogManagement blog, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/UploadedImages"), fileName);
                    ImageFile.SaveAs(path);
                    blog.Image = "~/UploadedImages/" + fileName;
                }
                else
                {
                    blog.Image = "~/UploadedImages/placeholder.jpg"; // imagine implicită
                }

                var blogCreate = new BlogDbTable
                {
                    Id=blog.Id,
                    Title = blog.Title,
                    Description = blog.Description,
                    Text = blog.Text,
                    Image = blog.Image,
                    Date = DateTime.Now
                };
                var result = _adminSession.UpdateBlog(blogCreate);
                if (result)
                    return RedirectToAction("Index", "Management", new { succes = true });
                else return RedirectToAction("UpdateBlog", "Management", new { error = true,id=blog.Id });
            }
            else
            {
                return RedirectToAction("UpdateBlog", "Management", new { error = true, id=blog.Id });
            }
        }
    }
}