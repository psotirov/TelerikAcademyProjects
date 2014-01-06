using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class FreeContentCatalog
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog cat = new Catalog();
            ICommandExecutor c = new CommandExecutor();

            foreach (ICommand item in Parse())
            {
                c.ExecuteCommand(cat, item, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> Parse()
        {
            List<ICommand> inputSequence = new List<ICommand>();
            bool isFinished = false;

            while (!isFinished)
            {
                string inputLine = Console.ReadLine();
                isFinished = (inputLine.Trim() == "End");
                if (!isFinished)
                {
                    inputSequence.Add(new Command(inputLine));
                }
            }

            return inputSequence;
        }
    }
}
