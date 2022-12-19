using System.Text.RegularExpressions;

namespace BankSystemConsole.Class
{
    internal class User
    {
        private Guid _id = Guid.NewGuid();
        private string _fullName;
        private string _cpf;
        private string _birthDate;
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
            // XXX.XXX.XXX-XX
            get { return FormatCpf(); }
            set { _cpf = Regex.Replace(value, "[^0-9]", ""); }
        }

        public string BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string CellphoneNumber
        {
            // (XX) X XXXX-XXXX
            get { return FormatCellphoneNumber(); }
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

        public User(string fullName, string cpf, string birthDate, string cellphoneNumber, string email, string password)
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


        private string FormatCpf()
        {
            return $"{_cpf.Substring(0, 3)}.{_cpf.Substring(3, 3)}.{_cpf.Substring(6, 3)}-{_cpf.Substring(9, 2)}";
        }

        private string FormatCellphoneNumber()
        {
            return $"({_cellphoneNumber.Substring(0, 2)}) {_cellphoneNumber.Substring(2, 1)} {_cellphoneNumber.Substring(3, 4)}-{_cellphoneNumber.Substring(7, 4)}";
        }
    }
}