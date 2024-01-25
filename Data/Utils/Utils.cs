using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Utils
{
    public static class Utils
    {
        public static string ApplicationDirectoryPath()
        {
            string directoryPath = @"C:\Users\Anish Shrestha\OneDrive\Desktop\C#Cousework";  // Define the path to the directory where you want to store your files.
            if (!Directory.Exists(directoryPath))    // If the directory doesn't exist
            {
                Directory.CreateDirectory(directoryPath);  // Create the directory
                return directoryPath;     // Return the path of the directory.
            }
            else
            {
                return directoryPath;   // else return if it is already there
            }
        }

        public static string AddInsFilePath()
        {
            string directoryPathCreated = ApplicationDirectoryPath();   // Calling the method ApplicationDirectoryPath that returns the folder created, and storing it in directoryPathCreated variable
            string filePath = Path.Combine(directoryPathCreated, "AddIns.json");  // Combine the directory path with the file name to get the complete file path.
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }

       public static string CoffeeFilePath()
        {
            string directoryPathCreated = ApplicationDirectoryPath();
            string filePath = Path.Combine(directoryPathCreated, "Coffee.json");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }

        public static string OrderFilePath()
        {
            string directoryPathCreated = ApplicationDirectoryPath();
            string filePath = Path.Combine(directoryPathCreated, "Order.json");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }

        public static string PaymentFilePath()
        {
            string directoryPathCreated = ApplicationDirectoryPath();
            string filePath = Path.Combine(directoryPathCreated, "Payment.json");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }

        public static string MemberFilePath()
        {
            string directoryPathCreated = ApplicationDirectoryPath();
            string filePath = Path.Combine(directoryPathCreated, "Member.json");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }
    }
}
