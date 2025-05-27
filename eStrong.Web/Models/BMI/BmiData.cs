using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eStrong.Web.Models.BMI
{
	public class BmiData
	{
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal BMI { get; set; }
    }
}