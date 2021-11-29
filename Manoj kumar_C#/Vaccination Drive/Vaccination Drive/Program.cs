using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_Drive
{
    class Program
    {
        public static List<Beneficiary> BeneficiariesUserList = new List<Beneficiary>();
        static void Main(string[] args)
        {
            // Adding  default user1  details\\
            Beneficiary user = new Beneficiary("Mano", 9790155828, "Salem", 22, 0);
            // Adding  default user2 \\
            Beneficiary user1 = new Beneficiary("kumaran", 9788959526, "Karur", 29, 0);
            user1.VaccinationDetails(0, DateTime.Now);
            // Adding default user 3 details\\
            Beneficiary user2 = new Beneficiary("kani", 9788855828, "Chennai", 25, 1);
            user2.VaccinationDetails(2, DateTime.Now);
            BeneficiariesUserList.Add(user);
            BeneficiariesUserList.Add(user1);
            BeneficiariesUserList.Add(user2);
            MainMenu();
            Console.ReadLine();
        }
        // adding new beneficary user \\
        public static void AddBeneficiaryRegistration()
        {
            string UserOption = string.Empty;
            do
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---->> Welcome to Add new BeneficiaryRegistration <<-----");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Enter your Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your Mobile number");
                long phoneNumber = (long.Parse(Console.ReadLine()));
                Console.WriteLine("Enter your City");
                string address = Console.ReadLine();
                Console.WriteLine("Enter your Age");
                int age = (int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter your Gender Male-->0, Female-->1, Others-->2");
                int gender = int.Parse(Console.ReadLine());
                Beneficiary user = new Beneficiary(name, phoneNumber, address, age, gender);
                BeneficiariesUserList.Add(user);
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Succesfully you complete the BeneficiaryRegistration\nyour Registernumber is {0}", user.RegistrationNumber);
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Hello " + user.Name + "\nyour Register Number :-" + user.RegistrationNumber);
                Console.WriteLine("Do you want to add another user details enter yes/no");
                UserOption = Console.ReadLine();
                Console.WriteLine("---------------------------------------------------------");
            } while (UserOption == "yes");

        }
        public static void Vaccination()
        {
            Console.WriteLine("Enter your Registration Number");
            int Registrationnumber = int.Parse(Console.ReadLine());
            bool success = false;
            Beneficiary selectedUser = null;
            foreach (Beneficiary user in BeneficiariesUserList)
            {
                if (user.RegistrationNumber == Registrationnumber)
                {
                    success = true;
                    selectedUser = user;
                    break;
                }
            }
            if (success)
            {
                Console.WriteLine("Choice your option\nTake Vaccination-->1\nVaccination History-->2\nNext Due Date-->3\nExit-->4");
                int userChoice = int.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------------------------------");
                if (userChoice == 1)
                {
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("----->>> Hi welcome and for Taking vaccination <<<------- ");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("Enter the vaccine Type \nCovidSheild-->0\nCovaccine-->1\nStupnic-->2");
                    int vaccineType = int.Parse(Console.ReadLine());
                    if (selectedUser.Vaccination.Count == 0)
                    {
                        Console.WriteLine("Enter Date in dd/mm/yyyy");
                        string date = Console.ReadLine();
                        string[] splitDate = date.Split('/');
                        DateTime date1 = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                        Console.WriteLine("your vaccination details " + selectedUser.VaccinationDetails(vaccineType, date1));
                    }
                    //checks  beneficiary  first dose details
                    else if (selectedUser.Vaccination.Count == 1)
                    {
                        //check 1st dose vaccine and selected vaccine are equal  
                        if ((Vaccine_Type)vaccineType == selectedUser.Vaccination[0].Vaccine)
                        {
                            Console.WriteLine("Enter Date in dd/mm/yyyy");
                            string date = Console.ReadLine();
                            string[] splitDate = date.Split('/');
                            DateTime date1 = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                            Console.WriteLine(selectedUser.VaccinationDetails(vaccineType, date1));
                        }
                        else
                        {
                            Console.WriteLine("You have selected different vaccine. Your First vaccine is " + selectedUser.Vaccination[0].Vaccine);
                        }
                    }
                    else if (userChoice == 2)
                    {
                        foreach (Vaccination user in selectedUser.Vaccination)
                        {
                            Console.WriteLine("vaccineType: " + user.Vaccine + "\n" + "Dosage: " + user.Dosage + "\n" + "Date: " + user.VaccinationDate.ToString("dd/MM/yyyy"));
                        }
                    }
                    else if (userChoice == 3)
                    {
                        Console.WriteLine(selectedUser.DueDate());
                    }
                    else if (userChoice == 4)
                    {
                        MainMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid registration number. Please enter valid one.");
                }
        }   }
            public  static void Exit()
            {
                System.Environment.Exit(0);
            }
            public static void MainMenu()
            {
                String choice = string.Empty;
                Console.WriteLine("Welcome --->> home <<---");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine(" enter your choice\n1.Beneficiary Registration-->1\n2.Vaccination-->2\n3.Exit-->3");
                int Userchoice = int.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------------------------------");
                do
                {
                    switch (Userchoice)
                    {
                        case 1:
                            {
                                AddBeneficiaryRegistration();
                                break;

                            }
                        case 2:
                            {
                                Vaccination();
                                break;
                            }
                        case 3:
                            {
                                Exit();
                                break;

                            }
                        default:
                            {
                                Console.WriteLine("Invalid input");
                                break;
                            }

                    }
                    Console.WriteLine("Do you want to goto mainmenu again  Yes/no");
                    choice = Console.ReadLine().ToLower();
                    Console.WriteLine("---------------------------------------------------------");
                if (choice == "yes")
                {
                    MainMenu();
                }
            } while (choice == "yes");

            }
    }
}


