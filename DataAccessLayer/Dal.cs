using System;
using System.Data;
using System.Data.SqlClient;
using Models;
namespace DataAccessLayer
{
   public class Dal
    {
        static string constr = "data source=LAPTOP-4FF8CQ3I\\SQLEXPRESS;initial catalog=RSystem;integrated security=True;";

        public void DisplayActiveRestarant()
        {
            DataTable DT = ExecuteData("select * from Restaurant where RestStatus='Active'");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("..............................................................................................................");
                Console.Write(" \n\n");
                Console.WriteLine("**************************ACTIVE RESTAURANTS******************************************************************");
                Console.Write(" \n\n");
                Console.WriteLine("..............................................................................................................");
                Console.Write(" \n\n");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["RestName"].ToString() + "  " + row["RestAddress"].ToString() + " " + row["RestPhoneNo"].ToString() + " " + row["RestCuisine"].ToString());
                }
                Console.WriteLine("================================================================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("!!!There Is NO Active Restarant!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public void DisplayAllRestarant()
        {
            DataTable DT = ExecuteData("select * from RestaurantA");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("...............................................................................................................");
                Console.Write(" \n\n");
                Console.WriteLine("********************************* LIST OF RESTAURANTS *********************************************************");
                Console.Write(" \n\n");
                Console.WriteLine("...............................................................................................................");
                Console.Write(" \n\n");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["RestId"].ToString() + " " + row["RestName"].ToString() + " " + row["RestAddress"].ToString() + " " + row["RestPhoneNo"].ToString() + " " + row["RestOpeningTime"].ToString() + " " + row["RestClosingTime"].ToString() + " " + row["RestCuisine"].ToString() + " " + row["RestStatus"].ToString());
                }
                Console.WriteLine("======================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("!!!No Records Found!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public DataTable ExecuteData(string Query)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(Query, sqlcon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    sqlcon.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public void SearchRestaurant()
        {
            string RestName = string.Empty;

            Console.Write("Search Restaurant: ");
            RestName = Console.ReadLine();

            DataTable DT = ExecuteData("select RestID, RestName, RestPhoneNo, RestAddress, RestOpeningTime, RestClosingTime, RestCuisine from RestaurantA where RestName='" + RestName + "'");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("..............................................................................................................");
                Console.Write(" \n\n");
                Console.WriteLine("----------------------- SEARCHED RESTUARUNTS IN MUMBAI -------------------------------------------------------");
                Console.Write(" \n\n");
                Console.WriteLine("...............................................................................................................");
                Console.Write(" \n\n");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["RestName"].ToString() + " " + row["RestPhoneNo"].ToString() + " " + row["RestAddress"].ToString() + " " + row["RestCuisine"].ToString());
                }
                Console.WriteLine("===============================================================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("!!!" + RestName + " not found!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public Restaurant GetRestaurant()
        {
            string RestId = string.Empty;
            string RestName = string.Empty;
            string RestPhoneNo = string.Empty;
            string RestAddress = string.Empty;
            string RestOpeningTime = string.Empty;
            string RestClosingTime = string.Empty;
            string RestCuisine = string.Empty;
            string RestStatus = string.Empty;

            Console.WriteLine("Insert Restaurant Details: ");

            Console.Write(" \n\n");

            Console.WriteLine("Enter Restaurant Id: ");
            RestId = Console.ReadLine();
            Console.Write(" \n\n");

            while (string.IsNullOrEmpty(RestName))
            {
                // Console.Write("Can't be Enter  Empty Restaurant Name: ");
                Console.Write("Enter Restaurant Name: ");
                RestName = Console.ReadLine();
                Console.Write(" \n\n");
            }
            
            Console.Write("Enter PhoneNo  of Restaurant: ");
            RestPhoneNo = Console.ReadLine();

            Console.Write(" \n\n");

            Console.Write("Enter Address of Restaurant: ");
            RestAddress = Console.ReadLine();

            Console.Write(" \n\n");


            Console.Write("Enter opening time of Restaurant as per 24 Hr Clock(HH:MM:SS): ");
            RestOpeningTime = Console.ReadLine();

            Console.Write(" \n\n");


            Console.Write("Enter closing time of Restaurant as per 24 Hr Clock(HH:MM:SS): ");
            RestClosingTime = Console.ReadLine();

            Console.Write(" \n\n");


            Console.Write("Enter Cuisine of Restaurant: ");
            RestCuisine = Console.ReadLine();

            Console.Write(" \n\n");

            Console.Write("Enter Activity of Restaurant Active/Deactive: ");
            RestStatus = Console.ReadLine();

            Console.Write(" \n\n");


            Restaurant restaurant = new Restaurant()
            {
                RestId = RestId,
                RestName = RestName,
                RestPhoneNo = RestPhoneNo,
                RestAddress = RestAddress,
                RestOpeningTime = RestOpeningTime,
                RestClosingTime = RestClosingTime,
                RestCuisine = RestCuisine,
                RestStatus = RestStatus,
            };
            return restaurant;
        }
        public void AddRestaurnat(Restaurant restaurant)
        {
            ExecuteCommand(String.Format("Insert into RestaurantA(RestId,RestName,RestAddress,RestPhoneNo,RestOpeningTime,RestClosingTime,RestCuisine,RestStatus) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", restaurant.RestId, restaurant.RestName, restaurant.RestAddress, restaurant.RestPhoneNo, restaurant.RestOpeningTime, restaurant.RestClosingTime, restaurant.RestCuisine, restaurant.RestStatus));
        }
        public void UpdateRestaurant(Restaurant restaurant)
        {
            ExecuteCommand(String.Format("Update RestaurantA set RestId='{0}', RestName='{1}', RestAddress='{2}', RestPhoneNo='{3}', RestOpeningTime='{4}', RestClosingTime='{5}', RestCuisine='{6}', RestStatus='{7}' where RestId={0}", restaurant.RestId, restaurant.RestName, restaurant.RestAddress, restaurant.RestPhoneNo, restaurant.RestOpeningTime, restaurant.RestClosingTime, restaurant.RestCuisine, restaurant.RestStatus));
        }
        public Restaurant GetInputRestaurant()
        {
            string RestId = string.Empty;
            string RestStatus = string.Empty;

            Console.WriteLine("Add New Restaurant: ");

            Console.Write(" \n\n");

            Console.Write(" Please Enter The Restaurant Id: ");
            RestId = Console.ReadLine();

            Console.Write(" \n\n");

            Console.WriteLine(" Please Enter The Activity of Restaurant Active/Deactive: ");
            RestStatus = Console.ReadLine();


            Restaurant restaurant = new Restaurant()
            {
                RestId = RestId,
                RestStatus = RestStatus,
            };
            return restaurant;
        }
        public void ActivateDeactivateRestaurant(Restaurant restaurant)
        {
            ExecuteCommand(String.Format("Update RestaurantA set RestStatus='{1}' where RestId={0}", restaurant.RestId, restaurant.RestStatus));
        }
        public bool ExecuteCommand(string queury)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(queury, sqlcon);
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
            return true;
        }
        public void DeleteRestaurant()
        {
            string RestId = string.Empty;

            Console.WriteLine("Delet Existing Rstaurant: ");
            Console.Write(" \n\n");

            Console.Write(" Please Enter The  Id of Restaurant: ");
            RestId = Console.ReadLine();
            Console.Write(" \n\n");

            ExecuteCommand(String.Format("Delete from RestaurantA where RestId = '{0}'", RestId));

            Console.WriteLine(" congratulations Restaurant SuccessFully Deleted from RSystem!!!!" + Environment.NewLine);
        }

    }
}

