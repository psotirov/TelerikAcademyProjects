using System;
using System.Collections.Generic;

namespace Knapsack_Problem
{
    class KnapsackProblem
    {
        static int productsCount;
        static string[] products = { "whiskey", "beer", "vodka", "cheese", "ham", "nuts" };
        static int[] productWeights = { 8, 3, 8, 4, 2, 1 };
        static int[] productCosts = { 13, 2, 12, 5, 3, 4 };
        static Stack<int> result;

        static void Main()
        {
            Console.WriteLine("Knapsack problem\nSelect most valuable items with total weight below knapsack capacity\n");

            // prints all products
            Stack<int> allProducts = new Stack<int>();
            for (int i = products.Length-1; i >=0; i--)
            {
                allProducts.Push(i);
            }
            PrintProducts(allProducts);

            // solve knapsack problem
            int capacity = 10;
            Console.WriteLine("\n\nThe solution for capacity of {0}:", capacity);
            Stack<int> result = KnapsackSolve(capacity, products.Length);
            // prints the result
            PrintProducts(result);
        }

        static Stack<int> KnapsackSolve(int knapsackCapacity, int productsCount)
        {
            int[,] knapsack = new int[productsCount + 1, knapsackCapacity + 1];

            // using memoization approach of dynamic programming to solve 0/1 Knapsack problem
            // http://en.wikipedia.org/wiki/Knapsack_problem
            // Input:
            // Values (stored in array v)
            // Weights (stored in array w)
            // Number of distinct items (n)
            // Knapsack capacity (W)
            //for w from 0 to W do
            //  m[0, w] := 0
            //end for 
            //for i from 1 to n do
            //  for j from 0 to W do
            //    if j >= w[i] then
            //      m[i, j] := max(m[i-1, j], m[i-1, j-w[i]] + v[i])
            //    else
            //      m[i, j] := m[i-1, j]
            //    end if
            //  end for
            //end for

            for (int prodCounter = 1; prodCounter <= productsCount; prodCounter++)
            {
                for (int partialWeight = 0; partialWeight <= knapsackCapacity; partialWeight++)
                {
                    knapsack[prodCounter, partialWeight] = knapsack[prodCounter - 1, partialWeight];
                    if (partialWeight >= productWeights[prodCounter-1])
                    {
                        int newContent = knapsack[prodCounter - 1, partialWeight - productWeights[prodCounter-1]] + productCosts[prodCounter-1];
                        if (newContent > knapsack[prodCounter, partialWeight])
                        {
                            knapsack[prodCounter, partialWeight] = newContent;                          
                        }                        
                    }
                }
            }

            // return back from solution to first product in order to show the products
            result = new Stack<int>();

            // knapsack[productsCount, knapsackCapacity] contains the solution
            int cost = knapsack[productsCount, knapsackCapacity];

            for (int i = productsCount - 1; i >= 0; i--)
            {
                if (knapsack[i, knapsackCapacity] != cost && cost > 0)
                {
                    cost = cost - productCosts[i];
                    result.Push(i);
                }
            }

            return result;
        }

        static void PrintProducts(Stack<int> result)
        {
            int weight = 0;
            int cost = 0;
            while (result.Count > 0)
            {
                int productIndex = result.Pop();
                Console.WriteLine("Product: {0,15}, Weight: {1,3}, Cost: {2,3}",
                    products[productIndex], productWeights[productIndex], productCosts[productIndex]);
                weight += productWeights[productIndex];
                cost += productCosts[productIndex];
            }

            Console.WriteLine("\nTotal weight: {0}, Total cost: {1}\n\n", weight, cost);
        }
    }
}
