/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_Queue
{
    public class SupermarketQueue
    {
        const string OK = "OK";
        const string Error = "Error";

        private LinkedList<string> queue;
        private Dictionary<string, int> names;

        public SupermarketQueue()
        {
            queue = new LinkedList<string>();
            names = new Dictionary<string, int>();
        }

        public string Append(string name)
        {
            queue.AddLast(name);
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

            if (position <= queue.Count / 2)
            {
                LinkedListNode<string> pos = queue.First;
                for (int i = 0; i < position; i++)
                {
                    pos = pos.Next;
                }
                queue.AddBefore(pos, name);
            }
            else
            {
                LinkedListNode<string> pos = queue.Last;
                for (int i = queue.Count - 1; i > position; i--)
                {
                    pos = pos.Previous;
                }
                queue.AddBefore(pos, name);
            }

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
            if (count < 1 || count > queue.Count)
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

                string name = queue.First.Value;
                output.Append(name);
                queue.RemoveFirst();
                this.RemoveName(name);
            }

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

            //Console.SetIn(new StreamReader(@"..\..\input.txt"));
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
}*/