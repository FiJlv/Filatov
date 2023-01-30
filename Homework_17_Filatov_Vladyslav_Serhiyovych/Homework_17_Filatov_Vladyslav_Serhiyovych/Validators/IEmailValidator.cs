using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_17_Filatov_Vladyslav_Serhiyovych.Validators
{
    public interface IEmailValidator
    {
        bool IsEmailValid(string email);
    }
}
