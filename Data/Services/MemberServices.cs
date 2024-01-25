using Bislerium.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bislerium.Data.Services
{
    public class MemberServices
    {
        public static void SaveMemberDataInJson(MemberModel member)
        {
            string filePath = Utils.Utils.MemberFilePath();
            try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
            {
                List<MemberModel> memberList; // object of List of AddForm i.e. formList
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    memberList = new List<MemberModel>();
                }
                else
                {
                    memberList = JsonConvert.DeserializeObject<List<MemberModel>>(existingJsonData);
                }
                // Add the current form to the list.
                memberList.Add(member);

                // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
                string orderJsonData = JsonConvert.SerializeObject(memberList, Formatting.Indented);

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

        public static List<MemberModel> RetrieveMemberData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.MemberFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<MemberModel>();
                }
                return JsonConvert.DeserializeObject<List<MemberModel>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return new List<MemberModel>();
            }
        }

        public static void SaveMemberToJson(List<MemberModel> updatedMemberList)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utils.Utils.MemberFilePath();

            // Serialize the list of Addins to JSON format with formatting Indented and store it in Variable jsonData
            string jsonData = JsonConvert.SerializeObject(updatedMemberList, Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, jsonData);
        }

        // Delete a member
        public static async Task DeleteMember(MemberModel memberToDelete)
        {
            try
            {
                // Retrieve the current list of members
                List<MemberModel> memberList = RetrieveMemberData();

                // Find and remove the member to delete
                MemberModel memberToRemove = memberList.FirstOrDefault(member => member.PhoneNumber == memberToDelete.PhoneNumber);

                if (memberToRemove != null)
                {
                    memberList.Remove(memberToRemove);

                    // Save the updated list back to the data source (e.g., JSON file)
                    SaveMemberToJson(memberList);

                    // Show a success message using DisplayAlert
                    await App.Current.MainPage.DisplayAlert("Success", "Member deleted successfully!", "OK");
                }
                else
                {
                    // If memberToRemove is null, the member was not found
                    await App.Current.MainPage.DisplayAlert("Error", "Member not found for deletion.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error deleting member: {ex.Message}");

                // Show an error message using DisplayAlert
                await App.Current.MainPage.DisplayAlert("Error", $"Error deleting member: {ex.Message}", "OK");
            }
        }

        public static bool CustomerExists(string phoneNumber)
        {
            // Retrieve the current list of members
            List<MemberModel> memberList = RetrieveMemberData();

            // Check if a member with the given phone number exists
            return memberList.Any(member => member.PhoneNumber == phoneNumber);
        }

    }
}
