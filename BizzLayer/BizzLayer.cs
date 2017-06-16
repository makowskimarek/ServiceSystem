using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 
namespace BizzLayer
{
    /// <summary>
    /// ta klasa służy do:
    /// - jako  klasa dziedzinowa (domenowa) (u Was bedzie pozyskana z mapowania OR)
    /// - jako klasa do  defniowania wartosci w filtrowaniu
    /// </summary>
    public class Patient
    { 
        public String FName {get ; set;}
        public String LName {get ; set;}
        public DateTime BDate { get; set; }
        public Decimal Height { get; set; }

    }

    static public class RegistrationFacade
    {
        
        public static List<Patient> GetPatients(Patient searchCrit)

        {
            var pat = new List<Patient> ();
            pat.Add(new Patient {FName = "aaaa", LName = "AAAAA", BDate = System.DateTime.Now, Height = 180});
            pat.Add(new Patient { FName = "aabbaa", LName = "AABBAA", BDate = System.DateTime.Now, Height = 200});
            pat.Add(new Patient { FName = "bbbb", LName = "BBBBB", BDate = DateTime.Parse("1991-01-01"), Height = 170 });
            var res = (from element in pat where element.LName.StartsWith(searchCrit.LName) select element).ToList();
            return res;
        }


    }




}
