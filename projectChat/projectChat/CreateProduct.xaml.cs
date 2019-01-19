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
        //private List<User> listUser;

        public CreateProduct ()
		{
			InitializeComponent ();
            //inicia la conexion
            _cnn = DependencyService.Get<ISQLiteDB>().GetConnection();
            #region Load Items
            _catProduct.ItemsSource = ps.ListCategories();
            _brandProduct.ItemsSource = ps.ListBrands();
            _subcatProduct.ItemsSource = ps.ListSubcategories();
            #endregion

            _btnSave.Clicked += _btnSave_Clicked;
            // _brandProduct.SelectedIndexChanged += _brandProduct_SelectedIndexChanged;
            _btnupload.Clicked += _btnupload_Clicked;
            _btnDelete.Clicked += _btnDelete_Clicked;
		}

        private async void _btnDelete_Clicked(object sender, EventArgs e)
        {
            await _cnn.DropTableAsync<ProductModel>();
        }

        //inicia el view
        protected async override void OnAppearing()
        {
          //  await _cnn.DropTableAsync<ProductModel>();
            List<ProductModel> pl = new List<ProductModel>();
            await _cnn.CreateTableAsync<ProductModel>();
            pl = await _cnn.Table<ProductModel>().ToListAsync();
            //await _cnn.DropTableAsync<ProductModel>();
            base.OnAppearing();
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

        //private void _brandProduct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    brand = _brandProduct.SelectedItem as String;
        //}

        private async void _btnSave_Clicked(object sender, EventArgs e)
        {
           // var brand = _brandProduct.SelectedItem as String;
            ///imagen a base64 ImageProduct = imageProduct.Source.ToString(),
            var pm = new ProductModel() {
                NameProduct = _nameProduct.Text,
                CostProduct =  float.Parse(_costProduct.Text),
                //BrandProduct = _brandProduct.SelectedItem as String,
               // CategoryProduct = _catProduct.SelectedItem as String,
               // SubCategoryProduct = _subcatProduct.SelectedItem as String,
                DescriptionProduct = _description.Text,
                QuantityProduct = int.Parse(_quantiProduct.Text),
            };
            await _cnn.InsertAsync(pm);

           await  Navigation.PushAsync(new ManagerProduct1());

        }
    }
}