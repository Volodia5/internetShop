using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    class Warehouse
    {
        public List<Product> Products { get; private set; }
        public List<ProductCount> ProductsCount { get; private set; }

        public Warehouse(List<Product> products)
        {
            Products = products;

            for (int i = 0; i < Products.Count; i++)
            {
                ProductsCount.Add(new ProductCount(Products[i]));
            }
        }

        public bool AreAviable(int id)
        {
            int index = FindProductIndexById(id);

            if (index != -1)
            {
                if (ProductsCount[index].Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private int FindProductIndexById(int Id)
        {
            for (int i = 0; i < Products.Count; i++)
                if (Products[i].ID == Id)
                    return i;

            return -1;
        }
    }
}
