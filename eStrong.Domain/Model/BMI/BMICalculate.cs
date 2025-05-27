using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStrong.Domain.Model.BMI
{
      public class BMICalculate
    {
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal BMI { get; set; }

    }
}
