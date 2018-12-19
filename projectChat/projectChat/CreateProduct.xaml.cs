using Plugin.Media;
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
	public partial class CreateProduct : ContentPage
	{
        private Pickers ps= new Pickers();
        private SQLiteAsyncConnection _cnn;
        private string brand;
        public CreateProduct ()
		{
			InitializeComponent ();
            //inicia la conexion
            _cnn = DependencyService.Get<ISQLiteDB>().GetConnection();
            _catProduct.ItemsSource = ps.ListCategories();
            _brandProduct.ItemsSource = ps.ListBrands();
            _subcatProduct.ItemsSource = ps.ListSubcategories();
            _btnSave.Clicked += _btnSave_Clicked;
            _brandProduct.SelectedIndexChanged += _brandProduct_SelectedIndexChanged;
            _btnupload.Clicked += _btnupload_Clicked;
		}

        private async void _btnupload_Clicked(object sender, EventArgs e)
        {
          //  var photo = await CrossMedia.Current.TakePhotoAsync(
            //    new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file !=null)
            {
                imageProduct.Source = ImageSource.FromStream(() => { return file.GetStream(); });
            }
        }

        private void _brandProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            brand = _brandProduct.SelectedItem as String;
        }

        private async void _btnSave_Clicked(object sender, EventArgs e)
        {
           // var brand = _brandProduct.SelectedItem as String;
            ///imagen a base64 ImageProduct = imageProduct.Source.ToString(),
            var pm = new ProductModel() {
                NameProduct = _nameProduct.Text,
                CostProduct =  float.Parse(_costProduct.Text),
                BrandProduct = brand,
                DescriptionProduct = _description.Text,
                MSIProduct = _switchOpt.IsToggled,
                QuantityProduct = int.Parse(_quantiProduct.Text),
            };
            await _cnn.InsertAsync(pm);
                       
        
        }
    }
}