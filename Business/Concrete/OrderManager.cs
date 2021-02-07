using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDAL _orderDAL;

        public OrderManager(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

     
        public void AddOrder(Order Order)
        {
            _orderDAL.Add(Order);
        }

        public void DeleteOrder(Order Order)
        {
            _orderDAL.Delete(Order);
        }

        public List<Order> GetAllOrders()
        {
            return _orderDAL.GetEntities();
        }

        public Order GetOrder(int id)
        {
            return _orderDAL.GetEntity(g => g.OrderId == id);
        }

        public void UpdateOrder(Order Order)
        {
            _orderDAL.Update(Order);
        }
    }
}
