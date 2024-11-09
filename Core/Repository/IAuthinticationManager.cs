using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IAuthinticationManager
    {
        Task<bool> ValidateUSer(UserLoginDTO user);
        Task<string> CreateToken();
    }
}
