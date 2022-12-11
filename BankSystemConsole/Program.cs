using BankSystemConsole;

bool isAppRunning = true;
Console.WriteLine("Bem Vindo ao Sistema Bancário.\n");

List<Bank> bankList = new List<Bank>();

//bankList.Add(new Bank("Banco do Brasil", "00.000.000/0001-91", "70.040-912", "(61) 3493-9002"));
//bankList.Add(new Bank("Banco de Brasilia", "00.000.208/0001-00", "70.040-250", "(61) 3409-4039"));
//bankList.Add(new Bank("Nu Bank", "18.236.120/0001-58", "05409-000", "(11) 2039-0650"));

static void AddBank(List<Bank> bankList)
{
    Console.Clear();
    Console.WriteLine("Certo, vou lhe orientar como cadastrar um novo banco!\n");
    Console.Write("Nome do Banco: ");
    string bankName = Console.ReadLine();
    Console.Write($"CNPJ: ");
    string bankCnpj = Console.ReadLine();
    Console.Write($"CEP: ");
    string bankCep = Console.ReadLine();
    Console.Write($"Telefone: ");
    string bankPhoneNumber = Console.ReadLine();
    bankList.Add(new Bank(bankName, bankCnpj, bankCep, bankPhoneNumber));
    Console.Clear();
    Console.WriteLine($"{bankName} adicionado com sucesso!\n");
}

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
                AddBank(bankList);
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
    else
    {
        Console.WriteLine(bankList.Count == 1 ? $"Existe {bankList.Count} banco registrado no sistema.\n" : $"Existem {bankList.Count} bancos registrados no sistema.\n");
        Console.WriteLine("Você deseja:\n");
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
                AddBank(bankList);
                break;

            case "2":
                Console.WriteLine("Ver a lista de bancos registrados.");
                break;

            case "3":
                Console.WriteLine("Atualizar os dados de um banco.");
                break;

            case "4":
                Console.WriteLine("Remover um banco do sistema.");
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