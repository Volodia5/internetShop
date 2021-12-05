using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    class User
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int CountProductInBasket { get; private set; }
        public List<Receipt> UserReceipts { get; private set; }

    }
}
