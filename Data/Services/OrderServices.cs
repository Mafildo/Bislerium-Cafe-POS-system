using Bislerium.Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Services
{
    public class OrderServices
    {
        public static void SaveOrderDataInJson(OrderModel order)
        {
            string filePath = Utils.Utils.OrderFilePath();
            try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
            {
                List<OrderModel> orderList; // object of List of AddForm i.e. formList
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    orderList = new List<OrderModel>();
                }
                else
                {
                    orderList = JsonConvert.DeserializeObject<List<OrderModel>>(existingJsonData);
                }
                // Add the current form to the list.
                orderList.Add(order);

                // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
                string orderJsonData = JsonConvert.SerializeObject(orderList, Formatting.Indented);

                // Write the JSON data back to the file.
                File.WriteAllText(filePath, orderJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }

        public static List<OrderModel> RetrieveOrderData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.OrderFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<OrderModel>();
                }
                return JsonConvert.DeserializeObject<List<OrderModel>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return new List<OrderModel>();
            }
        }

        public static OrderModel GetOrderbyId(Guid id)
        {
            List<OrderModel> order = RetrieveOrderData(); // Retrieves the list of hobbies and stores it in hobbies object

            // Return the first hobby with the specified Id.
            return order.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Hobbies is equal to the id of parameter that recieves value later on.
        }

        public static void SaveOrderToJson(List<OrderModel> order)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.OrderFilePath();

            // Serialize the list of Addins to JSON format with formatting Indented and store it in Variable jsonData
            string jsonData = JsonConvert.SerializeObject(order, Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, jsonData);
        }
        public static List<OrderModel> EditOrder(Guid id)
        {
            // Retrieve the list of Addins.
            List<OrderModel> Order = RetrieveOrderData();
            // Find the addins with the specified Id.
            OrderModel editOrder = Order.FirstOrDefault(x => x.Id == id);
            // If the addins is not found, throw an exception.
            if (editOrder == null)
            {
                throw new Exception("addins not found");
            }
            // Update the name of the addins.
            editOrder.PaymentStatus = true;
            SaveOrderToJson(Order); // Save the updated list of Addins to the JSON file by calling method SaveAddinsToJson
            return Order;  // Return the updated list of Addins.
        }

        public static List<OrderModel> RetrievePaymentData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.PaymentFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<OrderModel>();
                }
                return JsonConvert.DeserializeObject<List<OrderModel>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return new List<OrderModel>();
            }
        }



    }
}
