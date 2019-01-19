using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace projectChat.Models
{
    public class ProductModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdProduct { get; set; }

        public int QuantityProduct { get; set; }
        
        public String NameProduct { get; set; }
        public String DescriptionProduct { get; set; }
        //public string ImageProduct { get; set; }
       // public String BrandProduct { get; set; }
       // public String CategoryProduct { get; set; }
       // public String SubCategoryProduct { get; set; }
        //public string OptionPayProduct { get; set; }

        public float CostProduct { get; set; }
        
      //  public bool MSIProduct { get; set; }
       // public bool UbicationProduct { get; set; }

        //public byte[] itemData { get; set; }

    }
}