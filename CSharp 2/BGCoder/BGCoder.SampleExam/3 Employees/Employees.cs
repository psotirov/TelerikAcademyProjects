using System;

class Employees
{
    static void Main()
    {
        int posN = int.Parse(Console.ReadLine()); // number of positions

        string[] position = new string[posN]; 
        int[] rate = new int[posN];
        for (int i = 0; i < posN; i++) // reading positions and rate
        {
            string[] line = Console.ReadLine().Split('-');
            position[i] = line[0].Trim();
            rate[i] = int.Parse(line[1].Trim());
        }

        int persM = int.Parse(Console.ReadLine()); // number of persons

        string[,] names = new string[2,persM];
        int[] rates = new int[persM];
        for (int i = 0; i < persM; i++) // reading person names and positions and sumiltaneously set their rate
        {
            string[] line = Console.ReadLine().Split('-'); // splits names and position
            string[] nms = line[0].Trim().Split(' '); // split first name and family from name
            names[0, i] = nms[0];
            names[1, i] = nms[1];
            line[1] = line[1].Trim();

            int idx = 0;
            while (position[idx] != line[1]) idx++; // finds corresponding position in first set of arrays
            rates[i] = rate[idx]; // set employee's rate
        }

        for (int i = 0; i < persM; i++)
        {
            int max = i;
            for (int j = i+1; j < persM; j++)
            {
                if (rates[max] < rates[j] ||  // looking for the best rate
                    (rates[max] == rates[j] && (names[1, max].CompareTo(names[1, j]) > 0 || // or if equal rate - "smaller" family name
                    (names[1, max].CompareTo(names[1, j]) == 0 && names[0, max].CompareTo(names[0, j]) > 0)))) // or if equal family name - "smaller" first name
                {
                    max = j;
                }
            }
            Console.WriteLine(names[0, max] + " " + names[1, max]);
            if (max != i) // move first element to its position
            {
                rates[max] = rates[i];
                names[0, max] = names[0, i];
                names[1, max] = names[1, i];
            }
        }
 
    }
}
