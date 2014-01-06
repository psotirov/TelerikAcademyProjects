using System;

namespace _01_Straight_line_code
{
    public class Chef
    {
        private Bowl GetBowl()
        {
            Bowl result = new Bowl();
            // some code
            return result;
        }

        private Carrot GetCarrot()
        {
            Carrot result = new Carrot();
            // some code
            return result;
        }

        private Potato GetPotato()
        {
            Potato result = new Potato();
            // some code
            return result;
        }


        public void Cook()
        {
            Bowl bowl = new Bowl();

            Potato potato = GetPotato();
            potato.Peel();
            potato.Cut();
            bowl.Add(potato);

            Carrot carrot = GetCarrot();
            carrot.Peel();
            carrot.Cut();
            bowl.Add(carrot);

            // some code for boiling, etc
        }

        static void Main(string[] args)
        {
        }
    }
    
    public class Bowl
    {
        public void Add(Vegetable vegetable)
        {
        }
    }

    public class Vegetable
    {
        public void Peel()
        {
        }

        public void Cut()
        {
        }
    }

    public class Carrot : Vegetable
    {
    }

    public class Potato : Vegetable
    {
    }
}
