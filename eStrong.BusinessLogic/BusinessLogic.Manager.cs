using System;
using eStrong.BusinessLogic.BlStruct;
using eStrong.BusinessLogic.Interfaces;

namespace eStrong.BusinessLogic
{//implimentarea la metoda
    public class BusinessLogicManager
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
        public IBmi GetBmiBL()
        {
            return new BmiBL();
         }
        public IBlog GetBlogBL()
        {
            return new BlogBL();
        }
        public IAdminSession GetAdminSessionBL()
        {
            return new AdminSessionBL();
        }
    }
}