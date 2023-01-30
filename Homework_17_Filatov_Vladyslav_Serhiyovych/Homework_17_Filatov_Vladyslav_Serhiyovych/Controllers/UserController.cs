using Homework_17_Filatov_Vladyslav_Serhiyovych.Models.Domain;
using Homework_17_Filatov_Vladyslav_Serhiyovych.Models.DTO;
using Homework_17_Filatov_Vladyslav_Serhiyovych.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_17_Filatov_Vladyslav_Serhiyovych.Controllers
{
    public class UserController
    {
        private readonly IPasswordValidator passwordValidator;
        private readonly IEmailValidator emailValidator;

        public UserController(IPasswordValidator passwordValidator, IEmailValidator emailValidator)
        {
            this.passwordValidator = passwordValidator;
            this.emailValidator = emailValidator;
        }


        public bool ValidateUserDto(CreateUserDTO userDTO, out string message)
        {

            var isNameValid = userDTO.Name.Length >= 3;
            if (!isNameValid) 
            {
                message = "Wrong name";
                return false;
            }

            var isPasswordValid = passwordValidator.IsPasswordValid(userDTO.Password);
            if (!isPasswordValid)
            {
                message = "Wrong password";
                return false;
            }

            var isEmailValid = emailValidator.IsEmailValid(userDTO.Email);
            if (!isEmailValid)
            {
                message = "Wrong email";
                return false;
            }

            message = "Success";
            return true;
        }
    }
}
