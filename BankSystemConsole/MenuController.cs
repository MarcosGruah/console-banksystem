namespace BankSystemConsole
{
    internal static class MenuController
    {
        public static bool EmptyDBMenu(List<Bank> bankList)
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
                    return true;

                case "0":
                    Console.Clear();
                    Console.WriteLine("Programa finalizado.");
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção invalida.\n");
                    return true;
            }
        }

        public static bool MainMenu(List<Bank> bankList)
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
                    return true;

                case "2":
                    BankController.GetAll(bankList);
                    return true;

                case "3":
                    BankController.Update(bankList);
                    return true;

                case "4":
                    BankController.Delete(bankList);
                    return true;

                case "0":
                    Console.Clear();
                    Console.WriteLine("Saindo do programa.");
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção invalida.\n");
                    return true;
            }
        }
    }
}