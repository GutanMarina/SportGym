using eStrong.BusinessLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eStrong.BusinessLogic.Interfaces;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Model.User;
using System.Data.Entity;
using System.Web;
using eStrong.BusinessLogic.DBModel;
using eStrong.Domain.Entities;
using System.Net;


namespace eStrong.BusinessLogic.BlStruct
{
    public class SessionBL : UserAPI, ISession
    {
        public string UserRegister(UDbTable data)
        {
            return UserRegisterAction(data);
        }

        public UserMinimal UserDataLogin(UserLoginDTO data)
        {
            return UserLoginAction(data);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }
        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
          }
    }
    
}
