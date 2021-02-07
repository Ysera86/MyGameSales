using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class IMOrderDAL : IOrderDAL
    {
        List<Order> _Orders;
        public IMOrderDAL()
        {
            _Orders = new List<Order>();
        }
        public void Add(Order entity)
        {
            ICampaignDAL campaignDAL = new IMCampaignDAL();
            IGameDAL gameDAL = new IMGameDAL_();

            var campaign = campaignDAL.GetEntity(c => c.Id == entity.CampaignId);
            var game = gameDAL.GetEntity(g => g.Id == entity.GameId);

            entity.Price = game.Price - campaign.Discount;

            _Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            _Orders.Remove(_Orders.SingleOrDefault(x => x.OrderId == entity.OrderId));
        }

        public List<Order> GetEntities(Expression<Func<Order, bool>> filter = null)
        {
            return filter == null ? _Orders : _Orders.Where(filter.Compile()).ToList();                
        }

        public Order GetEntity(Expression<Func<Order, bool>> filter)
        {
            return _Orders.SingleOrDefault(filter.Compile());
        }

        public void Update(Order entity)
        {
            var OrderToUpdate = _Orders.SingleOrDefault(x => x.OrderId == entity.OrderId);
            OrderToUpdate.OrderDate = entity.OrderDate;
            OrderToUpdate.CustomerId = entity.CustomerId;
            OrderToUpdate.CampaignId = entity.CampaignId;
            OrderToUpdate.GameId = entity.GameId;

            ICampaignDAL campaignDAL = new IMCampaignDAL();
            IGameDAL gameDAL = new IMGameDAL_();

            var campaign = campaignDAL.GetEntity(c => c.Id == entity.CampaignId);
            var game = gameDAL.GetEntity(g => g.Id == entity.GameId);

            OrderToUpdate.Price = game.Price - campaign.Discount;
        }
    }
}
