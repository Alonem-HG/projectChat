using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace projectChat.Models
{
    public class ManagerProducts : IManagerProduct
    {
        private SQLiteAsyncConnection _cnn;
        private List<ProductModel> listProduct;

        public Task<List<ProductModel>> SearchByName(string name)
        {
            _cnn = DependencyService.Get<ISQLiteDB>().GetConnection();

             _cnn.CreateTableAsync<ProductModel>();

            //return _cnn.Table<ProductModel>().
            //    Where(i => i.NameProduct == name).ToListAsync();
            // return listProduct;

            return  _cnn.QueryAsync<ProductModel>
                ("Select from [ProductModel] where [NameProduct] like " + name+"%");

            //return (from c in listCursos
            //        where c.nombre.ToUpper().Contains(txt.ToUpper())
            //        select c).ToList();

            //where APELLIDOS like 'R%'
        }

    }
}
