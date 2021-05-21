using System;
using System.Collections.Generic;

namespace Fasade
{
    class DataManager
    {
        List<string> Data;

        public List<string> GetData()
        {
            Console.WriteLine("500 | Internal Server Error");
            Data = null;
            return Data;
        }
        public void PutSave(string someData)
        {
            Console.WriteLine("500 | Internal Server Error");

        }
    }

    class ReviewManager
    {
        public void LeaveComment(string msg)
        {
            Console.WriteLine(msg);
        }

        public string GetComment(int resID)
        {
            //DB aint working, so we can`t get comment by resID
            return null;
        }


        public void LeaveMark(int mark)
        {
            Console.WriteLine($"You blessed this resource with a mark of : {mark}");
        }

        public int? GetMark(int resID)
        {
            //DB aint working, so we can`t get comment by resID
            return null;
        }
    }

    class RatingFacade
    {
        DataManager dataManager;
        ReviewManager reviewManager;
        List<string> output;

        public RatingFacade(DataManager dm, ReviewManager rm)
        {
            this.dataManager = dm;
            this.reviewManager = rm;
        }
        public void Start()
        {
            var reviews = dataManager.GetData();
            if (reviews != null)
            {
                //getting id of reviews
                var comm = reviewManager.GetComment(1);
                var mark = reviewManager.GetMark(1);
                Console.WriteLine($"Info on review #{1}: mark {mark} - comment {comm}");
            }
            else
            {
                Console.WriteLine("No reviews found");
            }
        }
    }
}