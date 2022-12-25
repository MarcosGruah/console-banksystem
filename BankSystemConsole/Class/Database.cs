namespace BankSystemConsole.Class
{
    internal static class Database
    {
        private static List<User> _userDB;

        public static List<User> UserDB
        {
            get { return _userDB; }
            set { _userDB = value; }
        }

        public static void UserCount()
        {
            Console.WriteLine(_userDB.Count == 1 ? $"Existe {_userDB.Count} usuário registrado no sistema.\n" : $"Existem {_userDB.Count} usuários registrados no sistema.\n");
            Console.WriteLine("Escolha a opção \"2 - Ver detalhes de um usuário.\" para mais informações.\n");
        }
    }
}