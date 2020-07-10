using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = SetId(ticket),
                Name = ticket.Name,
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                AuthenticationType = "Forms",
                IsAuthenticated = true
            };


            return identity;
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return data[3].ToString();
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return data[2].ToString();
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            var roles = data[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return data[0].ToString();
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|');
            return new Guid(data[4]);
        }
    }
}
