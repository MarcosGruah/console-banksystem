using BankSystemConsole.Class;

namespace BankSystemConsole.Controller
{
    internal static class UserController
    {
        public static void Create(List<User> userDB)
        {
            Console.Clear();
            Console.WriteLine("Certo, vou lhe orientar como criar a sua conta!\n");
            Console.Write("Nome Completo: ");
            string userFullname = Console.ReadLine();
            Console.Write("CPF: ");
            string userCpf = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            string userBirthDate = Console.ReadLine();
            Console.Write("Celular: ");
            string userCellphoneNumber = Console.ReadLine();
            Console.Write("Email: ");
            string userEmail = Console.ReadLine();
            Console.Write("Senha: ");
            string userPassword = Console.ReadLine();
            userDB.Add(new User(userFullname, userCpf, userBirthDate, userCellphoneNumber, userEmail, userPassword));
            Console.Clear();
            Console.WriteLine($"{userFullname.ToUpper()} adicionado com sucesso!\n");
        }

        public static void GetAll(List<User> userDB)
        {
            Console.Clear();
            UtilityController.HorizontalBar();

            foreach (var user in userDB)
            {
                user.ShowDetailsSimple();
            }

            UtilityController.HorizontalBar();
        }

        public static void GetSpecific(List<User> userDB)
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a ID do usuário que deseja ver mais detalhes ou digite 2 para listar todos os usuários: ");
            string input = Console.ReadLine();
            if (input == "2")
            {
                GetAll(userDB);
            }
            else
            {
                User foundUser = userDB.Find(user => user.Id.ToString() == input);

                if (foundUser != null)
                {
                    Console.Clear();

                    UtilityController.HorizontalBar();
                    foundUser.ShowDetailsFull();
                    UtilityController.HorizontalBar();
                }
                else
                {
                    UtilityController.ErrorMessage("404", "USUÁRIO NÃO ENCONTRADO", "CONFIRA SE O ID DO USUÁRIO QUE DESEJA REMOVER ESTÁ CORRETO");
                }
            }
        }

        public static void Update(List<User> userDB)
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a ID do usuário que deseja atualizar os dados ou digite 2 para listar todos os usuários: ");
            string input = Console.ReadLine();
            if (input == "2")
            {
                GetAll(userDB);
            }
            else
            {
                User foundUser = userDB.Find(user => user.Id.ToString() == input);

                if (foundUser != null)
                {
                    Console.WriteLine($"\nVocê tem certeza que deseja atualizar {foundUser.FullName}?\n");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não\n");
                    string confirmDeletion = Console.ReadLine();

                    switch (confirmDeletion)
                    {
                        case "1":
                            Console.Clear();

                            UtilityController.HorizontalBar();
                            foundUser.ShowDetailsFull();
                            UtilityController.HorizontalBar();

                            Console.Write("Novo Celular: ");
                            foundUser.CellphoneNumber = Console.ReadLine();
                            Console.Write("Novo Email: ");
                            foundUser.Email = Console.ReadLine();
                            Console.Write("Nova Senha: ");
                            foundUser.Password = Console.ReadLine();

                            Console.Clear();

                            Console.WriteLine($"{foundUser.FullName} ATUALIZADO COM SUCESSO\n");
                            foundUser.ShowDetailsFull();
                            break;

                        default:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    UtilityController.ErrorMessage("404", "USUÁRIO NÃO ENCONTRADO", "CONFIRA SE O ID DO USUÁRIO QUE DESEJA ATUALIZAR ESTÁ CORRETO");
                }
            }
        }

        public static void Delete(List<User> userDB)
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a ID do usuário que deseja remover ou digite 2 para listar todos os usuários: ");
            string input = Console.ReadLine();
            if (input == "2")
            {
                GetAll(userDB);
            }
            else
            {
                User foundUser = userDB.Find(user => user.Id.ToString() == input);

                if (foundUser != null)
                {
                    Console.WriteLine($"\nVocê tem certeza que deseja remover {foundUser.FullName}? Esse processo é irreversível.\n");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não\n");
                    string confirmDeletion = Console.ReadLine();

                    switch (confirmDeletion)
                    {
                        case "1":
                            string userName = foundUser.FullName;
                            userDB.Remove(userDB.Where(user => user.Id.ToString() == input).First());
                            Console.Clear();
                            Console.WriteLine($"{userName} REMOVIDO COM SUCESSO\n");
                            break;

                        default:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    UtilityController.ErrorMessage("404", "USUÁRIO NÃO ENCONTRADO", "CONFIRA SE O ID DO USUÁRIO QUE DESEJA REMOVER ESTÁ CORRETO");
                }
            }
        }

        public static void SeedDatabase(List<User> userDB)
        {
            userDB.Add(new User("Breno Nelson Lima", "737.127.862-39", "06/02/1992", "(82) 99251-3958", "brenonelsonlima@gmail.com", "12345678"));
            userDB.Add(new User("Edson Marcelo Almada", "439.748.289-66", "21/05/1999", "(69) 98657-7221", "edson_almada@gmail.com", "12345678"));
            userDB.Add(new User("Silvana Heloise Drumond", "976.645.964-91", "04/10/1967", "(81) 98704-4490", "silvana.heloise.drumond@gmail.com", "12345678"));
            userDB.Add(new User("Elza Luzia Ayla Caldeira", "502.129.381-85", "13/12/1962", "(82) 99134-9650", "elza.luzia.caldeira@gmail.com", "12345678"));
            userDB.Add(new User("Nicole Kamilly Joana da Luz", "516.516.331-85", "19/01/1991", "(85) 98788-5803", "nicolekamillydaluz@gmail.com", "12345678"));

            Console.WriteLine(userDB.Count == 1 ? $"Existe {userDB.Count} usuário registrado no sistema.\n" : $"Existem {userDB.Count} usuários registrados no sistema.\n");
        }
    }
}