using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DarrayA1
{
    class Program
    {


        // 2D Array Assignment 1

        // initialized 2d array for use in part 1 and 2
        static int[,] part1;
        // part 1
        static int[,] generateMatrix()
        {
            // getting dimensions
            Console.WriteLine("what are the dimensions of your array?");
            Console.Write("Width: ");
            string w = Console.ReadLine();
            int wnum = Int32.Parse(w);
            Console.Write("Length: ");
            string l = Console.ReadLine();
            int lnum = Int32.Parse(l);
            

            // creating arrays using user input
            int[,] grid1 = new int[lnum, wnum];

            // fills array with random numbers
            var rand = new Random();
            for (int y = 0; y < lnum; y++)
            {
                for (int x = 0; x < wnum; x++)
                {
                    grid1[y, x] = rand.Next(0, 10); 
                }
            }

            // prints arrays
            for (int y = 0; y < lnum; y++)
            {
                for (int x = 0; x < wnum; x++)
                {
                    Console.Write(grid1[y, x] + " ");
                }
                Console.WriteLine("");
            }

            return grid1;

        }
        //====================================================================================================
        // part 2
        static int[,] generateTranspose(int[,] grid2a)
        {
            // getting array dimensions
            int l = grid2a.GetLength(0); // gets # of rows
            int w = grid2a.GetLength(1); // gets # of columns
            //Console.WriteLine(l);
            //Console.WriteLine(w);

            int[,] grid2b = new int[w, l];
            // transposing
            for (int y = 0; y < w; y++)
            {
                for (int x = 0; x < l; x++)
                {
                    grid2b[y, x] = grid2a[x, y];
                }
            }

            // prints array
            for (int y = 0; y < w; y++)
            {
                for (int x = 0; x < l; x++)
                {
                    Console.Write(grid2b[y, x] + " ");
                }
                Console.WriteLine("");
            }

            return grid2b;
        }
        //======================================================================================================
        // part 3
        static int[,] multiplyMatricByConstant()
        {
            
            // user input and creating initial array
            Console.Write("Input the constant to multiply by: ");
            string input2 = Console.ReadLine();
            int con = Int32.Parse(input2);
            int[,] part3 = generateMatrix();
            
            // gets dimentions
            int l = part3.GetLength(0);
            int w = part3.GetLength(1);

            // prints array showing the multiplication
            Console.WriteLine("Your array with multiplication steps: ");
            for (int y = 0; y < l; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.Write(part3[y, x] + "*" + input2 + "  ");
                }
                Console.WriteLine("");
            }
            // multiplys array           
            for (int y = 0; y < l; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    part3[y, x] = part3[y, x] * con;
                }
            }
            // prints array
            Console.WriteLine("Your array after the multiplication process: ");
            for (int y = 0; y < l; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.Write(part3[y, x] + " ");
                }
                Console.WriteLine("");
            }
            // I could make it a "void" method, but I did not in case I need to change it to have a return value
            return null;
        }
        //=========================================================================================================
        // part 4
        static int[,] multiplyMatrix()
        {
            // this was the incorrect version, but I coded both blocks just in case
            // creating two random arrays with user's dimensions
            /*
            Console.WriteLine("2 arrays will be generated for this matrix multiplication");
            Console.WriteLine("Array 1:");
            int[,] ARY1 = generateMatrix();
            Console.WriteLine("Array 2:");
            int[,] ARY2 = generateMatrix();
            // get dimensions for AR1
            int R1 = ARY1.GetLength(0);
            int C1 = ARY1.GetLength(1);
            // get dimensions for AR2
            int R2 = ARY2.GetLength(0);
            int C2 = ARY2.GetLength(1);
            */
            

            // creating one random array with user dimensions and other array will be the transposed version of it
            
            Console.WriteLine("One array will be generated and the other will be the transposed version of it");
            Console.WriteLine("Array 1:");
            int[,] ARY1 = generateMatrix();
            Console.WriteLine("Array 2:");
            int[,] ARY2 = generateTranspose(ARY1);
            // get dimensions for AR1
            int R1 = ARY1.GetLength(0);
            int C1 = ARY1.GetLength(1);
            // get dimensions for AR2
            int R2 = ARY2.GetLength(0);
            int C2 = ARY2.GetLength(1);
            


            // creating final array
            int[,] ARY3 = new int[R1, C2];

            //doing calculations for final array
            for (int a = 0; a < R1; a++)
            {
                for (int b = 0; b < C2; b++)
                {
                    ARY3[a, b] = 0;
                    for (int c = 0; c < C1; c++)
                    {
                        ARY3[a, b] = ARY3[a, b] + ARY1[a, c] * ARY2[c, b];
                    }
                }
            }

            // prints final array
            Console.WriteLine("the multiplied array is:");

            for (int y = 0; y < R1; y++)
            {
                for (int x = 0; x < C2; x++)
                {
                    Console.Write(ARY3[y, x] + " ");
                }
                Console.WriteLine("");
            }

                // I could make it a "void" method, but I did not in case I need to change it to have a return value
                return null;
        }
        //=================================================================================================================

        // main method
        static void Main(string[] args)
        {
            // the menu
            Console.WriteLine("-----Welcome To The Matrix Program!-----");
            // dec
            string input1 = "0";
            int errorcatch = 0;
            // the repeating part of the menu
            do
            { 
                Console.WriteLine("Please select one of the following options:");
                Console.WriteLine("1: The Random Matrix");
                Console.WriteLine("2: The Transpose Matrix");
                Console.WriteLine("3: Multiplying a Matrix by a Constant");
                Console.WriteLine("4: Multiplying Two Matrices");
                Console.WriteLine("5: Quit");
                Console.Write("Your choice is: ");
                // declaring input veriable
                input1 = Console.ReadLine();
                
                if (input1 == "1")
                {
                    // part 1
                    errorcatch = 1;
                    part1 = generateMatrix();
                }
                
                 if (input1 == "2")
                {
                    // part 2
                    if (errorcatch == 0)
                    {
                        Console.WriteLine("you must generate an array first. Select 1 in the menu to do that");
                    }
                    else
                    {
                        generateTranspose(part1);
                    }
                }
                if (input1 == "3")
                {
                    // part 3
                    multiplyMatricByConstant();
                }
                if (input1 == "4")
                {
                    // part 4
                    multiplyMatrix();
                }
                if (input1 == "5")
                 {
                    // quits
                    // two mesuares to quit:
                    // 1: the following "return;" code will end this method
                    // 2: the do while loop will realize the condition is no longer true
                    return; 
                 }
            } while (input1 != "5");
        }
    }
}
