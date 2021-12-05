using InternetShopProject.Model.ShopEntities;
using InternetShopProject.Model.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Model
{
    public class ShopData
    {
        private List<Product> _products;
        private List<Category> _categories;
        private Warehouse _warehouse;
        private User _user;

        private Saver _saver;

        public event Action AddedProduct;
        public event Action AddedCategory;

        public event Action RemovedProduct;
        public event Action RemovedCategory;

        public event Action UpdatedProduct;
        public event Action UpdatedCategory;

        public ShopData()
        {
            Loader loader = new Loader();

            _products = loader.LoadProduct();
            _categories = loader.LoadCategories();
            _warehouse = new Warehouse(_products);
            _user = new User();
        }

        #region Product CRUD
        public bool AddProduct(int cost, string title, int size, string specifications, string manufacturet, int categoryId)
        {
            Category category = GetCategoryById(categoryId);

            if (category == null)
                return false;

            _products.Add(new Product(cost, title, size, specifications, manufacturet, category));
            AddedProduct?.Invoke();

            return true;
        }

        public bool RemoveProduct(int id)
        {
            int index = FindProductIndexById(id);

            if (index != -1)
            {
                _products.RemoveAt(index);
                RemovedProduct?.Invoke();
                return true;
            }

            return false;
        }

        public bool UpdateProduct(int id, Func<int, IReadOnlyCategory> getCategory, int sum = -1, int categoryId = -1)
        {
            int index = FindProductIndexById(id);

            if (index != -1)
            {
                Category category = categoryId == -1 ? null : (Category)getCategory(categoryId);
                _products[index].Update(sum, category);
                UpdatedProduct?.Invoke();
                return true;
            }

            return false;

        }

        public IReadOnlyList<IReadOnlyProduct> GetProducts() => _products;

        public IReadOnlyProduct GetReadOnlyProductById(int id) => GetProductById(id);

        public IReadOnlyList<IReadOnlyProduct> GetFilteredProducts(int minSum, int maxSum, int categoryId)
        {
            List<Product> filteredProducts = _products.Where(x => x.Category.ID == categoryId || categoryId == -1
                                                               && x.Cost >= minSum && x.Cost <= maxSum).ToList();

            //List<Product> filteredProducts = new List<Product>();

            //foreach (var item in _products)
            //    if (categoryId == -1 || item.Category.ID == categoryId)
            //        if (item.Cost >= minSum && item.Cost <= maxSum)
            //            filteredProducts.Add(item);

            return filteredProducts;
        }
        #endregion

        #region Categories CRUD
        public bool AddCategory(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return false;

            foreach (var item in _categories)
                if (item.Title == title)
                    return false;

            _categories.Add(new Category(title));
            AddedCategory?.Invoke();

            return true;
        }

        public bool RemoveCategory(int id)
        {
            int index = FindCategoryById(id);

            if (index != -1)
            {
                _categories.RemoveAt(index);
                RemovedCategory?.Invoke();
                return true;
            }

            return false;
        }

        public bool UpdateCategory(int id, string newTitle)
        {
            int index = FindCategoryById(id);

            if (index != -1 && !string.IsNullOrWhiteSpace(newTitle))
            {
                _categories[index].Update(newTitle);
                UpdatedCategory?.Invoke();
                return true;
            }

            return false;
        }

        public IReadOnlyList<IReadOnlyCategory> GetCategories() => _categories;

        public IReadOnlyCategory GetReadOnlyCategoryById(int categoryId) => GetCategoryById(categoryId);
        #endregion

        #region Private ShopEntities Methods
        private int FindProductIndexById(int Id)
        {
            for (int i = 0; i < _products.Count; i++)
                if (_products[i].ID == Id)
                    return i;

            return -1;
        }

        private IReadOnlyProduct GetProductById(int id)
        {
            int index = FindProductIndexById(id);

            if (index != -1)
                return _products[index];
            else
                return null;
        }
        #endregion

        #region Private Category Methods
        private Category GetCategoryById(int categoryId)
        {
            foreach (var category in _categories)
                if (category.ID == categoryId)
                    return category;

            return null;
        }

        private int FindCategoryById(int id)
        {
            List<Category> categoriesList = _categories.ToList();

            for (int i = 0; i < categoriesList.Count; i++)
                if (id == categoriesList[i].ID)
                    return i;

            return -1;
        }
        #endregion
    }
}
