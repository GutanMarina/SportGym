using System;
using System.Collections.Generic;
using System.Text;
using eStrong.BusinessLogic.Core;
using eStrong.BusinessLogic.Interfaces;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Model.User;

namespace eStrong.BusinessLogic.BlStruct
{//legatura businesslog cu metoda, declararea metodei, implementare din interfata cu parametru in useriapi
    public class LoginBl : UserAPI, ISession
    {

        public string UserAuthLogic(UserLoginDTO data)
        {
            return UserAuthLogicAction(data);
        }


        public void UserRegister(UDbTable data)
        {
            throw new NotImplementedException();
        }
    }
}
