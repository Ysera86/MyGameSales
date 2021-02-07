using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCampaingDAL : ICampaignDAL
    {
        public void Add(Campaign entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Set<Campaign>().Add(entity); // todo : dene
                context.SaveChanges();
            }
        }

        public void Delete(Campaign entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Campaign> GetEntities(Expression<Func<Campaign, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Campaign>().Where(filter).ToList();
            }
        }

        public Campaign GetEntity(Expression<Func<Campaign, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Campaign>().SingleOrDefault(filter);
            }
        }

        public void Update(Campaign entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
