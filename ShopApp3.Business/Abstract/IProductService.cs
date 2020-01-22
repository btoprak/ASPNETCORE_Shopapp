using ShopApp3.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp3.Business.Abstract
{
    public interface IProductService:IValidator<Product>
    {
        Product GetById(int id);

        Product GetProductDetails(int id);

        Product GetByIdWithCategories(int id);

        List<Product> GetAll();

        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        bool Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        int GetCountByCategory(string category);

        void Update(Product entity, int[] categoryIds);

    }
}
