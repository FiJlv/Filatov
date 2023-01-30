using Homework_17_Filatov_Vladyslav_Serhiyovych.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_17_Filatov_Vladyslav_Serhiyovych.Stubs
{
    public class FakePasswordValidator : IPasswordValidator
    {
        public bool IsPasswordValid(string password) => true;
    }
}
