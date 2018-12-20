using projectChat.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectChat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        private SQLiteAsyncConnection _cnn;
        private List<User> listUser;
      
        public Login ()
		{
			InitializeComponent ();
            _btnCreateAccount.Clicked += _btnCreateAccount_Clicked;
            _btnLogin.Clicked += _btnLogin_Clicked;

            _cnn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }

        protected async override void OnAppearing()
        {
            await _cnn.CreateTableAsync<User>();
            listUser = await _cnn.Table<User>().ToListAsync();
             //result = listUser.Where <"">;
        }

        private async void _btnLogin_Clicked(object sender, EventArgs e)
        {
            //validar que tenga datos de la lista
            //buscar el usuario
            //var name = _userName.Text;
            //x => x.Id != client.Id).ToList()
            var compareName = await _cnn.Table<User>().Where(
                i => i.nameuser == _userName.Text && i.passworduser == _password.Text).ToListAsync();

            if (compareName!=null)
            {
              await Navigation.PushAsync(new ManagerProduct());
            }
            else
            {
              await DisplayAlert("Access deny","User invalid","Ok");
            }
            
        }

        private void _btnCreateAccount_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUser());
        }
    }
}