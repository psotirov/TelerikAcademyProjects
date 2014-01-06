using System;

class AirplaneDrinks
{
    static void Main()
    {
        // temporary console input redirection
        // Console.SetIn(new System.IO.StreamReader("test.003.in.txt"));

        // reads formatting parameters
        int passengersN = int.Parse(Console.ReadLine());
        int teaDrinkers = int.Parse(Console.ReadLine());

        sbyte[] planeMap = new sbyte[passengersN+1];
        // creates an array of all seats in the plane
        // Possible values are: 0 - passenger ordered coffee, 1 = passenger ordered tea 

        for (int i = 0; i < teaDrinkers; i++)
        {
             planeMap[int.Parse(Console.ReadLine())] = 1; // sets tea drinkers position (all others are cofee drinkers since 0 is default)
        }

        long timeSpent = 4 * passengersN; // the serving time spent initially counts only serving time ( 4 sec per passenger - constant)
        int lastTeaDrinker = 0;
        int lastCoffeeDrinker = 0;
        int flaskTea = 0;
        int flaskCoffee = 0;

        for (int pos = passengersN; pos > 0; pos--) // iterates through plane seat from tail to the cockpit
        {
            if (planeMap[pos] > 0) // we have tea drinker
            {
                if (pos > lastTeaDrinker) lastTeaDrinker = pos; // updates last position of tea drinker
                flaskTea++; // counts until a full flask orders was collected 
            }
            else // we have coffee drinker
            {
                if (pos > lastCoffeeDrinker) lastCoffeeDrinker = pos; // updates last position of tea drinker
                flaskCoffee++; // counts until a full flask orders was collected 
            }


            if (flaskTea == 7 || (pos == 1 && flaskTea > 0)) // stewardess has collected a full/last flask order for tea
            {
                timeSpent += lastTeaDrinker * 2 + 47; // she takes full flask, goes to the far tea drinker position and then returns to the cockpit
                lastTeaDrinker = 0; // clears last tea drinker position, next time it should be updated if there is at least one not served
                flaskTea = 0; // the flask is empty again
            }

            if (flaskCoffee == 7 || (pos == 1 && flaskCoffee > 0)) // stewardess has collected a full/last flask order for coffee
            {
                timeSpent += lastCoffeeDrinker * 2 + 47; // she takes full flask, goes to the far coffee drinker position and then returns to the cockpit
                lastCoffeeDrinker = 0; // clears last coffee drinker position, next time it should be updated if there is at least one not served 
                flaskCoffee = 0; // the flask is empty again
            }
        }
 
        // prints the output
        Console.WriteLine(timeSpent);
    }
}