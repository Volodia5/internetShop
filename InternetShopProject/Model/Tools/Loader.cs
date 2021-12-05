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
    public class Loader
    {
        public List<Product> LoadProduct()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileInfo fileInfo = new FileInfo("products.itp");

            if (fileInfo.Exists)
            {
                using (FileStream stream = new FileStream("products.itp", FileMode.Open))
                {
                    return (List<Product>)formatter.Deserialize(stream);
                }
            }
            else
            {
                return new List<Product>();
            }
        }

        public List<Category> LoadCategories()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileInfo fileInfo = new FileInfo("category.itp");

            if (fileInfo.Exists)
            {
                using (FileStream stream = new FileStream("category.itp", FileMode.Open))
                {
                    return (List<Category>)formatter.Deserialize(stream);
                }
            }
            else
            {
                return new List<Category>();
            }
        }
    }
}
