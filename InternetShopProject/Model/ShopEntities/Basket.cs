using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    class Basket
    {
        public List<Product> BacketProducts { get; private set; }
        public int BasketProductsCount { get; private set; }

    }
}
