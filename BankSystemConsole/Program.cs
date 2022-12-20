using BankSystemConsole.Class;
using BankSystemConsole.Controller;

bool isAppRunning = true;

List<User> userDB = new List<User>();

Console.WriteLine("Bem Vindo ao Sistema Bancário.\n");

UserController.SeedDatabase(userDB);

Console.WriteLine("USER OR ADMIN?");
string input = Console.ReadLine();

while (isAppRunning)
{
    if (input == "admin")
    {
        //isAppRunning = MenuController.AdminMenu(userDB, ref isAppRunning);
    }
    else if (input == "user")
    {
        isAppRunning = MenuController.UserMenu(userDB);
    }
    else
    {
        Console.Clear();
        Console.WriteLine("INVALID OPTION.\n");
    }
}