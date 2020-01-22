using ShopApp3.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp3.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        Category GetByIdWithProduct(int id);

        List<Category> GetAll();

        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int categoryId,int productId);
    }
}
