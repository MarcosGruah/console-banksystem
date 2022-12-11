namespace BankSystemConsole
{
    internal static class BankController
    {
        public static void Create(List<Bank> bankList)
        {
            Console.Clear();
            Console.WriteLine("Certo, vou lhe orientar como cadastrar um novo banco!\n");
            Console.Write("Nome do Banco: ");
            string bankName = Console.ReadLine();
            Console.Write($"CNPJ: ");
            string bankCnpj = Console.ReadLine();
            Console.Write($"CEP: ");
            string bankCep = Console.ReadLine();
            Console.Write($"Telefone: ");
            string bankPhoneNumber = Console.ReadLine();
            bankList.Add(new Bank(bankName, bankCnpj, bankCep, bankPhoneNumber));
            Console.Clear();
            Console.WriteLine($"{bankName} adicionado com sucesso!\n");
        }

        public static void GetAll(List<Bank> bankList)
        {
            Console.Clear();
            Console.WriteLine("==============================================\n");

            foreach (var bank in bankList)
            {
                Console.WriteLine($"ID: {bank.Id}");
                Console.WriteLine($"Nome: {bank.Name}");
                Console.WriteLine($"CNPJ: {bank.Cnpj}");
                Console.WriteLine($"CEP: {bank.Cep}");
                Console.WriteLine($"Telefone: {bank.PhoneNumber}\n");
            }
            Console.WriteLine("==============================================\n");
        }

        public static void Update(List<Bank> bankList)
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a ID do Banco que deseja atualizar os dados ou digite 2 para listar todos os bancos: ");
            string input = Console.ReadLine();
            if (input == "2")
            {
                GetAll(bankList);
            }
            else
            {
                Bank foundBank = bankList.Find(bank => bank.Id.ToString() == input);

                if (foundBank != null)
                {
                    Console.WriteLine($"\nVocê tem certeza que deseja remover {foundBank.Name}? Esse processo é irreversível.\n");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não\n");
                    string confirmDeletion = Console.ReadLine();

                    switch (confirmDeletion)
                    {
                        case "1":
                            string bankName = foundBank.Name;
                            //bankList.Remove(bankList.Where(bank => bank.Id.ToString() == input).First());
                            Console.Clear();
                            Console.WriteLine($"{bankName} REMOVIDO COM SUCESSO\n");
                            break;

                        default:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    UtilityController.ErrorMessage("404", "BANCO NÃO ENCONTRADO", "CONFIRA SE O ID DO BANCO QUE DESEJA ATUALIZAR ESTÁ CORRETO");
                }
            }
        }

        public static void Delete(List<Bank> bankList)
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a ID do Banco que deseja remover ou digite 2 para listar todos os bancos: ");
            string input = Console.ReadLine();
            if (input == "2")
            {
                GetAll(bankList);
            }
            else
            {
                Bank foundBank = bankList.Find(bank => bank.Id.ToString() == input);

                if (foundBank != null)
                {
                    Console.WriteLine($"\nVocê tem certeza que deseja remover {foundBank.Name}? Esse processo é irreversível.\n");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não\n");
                    string confirmDeletion = Console.ReadLine();

                    switch (confirmDeletion)
                    {
                        case "1":
                            string bankName = foundBank.Name;
                            bankList.Remove(bankList.Where(bank => bank.Id.ToString() == input).First());
                            Console.Clear();
                            Console.WriteLine($"{bankName} REMOVIDO COM SUCESSO\n");
                            break;

                        default:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    UtilityController.ErrorMessage("404", "BANCO NÃO ENCONTRADO", "CONFIRA SE O ID DO BANCO QUE DESEJA REMOVER ESTÁ CORRETO");
                }
            }
        }

        public static void SeedDatabase(List<Bank> bankList)
        {
            bankList.Add(new Bank("Banco do Brasil", "00.000.000/0001-91", "70.040-912", "(61) 3493-9002"));
            bankList.Add(new Bank("Banco de Brasilia", "00.000.208/0001-00", "70.040-250", "(61) 3409-4039"));
            bankList.Add(new Bank("Nu Bank", "18.236.120/0001-58", "05409-000", "(11) 2039-0650"));
            Console.WriteLine(bankList.Count == 1 ? $"Existe {bankList.Count} banco registrado no sistema.\n" : $"Existem {bankList.Count} bancos registrados no sistema.\n");
        }
    }
}