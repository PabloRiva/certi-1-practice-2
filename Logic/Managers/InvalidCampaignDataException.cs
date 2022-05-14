using System;
using System.Runtime.Serialization;

namespace Logic.Managers
{
    [Serializable]
    public class InvalidCampaignDataException : Exception
    {
        public InvalidCampaignDataException()
        {
        }

        public InvalidCampaignDataException(string message) : base(message)
        {
        }

        public InvalidCampaignDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCampaignDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}