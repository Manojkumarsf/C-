using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccination_Drive
{
   public class Vaccination
   {
        public  Vaccine_Type Vaccine { get; set; }
        public int Dosage { get; set; }
        public DateTime VaccinationDate { get; set; }
        public Vaccination(int vaccine, DateTime date, int dose)
        {
             Vaccine = (Vaccine_Type)vaccine;
             VaccinationDate = date;
             Dosage = dose;
        }
        
        
        
   }
    public enum Vaccine_Type
    {
        Covaxin,
        Covishield,
        Sputnic
    }

}

