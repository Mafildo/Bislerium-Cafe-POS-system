using Newtonsoft.Json; //Giving the reference of the package so that we can use it's method
using Bislerium.Data.Model; //Giving the path of the files that are in Model folder i.e. AddForm.cs and Hobby.cs, Allowing us to use it
using Bislerium.Data.Utils;  //Giving the path of the files that is in Utils folder i.e. FormUtils.cs, allowing us to use it's methods

// This class provides methods for saving, retrieving, and manipulating hobby data.
namespace Bislerium.Data.Services
{
    public class CoffeeServices
    {
        public static List<CoffeeModel> RetrieveCoffeeData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.CoffeeFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<CoffeeModel>();
                }
                return JsonConvert.DeserializeObject<List<CoffeeModel>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return new List<CoffeeModel>();
            }
        }
        public static List<CoffeeModel> EditCoffee(int id, decimal newPrice)
        {
            // Retrieve the list of Addins.
            List<CoffeeModel> Coffee = RetrieveCoffeeData();
            // Find the addins with the specified Id.
            CoffeeModel editcoffee = Coffee.FirstOrDefault(x => x.Id == id);
            // If the addins is not found, throw an exception.
            if (editcoffee == null)
            {
                throw new Exception("addins not found");
            }
            // Update the name of the addins.
            editcoffee.Price = newPrice;
            SaveCoffeeToJson(Coffee); // Save the updated list of Addins to the JSON file by calling method SaveAddinsToJson
            return Coffee;  // Return the updated list of Addins.
        }

        public static void SaveCoffeeToJson(List<CoffeeModel> coffee)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.CoffeeFilePath();

            // Serialize the list of Addins to JSON format with formatting Indented and store it in Variable jsonData
            string jsonData = JsonConvert.SerializeObject(coffee, Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, jsonData);
        }
        public static CoffeeModel GetCoffeebyId(int id)
        {
            List<CoffeeModel> coffee = RetrieveCoffeeData(); // Retrieves the list of hobbies and stores it in hobbies object

            // Return the first hobby with the specified Id.
            return coffee.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Hobbies is equal to the id of parameter that recieves value later on.
        }

        public static void InjectSampleCoffeeData()
        {
            // Gets the file path where hobby data will be stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.CoffeeFilePath();

            // Read existing data from the file and store it in variable existingData
            var existingData = File.ReadAllText(filePath);

            // If the file is empty, injects a list of sample hobby data in a object of List<Hobby> called sampleHobbies first and saves it in a Json File by calling method SaveHobbiesToJson.
            if (string.IsNullOrEmpty(existingData))
            {
                List<CoffeeModel> sampleCoffee = new List<CoffeeModel>
            {
                new CoffeeModel {Id=1, CoffeeName = "Expresso", Price=8},
                new CoffeeModel {Id=2, CoffeeName = "Cappuccino", Price=10 },
                new CoffeeModel {Id=3, CoffeeName = "Americano",Price=5 },
                new CoffeeModel {Id=4, CoffeeName = "Latte", Price = 20 }
            };
                SaveCoffeeToJson(sampleCoffee); // Save the sample hobby data to the JSON file by calling SaveHobbiesToJson Method and passing sampleHobbies as it Argument.
            }
        }
    }
  


}