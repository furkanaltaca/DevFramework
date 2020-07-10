using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public string Login(string userName, string password)
        {
            var user = _userService.GetByUserNameAndPassword(new User { UserName = userName, Password = password });
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    user.UserName,
                    user.Email,
                    DateTime.Now.AddSeconds(10),
                    _userService.GetUserRoles(user).Select(ur => ur.RoleName).ToArray(),
                    false,
                    user.FirstName,
                    user.LastName
                    );
                return "User is authenticated.";
            }
            return "User is not authenticated.";
        }
    }
}