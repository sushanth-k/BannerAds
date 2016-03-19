using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerAds
{
    class AdGenerator
    {
        static List<Ads> adsList;    
        static Random rnd = new Random();
        static int[] csum = new int[] { 13, 26, 38, 49, 57, 63, 70, 77, 84, 92, 95, 100 }; //cumulative  sum. Could work on better way than taking from local array
        public Result getAdvertisement()
        {
            int maxWeight = 0, maxCSum = 0;
            #region Products Initialization
            adsList = new List<Ads>();
            adsList.Add(new Ads("c101", "SLR Camera", 13, 13));
            adsList.Add(new Ads("c102", "Hybrid Camera", 13, 26));
            adsList.Add(new Ads("c103", "Pocket Camera", 12, 38));
            adsList.Add(new Ads("l101", "Telephoto Lens", 11, 49));
            adsList.Add(new Ads("l102", "Macro Lens", 8, 57));
            adsList.Add(new Ads("l103", "2X Lens", 6, 63));
            adsList.Add(new Ads("l104", "100mm Lens", 7, 70));
            adsList.Add(new Ads("l105", "50mm Lens", 7, 77));
            adsList.Add(new Ads("l106", "25mm Lens", 7, 84));
            adsList.Add(new Ads("l107", "30-80mm Zoom Lens", 8, 92));
            adsList.Add(new Ads("m101", "Micro Fiber Cloth", 3, 95));
            adsList.Add(new Ads("m102", "Anti-Static Brush", 5, 100));
            #endregion        
            
            maxCSum = adsList.OrderByDescending(c => c.Csum).First().Csum;
            maxWeight = adsList.OrderByDescending(c => c.Weight).First().Weight;

            Result adToBeDisplayed = GetAdToBeDisplayed(maxWeight, maxCSum); //Select product based on the  intervals that cover 0 to sum(weights)           
           
            return adToBeDisplayed;       

        }

        private static Result GetAdToBeDisplayed(int maxWeight, int maxCSum)
        {         
            Ads probableList;
            int r = rnd.Next(0, maxCSum);
            probableList = adsList.Where(c => c.Weight == maxWeight).FirstOrDefault(); //To initialize highest preferred product as default          
            for (int i = 0; i < adsList.Count(); i++)
            {               
                if (csum[i] > r)
                {
                    probableList = adsList.Where(c => c.Csum == csum[i]).FirstOrDefault();
                    break;                    
                }
            }          
            var result = new Result() { Product = probableList.Tag, Weight = probableList.Weight, Frequency = 1 };
            return result;
        }
    }
}
