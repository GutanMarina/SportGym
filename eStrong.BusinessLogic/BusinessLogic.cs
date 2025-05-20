using System;
using eStrong.BusinessLogic.BlStruct;
using eStrong.BusinessLogic.Interfaces;

namespace eStrong.BusinessLogic
{//implimentarea la metoda
    public class BusinessLogic
    {
        public ISession GetAuthBl()
        {
            return new LoginBl();
        }

    }
}