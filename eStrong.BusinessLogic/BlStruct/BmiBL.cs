using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eStrong.BusinessLogic.Core;
using eStrong.BusinessLogic.Interfaces;
using eStrong.Domain.Model.BMI;

namespace eStrong.BusinessLogic.BlStruct
{
    public class BmiBL : UserAPI, IBmi
    {
        public decimal CalculateBMI(BMICalculate bmi)
        {
            return CalculateBMIAction(bmi);
        }
        public bool SaveBmi(BMICalculate data, int userId)
        {
            return SaveBmiAction(data, userId);
        }
        public decimal BmiResult(int userId)
        {
            return BmiResultAction(userId);
        }
    }
}
