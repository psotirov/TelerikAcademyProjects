using System;
using System.Collections.Generic;
using System.IO;

namespace Frames
{
    public struct Frame
    {
        public int X;
        public int Y;

        public Frame(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Flip()
        {
            if (this.X == this.Y)
            {
                return false;
            }

            int temp = this.X;
            this.X = this.Y;
            this.Y = temp;
            return true;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }

    class Frames
    {
        static Frame[] frames;
        static SortedSet<string> result = new SortedSet<string>();

        static void Main()
        {
            // Console.SetIn(new StreamReader(@"..\..\input.txt"));
            GetInput();

            PutPermutations("", 0);
            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void GetInput()
        {
            int framesCount = int.Parse(Console.ReadLine().Trim());
            frames = new Frame[framesCount];
            for (int i = 0; i < framesCount; i++)
            {
                string[] dimensions = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int x = int.Parse(dimensions[0]);
                int y = int.Parse(dimensions[1]);
                frames[i] = new Frame(x,y);
            }
        }

        static void PutPermutations(string output, int index)
        {
            if (index == frames.Length)
            {
                if (!result.Contains(output))
                {
                    result.Add(output);
                }
                return;
            }

            if (output.Length > 0)
            {
                output += " | ";
            }

            PutPermutations(output + frames[index].ToString(), index + 1);
            if (frames[index].Flip())
            {
                PutPermutations(output + frames[index].ToString(), index + 1);
                frames[index].Flip();
            }

            for (int i = index+1; i < frames.Length; i++)
            {
                SwapFrame(index, i);
                PutPermutations(output + frames[index].ToString(), index + 1);
                if (frames[index].Flip())
                {
                    PutPermutations(output + frames[index].ToString(), index + 1);
                    frames[index].Flip();
                }

                SwapFrame(index, i);
            }
        }

        static void SwapFrame(int i, int j)
        {
            Frame temp = frames[i];
            frames[i] = frames[j];
            frames[j] = temp;
        }
    }
}
