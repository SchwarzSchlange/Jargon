using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.Mail;

using System.Diagnostics;
using Microsoft.Win32;

namespace Jargon
{
    internal class Other
    {

 
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);




        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        private static Random random = new Random();


        public static MailMessage ePosta = new MailMessage();
      

        public static void HideWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }
        public static void ShowWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
        }


   


  
    }
}
