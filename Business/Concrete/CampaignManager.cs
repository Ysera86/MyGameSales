using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        ICampaignDAL _campaignDAL;
        public CampaignManager(ICampaignDAL campaignDAL)
        {
            _campaignDAL = campaignDAL;
        }
        public void AddCampaign(Campaign campaign)
        {
            _campaignDAL.Add(campaign);
        }

        public void DeleteCampaign(Campaign campaign)
        {
            _campaignDAL.Delete(campaign);
        }

        public List<Campaign> GetAllCampaigns()
        {
            return _campaignDAL.GetEntities();
        }

        public Campaign GetCampaign(int id)
        {
            return _campaignDAL.GetEntity(c => c.Id == id);
        }

        public void UpdateCampaign(Campaign campaign)
        {
            _campaignDAL.Update(campaign);
        }
    }
}
