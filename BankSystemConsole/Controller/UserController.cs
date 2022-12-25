using BankSystemConsole.Class;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BankSystemConsole.Controller
{
    internal static class UserController
    {
        public static void Create()
        {
            string userFullname, userCpf, userCellphoneNumber, userEmail, userPassword;
            DateTime userBirthDate;
            bool invalidCellphoneNumber = true;
            bool invalidUserEmail = true;
            bool invalidPassword = true;
            Console.Clear();

            userFullname = "Test Testson"; //ValidateUserFullname();
            userCpf = "12345678912"; //ValidateUserCpf();

            userBirthDate = ValidateBirthDate();

            Console.Write("Celular: ");
            userCellphoneNumber = Console.ReadLine();
            Console.Write("Email: ");
            userEmail = Console.ReadLine();
            Console.Write("Senha: ");
            userPassword = Console.ReadLine();
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

        private static string ValidateUserFullname()
        {
            string userFullname;
            bool invalidFullname = true;

            do
            {
                do
                {
                    Console.WriteLine("Para criar a sua conta eu preciso dos seus seguintes dados: \n");
                    Console.Write("Nome Completo: ");
                    userFullname = Console.ReadLine().Trim();

                    if (userFullname.Replace(" ", "").Length < 6)
                    {
                        Console.Clear();
                        Console.WriteLine("Por favor digite seu nome completo.\n");
                    }
                } while (userFullname.Replace(" ", "").Length < 6);

                Console.Clear();
                Console.WriteLine($"Seu nome completo é \"{userFullname.ToUpper()}\" ?\n");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não\n");

                string confirmName = Console.ReadLine();

                do
                {
                    switch (confirmName)
                    {
                        case "1":
                            Console.Clear();
                            invalidFullname = false;
                            break;

                        case "2":
                            Console.Clear();
                            break;

                        default:
                            UtilityController.InvalidOption();
                            Console.WriteLine($"Seu nome completo é \"{userFullname.ToUpper()}\" ?\n");
                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não\n");
                            confirmName = Console.ReadLine();
                            if (confirmName == "1")
                            {
                                invalidFullname = false;
                            }
                            break;
                    }
                } while (confirmName != "1" && confirmName != "2");
                Console.Clear();
            } while (invalidFullname);
            return userFullname;
        }

        private static string ValidateUserCpf()
        {
            string userCpf;
            bool invalidCpf = true;
            bool invalidCpfInput = true;

            do
            {
                do
                {
                    Console.WriteLine("Para criar a sua conta eu preciso dos seus seguintes dados: \n");
                    Console.Write("CPF: ");
                    userCpf = Console.ReadLine();
                    string validateInputCpf = Regex.Replace(userCpf, @"[^\d]", "");

                    if (validateInputCpf.Length != 11)
                    {
                        Console.Clear();
                        Console.WriteLine("CPF Invalido.\n");
                        Console.WriteLine("Todo CPF precisa ter 11 digitos.\n");
                    }
                    else
                    {
                        invalidCpfInput = false;
                    }
                } while (invalidCpfInput);

                Console.Clear();
                Console.WriteLine($"Seu CPF é o \"{UtilityController.FormatCpf(userCpf)}\" ?\n");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não\n");

                string confirmCpf = Console.ReadLine();

                do
                {
                    switch (confirmCpf)
                    {
                        case "1":
                            Console.Clear();
                            invalidCpf = false;
                            break;

                        case "2":
                            Console.Clear();
                            break;

                        default:
                            UtilityController.InvalidOption();
                            Console.WriteLine($"Seu CPF é o \"{UtilityController.FormatCpf(userCpf)}\" ?\n");
                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não\n");
                            confirmCpf = Console.ReadLine();
                            if (confirmCpf == "1")
                            {
                                invalidCpf = false;
                            }
                            break;
                    }
                } while (confirmCpf != "1" && confirmCpf != "2");

                if (App.RealLifeCpfValidation && invalidCpf == false)
                {
                    int[] cpfArray = new int[userCpf.Length];
                    for (int i = 0; i < userCpf.Length; i++)
                    {
                        cpfArray[i] = int.Parse(userCpf[i].ToString());
                    }

                    int total = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        total += cpfArray[i] * (i + 1);
                    }

                    int primeiroDigitoVerificador = (total % 11) == 10 ? 0 : total % 11;

                    total = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        total += cpfArray[i] * (i);
                    }

                    total += primeiroDigitoVerificador * 9;

                    int segundoDigitoVerificador = (total % 11) == 10 ? 0 : total % 11;

                    string validatedUserCpf = "";

                    for (int i = 0; i < 9; i++)
                    {
                        validatedUserCpf += cpfArray[i];
                    }

                    validatedUserCpf += primeiroDigitoVerificador;
                    validatedUserCpf += segundoDigitoVerificador;

                    if (userCpf != validatedUserCpf)
                    {
                        invalidCpf = true;
                        Console.Clear();
                        Console.WriteLine("CPF fornecido não passou pelo processo de validação.\n");
                        Console.WriteLine("Forneça um CPF válido ou desative a opção de validação de CPF nas configurações do programa.\n"); // TODO
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                if (!App.RealLifeCpfValidation)
                {
                    Console.Clear();
                }
            } while (invalidCpf);

            return userCpf;
        }

        private static DateTime ValidateBirthDate()
        {
            DateTime date;
            string userBirthDate;
            bool invalidBirthDate = true;

            do
            {
                Console.WriteLine("Para criar a sua conta eu preciso dos seus seguintes dados: \n");
                Console.Write("Data de Nascimento (dd/MM/yyyy): ");
                userBirthDate = Console.ReadLine();

                if (DateTime.TryParse(userBirthDate, out date))
                {
                    Console.Clear();
                    Console.WriteLine($"Você nasceu no dia {date.Day} de {date.ToString("MMMM", new CultureInfo("pt-BR"))} de {date.Year}?\n");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não\n");

                    string confirmDate = Console.ReadLine();
                    do
                    {
                        switch (confirmDate)
                        {
                            case "1":
                                Console.Clear();
                                invalidBirthDate = false;
                                break;

                            case "2":
                                Console.Clear();
                                break;

                            default:
                                UtilityController.InvalidOption();
                                Console.WriteLine($"Você nasceu no dia {date.Day} de {date.ToString("MMMM", new CultureInfo("pt-BR"))} de {date.Year}?\n");
                                Console.WriteLine("1 - Sim");
                                Console.WriteLine("2 - Não\n");

                                confirmDate = Console.ReadLine();
                                if (confirmDate == "1")
                                {
                                    invalidBirthDate = false;
                                }
                                Console.Clear();
                                break;
                        }
                    } while (confirmDate != "1" && confirmDate != "2");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\"{userBirthDate}\" Não é um formato de Data válido. Tente novamente.\n");
                }
            } while (invalidBirthDate);

            return date;
        }
    }
}