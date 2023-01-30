using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_17_Filatov_Vladyslav_Serhiyovych.Validators
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsEmailValid(string email)
        {
            if (email.Contains('@') && email.Contains('.') && email.Length >=5)
                return true;

            return false;
        }
    }
}
