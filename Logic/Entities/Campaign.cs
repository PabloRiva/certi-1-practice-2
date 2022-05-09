using System;
using Services;

namespace Logic
{
    public class Campaign
    {
        public String Name { get; set; }
        public String Code { get; set; }

        public String Type { get; set; }

        public String Description { get; set; }

        public bool Enable { get; set; }

        public Partner Partner { get; set; }
    }
}
 