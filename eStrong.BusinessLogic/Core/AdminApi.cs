using eStrong.BusinessLogic.DBModel;
using eStrong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStrong.BusinessLogic.Core
{
    public class AdminApi
    {
        public bool CreateBlogAction(BlogDbTable blog)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Blog.Add(blog);
                db.SaveChanges();
            }
            return true;
        }
        public bool UpdateBlogAction(BlogDbTable blog)
        {
            using (var db = new ApplicationDbContext())
            {
                var existingBlog = db.Blog.Find(blog.Id);
                if (existingBlog == null)
                    return false;

                existingBlog.Title = blog.Title;
                existingBlog.Description = blog.Description;
                existingBlog.Text = blog.Text;
                existingBlog.Image = blog.Image; // doar dacă ai încărcat imaginea nouă
                existingBlog.Date = DateTime.Now;

                db.SaveChanges();
            }
            return true;
        }

        public bool DeleteBlogAction(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var blog = db.Blog.Find(id);
                if (blog != null)
                {
                    db.Blog.Remove(blog);
                    db.SaveChanges();
                }
            }
            return true;
        }
    }
}
