using BankSystemConsole.Class;
using BankSystemConsole.Controller;

Database.UserDB = DatabaseController.LoadUsersFromDatabase();

App.IsAppRunning = true;

DatabaseController.SeedDatabase();

Console.WriteLine("Bem Vindo ao Sistema Bancário.\n");

string input = App.AccessLevelCheck();

while (App.IsAppRunning)
{
    switch (input)
    {
        case "1":
            MenuController.AdminMenu();
            break;

        case "2":
            MenuController.UserMenu();
            break;

        default:
            Console.WriteLine("Opção invalida.");
            break;
    }
}