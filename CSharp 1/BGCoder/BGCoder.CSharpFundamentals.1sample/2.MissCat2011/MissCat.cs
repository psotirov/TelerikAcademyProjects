using System;

class MissCat
{
    static void Main()
    {
        int[] catVotes = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // initial votes per each of all 10 cats is 0 

        int voters = int.Parse(Console.ReadLine()); // reads number of voters 

        for (int i = 0; i < voters; i++) // Loop to enter votes
        {
            int vote = int.Parse(Console.ReadLine()); // obtains the vote
            catVotes[vote-1]++; // assigns to respective cat 
        }

        int result = 0; // assumes that cat Nr.1 is the winner
        for (int i = 1; i < 10; i++) // iterates through all other cats
        {
            if (catVotes[i] > catVotes[result]) result = i; // if i-th cat has greater vote than current she becomes a temporary winnner 
        }

        Console.WriteLine(result+1);
    }
}

