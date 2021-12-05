using InternetShopProject.Model.ShopEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternetShopProject.View
{
    public partial class FormMain : Form
    {
        public event Func<IReadOnlyList<IReadOnlyProduct>> GettingAllProducts;
        public event Func<int, int, int, IReadOnlyList<IReadOnlyProduct>> GettingFilteredProducts;
        public event Func<int, IReadOnlyProduct> GettingProduct;
        public event Action<int, string, int, string, string, int> AddingProduct;
        public event Action<int> RemovingProduct;

        public event Func<IReadOnlyList<IReadOnlyCategory>> GettingAllCategories;
        public event Func<int, IReadOnlyCategory> GettingCategory;

        public FormMain()
        {
            InitializeComponent();
        }

        public void RefreshProductData()
        {

        }

        public void RefreshCategoryData()
        {

        }
    }
}
