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
        
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        public string ImageProduct { get; set; }
        public string BrandProduct { get; set; }
        public string CategoryProduct { get; set; }
        public string SubCategoryProduct { get; set; }
        public string OptionPayProduct { get; set; }

        public float CostProduct { get; set; }
        
        public bool MSIProduct { get; set; }
        public bool localeProduct { get; set; }

       

    }
}