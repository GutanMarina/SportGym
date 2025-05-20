using System;
using System.Collections.Generic;
using System.Text;
using eStrong.BusinessLogic.DBModel;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Model.User;
using System.Linq;
using System.Data.Entity;
namespace eStrong.BusinessLogic.Core
{//implementarea metodei
    public class UserAPI
    {
        public string UserAuthLogicAction(UserLoginDTO data)
        {
            return "token key";
        }
        public void UserRegisterAction(UDbTable data)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.UDbTable.Any(u => u.Email == data.Email || u.Username == data.Username))
                {
                    throw new Exception("Acest utilizator există deja!");
                }

                db.UDbTable.Add(data);
                db.SaveChanges();
            }
        }
    }
}

