using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using eStrong.Domain.Model.BMI;

namespace eStrong.BusinessLogic.Interfaces
{
   public interface IBmi
    {
        decimal CalculateBMI(BMICalculate bmi);
        bool SaveBmi(BMICalculate data, int userId);//salvare database4

        decimal BmiResult(int userId);


    }
}
