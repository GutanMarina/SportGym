using System;
using System.Collections.Generic;
using System.Text;
using eStrong.BusinessLogic.DBModel;
using eStrong.Domain.Entities.User;
using eStrong.Domain.Model.User;
using System.Linq;
using System.Data.Entity;
using eStrong.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using eStrong.Helpers;
using eStrong.Domain.Entities;
using System.Web;
using System.Net.Http.Headers;
using eStrong.Domain.Model.BMI;
using System.Runtime.Remoting.Contexts;
namespace eStrong.BusinessLogic.Core
{//implementarea metodei
    public class UserAPI
    {
        public string UserRegisterAction(UDbTable data)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.UDbTable.Any(u => u.Email == data.Email || u.Username == data.Username))
                {
                    return ("This User Exists Already!");

                }

                var hashedPassword = LoginHelper.HashGen(data.Password);

                var newUser = new UDbTable
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = hashedPassword,
                    RegistrationDateTime = data.RegistrationDateTime,
                    LastLogin = DateTime.Now,
                    RegistrationIp = data.RegistrationIp,
                    Level = data.Level
                };


                db.UDbTable.Add(newUser);
                db.SaveChanges();
                return ("Registration with Succes!");
            }
        }

        internal UserMinimal UserLoginAction(UserLoginDTO data)
        {
            try
            {
                UDbTable result;
                var validate = new EmailAddressAttribute();
                var pass = LoginHelper.HashGen(data.Password); 

                using (var db = new ApplicationDbContext())
                {
                    if (validate.IsValid(data.Username))
                    {
                        result = db.UDbTable
                            .FirstOrDefault(u => u.Email == data.Username && u.Password == pass);
                    }
                    else
                    {
                        result = db.UDbTable
                            .FirstOrDefault(u => u.Username == data.Username && u.Password == pass);
                    }
                    if (result != null)
                    {
                        result.LastIp = data.LastIp;
                        result.LastLogin = data.LastLogin;

                        result.LastLogin = data.LastLogin < new DateTime(1753, 1, 1) ? DateTime.Now : data.LastLogin;

                        db.Entry(result).State = EntityState.Modified;
                        db.SaveChanges();

                        var user = new UserMinimal
                        {

                            Id = result.Id,
                            Username = result.Username,
                            Email = result.Email,
                            LastLogin = result.LastLogin,
                            LastIp = result.LastIp,
                            Level = result.Level

                        };
                        return user;
                    }


                    return null;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        internal HttpCookie Cookie(string loginCredential)
        {
            try
            {
                var apiCookie = new HttpCookie("X-KEY")
                {
                    Value = CookieGenerator.Create(loginCredential)
                };

                using (var db = new ApplicationDbContext())
                {
                    Session curent;
                    var validate = new EmailAddressAttribute();

                    curent = db.Sessions
                        .FirstOrDefault(e => e.Username == loginCredential);

                    if (curent != null)
                    {
                        curent.CookieString = apiCookie.Value;
                        curent.ExpireTime = DateTime.Now.AddMinutes(60);

                        using (var todo = new ApplicationDbContext())
                        {
                            todo.Entry(curent).State = EntityState.Modified;
                            todo.SaveChanges();
                        }
                    }
                    else
                    {
                        db.Sessions.Add(new Session
                        {
                            Username = loginCredential,
                            CookieString = apiCookie.Value,
                            ExpireTime = DateTime.Now.AddMinutes(60)
                        });

                        db.SaveChanges();
                    }
                }

                return apiCookie;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
            internal UserMinimal UserCookie(string cookie)
        {
            try
            {
                Session session;
                UDbTable curentUser;

                using (var db = new ApplicationDbContext())
                {
                    session = db.Sessions
                        .FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
                }

                if (session == null) return null;

                using (var db = new ApplicationDbContext())
                {
                    var validate = new EmailAddressAttribute();

                    if (validate.IsValid(session.Username))
                    {
                        curentUser = db.UDbTable
                            .FirstOrDefault(u => u.Email == session.Username);
                    }
                    else
                    {
                        curentUser = db.UDbTable
                            .FirstOrDefault(u => u.Username == session.Username);
                    }
                }

                if (curentUser == null) return null;

                UserMinimal userMinimal = new UserMinimal
                {
                    Id = curentUser.Id,
                    Username = curentUser.Username,
                    Email = curentUser.Email,
                    LastLogin= curentUser.LastLogin,
                    LastIp=curentUser.LastIp,
                    Level=curentUser.Level
                };
                return userMinimal;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        internal decimal CalculateBMIAction(BMICalculate bmi)
        {
            decimal bmiResult = (bmi.Weight) / (bmi.Height/100 * bmi.Height/100);
            return bmiResult;
        }
        internal bool SaveBmiAction(BMICalculate data, int userId)
        {
            if (string.IsNullOrEmpty(data.Gender))
            {
                return false;
            }

            if (data.Height <= 0 || data.Weight <= 0 || data.Age <= 0)
             {
                return false;
            }
            using (var db= new ApplicationDbContext())
            {
                var bmiValue = new BMIDbTable
                {
                    Height = data.Height,
                    Weight = data.Weight,
                    Age = data.Age,
                    Gender = data.Gender,
                    CalculateTime = DateTime.Now,
                    UserId = userId,
                    BMI = data.BMI
                };

                db.BMI.Add(bmiValue);
                db.SaveChanges();
                return true;
            }


            
        }
        internal decimal BmiResultAction(int userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var lastBmi = db.BMI
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CalculateTime) // sau alt câmp după care vrei să iei "ultimul"
                .FirstOrDefault();

                return lastBmi.BMI;
            }
        }
       internal List<BlogDbTable> GetAllBlogsAction()
        {
            using (var db= new ApplicationDbContext())
            {
                var blogs = db.Blog.ToList();

                return blogs;
            }
            
        }

        internal BlogDataDbTable GetBlogByIdAction(int blogId)
        {
            using (var db = new ApplicationDbContext())
            {
                var blog = db.Blog.FirstOrDefault(b => b.Id == blogId);

                var blogData = new BlogDataDbTable
                {
                    Date = blog.Date,
                    Description = blog.Description,
                    Title = blog.Title,
                    Image = blog.Image,
                    Text = blog.Text
                };

                return blogData;

            }
            
        }
        internal List<BlogDbTable> GetBlogsBySearchQueryAction(string search, List<BlogDbTable> allBlogs)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(search))
                    return allBlogs;


                // Împarte căutarea în cuvinte individuale
                var searchWords = search
                    .Split(new[] { ' ', ',', '.', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.ToLower())
                    .ToList();

                // Filtrare în memorie
                var filteredBlogs = allBlogs
                    .Where(blog => searchWords.Any(word =>
                        (!string.IsNullOrEmpty(blog.Title) && blog.Title.ToLower().Contains(word)) ||
                        (!string.IsNullOrEmpty(blog.Description) && blog.Description.ToLower().Contains(word))
                    ))
                    .ToList();

                return filteredBlogs;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<BlogDbTable>();
            }

        }
    }
    }
 


