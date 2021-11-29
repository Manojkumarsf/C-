using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_Drive
{
    class Beneficiary
    {
        private static int _autoIncreamentedRegisterNumber = 120031;
        public int RegistrationNumber { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public GenderChoice Gender { get; set; }
        public List<Vaccination> Vaccination = new List<Vaccination>();
        public Beneficiary(string name, long phoneNumber, string address, int age, int gender)
        {
            RegistrationNumber = _autoIncreamentedRegisterNumber++;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Age = age;
            Gender = (GenderChoice)gender;

        }
        
        public string  VaccinationDetails(int vaccine, DateTime date)
        {
            string userDisplay = null;
            if (Vaccination.Count == 0)
            {
                Vaccination details = new Vaccination(vaccine, date, 0);
                Vaccination.Add(details);
                userDisplay="Your Next dose due time is "+details.VaccinationDate.AddDays(30).ToString("dd/MM/yyyy");
                return userDisplay;
            }
            else if (Vaccination.Count == 1)
            {
                 if (Vaccination[0].VaccinationDate > Vaccination[0].VaccinationDate.AddDays(30))
                 {
                     Vaccination details = new Vaccination(vaccine, date, 2);
                     Vaccination.Add(details);
                     userDisplay= "You have completed the vaccination course. Thanks for your participation in the vaccination drive.";
                     
                 }
                 else
                 {
                     userDisplay="You are not able to take the second dose of vaccination because your date is: "+Vaccination[0].VaccinationDate.AddDays(30).ToString("dd/MM/yyyy");
                 }
            }
            else
            {
                userDisplay= "You have completed the 2 doses already.";
            }
            return userDisplay;
        }
        public string  DueDate()
        {
            string userDisplay = null;
            if (Vaccination.Count == 1)
            {
              userDisplay="Your Next dose due time is"+ Vaccination[0].VaccinationDate.AddDays(30).ToString("dd/MM/yyyy");
                return userDisplay;
            }
            else
            {
                userDisplay="You have completed the vaccination course. Thanks for your participation in the vaccination drive.";
                return userDisplay;
            }
        }

        // creating enum for gender
        public enum GenderChoice
        {
            Male,
            Female,
            Transgender
        }
    }

}

