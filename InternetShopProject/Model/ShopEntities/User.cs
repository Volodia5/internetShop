using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    class User
    {
        public List<Receipt> Receipt { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public int Balance { get; private set; }

        public User()
        {
            Name = "";
            Password = "";
            Balance = 0;
        }
    }
}
