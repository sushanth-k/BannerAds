using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerAds
{
    class GetAd
    {
        static List<Ads> adsList;    
        static Random rnd = new Random();       
        public Result  getAdvertisement() 
        {
            int minWeight, maxWeight = 0;
            #region Products Initialization
            adsList = new List<Ads>();
            adsList.Add(new Ads("c101", "SLR Camera", 13,13));
            adsList.Add(new Ads("c102", "Hybrid Camera", 13,26));
            adsList.Add(new Ads("c103", "Pocket Camera", 12,38));
            adsList.Add(new Ads("l101", "Telephoto Lens", 11,49));
            adsList.Add(new Ads("l102", "Macro Lens", 8,57));
            adsList.Add(new Ads("l103", "2X Lens", 6,63));
            adsList.Add(new Ads("l104", "100mm Lens", 7,70));
            adsList.Add(new Ads("l105", "50mm Lens", 7,77));
            adsList.Add(new Ads("l106", "25mm Lens", 7,84));
            adsList.Add(new Ads("l107", "30-80mm Zoom Lens", 8,92));
            adsList.Add(new Ads("m101", "Micro Fiber Cloth", 3,95));
            adsList.Add(new Ads("m102", "Anti-Static Brush", 5,100));
            #endregion

            TimeSpan start = new TimeSpan(9, 0, 0); //9 o'clock
            TimeSpan end = new TimeSpan(12, 0, 0); //12 o'clock
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now > start) && (now < end)) //High peak time for business operations. Show more ocucrances of higher weight products
            {
                int min = adsList.OrderBy(c => c.Weight).First().Weight;
                maxWeight = adsList.OrderByDescending(c => c.Weight).First().Weight;
                if (adsList.Count % 2 == 0)
                {
                    minWeight = (min + maxWeight) / 2;
                }
                else
                {
                    minWeight = ((min + maxWeight) / 2) - 1;
                }
            }
            else
            {
                minWeight = adsList.OrderBy(c => c.Weight).First().Weight;
                maxWeight = adsList.OrderByDescending(c => c.Weight).First().Weight;               
            }

            Result adToBeDisplayed = GetAdToBeDisplayed(minWeight, maxWeight); //Select product based on the variable weights            
            return adToBeDisplayed;
        }

        private static Result GetAdToBeDisplayed(int minWeight, int maxWeight)
        {
      
            Ads probableList;       
           // probableList = adsList.Where(c => c.Weight == maxWeight).FirstOrDefault();                      
            try
            {
                 probableList = adsList.Where(c => c.Weight == rnd.Next(minWeight, maxWeight)).FirstOrDefault();
                 if (probableList == null)
                 {
                     throw new ArgumentNullException();
                 }
            }
            catch (Exception)
            {
                probableList = adsList.Where(c => c.Weight == maxWeight).FirstOrDefault();
   
            }
            var result = new Result(){Product = probableList.Tag, Weight= probableList.Weight, Frequency=1};
            return result;
        }
             
    }   
}

