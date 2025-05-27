using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStrong.Domain.Entities
{
    public class BlogDataDbTable
    {
       
        public int Id { get; set; }

        public string Title { get; set; }

       
        public string Description { get; set; }

       
        public DateTime Date { get; set; }

        public string Image { get; set; }

       
        public string Text { get; set; }
    }
}
