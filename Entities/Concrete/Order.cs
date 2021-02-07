using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int GameId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CampaignId { get; set; }
        public decimal Price { get; set; }
    }
}
