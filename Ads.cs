using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerAds
{
    class Ads
    {
        public String Tag { get; private set; }
        public String Desc { get; private set; }
        public int Weight { get; private set; }
        public int Frequency { get; set; }

        public Ads(String tag, String desc, int weight)
        {
            Tag = tag;
            Desc = desc;
            Weight = weight;
        }

    }
}
