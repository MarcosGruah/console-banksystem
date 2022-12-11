namespace BankSystemConsole
{
    internal static class UtilityController
    {
        public static void ErrorMessage(string statusCode, string statusMsg, string descriptionMsg)
        {
            Console.Clear();
            Console.WriteLine("==============================================\n");
            Console.WriteLine($"{statusCode} - {statusMsg}\n");
            Console.WriteLine($"{descriptionMsg}\n");
            Console.WriteLine("==============================================\n");
        }
    }
}