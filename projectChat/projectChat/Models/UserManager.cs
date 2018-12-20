using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace projectChat.Models
{
    public class UserManager : IUserManager
    {
        private SQLiteAsyncConnection _cnn;
        

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveUser()
        {
            //_cnn = DependencyService.Get<ISQLiteDB>().GetConnection();
            //await _cnn.InsertAsync(client);
            //listClient.Add(client);
        }

        public List<User> SearchByUser(string user)
        {
            //_cnn = DependencyService.Get<ISQLiteDB>().GetConnection();
            //  _cnn.GetAsync();
            // return;
            throw new NotImplementedException();
        }

        public void UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
