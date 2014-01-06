using System;
using System.Text;

namespace Shopping_Center
{
    class ShoppingCenter
    {
        static void Main()
        {
            ProductRepository repo = new ProductRepository();
            int commandsCount = int.Parse(Console.ReadLine());
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < commandsCount; i++)
            {
                string commandLine = Console.ReadLine().Trim();
                int startParameters = commandLine.IndexOf(' ');
                string[] parameters = commandLine.Substring(startParameters+1).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = commandLine.Substring(0, startParameters);
                switch (command)
                {
                    case "AddProduct":
                            output.AppendLine(repo.AddProduct(parameters[0], double.Parse(parameters[1]),parameters[2]));
                        break;
                    case "DeleteProducts":
                        if (parameters.Length == 1)
	                    {
                            output.AppendLine(repo.DeleteProducts(parameters[0]));		 
	                    }
                        else
                        {
                            output.AppendLine(repo.DeleteProducts(parameters[1], parameters[0]));
                        }

                        break;
                    case "FindProductsByName":
                            output.AppendLine(repo.FindProducts("", parameters[0]));
                        break;
                    case "FindProductsByPriceRange":
                            output.AppendLine(repo.FindProducts("", "", double.Parse(parameters[0]),double.Parse(parameters[1])));
                        break;
                    case "FindProductsByProducer":
                            output.AppendLine(repo.FindProducts(parameters[0], ""));
                        break;
                }
            }
            Console.Write(output);
        }
    }
}
