using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copmilers
{
    public class UserInterface
    {
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }


    }


}
