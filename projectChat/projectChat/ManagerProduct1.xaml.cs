using projectChat.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectChat
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManagerProduct1 : ContentPage
	{
        private ObservableCollection<ProductModel> _obproduct;
        private SQLiteAsyncConnection _cnn;
        private List<ProductModel> listClient = new List<ProductModel>();
        public ManagerProduct1 ()
		{
			InitializeComponent ();
            _cnn = DependencyService.Get<ISQLiteDB>().GetConnection();
            _back.Clicked += _back_Clicked;
            _add.Clicked += _add_Clicked;
        }

        private async void _add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateProduct());
        }

        private async void _back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManagerProduct1());
        }

        protected async override void OnAppearing()
        {
           // base.OnAppearing();
            await _cnn.CreateTableAsync<ProductModel>();
           // var productL = await _cnn.Table<ProductModel>().ToListAsync();
             listClient  = await _cnn.Table<ProductModel>().ToListAsync();
            //_obproduct = new ObservableCollection<ProductModel>(productL);
            xProductView.ItemsSource = listClient;
        }

        private void _btnEdit_Clicked(object sender, EventArgs e)
        {
           
        }

        private void _btnRemove_Clicked(object sender, EventArgs e)
        {

        }
    }
}