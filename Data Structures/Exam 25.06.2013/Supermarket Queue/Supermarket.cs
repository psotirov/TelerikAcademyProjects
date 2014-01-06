using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Supermarket_Queue
{
    public class SupermarketQueue
    {
        const string OK = "OK";
        const string Error = "Error";

        private List<string> queue;
        private Dictionary<string, int> names;

        public SupermarketQueue()
        {
            queue = new List<string>();
            names = new Dictionary<string, int>();
        }

        public string Append(string name)
        {
            queue.Add(name);
            this.AppendName(name);
            return OK;
        }

        private void AppendName(string name)
        {
            if (!names.ContainsKey(name))
            {
                names.Add(name, 1);
            }
            else
            {
                names[name]++;
            }
        }

        public string Insert(int position, string name)
        {
            if (position < 0 || position > queue.Count)
            {
                return Error;
            }

            if (position == queue.Count)
            {
                return this.Append(name);
            }

            queue.Insert(position, name);
            this.AppendName(name);
            return OK;
        }

        public string Find(string name)
        {
            int count = 0;
            if (names.ContainsKey(name))
            {
                count = names[name];
            }

            return count.ToString();
        }

        public string Serve(int count)
        {
            if (count < 1 || count > queue.Count )
            {
                return Error;
            }

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (output.Length > 0)
                {
                    output.Append(" ");
                }

                string name = queue[i];
                output.Append(name);
                this.RemoveName(name);
            }

            queue.RemoveRange(0, count);

            return output.ToString();
        }

        private void RemoveName(string name)
        {
            names[name]--;
            if (names[name] == 0)
            {
                names.Remove(name);                
            }
        }
    }

    class Supermarket
    {
        static void Main(string[] args)
        {
            SupermarketQueue queue = new SupermarketQueue();
            StringBuilder output = new StringBuilder();

            // Console.SetIn(new StreamReader(@"..\..\input.txt"));
            while (true)
	        {
                string[] command = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string result = "";
                switch (command[0])
                {
                    case "Append": result = queue.Append(command[1]); break;
                    case "Insert": result = queue.Insert(int.Parse(command[1]), command[2]); break;
                    case "Find": result = queue.Find(command[1]); break;
                    case "Serve": result = queue.Serve(int.Parse(command[1])); break;
                    case "End": Console.WriteLine(output); return;
                }

                output.AppendLine(result);
	        }
        }
    }
}
