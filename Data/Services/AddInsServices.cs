using Bislerium.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json; //Giving the reference of the package so that we can use it's method
using System.Threading.Tasks;

namespace Bislerium.Data.Services
{
    public class AddInsServices
    {

        public static void SaveAddinsToJson(List<AddInModel> addin)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in Utils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.AddInsFilePath();

            // Serialize the list of adddins to JSON format with formatting Indented and store it in Variable jsonData
            string jsonData = JsonConvert.SerializeObject(addin, Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, jsonData);
        }


        public static List<AddInModel> RetrieveAddinData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.AddInsFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<AddInModel>();
                }
                return JsonConvert.DeserializeObject<List<AddInModel>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return new List<AddInModel>();
            }
        }

        public static AddInModel GetAddinsbyId(int id)
        {
            List<AddInModel> coffee = RetrieveAddinData(); // Retrieves the list of addins and stores it in addins object

            // Return the first addin with the specified Id.
            return coffee.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of addins is equal to the id of parameter that recieves value later on.
        }

        public static List<AddInModel> EditAddins(int id, decimal newPrice)
        {
            // Retrieve the list of Addins.
            List<AddInModel> Addin = RetrieveAddinData();
            // Find the addins with the specified Id.
            AddInModel editAddin = Addin.FirstOrDefault(x => x.Id == id);
            // If the addins is not found, throw an exception.
            if (editAddin == null)
            {
                throw new Exception("addins not found");
            }
            // Update the name of the addins.
            editAddin.Price = newPrice;
            SaveAddinsToJson(Addin); // Save the updated list of Addins to the JSON file by calling method SaveAddinsToJson
            return Addin;  // Return the updated list of Addins.
        }

        public static void InjectSampleAddinsData()
        {
            // Gets the file path where hobby data will be stored from AddinsFilePath method
            // in Utils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.AddInsFilePath();

            // Read existing data from the file and store it in variable existingData
            var existingData = File.ReadAllText(filePath);

            // If the file is empty, injects a list of sample addins data in a object of List<AddinModel> called sampleAddins first and saves it in a Json File by calling method SaveAddinToJson.
            if (string.IsNullOrEmpty(existingData))
            {
                List<AddInModel> sampleAddins = new List<AddInModel>
            {
                new AddInModel {Id=1, Name = "Sugar", Price=0.2m },
                new AddInModel {Id=2, Name = "Peppermint", Price=0.6m },
                new AddInModel {Id=3, Name = "Ginger", Price=0.5m },
                new AddInModel {Id=4, Name = "Chocolate", Price=0.4m },
                new AddInModel {Id=5, Name = "Caramel Sirup", Price=0.5m},
                new AddInModel {Id=6, Name = "Avocado", Price=0.7m}
            };
                SaveAddinsToJson(sampleAddins); // Save the sample hobby data to the JSON file by calling SaveAddinToJson Method and passing sampleAddins as it Argument.
            }
        }
    }
}
