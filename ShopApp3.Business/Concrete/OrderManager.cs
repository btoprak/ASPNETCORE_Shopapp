﻿using ShopApp3.Business.Abstract;
using ShopApp3.DataAccess.Abstract;
using ShopApp3.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp3.Business.Concrete
{
    public class OrderManager:IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public void Create(Order entity)
        {
            _orderDal.Create(entity);
        }

        public List<Order> GetOrders(string userId)
        {
            return _orderDal.GetOrders(userId);
        }
    }
}
