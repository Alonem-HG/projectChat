using Plugin.Media;
using projectChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectChat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateUser : ContentPage
	{
		public CreateUser ()
		{
			InitializeComponent ();
            //Events to Password
            password.Completed += password_completed;
            passwordc.Completed += password_completed;
            //Picker of Countries
            _pcountries.Items.Add("aqui van los paises");
            //Events to Date
            dBirthday.Date = DateTime.Now;
            dBirthday.MinimumDate = new DateTime(1980, 12, 12);
            dBirthday.MaximumDate = new DateTime(2019, 12, 12);
            // dBirthday.DateSelected += FECHA_Seleccionada;

            //event today regiser
            // var dateR = dDayRegister.Date = DateTime.Now;
            User ob_user = new User();
            ob_user.dateRegister = DateTime.Now;

            //media
            _btntake.Clicked += _btntake_Clicked;
            _btnupload.Clicked += _btnupload_Clicked;
        }

        private async void _btnupload_Clicked(object sender, EventArgs e)
        {

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No upload", "Picking a photo is not supported", "OK");
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
            {
                return;
            }
            imageUser.Source = ImageSource.FromStream(() => file.GetStream());

        }

        private async void _btntake_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera", "No camare available", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name = "test.jpg"
            });


            if (file == null)
            {
                return;
            }
            else

            //imageUser.Source = ImageSource.FromStream(() => file.GetStream());
            imageUser.Source = ImageSource.FromStream(() => { return file.GetStream(); });

        }

        private async void password_completed(object sender, EventArgs e)
        {
            var regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8-15}";

            //
            Regex rx = new Regex(regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //metodo que regresa un objeto
            var result = rx.Match(password.Text);
            if (!string.IsNullOrEmpty(password.Text))
            {
                result = rx.Match(password.Text);
                if (!result.Success)
                {
                    await DisplayAlert("Error!", "Contraseña invalida", "Cancel");
                }

            }


            if (!string.IsNullOrEmpty(passwordc.Text))
            {
                //metodo que regresa un objeto
                result = rx.Match(passwordc.Text);

                if (!result.Success)
                {
                    await DisplayAlert("Error!", "Contraseña", "Cancel");
                }
            }


        }


        private async void Button_Clicked(object sender, EventArgs e)
        {

            /**
     Fields aren't emptys
     **/
            if (password.Text != null && passwordc.Text != null)
            {
                /**
                 * Password doesn't match
                 **/
                if (password.Text != passwordc.Text)
                {
                    await DisplayAlert("Error!", "Your password doesn't match!, Try again please.", "Cancel", "Continue");
                }
                /**
                 * Password are match
                 **/
                else if (password.Text.Equals(passwordc.Text))
                {
                    await DisplayAlert("Password is succesfull!", "Password are OK!", "Cancel", "Continue");
                }
            }
            /**
             * Some field is empty and it needs to fill it.
             **/
            else
            {
                await DisplayAlert("Error!", "Fill correctly the fields, please.", "Cancel", "Continue");
            }
        }
    }
}