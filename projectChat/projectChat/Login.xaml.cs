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
		public Login ()
		{
			InitializeComponent ();
            _btnCreateAccount.Clicked += _btnCreateAccount_Clicked;
            _btnLogin.Clicked += _btnLogin_Clicked;
            
		}

        private void _btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManagerProduct());
        }

        private void _btnCreateAccount_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUser());
        }
    }
}