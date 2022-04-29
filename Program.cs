using System;
using System.Collections.Generic;

namespace TicTacToe // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create board
            List<char> board = new List<char> {'1','2','3','4','5','6','7','8','9'};
            
            char player = 'x';
            bool winner = DetermineWinner(board, player);
            //while no winner or tie
            while (winner == false){
                //Display board
                DisplayBoard(board);

                //Get input
                int userInput = GetInput(player);

                //Update board
                UpdateBoard(board, player, userInput);

                //switch players
                player = SwitchPlayer(player);
                
                //check for winner
                winner = DetermineWinner(board, player);
            }
        }

        static void DisplayBoard(List<char> board)
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }

        static int GetInput(char player)
        {
            Console.WriteLine($"{player}'s turn to choose a square(1-9): ");
            string userInputStr = Console.ReadLine();
            int userInput = int.Parse(userInputStr);
            return userInput;
        }

        static void UpdateBoard(List<char> board, char player, int userInput)
        {
            //if player is x, change the board[userinput-1] to x
            if (player == 'x'){
                board[userInput-1] = 'x';
            }
            else if (player == 'o'){
                board[userInput-1] = 'o';
            }
        }

        static char SwitchPlayer(char player)
        {
            if (player == 'x'){
                player = 'o';
            }
            else if(player == 'o'){
                player = 'x';
            }
            return player;
        }

        static bool DetermineWinner(List<char> board, char player)
        {
            if((player == board[0] && player == board[1] && player == board[2])
            ||(player == board[3] && player == board[4] && player == board[5])
            ||(player == board[6] && player == board[7] && player == board[8])
            ||(player == board[0] && player == board[3] && player == board[6])
            ||(player == board[1] && player == board[4] && player == board[7])
            ||(player == board[2] && player == board[5] && player == board[8])
            ||(player == board[0] && player == board[4] && player == board[8])
            ||(player == board[2] && player == board[4] && player == board[6])){
                return true;}
            else {
                return false;
            }
            
        }

    }
}