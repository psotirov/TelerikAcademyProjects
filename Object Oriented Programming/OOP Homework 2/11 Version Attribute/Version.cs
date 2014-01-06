using System;

namespace _11_Version_Attribute
{
    [Version("1.0")] // sets class version
    class VersionTest
    {
        [Version("1.2")] // sets method version
        public static void Main() // Main method is set to public in order to access it through Reflection
        {
            Type thisClass = typeof(VersionTest); // gets class type via Reflection
            object[] thisAttributes = thisClass.GetCustomAttributes(true); // list of all custom attributes of this class
            if (thisAttributes.Length > 0) // checks if there are any attributes
            {
                Console.WriteLine("\r\nClass: " + thisClass.Name); // takes test class name
                Console.WriteLine((VersionAttribute)thisAttributes[0]); // here we are expecting to have only version attributes

                foreach (var item in thisClass.GetMethods()) // iterates through all public methods of the test class
                {
                    Console.WriteLine("\r\nMethod: " + thisClass.Name + "."+ item.Name); // takes current method name
                    thisAttributes = item.GetCustomAttributes(true); // list of all custom attributes of this method
                    // tests if the first attribute is version
                    if (thisAttributes[0] as VersionAttribute != null) Console.WriteLine((VersionAttribute)thisAttributes[0]);
                    else Console.WriteLine("No version info");
                }
            }

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }

        [Version("0.1")]
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
