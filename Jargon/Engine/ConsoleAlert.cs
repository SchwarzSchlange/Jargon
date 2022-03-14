using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jargon
{
    internal class ConsoleAlert
    {
        public static void Warning(string content)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now).ToLongTimeString()}] [Warning] => {content}");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void Success(string content)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now).ToLongTimeString()}] [Success] => {content}");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void Error(string content)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now).ToLongTimeString()}] [Error] => {content}");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void Info(string content)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[{TimeZone.CurrentTimeZone.ToLocalTime(DateTime.Now).ToLongTimeString()}] [Info] => {content}");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }


        public static void PrintTitle()
        {
            string text = @"


 _____                                            
/\___ \                                           
\/__/\ \     __     _ __    __     ___     ___    
   _\ \ \  /'__`\  /\`'__\/'_ `\  / __`\ /' _ `\  
  /\ \_\ \/\ \L\.\_\ \ \//\ \L\ \/\ \L\ \/\ \/\ \ 
  \ \____/\ \__/.\_\\ \_\\ \____ \ \____/\ \_\ \_\
   \/___/  \/__/\/_/ \/_/ \/___L\ \/___/  \/_/\/_/
                            /\____/               
                            \_/__/                


        ";

            Console.WriteLine(text);
        }
    }
}
