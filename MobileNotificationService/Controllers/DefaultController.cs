using DevOne.Security.Cryptography.BCrypt;
using MobileNotificationService.Models;
using MobileNotificationService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MobileNotificationService.Controllers
{
    [Authorize]
    public class DefaultController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Register([FromBody] UserRegisterModel model)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    if (ctx.Users.SingleOrDefault(w => w.Username.Equals(model.Username)) != null)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Kullanıcı adı zaten var"
                        });
                    }
                    ctx.Users.Add(new User()
                    {
                        SystemId = model.SystemId,
                        Username = model.Username,
                        PasswordHash = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt(12)),
                        Role = "client"
                    });
                    ctx.SaveChanges();
                    return Json(new
                    {
                        success = true
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpGet]
        public IHttpActionResult Profile()
        {
            try
            {
                var profile = new ProfileModel();
                var user = GetCurrentUser();
                profile.Username = user.Username;
                profile.NotificationSubjects = new List<NotificationSubject>();
                profile.NotificationSubjects.Add(new NotificationSubject()
                {
                    Description = "açıklama",
                    DescriptionNo = 1,
                    IconPath = "c:/deneme",
                    SubjectCount = 5,
                    SmallDescription="kısa açıklama",
                    ID=1
                });
                return Json(new
                {
                    success = true,
                    profile
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            try
            {
                var users = new List<UserModel>();
                using (var ctx = new DatabaseContext())
                {
                    foreach (var user in ctx.Users.ToList())
                    {
                        users.Add(new UserModel()
                        {
                            SystemId = user.SystemId,
                            Username = user.Username
                        });
                    }
                    return Json(new
                    {
                        success = true,
                        users
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [NonAction]
        public User GetCurrentUser()
        {
            using (var ctx = new DatabaseContext())
            {
                var identity = (ClaimsIdentity)User.Identity;
                var claims = identity.Claims.ToList();
                var username = claims[0].Value;
                return ctx.Users.SingleOrDefault(w => w.Username == username);
            }
        }
    }
}
