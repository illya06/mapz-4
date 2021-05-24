using System.Collections.Generic;
using System;

using Fasade;
using Proxy_;
using Composite_;

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

            //student requesting info for PZ
            Client client = new Client();
            //PZ construction
            System.Console.WriteLine("\n\nInfo about PZ\n");
            Composite PZ = new Composite();

            Composite Title = new Composite();
            Title.Add(new Leaf("Title: Prog Zabezp"));
            Composite Rating = new Composite();
            Rating.Add(new Leaf("Rating: 10/12"));
            Composite Content = new Composite();
            Content.Add(new Leaf("Content: Nice stuff"));
            Composite Comments = new Composite();
            Comments.Add(new Leaf("Comments: How about Levus?"));
            PZ.Add(new List<Component> { Title, Rating, Content, Comments });
            //client.GetContent(PZ);
            client.AddNewComponent(Comments, new Leaf("\tComment: not well..."));
            client.GetContent(PZ);

        }
    }
}
