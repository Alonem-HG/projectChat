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
    public partial class EditProduct
    {
        private SQLiteAsyncConnection _cnn;
        private ObservableCollection<ProductModel> _obproduct;
        private List<ProductModel> pl = new List<ProductModel>();
        private ProductModel objpm ;
        
        public EditProduct()
        {
            InitializeComponent();
            _cnn = DependencyService.Get<ISQLiteDB>().GetConnection();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _cnn.CreateTableAsync<ProductModel>();
            pl = await _cnn.Table<ProductModel>().
                Where(i => i.IdProduct == ManagerProduct.pm.IdProduct)
                .ToListAsync();
        
            _obproduct = new ObservableCollection<ProductModel>(pl);
            xProductView.ItemsSource = _obproduct;
        }

        private async void _btnEdit_Clicked(object sender, EventArgs e)
        {
            objpm = xProductView.SelectedItem as ProductModel;

           var success=  await _cnn.UpdateAsync(objpm);

            if (success >0)
            {
                await DisplayAlert("Update","Succes","Accept");
                await PopupNavigation.Instance.PopAsync(true);


            }
            //_cnn.Table<ProductModel>().Equals(ManagerProduct.pm.IdProduct);
            // await _cnn.QueryAsync<ProductModel>("SELECT * FROM [ProductModel] WHERE [IdProduct] = "+ManagerProduct.pm.IdProduct);
        }

        private async void _btnBack_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}