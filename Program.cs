//Tic-Tac-Toe game by Victoriah Meyer
//
using System;
using System.Collections.Generic;

namespace TicTacToe // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            while(playAgain == true){
                //Create board
                List<char> board = new List<char> {'1','2','3','4','5','6','7','8','9'};
                
                //initiate variables
                char player = 'x';
                int num_turns = 0;
                bool winner = DetermineWinner(board, player, num_turns);
                

                //while no winner or tie
                while (winner == false){
                    num_turns++;

                    //Display board
                    DisplayBoard(board);

                    //Get input
                    int userInput = GetInput(board, player);

                    //Update board
                    UpdateBoard(board, player, userInput);

                    //switch players
                    player = SwitchPlayer(player);
                    
                    //check for winner
                    winner = DetermineWinner(board, player, num_turns);

                }
                playAgain = EndGame(player, playAgain);
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

        static int GetInput(List<char> board,char player)
        {
            bool valid = false;
            Console.Write($"\n{player}'s turn to choose a square(1-9): ");
            string userInputStr = Console.ReadLine();
            int userInput = int.Parse(userInputStr);

            while (valid == false)
            { 
                if (userInput >= 1 && userInput <= 9){
                    valid = true;
                }
                else if (board[userInput]=='x' || board[userInput]=='o'){
                    Console.WriteLine($"I'm sorry, that square is already taken. Choose another square: ");
                    userInputStr = Console.ReadLine();
                    userInput = int.Parse(userInputStr);
                    valid = false;
                }
                else{
                    Console.Write($"I'm sorry, {userInput} is not a valid input. Choose another square: ");
                    userInputStr = Console.ReadLine();
                    userInput = int.Parse(userInputStr);
                    valid = false;
                }
            }
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

        static bool DetermineWinner(List<char> board, char player, int num_turns)
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
            else if (num_turns >= 9){
                Console.WriteLine("You have tied.");
                return true;
            }
            else {
                return false;
            }
        }
        static bool EndGame(char player, bool playAgain)
        {
            Console.WriteLine($"Player {player} wins! Thanks for playing.");
            
            Console.WriteLine("Would you like to play again? (yes/no): ");
            string playAgainStr = Console.ReadLine();
            
            if (playAgainStr == "yes"){
                playAgain = true;
            }
            else{
                playAgain = false;
            }
            return playAgain;
        }

    }
}