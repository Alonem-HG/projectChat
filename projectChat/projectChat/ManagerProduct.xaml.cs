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
        public ObservableCollection<ProductModel> _obproduct { get; private set; } = 
            new ObservableCollection<ProductModel>();
        private List<ProductModel> pl;
        public static ProductModel pm;
        private SQLiteAsyncConnection _cnn;

        public ManagerProduct()
        {
            InitializeComponent();
            _cnn = DependencyService.Get<ISQLiteDB>().GetConnection();
            _add.Clicked += _add_Clicked;
           _seachBarNombre.TextChanged += _seachBarNombre_TextChanged;           
            xProductView.ItemSelected += XProductView_ItemSelected;
            xProductView.Refreshing += XProductView_Refreshing;    
        }

        private void XProductView_Refreshing(object sender, EventArgs e)
        {
            xProductView.EndRefresh();
        }

        private void XProductView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           pm = e.SelectedItem as ProductModel;
          //  pm = xProductView.ItemsSource as ProductModel;
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _cnn.CreateTableAsync<ProductModel>();
            pl = await _cnn.Table<ProductModel>().ToListAsync();
            if (pl.Count!= 0)
            {
                _obproduct = new ObservableCollection<ProductModel>(pl);
                xProductView.ItemsSource = _obproduct;
                xProductView.EndRefresh();
            }
            else
            {
                await  DisplayAlert("Empty","You need add products once","Accept");
               
                 await Navigation.PushAsync(new CreateProduct());
            }
          
        }

        private async void _seachBarNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txt = (_seachBarNombre.Text).ToUpper();

            await _cnn.CreateTableAsync<ProductModel>();

            var test = await _cnn.QueryAsync<ProductModel>
                ("SELECT * FROM [ProductModel] WHERE [NameProduct] LIKE '" + txt + "%'");

            if (!string.IsNullOrEmpty(txt))
            {
                // var result = await manager.SearchByName(txt);

                if (test != null)
                {
                    xProductView.ItemsSource = test;
                }
                else
                {
                    await DisplayAlert("Curso", "No se encontro", "Cancel");
                }

            }
        }

        private async void _btnRemove_Clicked(object sender, EventArgs e)
        {
            if (pm.IdProduct > 0)
            {
                bool desicion = await DisplayAlert("Remove Alert!", "Are you sure to eliminate this product?", "Accept", "Cancel");

                if (desicion == true)
                {
                    await _cnn.DeleteAsync(pm);

                    await _cnn.CreateTableAsync<ProductModel>();
                    pl = await _cnn.Table<ProductModel>().ToListAsync();
                    _obproduct = new ObservableCollection<ProductModel>(pl);
                    xProductView.ItemsSource = _obproduct;
                }
            }
        }

        private async void _add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateProduct());
        }

        private void _btnEdit_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new EditProduct());
        }
    }
}