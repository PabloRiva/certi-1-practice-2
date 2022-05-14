using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using Microsoft.Extensions.Configuration;
using Services;


namespace Logic.Managers
{
    public class CampaignManager
    {
        private List<Campaign> _campaigns;
        private IConfiguration _configuration;
        private PartnerService _partnerService;
        Partner response;
        public CampaignManager(IConfiguration configuration, PartnerService partnerService)
        {
            _configuration = configuration;
            _partnerService = partnerService;
            _campaigns = new List<Campaign>();
            _campaigns.Add(new Campaign() { Name = "Descuento", Type = "Navidad", Code = "XMAX", Description = "Descuento del 10%", Enable = true, Partner = null });
            _campaigns.Add(new Campaign() { Name = "Descuento", Type = "Navidad", Code = "XMAX", Description = "Descuento del 10%", Enable = true, Partner = null });
            _campaigns.Add(new Campaign() { Name = "Descuento", Type = "Navidad", Code = "XMAX", Description = "Descuento del 10%", Enable = true, Partner = null });
            _campaigns.Add(new Campaign() { Name = "Descuento", Type = "Navidad", Code = "XMAX", Description = "Descuento del 10%", Enable = true, Partner = null });
        }
        public List<Campaign> GetCampaigns()
        {
            foreach (Campaign camp in _campaigns)
            {
                if (camp.Partner == null)
                {
                    response = _partnerService.GetPartner().Result;
                    camp.Partner = response;
                }
            }
            return _campaigns;
        }

        public Campaign CreateCampaign(string name, string type, string description, bool enable)
        {
            string code = getCode(type);
            
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(type) || String.IsNullOrEmpty(description))
            {
                throw new InvalidCampaignDataException("Los datos son invalidos");
            }
            Partner retrievePartner = _partnerService.GetPartner().Result;
            Campaign createdCampaign = new Campaign() { Name = name, Code = code, Description = description, Enable = enable, Type = type, Partner = retrievePartner };
            _campaigns.Add(createdCampaign);
            return createdCampaign;
        }

        public void UpdateProduct(string name, string type, string description, bool enable)
        {
            
           
        }

        public List<Campaign> DeleteCampaign(string code)
        {
            List<Campaign> deletedCampaigns = new List<Campaign>();
            foreach(Campaign c in _campaigns)
            {
                if (c.Code == code)
                {

                    deletedCampaigns.Add(c);
                    _campaigns.Remove(c);
                }                                     
            }
            
            
            return deletedCampaigns;
        }

        public string getCode(string type)
        {
            string code = "";
            if (type == "Navidad")
                code = "XMAX";
            else if (type == "Verano")
                code = "SUMMER";
            else if (type == "Black Fryday")
                code = "BFRIDAY";
            return code;
        }

        public void setCampaings(List<Campaign>retrieved)
        {
            this._campaigns = retrieved;
        }
    }
}
