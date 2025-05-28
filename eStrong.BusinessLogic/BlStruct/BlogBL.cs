using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eStrong.BusinessLogic.Core;
using eStrong.BusinessLogic.Interfaces;
using eStrong.Domain.Entities;

namespace eStrong.BusinessLogic.BlStruct
{
    public class BlogBL:UserAPI, IBlog
    {
        public BlogDataDbTable GetBlogById(int blogId)
        {
            return GetBlogByIdAction(blogId);
        }
        public List<BlogDbTable> GetAllBlogs()
        {
            return GetAllBlogsAction();
        }

        public List<BlogDbTable> GetBlogsBySearchQuery(string search, List<BlogDbTable> allBlogs)
        {

            return GetBlogsBySearchQueryAction(search, allBlogs);
        }
    }
}
