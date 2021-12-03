using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    class User
    {
        private List<Receipt> _receipts;
        
        public string Name { get; private set; }
        public string Password { get; private set; }
        public int CountProductInBasket { get; private set; }

    }
}
