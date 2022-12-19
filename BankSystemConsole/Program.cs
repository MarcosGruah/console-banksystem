using BankSystemConsole.Class;
using BankSystemConsole.Controller;

bool isAppRunning = true;
List<User> userDB = new List<User>();

Console.WriteLine("Bem Vindo ao Sistema Bancário.\n");

UserController.SeedDatabase(userDB);

while (isAppRunning)
{
    if (userDB.Count == 0)
    {
        isAppRunning = MenuController.EmptyDBMenu(userDB);
    }
    else
    {
        isAppRunning = MenuController.MainMenu(userDB);
    }
}