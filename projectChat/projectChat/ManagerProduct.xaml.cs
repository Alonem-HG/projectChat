using projectChat.Models;
using Rg.Plugins.Popup.Services;
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
	public partial class ManagerProduct : ContentPage
	{
        private ObservableCollection<ProductModel> productList = new ObservableCollection<ProductModel>();
        private List<ProductModel> pt = new List<ProductModel>();
        private SQLiteAsyncConnection _cnn;
        public ManagerProduct ()
		{
			InitializeComponent ();
            _btnEdit.Clicked += _btnEdit_Clicked;
            _btnRemove.Clicked += _btnRemove_Clicked;
		}
        protected async override void OnAppearing()
        {        
            await _cnn.CreateTableAsync<ProductModel>();

            productList = await _cnn.Table<ProductModel>().ToListAsync();          
            xProductView.ItemsSource = productList;
            //    base.OnAppearing();
        }

        private void _btnRemove_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private  void _btnEdit_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new EditProduct());
        }
    }
}