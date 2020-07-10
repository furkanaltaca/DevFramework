using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class UserValidatior : AbstractValidator<User>
    {
        public UserValidatior()
        {
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();

            RuleFor(u => u.UserName.Length).LessThanOrEqualTo(50);
            RuleFor(u => u.Password.Length).LessThanOrEqualTo(50);

        }
    }
}
