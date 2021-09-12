using System;
using Models;
using DataAccessLayer;

namespace RestaurantSystem
{
    class RSystemm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.Write(" \n\n");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^@ RESTAURANT APPLICATION SYSTEM ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.Write(" \n\n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Dal dal = new Dal();

            

            

            dal.DisplayAllRestarant();
            Restaurant AddRestra = dal.GetRestaurant();

            dal.AddRestaurnat(AddRestra);
            dal.DisplayAllRestarant();

            dal.DeleteRestaurant();
            dal.DisplayAllRestarant();

            Restaurant updateRestra = dal.GetRestaurant();
            dal.UpdateRestaurant(updateRestra);
            dal.DisplayAllRestarant();

            dal.SearchRestaurant();
            Restaurant Searchrestra = dal.GetInputRestaurant();
            dal.ActivateDeactivateRestaurant(Searchrestra);
            dal.DisplayAllRestarant();
            dal.DisplayActiveRestarant();
            Console.WriteLine("...............................THANK YOU FOR VISITING OUR RESTAURANT SYSTEM APPLICSTION ...........................");
        }
    }
}
