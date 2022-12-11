using System.Text.RegularExpressions;

namespace BankSystemConsole
{
    internal class Bank
    {
        private Guid _id = Guid.NewGuid();
        private string _name;
        private string _cnpj;
        private string _cep;
        private string _phoneNumber;

        public Bank(string name, string cnpj, string cep, string phoneNumber)
        {
            Name = name;
            Cnpj = cnpj;
            Cep = cep;
            PhoneNumber = phoneNumber;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value.ToUpper(); }
        }

        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = Regex.Replace(value, "[^0-9]", ""); ; }
        }

        public string Cep
        {
            get { return _cep; }
            set { _cep = Regex.Replace(value, "[^0-9]", ""); ; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = Regex.Replace(value, "[^0-9]", ""); ; }
        }

        public void ShowDetails()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {Name}");
            Console.WriteLine($"CNPJ: {Cnpj}");
            Console.WriteLine($"CEP: {Cep}");
            Console.WriteLine($"Telefone: {PhoneNumber}\n");
        }
    }
}