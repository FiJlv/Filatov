using Homework_17_Filatov_Vladyslav_Serhiyovych.Models.Domain;
using Homework_17_Filatov_Vladyslav_Serhiyovych.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_17_Filatov_Vladyslav_Serhiyovych.Repositories
{
    public interface IUserRepository
    {
        User CreateUser(CreateUserDTO userDTO);
    }
}
