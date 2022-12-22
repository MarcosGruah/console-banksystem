using BankSystemConsole.Class;

namespace BankSystemConsole.Controller
{
    internal static class UserController
    {
        public static void Create()
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
            Database.UserDB.Add(new User(userFullname, userCpf, userBirthDate, userCellphoneNumber, userEmail, userPassword));
            Console.Clear();
            Console.WriteLine($"{userFullname.ToUpper()} adicionado com sucesso!\n");
            DatabaseController.SaveAndReloadDatabase();
        }

        public static void GetAll()
        {
            Console.Clear();
            UtilityController.HorizontalBar();

            foreach (var user in Database.UserDB)
            {
                user.ShowDetailsSimple();
            }
            UtilityController.HorizontalBar();
            Database.UserCount();
            UtilityController.HorizontalBar();
        }

        public static void GetSpecific()
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a ID do usuário que deseja ver mais detalhes ou digite 2 para listar todos os usuários: ");
            string input = Console.ReadLine();
            if (input == "2")
            {
                GetAll();
            }
            else
            {
                User foundUser = Database.UserDB.Find(user => user.Id.ToString() == input);

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

        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a ID do usuário que deseja atualizar os dados ou digite 2 para listar todos os usuários: ");
            string input = Console.ReadLine();
            if (input == "2")
            {
                GetAll();
            }
            else
            {
                User foundUser = Database.UserDB.Find(user => user.Id.ToString() == input);

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
                            DatabaseController.SaveAndReloadDatabase();
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

        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Por favor digite a ID do usuário que deseja remover ou digite 2 para listar todos os usuários: ");
            string input = Console.ReadLine();
            if (input == "2")
            {
                GetAll();
            }
            else
            {
                User foundUser = Database.UserDB.Find(user => user.Id.ToString() == input);

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
                            Database.UserDB.Remove(Database.UserDB.Where(user => user.Id.ToString() == input).First());
                            Console.Clear();
                            DatabaseController.SaveAndReloadDatabase();
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
    }
}