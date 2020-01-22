using ShopApp3.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopApp3.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        Category GetByIdWithProduct(int id);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
