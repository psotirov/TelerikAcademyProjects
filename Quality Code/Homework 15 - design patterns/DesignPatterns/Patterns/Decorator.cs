﻿using System;

namespace Patterns
{
    class Decorator
    {
        interface IComponent
        {
            string Operation();
        }
 
        class Component : IComponent
        {
            public string Operation()
            {
                return "I am walking ";
            }
        }
 
        class DecoratorA : IComponent
        {
            IComponent component;
 
            public DecoratorA(IComponent c)
            {
                component = c;
            }
 
            public string Operation()
            {
                string s = component.Operation();
                s += "and listening radio ";
                return s;
            }
        }
 
        class DecoratorB : IComponent
        {
            IComponent component;
            public string addedState = "past the Coffee Shop ";
  
            public DecoratorB(IComponent c)
            {
                component = c;
            }
 
            public string Operation()
            {
                string s = component.Operation();
                s += "to school ";
                return s;
            }
 
            public string AddedBehavior()
            {
                return "and I bought a cappuccino ";
            }
        }
 
        public class Client
        { 
            void Display(string s, IComponent c)
            { 
                Console.WriteLine(s + c.Operation());
            } 
 
            public void DecoratorExample()
            {
                Console.WriteLine ( "Decorator Pattern\n" );
 
                IComponent component = new Component ();
                Display ( "1. Basic component: ", component );
                Display ( "2. A-decorated : ", new DecoratorA ( component ) );
                Display ( "3. B-decorated : ", new DecoratorB ( component ) );
                Display ( "4. B-A-decorated : ", new DecoratorB ( new DecoratorA ( component ) ) );

                // Explicit DecoratorB
                DecoratorB b = new DecoratorB ( new Component () );
                Display ( "5. A-B-decorated : ", new DecoratorA ( b ) );
                // Invoking its added state and added behavior
                Console.WriteLine ( "\t\t\t" + b.addedState + b.AddedBehavior() );
                        
                /* Output
                Decorator Pattern
 
                1. Basic component: I am walking 
                2. A-decorated : I am walking and listening to Classic FM - 
                3. B-decorated : I am walking to school
                4. B-A-decorated : I am walking and listening to Classic FM to school
                5. A-B-decorated : I am walking to school and listening to Classic FM
                                                    past the Coffee Shop and I bought a cappuccino
                */
            }
        }
    }
}

