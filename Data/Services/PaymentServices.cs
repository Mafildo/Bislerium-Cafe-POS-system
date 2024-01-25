using Bislerium.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bislerium.Data.Services
{
    public class PaymentServices
    {
        public static void SavePaymentDataInJson(PaymentModel payment)
        {
            string filePath = Utils.Utils.PaymentFilePath();
            try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
            {
                List<PaymentModel> paymentList; // object of List of AddForm i.e. formList
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    paymentList = new List<PaymentModel>();
                }
                else
                {
                    paymentList = JsonConvert.DeserializeObject<List<PaymentModel>>(existingJsonData);
                }
                // Add the current form to the list.
                paymentList.Add(payment);

                // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
                string orderJsonData = JsonConvert.SerializeObject(paymentList, Formatting.Indented);

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

        public static List<PaymentModel> RetrievePaymentData()
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
                    return new List<PaymentModel>();
                }
                return JsonConvert.DeserializeObject<List<PaymentModel>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return new List<PaymentModel>();
            }
        }
    }
}
