using projectChat.Commons;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace projectChat.Models
{
    public class ProductModel : BaseNotifyPropetyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int IdProduct { get; set; }

        private int _quanti;
        public int QuantityProduct
        {
            get
            {
                return _quanti;
            }
            set
            {

                 SetValue(ref _quanti, value);
                //_quantity = value;
                base.OnPropetyChanged(nameof(QuantityProduct));

            }
        }

        private String _name;
        public String NameProduct
        {
            get
            {
                return _name;
            }
            set
            {
               // SetValue(ref _name, value);
                _name = value;
                base.OnPropetyChanged(nameof(NameProduct));
            }
        }

        public String _description { get; set; }
        public String DescriptionProduct
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                base.OnPropetyChanged(nameof(DescriptionProduct));
            }
        }
       
        public String _brand { get; set; }
        public String BrandProduct
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
                base.OnPropetyChanged(nameof(BrandProduct));
            }
        }

        private float _cost;
        public float CostProduct
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
                base.OnPropetyChanged(nameof(CostProduct));
            }
        }

        //  public bool MSIProduct { get; set; }
        // public bool UbicationProduct { get; set; }
        //public byte[] itemData { get; set; }
        //public string ImageProduct { get; set; }
        // public String CategoryProduct { get; set; }
        // public String SubCategoryProduct { get; set; }
        //public string OptionPayProduct { get; set; }
    }
}