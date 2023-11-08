using BankSystemConsole.Class;

namespace BankSystemConsole.Controller
{
    internal static class MenuController
    {
        public static void AdminMenu()
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
                    UserController.Create();
                    break;

                case "2":
                    UserController.GetSpecific();
                    break;

                case "3":
                    UserController.Update();
                    break;

                case "4":
                    UserController.Delete();
                    break;

                case "5":
                    UserController.GetAll();
                    break;

                default:
                    UtilityController.InvalidOption();
                    break;
            }
        }

        public static void UserMenu()
        {
            Console.WriteLine("Esta funcionalidade ou recurso ainda não foi implementado.\n");
            Console.WriteLine("1 - Administrador");
            Console.WriteLine("0 - Sair\n");
            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "0":
                    UtilityController.ClosingProgram();
                    break;

                case "1":
                    Console.Clear();
                    Console.WriteLine("Bem vindo ao Painel do Administrador\n");
                    MenuController.AdminMenu();
                    break;

                default:
                    UtilityController.InvalidOption();
                    break;
            }
        }

        public static void EmptyDBMenu()
        {
            bool continueLoop = true;
            while (continueLoop)
            {
                if (Database.UserDB.Count == 0)
                {
                    Console.WriteLine("Não detectamos nenhum usuário registrado no Banco de Dados\n");
                    Console.WriteLine("1 - Registrar 5 usuários para testes.");
                    Console.WriteLine("0 - Continuar com o Banco de Dados vazio.\n");
                    string input = Console.ReadLine();
                    Console.WriteLine();
                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            Database.UserDB.Add(new User("Breno Nelson Lima", "737.127.862-39", DateTime.Parse("06/02/1992"), "(82) 99251-3958", "brenonelsonlima@gmail.com", "12345678"));
                            Database.UserDB.Add(new User("Edson Marcelo Almada", "439.748.289-66", DateTime.Parse("21/05/1999"), "(69) 98657-7221", "edson_almada@gmail.com", "12345678"));
                            Database.UserDB.Add(new User("Silvana Heloise Drumond", "976.645.964-91", DateTime.Parse("04/10/1967"), "(81) 98704-4490", "silvana.heloise.drumond@gmail.com", "12345678"));
                            Database.UserDB.Add(new User("Elza Luzia Ayla Caldeira", "502.129.381-85", DateTime.Parse("13/12/1962"), "(82) 99134-9650", "elza.luzia.caldeira@gmail.com", "12345678"));
                            Database.UserDB.Add(new User("Nicole Kamilly Joana da Luz", "516.516.331-85", DateTime.Parse("19/01/1991"), "(85) 98788-5803", "nicolekamillydaluz@gmail.com", "12345678"));
                            DatabaseController.SaveAndReloadDatabase();
                            continueLoop = false;
                            break;

                        case "0":
                            Console.Clear();
                            continueLoop = false;
                            break;

                        default:
                            UtilityController.InvalidOption();
                            break;
                    }
                }
                else
                {
                    continueLoop = false;
                }
            }
        }
    }
}