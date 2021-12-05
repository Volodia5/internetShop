using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model.ShopEntities
{
    [Serializable]
    public class Category : IReadOnlyCategory
    {
        private static int _id;

        public int ID { get; private set; }
        public string Title { get; private set; }

        static Category()
        {
            _id = 0;
        }

        public Category(string title)
        {
            ID = ++_id;
            Title = title;
        }

        public void Update(string title = "")
        {
            if (title != "")
                Title = title;
        }

        public override string ToString()
        {
            return Title;
        }

        public static int GetCurrentId()
        {
            return _id;
        }

        public static void SetCurrentId(int id)
        {
            _id = id;
        }
    }

    public interface IReadOnlyCategory
    {
        int ID { get; }
        string Title { get; }
    }
}
