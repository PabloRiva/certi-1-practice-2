using System;
using System.Runtime.Serialization;

namespace Services
{

    public class PartnerServiceNotFoundException : Exception
    {
        public PartnerServiceNotFoundException()
        {
        }

        public PartnerServiceNotFoundException(string message) : base(message)
        {
        }

       
    }
}