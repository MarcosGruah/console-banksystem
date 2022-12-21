using BankSystemConsole.Class;

namespace BankSystemConsole.Controller
{
    internal static class MenuController
    {
        public static void EmptyDBMenu(List<User> userDB)
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
                    break;

                case "0":
                    Console.Clear();
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    UtilityController.InvalidOption();
                    break;
            }
        }

        public static void AdminMenu(List<User> userDB)
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
                    UtilityController.ClosingProgram();
                    break;

                case "1":
                    UserController.Create(userDB);
                    break;

                case "2":
                    UserController.GetSpecific(userDB);
                    break;

                case "3":
                    UserController.Update(userDB);
                    break;

                case "4":
                    UserController.Delete(userDB);
                    break;

                case "5":
                    UserController.GetAll(userDB);
                    break;

                default:
                    UtilityController.InvalidOption();
                    break;
            }
        }

        public static void UserMenu(List<User> userDB)
        {
            Console.WriteLine("1 - USER MENU");
            Console.WriteLine("0 - Sair\n");
            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "0":
                    UtilityController.ClosingProgram();
                    break;

                case "1":
                    Console.WriteLine("USER MENU STUFF");
                    break;

                default:
                    UtilityController.InvalidOption();
                    break;
            }
        }
    }
}