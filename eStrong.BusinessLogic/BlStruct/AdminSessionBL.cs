using eStrong.BusinessLogic.Core;
using eStrong.BusinessLogic.Interfaces;
using eStrong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStrong.BusinessLogic.BlStruct
{
   public class AdminSessionBL: AdminApi, IAdminSession 
    {
        public bool CreateBlog(BlogDbTable blog)
        {
            return CreateBlogAction(blog);
        }
        public bool UpdateBlog(BlogDbTable blog)
        {
            return UpdateBlogAction(blog);
        }
        public bool DeleteBlog(int id)
        {
            return DeleteBlogAction(id);
        }

    }
}
