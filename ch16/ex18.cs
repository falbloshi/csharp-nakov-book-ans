using System;
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


    //position x y
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


    //position with parent number
    public class PosWithN
    {
        public Pos pos;
        public int parentNumber;

        public PosWithN(int parentNumber, Pos pos)
        {
            this.parentNumber = parentNumber;
            this.pos = pos;
        }
    }

    public static Pos FindStartPoint(String[,] matrix)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == "*")
                {
                    return new Pos(i, j);
                }
            }
        }
        return null;
    }

    public static void MazeTraversal(String[,] matrix)
    {

        //x on the right side (col)
        //y on the left side (row)
        int number = 1;
        string path = "0";
        Pos startingPoint = FindStartPoint(matrix);
        Queue<PosWithN> posQ = new Queue<PosWithN>();

        //initializing starting position
        posQ.Enqueue(new PosWithN(number, startingPoint));

        //-1.north +1.south
        int[] rowP = { -1, +1, 0, 0 };
        //-1.west +1.east
        int[] colP = { 0, 0, -1, +1 };

        while (posQ.Count != 0)
        {
            //current position with number
            PosWithN cPos = posQ.Dequeue();
            int y = cPos.pos.Y;
            int x = cPos.pos.X;
            int cNumber = cPos.parentNumber;

            for (var i = 0; i < 4; i++)
            {
                //adding new coordinates with new starting point with its cardinal locations
                int row = y + rowP[i];
                int col = x + colP[i];



                //check if it is out of bounds
                if ((row >= 0 && col >= 0) && (row < matrix.GetLength(0) && col < matrix.GetLength(1)))
                {
                    //if it is within bound 
                    //check if it is a path
                    if (matrix[row, col] == path)
                    {
                        //if it is, add the current number
                        matrix[row, col] = cNumber.ToString();

                        //enque current direction, including the parent number + 1
                        posQ.Enqueue(new PosWithN(cNumber + 1, new Pos(row, col)));

                    }
                }

            }

        }

    }
}