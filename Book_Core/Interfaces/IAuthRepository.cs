using Book_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Core.Interfaces
{
    public interface IAuthRepository
    {
        Task <string> RegisterAsync(Users users, string password);   
        Task <string> LoginAsync(string usersName, string password);   
        Task <string> ChangePasswordAsync(string email, string oldPassword,string newPassword);   
    }
}
