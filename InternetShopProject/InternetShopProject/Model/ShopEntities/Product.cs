using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    public class Product
    {
        private static int _id;

        public int ID { get; private set; }
        public int Cost { get; private set; }
        public string Title { get; private set; }
        public int Size { get; private set; }
        public string Specifications { get; private set; }
        public string Manufacturer { get; private set; }
        public Category Category { get; private set; }

        static Product()
        {
            _id = 0;
        }

        public Product(int cost,string title, int size, string specifications,string manufacturer, Category category)
        {
            ID = ++_id;
            Cost = cost;
            Size = size;
            Specifications = specifications;
            Manufacturer = manufacturer;
            Category = category;
        }

        public void Update(int cost = -1, Category category = null, string title = "", int size = -1, string specifications = "", string manufacturer = "")
        {
            if(cost != -1)
                Cost = cost;
            if(category != null)
                Category = category;
            if(title != "")
                Title = title;
            if(size != -1)
                Size = size;
            if (specifications != "")
                Specifications = specifications;
            if (manufacturer != "")
                Manufacturer = manufacturer;
        }
    }
}
