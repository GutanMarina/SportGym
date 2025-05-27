using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using eStrong.Domain.Entities;

namespace eStrong.BusinessLogic.Interfaces
{
    public interface IBlog
    {
        List<BlogDbTable> GetAllBlogs();
        BlogDataDbTable GetBlogById(int blogId);

        List<BlogDbTable> GetBlogsBySearchQuery(string search, List<BlogDbTable> allBlogs);

    }
}
