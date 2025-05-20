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


namespace eStrong.BusinessLogic.BlStruct
{
    public class SessionBL : UserAPI, ISession
    {
        public void UserRegister(UDbTable data)
        {
            UserRegisterAction(data);
        }

    }

}
