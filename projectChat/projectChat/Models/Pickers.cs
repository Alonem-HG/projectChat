using System;
using System.Collections.Generic;
using System.Text;

namespace projectChat.Models
{
    public class Pickers
    {
       private List<string> categories = new List<string>();
       private List<string> subcategories = new List<string>();
       private List<string> typePay = new List<string>();
       private List<string> brands = new List<string>();

        public List<string> ListCategories()
        {
            categories.Add("Hardware");
            categories.Add("Software");
            categories.Add("Accesory");
            categories.Add("Storage");

            return categories;
        }

        public List<string> ListSubcategories()
        {
            subcategories.Add("Hardware");
            subcategories.Add("Software");
            subcategories.Add("Accesory");
            subcategories.Add("Storage");

            return subcategories;
        }

        public List<string> ListTypePays()
        {
            typePay.Add("Master Card");
            typePay.Add("Visa");
            typePay.Add("Oxxo");

            return typePay;
        }

        public List<string> ListBrands()
        {
            brands.Add("Adata");
            brands.Add("Vorago");
            brands.Add("Asus");
            brands.Add("Dell");
            brands.Add("Cooler Master");
            brands.Add("AMD");
            brands.Add("INTEL");

            return brands;
        }
    }
}
