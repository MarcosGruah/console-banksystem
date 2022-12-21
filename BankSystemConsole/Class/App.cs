using BankSystemConsole.Controller;

namespace BankSystemConsole.Class
{
    internal static class App
    {
        private static bool _isAppRunning;

        public static bool IsAppRunning
        {
            get { return _isAppRunning; }
            set { _isAppRunning = value; }
        }

        public static string AccessLevelCheck()
        {
            do
            {
                Console.WriteLine("Você deseja acessar o aplicativo como Administrador ou Usuário?\n");
                Console.WriteLine("1 - Administrador");
                Console.WriteLine("2 - Usuário");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Bem vindo ao Painel do Administrador\n");
                    return input;
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Bem vindo ao Painel do Usuário\n");
                    return input;
                }
                else
                {
                    UtilityController.InvalidOption();
                }
            } while (true);
        }
    }
}