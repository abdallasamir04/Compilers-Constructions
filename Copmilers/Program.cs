using Copmilers;
using System;
using System.Collections.Generic;


    public class Program
    {
        public static void Main()
        {
            bool continueInput = true;

            while (continueInput)
            {
                string userInput = UserInterface.GetUserInput("Please enter an identifier: ");
                string identifier = IdentifierValidator.GetIdentifier(userInput);

                if (identifier != null)
                {
                    if (ReservedWordsManager.IsReservedWord(identifier))
                    {
                        UserInterface.ShowMessage($"'{identifier}' is a reserved word, not a user-defined identifier.");
                    }
                    else
                    {
                        UserInterface.ShowMessage($"Valid identifier: {identifier}");
                    }
                }
                else
                {
                    UserInterface.ShowMessage("Invalid identifier. An identifier must start with a letter and can contain letters and digits.");
                }

                continueInput = UserInterface.AskIfContinue();
            }

            UserInterface.ShowMessage("Thanks For Using Our Scanner :)");
        }
    }


