using System.Collections.Generic;
using System;

using Fasade;
using Proxy_;

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

            List<string> resourses = new() { "EBEC", "Chess tournament", "WIPZ KR" };

            UserRequest request = new UserRequest();

            System.Console.WriteLine("\nSimulating work for unregistered User");
            foreach (var res in resourses)
            {
                RealResource realResource = new RealResource(res);
                Proxy proxy = new Proxy(realResource, 0); //unregistered user, wirh accessLevel = 0
                request.Get(proxy);
            }

            System.Console.WriteLine("\nSimulating work for registered User");
            foreach (var res in resourses)
            {
                RealResource realResource = new RealResource(res);
                Proxy proxy = new Proxy(realResource, 1); //unregistered user, wirh accessLevel = 0
                request.Get(proxy);
            }

        }
    }
}
