using System;
using System.Runtime.Serialization;

namespace Services
{

    public class PartnerServiceException : Exception
    {
        public PartnerServiceException()
        {

        }

        public PartnerServiceException(string message) : base(message)
        {
        }

      
    }
}