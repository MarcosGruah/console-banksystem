namespace BankSystemConsole
{
    internal class Bank
    {
        public Bank(string name, string cnpj, string cep, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cnpj = cnpj;
            Cep = cep;
            PhoneNumber = phoneNumber;
        }
        public Guid Id { get; set; }
        public string Name { get; }
        public string Cnpj { get; }
        public string Cep { get; }
        public string PhoneNumber { get; }
    }
}
