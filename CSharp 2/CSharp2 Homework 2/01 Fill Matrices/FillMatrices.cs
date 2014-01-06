using System;

class FillMatrices
{
    static void Main()
    {
        Console.WriteLine("Task 01 - Fill the matrix with predefined pattern\n\n"+
                          "    1 - Vertical lines pattern\n"+
                          "    2 - Serpent pattern\n"+
                          "    3 - Diagonal pattern\n"+
                          "    4 - Spiral pattern\n");

        Console.Write("Please select one of the options [1,4]: ");

        const int SIZE = 4;
        int selection = 0;
        int.TryParse(Console.ReadLine(), out selection);

        int[,] matrix = new int[SIZE, SIZE];
        int value, row, col, direction;

        switch (selection)
        {
            case 1:
                for (col = 0; col < SIZE; col++)
                    for (row = 0; row < SIZE; row++)
			        {
			            matrix[row, col] = col * SIZE + row + 1;
			        }
                break;
            case 2:
                for (col = 0; col < SIZE; col++)
                    for (row = 0; row < SIZE; row++)
			        {
			            matrix[row, col] = col * SIZE + ((col%2 == 0)?row:(SIZE-row-1)) + 1; // direction depends on column iterator parity
			        }
                break;
            case 3:
                row = SIZE - 1;
                col = 0;
                value = 1;
                while (value <= SIZE * SIZE)
                {
                    matrix[row, col] = value++; // puts current value in current element
                    // moves diagonally
                    row++;
                    col++;

                    if (col == SIZE) // if current element is at the matrix right
                    {
                        col = SIZE + 1 - row;
                        row = 0;
                    }
                    if (row == SIZE) // if current element is at the matrix bottom
                    {
                        row = SIZE - 1 - col;
                        col = 0;
                    }

                }
                break;
            case 4:
                row = 0;
                col = 0;
                value = 1;
                direction = 0;
                while (value <= SIZE * SIZE)
                {
                    matrix[row, col] = value++; // puts current value in current element
                    switch (direction) // updates coordinates for the next move and changes direction if necessary
                    {
                        case 0: // Direction is down
                            row++;
                            if (row == (SIZE - 1) || matrix[row + 1, col] > 0) direction++; // Change direction to right;
                            break;
                        case 1: // Direction is right
                            col++;
                            if (col == (SIZE - 1) || matrix[row, col + 1] > 0) direction++; // Change direction to up;
                            break;
                        case 2: // Direction is up
                            row--;
                            if (row == 0 || matrix[row - 1, col] > 0) direction++; // Change direction to left
                            break;
                        case 3: // Direction is left
                            col--;
                            if (col == 0 || matrix[row, col - 1] > 0) direction = 0; // Change direction to down;
                            break;
                        default:
                            break;
                    }
                }
                break;
            default:
                Console.WriteLine("Bad choice!");
                break;
        }

        for (row = 0; row < SIZE; row++)
        {
            for (col = 0; col < SIZE; col++)
            {
                Console.Write("{0,2} ", matrix[row, col]);
            }
            Console.WriteLine();
        }

        Console.WriteLine("Press Enter to finish");
        Console.ReadLine();
    }
}

