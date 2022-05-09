using System;
using System.Collections.Generic;
using System.Text;
using Logic;


namespace Logic.Managers
{
    public class CampaignManager
    {
        private List<Campaign> _campaigns;
        public CampaignManager()
        {
            _campaigns = new List<Campaign>();
            _campaigns.Add(new Campaign() { Name = "Descuento",Type = "Navidad", Code = "XMAX", Description = "Descuento del 10%", Enable = true, partner = null});
            _campaigns.Add(new Campaign() { Name = "Descuento", Type = "Navidad", Code = "XMAX", Description = "Descuento del 10%", Enable = true, partner = null });
            _campaigns.Add(new Campaign() { Name = "Descuento", Type = "Navidad", Code = "XMAX", Description = "Descuento del 10%", Enable = true, partner = null });
            _campaigns.Add(new Campaign() { Name = "Descuento", Type = "Navidad", Code = "XMAX", Description = "Descuento del 10%", Enable = true, partner = null });
        }
        public List<Campaign> GetCampaigns()
        {
           
            return _campaigns;
        }

        public Campaign CreateCampaign(string name, string type, string description, bool enable)
        {
            string code = getCode(type);

            Campaign createdCampaign = new Campaign() { Name = name, Code = code, partner = null, Description = description, Enable = enable, Type = type};
            _campaigns.Add(createdCampaign);
            return createdCampaign;
        }

        //public Campaign UpdateProduct(string name, string type, string description, bool enable)
        //{
            
           
        //}

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
