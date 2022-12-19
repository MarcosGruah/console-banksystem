using BankSystemConsole.Class;

namespace BankSystemConsole.Controller
{
    internal static class MenuController
    {
        public static bool EmptyDBMenu(List<User> userDB)
        {
            Console.WriteLine("Não detectamos nenhum usuário registrado no nosso sistema.\n");
            Console.WriteLine("1 - Registrar um novo usuário.");
            Console.WriteLine("0 - Sair\n");
            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    UserController.Create(userDB);
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

        public static bool MainMenu(List<User> userDB)
        {
            Console.WriteLine("1 - Registrar um novo usuário.");
            Console.WriteLine("2 - Ver detalhes de um usuário.");
            Console.WriteLine("3 - Atualizar os dados de um usuário.");
            Console.WriteLine("4 - Remover um usuário do sistema.");
            Console.WriteLine("5 - Ver a lista de usuários registrados.");
            Console.WriteLine("0 - Sair\n");
            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "0":
                    Console.Clear();
                    Console.WriteLine("Saindo do programa.");
                    return false;

                case "1":
                    UserController.Create(userDB);
                    return true;

                case "2":
                    UserController.GetSpecific(userDB);
                    return true;

                case "3":
                    UserController.Update(userDB);
                    return true;

                case "4":
                    UserController.Delete(userDB);
                    return true;

                case "5":
                    UserController.GetAll(userDB);
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção invalida.\n");
                    return true;
            }
        }
    }
}