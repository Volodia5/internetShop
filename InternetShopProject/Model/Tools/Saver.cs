using InternetShopProject.Model.ShopEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.Tools
{
    public class Saver
    {
        public void Save(ShopData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream("products.itp", FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, data.GetProducts());
            }

            using (FileStream stream = new FileStream("category.itp", FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, data.GetCategories());
            }

            using (FileStream stream = new FileStream("settings.itp", FileMode.OpenOrCreate))
            {
                Dictionary<string, int> settings = new Dictionary<string, int>();
                settings.Add("productId", Product.GetCurrentId());
                settings.Add("categoryId", Category.GetCurrentId());
                formatter.Serialize(stream, settings);
            }
        }
    }
}
