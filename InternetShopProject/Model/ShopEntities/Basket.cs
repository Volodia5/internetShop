using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    class Basket
    {
        public List<Product> Product { get; private set; }
        public int ProductsCount { get; private set; }    

        public Basket(List<Product> products, int productsCount)
        {
            Product = products;
            ProductsCount = productsCount;
        }

    }
}
