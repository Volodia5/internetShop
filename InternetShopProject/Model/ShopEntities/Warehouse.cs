using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    class Warehouse
    {
        public List<Product> ProductsInWarehouse { get; private set; }
        public int ProductsCount { get; private set; }
        public bool AreAvailable { get; private set; }

    }
}
