using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eStrong.Domain.Model.User;

namespace eStrong.Web.Extension
{
    public static class HttpContextExtensions
    {
        public static UserMinimal GetMySessionObject(this HttpContext current)
        {
            return (UserMinimal)current?.Session["__SessionObject"];
        }

        public static void SetMySessionObject(this HttpContext current, UserMinimal profile)
        {
            current.Session.Add("__SessionObject", profile);
        }
    }
}