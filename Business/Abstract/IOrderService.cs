using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrder(int id);
        void AddOrder(Order Order);
        void UpdateOrder(Order Order);
        void DeleteOrder(Order Order);
    }
}