using BankSystemConsole.Controller;
using System.Text.RegularExpressions;

namespace BankSystemConsole.Class
{
    internal class User
    {
        private Guid _id = Guid.NewGuid();
        private string _fullName;
        private string _cpf;
        private DateTime _birthDate;
        private string _cellphoneNumber;
        private string _email;
        private string _password;

        public Guid Id
        {
            get { return _id; }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value.ToUpper(); }
        }

        public string Cpf
        {
            get { return UtilityController.FormatCpf(_cpf); }
            set { _cpf = Regex.Replace(value, "[^0-9]", ""); }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string CellphoneNumber
        {
            get { return UtilityController.FormatCellphoneNumber(_cellphoneNumber); }
            set { _cellphoneNumber = Regex.Replace(value, "[^0-9]", ""); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User(string fullName, string cpf, DateTime birthDate, string cellphoneNumber, string email, string password)
        {
            FullName = fullName;
            Cpf = cpf;
            BirthDate = birthDate;
            CellphoneNumber = cellphoneNumber;
            Email = email;
            Password = password;
        }

        public void ShowDetailsSimple()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {FullName}\n");
        }

        public void ShowDetailsFull()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {FullName}");
            Console.WriteLine($"Data de Nascimento: {BirthDate}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"Celular: {CellphoneNumber}");
            Console.WriteLine($"Email: {Email}\n");
        }
    }
}