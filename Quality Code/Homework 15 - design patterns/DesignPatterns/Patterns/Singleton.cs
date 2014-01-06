using System;

namespace Patterns
{
    // Lazy Initialization - on demand
    public class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    /* Eager Initialization - on start-up
     
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
   
        private Singleton(){}

        public static Singleton Instance
        {
            get 
            {
                return instance; 
            }
        }
    }
     */
}
