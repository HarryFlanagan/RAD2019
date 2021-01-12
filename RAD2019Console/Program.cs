using RAD2019ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2019Console
{
    class Program
    {
        static void Main(string[] args)
        {
           
            RadBankContext bc = new RadBankContext();
            Console.WriteLine("Hello");
            get_transcations(bc);
            
        }
        public static void get_transcations(RadBankContext bc)
        {
            var getTranscations = from t in bc.Transcations
                                  join a in bc.Accounts on t.AccountID equals a.AccountID
                                  select new {t.TransactionID};                           
                                 
            foreach (var item in getTranscations)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
