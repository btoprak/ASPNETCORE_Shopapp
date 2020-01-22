using ShopApp3.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp3.DataAccess.Abstract
{
    public interface IOrderDal:IRepository<Order>
    {
        List<Order> GetOrders(string userId);
    }
}
