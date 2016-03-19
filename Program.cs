using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerAds
{
    class Program
    {
        static List<Result> resultsList, adToBeDisplayed;
        static void Main(string[] args)
        {
            GetAd prog = new GetAd();
            resultsList = new List<Result>();
            Result adToBeDisplayed = new Result();       
            for (int i = 0; i < 10; i++)
            {
                adToBeDisplayed = prog.getAdvertisement();
                if (resultsList.Exists(x => x.Product == adToBeDisplayed.Product))
                {
                    var ad = resultsList.FirstOrDefault(c => c.Product == adToBeDisplayed.Product);
                    ad.Frequency += 1; //If the result set already has the product displayed on banner then increment frequency
                }
                else
                {
                    resultsList.Add(new Result() { Product = adToBeDisplayed.Product, Weight = adToBeDisplayed.Weight, Frequency = adToBeDisplayed.Frequency });
                }
            }     
            
            Console.WriteLine("Product" + " " + "Frequency");
            foreach (var item in resultsList)
            {
                Console.WriteLine(item.Product + " " + item.Frequency);
            }
            Console.ReadLine();
        }      
        }
        /*#region code
        static List<Ads> adsList;
        static List<Result> resultsList;
        //public List<Result> GetBannerAd() 
        static void Main(string[] args)
        {
            int minWeight, maxWeight = 0;
            #region Products Initialization
            adsList = new List<Ads>();
            adsList.Add(new Ads("c101", "SLR Camera", 13));
            adsList.Add(new Ads("c102", "Hybrid Camera", 13));
            adsList.Add(new Ads("c103", "Pocket Camera", 12));
            adsList.Add(new Ads("l101", "Telephoto Lens", 11));
            adsList.Add(new Ads("l102", "Macro Lens", 8));
            adsList.Add(new Ads("l103", "2X Lens", 6));
            adsList.Add(new Ads("l104", "100mm Lens", 7));
            adsList.Add(new Ads("l105", "50mm Lens", 7));
            adsList.Add(new Ads("l106", "25mm Lens", 7));
            adsList.Add(new Ads("l107", "30-80mm Zoom Lens", 8));
            adsList.Add(new Ads("m101", "Micro Fiber Cloth", 3));
            adsList.Add(new Ads("m102", "Anti-Static Brush", 5));
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

            resultsList = new List<Result>();
            if (resultsList.Contains(adToBeDisplayed))
            {
                var ad = resultsList.FirstOrDefault(c => c.Product == adToBeDisplayed.Product);
                ad.Frequency += 1; //If the result set already has the product displayed on banner then increment frequency
            }
            else
            {
                resultsList.Add(new Result() { Product = adToBeDisplayed.Product, Weight = adToBeDisplayed.Weight, Frequency = adToBeDisplayed.Frequency });
            }

            return resultsList;
            //PrintAdsDisplayed();

            //Console.ReadLine();

        }

        private static Result GetAdToBeDisplayed(int minWeight, int maxWeight)
        {
            Random rnd = new Random();
            Ads probableList;
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

        private static void PrintAdsDisplayed()
        {
            Console.WriteLine("Product" + " " + "Frequency");
            foreach (var item in resultsList)
            {
                Console.WriteLine(item.Product + " " + item.Frequency);
            }
        }
        #endregion*/

    }




    