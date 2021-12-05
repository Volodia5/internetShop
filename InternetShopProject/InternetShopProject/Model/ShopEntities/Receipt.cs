using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    class Receipt
    {
        public int ID { get; private set; }
        public int Summ { get; private set; }
        public int Date { get; private set; }
        public string ProductTitle  { get; private set; }
        public int ProductCount { get; private set; }

    }
}
