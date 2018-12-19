using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailMainMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailMainMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailMainMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailMainMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailMainMenuItem> MenuItems { get; set; }
            
            public MasterDetailMainMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailMainMenuItem>(new[]
                {
                    new MasterDetailMainMenuItem { Id = 0, Title = "Products", TargetType = typeof(ManagerProduct) },
                    new MasterDetailMainMenuItem { Id = 1, Title = "Users" },
                    new MasterDetailMainMenuItem { Id = 2, Title = "Places" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}