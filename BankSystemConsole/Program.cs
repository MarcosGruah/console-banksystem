using BankSystemConsole;

bool isAppRunning = true;
List<Bank> bankList = new List<Bank>();

Console.WriteLine("Bem Vindo ao Sistema Bancário.\n");

BankController.SeedDatabase(bankList);

do
{
    if (bankList.Count == 0)
    {
        Console.WriteLine("Não detectamos nenhum Banco registrado no nosso sistema.\n");
        Console.WriteLine("1 - Registrar um novo banco.");
        Console.WriteLine("0 - Sair\n");
        string input = Console.ReadLine();
        Console.WriteLine();
        switch (input)
        {
            case "1":
                BankController.Create(bankList);
                break;

            case "0":
                Console.Clear();
                Console.WriteLine("Programa finalizado.");
                isAppRunning = false;
                break;

            default:
                Console.Clear();
                Console.WriteLine("Opção invalida.\n");
                break;
        }
    }
    else
    {
        Console.WriteLine("1 - Registrar um novo banco.");
        Console.WriteLine("2 - Ver a lista de bancos registrados.");
        Console.WriteLine("3 - Atualizar os dados de um banco.");
        Console.WriteLine("4 - Remover um banco do sistema.");
        Console.WriteLine("0 - Sair\n");
        string input = Console.ReadLine();
        Console.WriteLine();
        switch (input)
        {
            case "1":
                BankController.Create(bankList);
                break;

            case "2":
                BankController.GetAll(bankList);
                break;

            case "3":
                Console.WriteLine("Atualizar os dados de um banco.");
                break;

            case "4":
                BankController.Delete(bankList);
                break;

            case "0":
                Console.Clear();
                Console.WriteLine("Saindo do programa.");
                isAppRunning = false;
                break;

            default:
                Console.Clear();
                Console.WriteLine("Opção invalida.\n");
                break;
        }
    }
} while (isAppRunning);