using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Phonebook
{
    /// <summary>
    /// Phonebook Application
    /// </summary>
    public class PhonebookApplication
    {
        private const string InternationalCode = "+359";
        private static readonly IPhonebookRepository phonebook = new PhonebookRepository();
        private static readonly StringBuilder applicationOutput = new StringBuilder();

        /// <summary>
        /// Program's entry point
        /// </summary>
        public static void Main()
        {
            // Console redirection for test purposes
            /*
            string inputFilename = @"..\..\..\..\Phonebook-Tests\test.010.in.txt";
            StreamReader inTest = new StreamReader(inputFilename);
            Console.SetIn(inTest); // redirects console input from test file
            */

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End" || inputLine == null)
                {
                    break;
                }

                int startParametersList = inputLine.IndexOf('(');
                if (startParametersList == -1 || !inputLine.EndsWith(")"))
                {
                    throw new FormatException("Command's parameters list must be surrounded by braces");
                }

                string command = inputLine.Substring(0, startParametersList);
                string parametersList = inputLine.Substring(startParametersList + 1, inputLine.Length - startParametersList -2);
                string[] commandParameters = parametersList.Split(',');
                for (int j = 0; j < commandParameters.Length; j++)
                {
                    commandParameters[j] = commandParameters[j].Trim();
                }

                if (commandParameters.Length < 2)
                {
                    throw new FormatException("Command's parameters list must be at least 2");
                }

                switch (command)
                {
                    case "AddPhone":
                        AddPhoneCommand(commandParameters);
                        break;
                    case "ChangePhone":
                        ChangePhoneCommand(commandParameters);
                        break;
                    case "List":
                        ListCommand(commandParameters);
                        break;
                    default:
                        throw new ApplicationException("Unknown Command");
                }
            }

            Console.Write(applicationOutput);
        }

        /// <summary>
        /// Executes AddPhone command
        /// </summary>
        /// <param name="parameters">
        /// array of string arguments:
        /// first argument - Person's name as string
        /// one or more additional arguments - Person's phone number(s)
        /// </param>
        private static void AddPhoneCommand(string[] parameters)
        {
            string personName = parameters[0];
            var personPhones = parameters.Skip(1).ToList();
            for (int i = 0; i < personPhones.Count; i++)
            {
                personPhones[i] = ConvertPhoneNumber(personPhones[i]);
            }

            bool isNewEntry = phonebook.AddPhone(personName, personPhones);

            if (isNewEntry)
            {
                Print("Phone entry created");
            }
            else
            {
                Print("Phone entry merged");
            }
        }

        /// <summary>
        /// Executes ChangePhone command
        /// </summary>
        /// <param name="parameters">
        /// array of string arguments:
        /// first argument - existing phone number
        /// second argument - new phone number
        /// /// </param>
        private static void ChangePhoneCommand(string[] parameters)
        {
            int entriesChanged = phonebook.ChangePhone(ConvertPhoneNumber(parameters[0]), ConvertPhoneNumber(parameters[1]));
            Print("" + entriesChanged + " numbers changed");
        }

        /// <summary>
        /// Executes List command
        /// </summary>
        /// <param name="parameters">
        /// array of string arguments:
        /// first argument - starting index of Phonebook entries' repository
        /// second argument - number of Phonebook entries
        /// /// </param>
        private static void ListCommand(string[] parameters)
        {
            int start = int.Parse(parameters[0]);
            int count = int.Parse(parameters[1]);
            IEnumerable<PhonebookEntry> entries = phonebook.ListEntries(start, count);
            if (entries !=  null)
        	{
                foreach (var entry in entries)
                {
                    Print(entry.ToString());
                }
            }
            else
            {
                Print("Invalid range");
            }
        }

        /// <summary>
        /// Converts a phone number in its cannonical format
        /// </summary>
        /// <param name="phoneNumber">phone number to convert</param>
        /// <returns>cannonical phone number, i.e. +359xxxxxxxxxxx</returns>
        private static string ConvertPhoneNumber(string phoneNumber)
        {
            StringBuilder result = new StringBuilder();
            // The Following lines of code form application bottleneck
            // due to big amount of unnecessary repetitions
            /*
            for (int i = 0; i <= applicationOutput.Length; i++)
            {
                result.Clear();
                foreach (char symbol in phoneNumber)
                {
                    if (char.IsDigit(symbol) || (symbol == '+'))
                    {
                        result.Append(symbol);
                    }
                }

                if (result.Length >= 2 && result[0] == '0' && result[1] == '0')
                {
                    result.Remove(0, 1);
                    result[0] = '+';
                }

                while (result.Length > 0 && result[0] == '0')
                {
                    result.Remove(0, 1);
                }

                if (result.Length > 0 && result[0] != '+')
                {
                    result.Insert(0, InternationalCode);
                }

                result.Clear();
                foreach (char symbol in phoneNumber)
                {
                    if (char.IsDigit(symbol) || (symbol == '+'))
                    {
                        result.Append(symbol);
                    }
                }

                if (result.Length >= 2 && result[0] == '0' && result[1] == '0')
                {
                    result.Remove(0, 1);
                    result[0] = '+';
                }

                while (result.Length > 0 && result[0] == '0')
                {
                    result.Remove(0, 1);
                }

                if (result.Length > 0 && result[0] != '+')
                {
                    result.Insert(0, InternationalCode);
                }

                result.Clear();
                */
                foreach (char symbol in phoneNumber)
                {
                    if (char.IsDigit(symbol) || (symbol == '+'))
                    {
                        result.Append(symbol);
                    }
                }

                if (result.Length >= 2 && result[0] == '0' && result[1] == '0')
                {
                    result.Remove(0, 1);
                    result[0] = '+';
                }

                while (result.Length > 0 && result[0] == '0')
                {
                    result.Remove(0, 1);
                }

                if (result.Length > 0 && result[0] != '+')
                {
                    result.Insert(0, InternationalCode);
                }
            //} // End of unnecessary loop above
            return result.ToString();
        }

        /// <summary>
        /// Prints single line message to the output queue
        /// </summary>
        private static void Print(string outputLine)
        {
            applicationOutput.AppendLine(outputLine);
        }
    }
}
