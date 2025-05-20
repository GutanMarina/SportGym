using System;
using System.Collections.Generic;
using System.Text;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Model.User;

namespace eStrong.BusinessLogic.Interfaces
{//declaram metoda
    public interface ISession
    {
        void UserRegister(UDbTable data);
    }
}


