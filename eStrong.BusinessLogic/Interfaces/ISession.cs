using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Model.User;

namespace eStrong.BusinessLogic.Interfaces
{//declaram metoda
    public interface ISession
    {
        string UserRegister(UDbTable data);
        HttpCookie GenCookie(string loginCredential);

        UserMinimal UserDataLogin(UserLoginDTO data);
        UserMinimal GetUserByCookie(string apiCookieValue);

      
    }
}


