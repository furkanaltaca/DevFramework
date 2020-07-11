using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DevFramework.Northwind.WebApi.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':');

                    IUserService userService = InstanceFactory.GetInstance<IUserService>();
                    var user = userService.GetByUserNameAndPassword(new User
                    {
                        UserName = tokenValues[0].ToString(),
                        Password = tokenValues[1].ToString(),
                    });

                    if (user != null)
                    {
                        var userRoles = userService.GetUserRoles(user).Select(ur => ur.RoleName).ToArray();
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), userRoles);

                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch
            {
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}