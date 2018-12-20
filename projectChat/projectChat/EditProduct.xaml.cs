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
    public partial class EditProduct
    {
        public EditProduct()
        {
            InitializeComponent();
            _btnEdit.Clicked += _btnEdit_Clicked;
        }

        private void _btnEdit_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}