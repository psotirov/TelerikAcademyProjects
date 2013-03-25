﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Program
    {
        static Engine GetEngineInstance()
        {
            return new ExtendedEngine();
        }

        static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }

            /*using (StreamReader sr = new StreamReader(@"..\..\..\..\sample-input.txt"))
            {
                string command = sr.ReadLine();
                while (command != "end")
                {
                    engine.ExecuteCommand(command);
                    command = sr.ReadLine();
                }
            }

            Console.ReadLine();*/
        }
    }
}
