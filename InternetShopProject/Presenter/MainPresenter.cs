using InternetShopProject.Model;
using InternetShopProject.Model.ShopEntities;
using InternetShopProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopProject.Presenter
{
    public class MainPresenter
    {
        private ShopData _model;
        private FormMain _view;

        public MainPresenter(ShopData model, FormMain view)
        {
            _model = model;
            _view = view;

            _model.AddedProduct += OnAddedProduct;
            _model.RemovedProduct += OnRemovedProduct;
            _model.UpdatedProduct += OnUpdatedProduct;

            _model.AddedCategory += OnAddedCategory;
            _model.UpdatedCategory += OnUpdatedCategory;
            _model.RemovedCategory += OnRemovedCategory;

            _view.GettingAllProducts += OnGettingAllProducts;
            _view.GettingProduct += OnGettingProduct;
            _view.GettingFilteredProducts += OnGettingFilteredProducts;
            _view.AddingProduct += OnAddingProduct;
            _view.RemovingProduct += OnRemovingProduct;

            _view.GettingAllCategories += OnGettingAllCategories;
            _view.GettingCategory += OnGettingCategory;
        }

        #region Product
        private void OnAddedProduct() => _view.RefreshProductData();

        private void OnAddingProduct(int cost, string title, int size, string specifications, string manufacturet, int categoryId)
                 => _model.AddProduct(cost, title, size, specifications, manufacturet, categoryId);

        private void OnRemovedProduct() => _view.RefreshProductData();

        private void OnRemovingProduct(int id) => _model.RemoveProduct(id);

        private void OnUpdatedProduct() => _view.RefreshProductData();

        private IReadOnlyList<IReadOnlyProduct> OnGettingAllProducts() => _model.GetProducts();

        private IReadOnlyProduct OnGettingProduct(int id) => _model.GetReadOnlyProductById(id);

        private IReadOnlyList<IReadOnlyProduct> OnGettingFilteredProducts(int minSum, int maxSum, int categoryId)
                                            => _model.GetFilteredProducts(minSum, maxSum, categoryId);
        #endregion

        #region Category
        private void OnAddedCategory() => _view.RefreshCategoryData();

        private void OnRemovedCategory() => _view.RefreshCategoryData();

        private void OnUpdatedCategory() => _view.RefreshCategoryData();

        private IReadOnlyList<IReadOnlyCategory> OnGettingAllCategories() => _model.GetCategories();

        private IReadOnlyCategory OnGettingCategory(int id) => _model.GetReadOnlyCategoryById(id);
        #endregion
    }
}
