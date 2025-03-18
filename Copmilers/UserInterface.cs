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
            return Console.ReadLine();
        }

        public static bool AskIfContinue()
        {
            string answer = GetUserInput("Do you want to enter another identifier? (y/n): ").ToLower();

            while (true)
            {
                if (answer == "y")
                {
                    return true;
                }
                else if (answer == "n")
                {
                    return false;
                }
                else
                {
                    ShowMessage("Invalid input. Please enter 'y' for yes or 'n' for no.");
                    answer = GetUserInput("Do you want to enter another identifier? (y/n): ").ToLower();
                }
            }
        }
    }


}
