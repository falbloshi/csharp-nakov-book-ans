using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;


class Maze
{

    static void Main()
    {
        string[,] myMaze = new String[,]
        {

            {"0", "0", "0", "x", "0", "x"} ,
            {"0", "x", "0", "x", "0", "x"} ,
            {"0", "*", "x", "0", "x", "0"} ,
            {"0", "x", "0", "0", "0", "0"} ,
            {"0", "0", "0", "x", "x", "0"} ,
            {"0", "0", "0", "x", "0", "x"} ,

        };
 
        //[1,2] 1-leftside is rows, 2-right side is column
        //here i is rows, j is column
        //however, use x as column, and y as rows

        MazeTraversal(myMaze);
        for (var i = 0; i < myMaze.GetLength(0); i++)
        {
            for (var j = 0; j < myMaze.GetLength(1); j++)
            {
                if (!String.IsNullOrEmpty(myMaze[i, j]))
                {
                    if (j > 0)
                    {
                        Console.Write(myMaze[i, j].ToString().PadLeft(4));
                    }
                    else
                    {
                        Console.Write(myMaze[i, j].ToString());
                    }

                }
            }
            Console.WriteLine();
        }
    }

    public class Pos
    {
        public int X;
        public int Y;

        public Pos(int y, int x)
        {
            X = x;
            Y = y;
        }
    }

    public class PosWithN
    {
        public Pos pos;
        public int parentNumber;

        public PosWithN(int parNo, Pos posN)
        {
            this.parentNumber = parNo;
            this.pos = posN;
        }
    }

    public static void MazeTraversal(String[,] matrix)
    {

        //x on the right side (col)
        //y on the left side (row)
        int number = 1;
        string path = "0";
        Queue<PosWithN> posQ = new Queue<PosWithN>();

        //initializing starting position
        posQ.Enqueue(new PosWithN(number, new Pos(2, 1)));

        //-1.north +1.south
        int[] rowP = {-1, +1, 0, 0};
        //-1.west +1.east
        int[] colP = {0, 0, -1, +1};

        while(posQ.Count != 0)
        {
            PosWithN cPos = posQ.Dequeue();
            int y = cPos.pos.Y;
            int x = cPos.pos.X;
            int cNumber = cPos.parentNumber;

            Console.WriteLine($"=== Coordinate [{y}, {x}] ===");


            for(var i = 0; i < 4; i++)
            {
                int row = y + rowP[i];
                int col = x + colP[i];


                //debug
                string Loc;
                if(rowP[i] != 0) Loc = (rowP[i] > 0) ? "South" : "North"; 
                else Loc = (colP[i] > 0) ? "East" : "West"; 
                //debug

                if((row >= 0 && col >= 0) && (row < matrix.GetLength(0) && col < matrix.GetLength(1)) )
                {       
                    
                    //debug
                    Console.WriteLine($"Checking {Loc} = {matrix[row, col]}");
                    
                    if(matrix[row, col] == path){
                        matrix[row, col] = cNumber.ToString();
                        posQ.Enqueue(new PosWithN(cNumber + 1, new Pos(row, col)));

                        //debug
                        Console.WriteLine($"Adding {Loc} coordinate [{row}, {col}] to queue");
                        
                    }
                }
                else
                {
                    //debug
                    Console.WriteLine($"{Loc} is out of bounds");
                }
            }
            Console.WriteLine("=== New Loop ===");
        }  

    }
}