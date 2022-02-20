using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalResponsibilityPrincipleDemo
{
    public class ShowMessage
    {
        // 印出訊息的功能
        public static void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome");
        }

        public static void ShowEndMessage()
        {
            Console.WriteLine("Press any button to exit.");
            Console.ReadLine();
        }

        public static void ShowErrorMessage(string message)
        {
            Console.WriteLine($"You don't give us a valid {message}.");
        }
    }
}
