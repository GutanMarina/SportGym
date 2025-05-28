using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStrong.Web.Models.Blog
{
	public class BlogInfo
	{
        public int Id { get; set; }

        public string Title { get; set; }


        public string Description { get; set; }


        public DateTime Date { get; set; }

        public string Image { get; set; }


        public string Text { get; set; }
    }
}