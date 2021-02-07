using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class IMCampaignDAL : ICampaignDAL
    {
        List<Campaign> _campaigns;
        public IMCampaignDAL()
        {
            _campaigns = new List<Campaign>
            {
                new Campaign{ Id=1, CampaignName="CampaignName1", Description="Description1", Discount= 1},
                new Campaign{ Id=2, CampaignName="CampaignName2", Description="Description2", Discount= 1.5M},
                new Campaign{ Id=3, CampaignName="CampaignName3", Description="Description3", Discount= 3},
                new Campaign{ Id=4, CampaignName="CampaignName4", Description="Description4", Discount= 2.1M}
            };
        }
        public void Add(Campaign entity)
        {
            _campaigns.Add(entity);
        }

        public void Delete(Campaign entity)
        {
            _campaigns.Remove(_campaigns.SingleOrDefault(x => x.Id == entity.Id));
        }

        public List<Campaign> GetEntities(Expression<Func<Campaign, bool>> filter = null)
        {
            return filter == null ? _campaigns : _campaigns.Where(filter.Compile()).ToList();
        }

        public Campaign GetEntity(Expression<Func<Campaign, bool>> filter)
        {
            return _campaigns.SingleOrDefault(filter.Compile());
        }

        public void Update(Campaign entity)
        {
            var entityToUpdate = _campaigns.SingleOrDefault(x => x.Id == entity.Id);

            entityToUpdate.CampaignName = entity.CampaignName;
            entityToUpdate.Description = entity.Description;
        }
    }
}
