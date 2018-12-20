using System;
using System.Collections.Generic;
using System.Text;

namespace projectChat.Models
{
    public interface IUserManager
    {
        List<string> GetAll();
        void SaveUser();
        void DeleteUser();
        void UpdateUser();
        List<User> SearchByUser(string user);
    }
}
