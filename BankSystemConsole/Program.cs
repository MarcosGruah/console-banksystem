using BankSystemConsole;

bool isAppRunning;
List<Bank> bankList = new List<Bank>();

Console.WriteLine("Bem Vindo ao Sistema Bancário.\n");

//BankController.SeedDatabase(bankList);

do
{
    if (bankList.Count == 0)
    {
        isAppRunning = MenuController.EmptyDBMenu(bankList);
    }
    else
    {
        isAppRunning = MenuController.MainMenu(bankList);
    }
} while (isAppRunning);