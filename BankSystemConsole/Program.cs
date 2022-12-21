using BankSystemConsole.Class;
using BankSystemConsole.Controller;

List<User> userDB = new List<User>();
App.IsAppRunning = true;

Console.WriteLine("Bem Vindo ao Sistema Bancário.\n");

UserController.SeedDatabase(userDB);

string input = App.AccessLevelCheck();

while (App.IsAppRunning)
{
    switch (input)
    {
        case "1":
            MenuController.AdminMenu(userDB);
            break;

        case "2":
            MenuController.UserMenu(userDB);
            break;

        default:
            Console.WriteLine("Opção invalida.");
            break;
    }
}