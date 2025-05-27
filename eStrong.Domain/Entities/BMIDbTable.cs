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
    [Table("BMI")]
    public class BMIDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UDbTable User {get; set;}

        [Required]
        [Display(Name = "Height")]
        public decimal Height { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime CalculateTime { get; set; }

        [Display(Name = "BMI")]
        public decimal BMI { get; set; }

    }
}
