using BankSystemConsole.Class;

namespace BankSystemConsole.Controller
{
    internal static class UtilityController
    {
        public static string FormatCpf(string _cpf)
        {
            // XXX.XXX.XXX-XX
            return $"{_cpf.Substring(0, 3)}.{_cpf.Substring(3, 3)}.{_cpf.Substring(6, 3)}-{_cpf.Substring(9, 2)}";
        }

        public static string FormatCellphoneNumber(string _cellphoneNumber)
        {
            // (XX) X XXXX-XXXX
            return $"({_cellphoneNumber.Substring(0, 2)}) {_cellphoneNumber.Substring(2, 1)} {_cellphoneNumber.Substring(3, 4)}-{_cellphoneNumber.Substring(7, 4)}";
        }

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