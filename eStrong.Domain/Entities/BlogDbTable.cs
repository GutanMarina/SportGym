using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eStrong.Domain.Entities.User;

namespace eStrong.Domain.Entities
{
    [Table("Blog")]
   public class BlogDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        
        public string Image { get; set; }

        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}

