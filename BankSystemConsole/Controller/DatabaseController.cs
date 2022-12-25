using BankSystemConsole.Class;
using System.Text.Json;

namespace BankSystemConsole.Controller
{
    internal static class DatabaseController
    {
        public static List<User> LoadUsersFromDatabase()
        {
            if (!File.Exists("userDB.json"))
            {
                File.WriteAllText("userDB.json", "[]");
            }

            string dataInput = File.ReadAllText("userDB.json");
            return JsonSerializer.Deserialize<List<User>>(dataInput);
        }

        public static void SaveAndReloadDatabase()
        {
            string userDBJson = JsonSerializer.Serialize(Database.UserDB);
            File.WriteAllText("userDB.json", userDBJson);
            LoadUsersFromDatabase();
        }

        public static void SeedDatabase()
        {
            MenuController.EmptyDBMenu();
        }
    }
}