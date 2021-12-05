using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    public class ProductCount : IReadOnlyProductCount
    {
        public Product Product { get; private set; }
        public int Count { get; private set; }

        public ProductCount(Product product)
        {
            Product = product;
            Count = 0;
        }

        public void IncreaseProductCount(int number)
        {
            if (number > 0)
                Count += number;
        }

        public void DecreaseProductCount(int number)
        {
            if (Count > number)
                Count -= number;
        }
    }

    interface IReadOnlyProductCount
    {
        Product Product { get; }
        int Count { get; }
    }
}
