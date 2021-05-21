using System;
using Fasade;

namespace mapz_4
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            ReviewManager reviewManager = new ReviewManager();

            RatingFacade ratingPortal = new RatingFacade(dataManager, reviewManager);
            ratingPortal.Start();


        }
    }
}
