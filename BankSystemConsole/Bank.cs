using System.Text.RegularExpressions;

namespace BankSystemConsole
{
    internal class Bank
    {
        public Bank(string name, string cnpj, string cep, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name.ToUpper();
            Cnpj = Regex.Replace(cnpj, "[^0-9]", "");
            Cep = Regex.Replace(cep, "[^0-9]", "");
            PhoneNumber = Regex.Replace(phoneNumber, "[^0-9]", "");
        }
        public Guid Id { get; set; }
        public string Name { get; }
        public string Cnpj { get; }
        public string Cep { get; }
        public string PhoneNumber { get; }
    }
}
