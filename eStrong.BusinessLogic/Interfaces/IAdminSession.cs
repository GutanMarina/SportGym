using eStrong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStrong.BusinessLogic.Interfaces
{
    public interface IAdminSession
    {
        bool CreateBlog(BlogDbTable blog);
        bool UpdateBlog(BlogDbTable blog);
        bool DeleteBlog(int id);
    }
}
