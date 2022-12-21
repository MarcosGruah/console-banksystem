using BankSystemConsole.Class;

namespace BankSystemConsole.Controller
{
    internal static class UtilityController
    {
        public static void ClosingProgram()
        {
            App.IsAppRunning = false;
            Console.Clear();
            Console.WriteLine("Saindo do programa.");
        }

        public static void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Opção invalida.\n");
        }

        public static void ErrorMessage(string statusCode, string statusMsg, string descriptionMsg)
        {
            Console.Clear();
            Console.WriteLine($"{statusCode} - {statusMsg}\n");
            Console.WriteLine($"{descriptionMsg}\n");
            HorizontalBar();
        }

        public static void HorizontalBar()
        {
            Console.WriteLine("==============================================\n");
        }
    }
}