using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMemoryPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("put long of the board");

            int numBoard = int.Parse(Console.ReadLine());
            while (numBoard % 2 != 0)
            {
                Console.WriteLine("the length you put is not available, put new long of the board");
                numBoard = int.Parse(Console.ReadLine());
            }

            int[,] boardd;
            int sum = 0;
            int sum1 = 0;
            boardd=creatBoard(numBoard);
            bool flag = true;

            while (flag == true)
            {
                sum = round1(boardd, sum, numBoard);
                flag = cheke(boardd, numBoard);
                if (flag == false)
                    break;
                sum1 = round2(boardd, sum1, numBoard);
                flag = cheke(boardd, numBoard);
            }
            if (sum1 > sum)
                Console.WriteLine("the winner is player 2");
            else if (sum > sum1)
                Console.WriteLine("the winner is player 1");
            else
                Console.WriteLine("the game end in tiko");
            //  printBoard(boardd, numBoard);

            Console.ReadLine();
        }
        public static int[,] creatBoard(int numBoard)
        {
            /*   int[,] board = new int[numBoard, numBoard];
               int card;
               Random rnd = new Random();
               for (int i = 0; i < numBoard; i++)
               {
                   for (int j = 0; j < numBoard; j++)
                   {
                       card = rnd.Next(0, (numBoard * numBoard) / 2);
                       board[i, j] = card;
                       Console.Write(board[i, j]);
                   }
                   Console.WriteLine();
               }
               return board;*/
            Console.WriteLine("For the cheker: I print the cards of board to cheke that the program work corectly, its can be ereas in easy");
            int[,] board = new int[numBoard, numBoard];
            int card=0;
            Random rnd = new Random();
            for (int i = 0; i < numBoard; i++)
            {
                for (int j = 0; j < numBoard; j++)
                {
                    if (j % 2 == 0)
                        card++;
                    board[i, j] = card;
                    Console.Write(board[i, j]+"\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < (numBoard * 2); i++)
            { 
            int capit1 = rnd.Next(0,numBoard);
            int capit2 = rnd.Next(0, numBoard);
            int capit3 = rnd.Next(0, numBoard);
            int capit4 = rnd.Next(0, numBoard);
                int saver = board[capit1, capit2];
                board[capit1, capit2] = board[capit3, capit4];
                    board[capit3, capit4] = saver;
            }
            Console.WriteLine();
            for (int i = 0; i < numBoard; i++)
            {
                for (int j = 0; j < numBoard; j++)
                {
                    Console.Write(board[i, j]+"\t");
                }
                Console.WriteLine();
            }
            printHideBoard(board, numBoard);
            return board; 
        }
        public static int round1(int[,] Board,int sum, int numBoard)
        {
            int score1 = sum; ;
            Console.WriteLine("hello player1 choose row & column of your first card");
            int rowCard1 = int.Parse(Console.ReadLine());
            int columCard1 = int.Parse(Console.ReadLine());
            Console.WriteLine("choose row & column of your second card");
            int rowCard2 = int.Parse(Console.ReadLine());
            int columCard2 = int.Parse(Console.ReadLine());
            if (rowCard1==rowCard2 && columCard1==columCard2 || Board[rowCard1, columCard1]==-1|| Board[rowCard2, columCard2]==-1)
            {
               Console.WriteLine("its unlegal play, choose cards again");
                score1=round1(Board, sum, numBoard);
                return score1;
            }    
            if (Board[rowCard1, columCard1] == Board[rowCard2, columCard2])
            {
                Console.WriteLine("VeryGood");
                score1++;
                Board[rowCard1, columCard1] = -1;
                Board[rowCard2, columCard2] = -1;
            }
            else
            {
                Console.WriteLine("Maybi next time");
            }

            Console.WriteLine("your score is {0}",score1);
            printHideBoard(Board,numBoard);
            return score1;
            
        }

        public static int round2(int[,] Board, int sum, int numBoard)
        {
            int score1 = sum; ;
            Console.WriteLine("hello player2 choose row & column of your first card");
            int rowCard1 = int.Parse(Console.ReadLine());
            int columCard1 = int.Parse(Console.ReadLine());
            Console.WriteLine("choose row & column of your second card");
            int rowCard2 = int.Parse(Console.ReadLine());
            int columCard2 = int.Parse(Console.ReadLine());

            if (rowCard1 == rowCard2 && columCard1 == columCard2 || Board[rowCard1, columCard1] == -1 || Board[rowCard2, columCard2] == -1)
            {
                Console.WriteLine("its unlegal act, choose again");
                score1=round2(Board, sum, numBoard);
                return score1;
            }

            if (Board[rowCard1, columCard1] == Board[rowCard2, columCard2])
            {
                Console.WriteLine("VeryGood");
                score1++;
                Board[rowCard1, columCard1] = -1;
                Board[rowCard2, columCard2] = -1;
            }
            else
            {
                Console.WriteLine("Maybi next time");
            }
            Console.WriteLine("your score is {0}", score1);
            printHideBoard(Board, numBoard);
            return score1;

        }



        public static void printHideBoard(int[,]Board, int numbo)
        {
            Console.WriteLine("the situation of the board is:");
            for (int i = 0; i < numbo; i++)
            {
                for (int j = 0; j <numbo ; j++)
                {
                    if(Board[i, j]!=-1)
                    Console.Write("*"+ "\t");
                    else
                    Console.Write(Board[i, j]+ "\t");
                }
                Console.WriteLine();
            }

        }

        public static void printBoard(int[,] board, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j <length; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
         }
        public static bool cheke(int[,] board, int length)
        {
            bool flag = false;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (board[i, j] != -1)
                    {
                        flag = true;
                    }
                }

            }
            return flag;
        }
    }
}
