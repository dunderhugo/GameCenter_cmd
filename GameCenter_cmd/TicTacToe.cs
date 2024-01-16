using System.Numerics;

namespace GameCenter_cmd
{
    internal class TicTacToe
    {
        public static void PrintPlayField()
        {
            string[] arr = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
            PrintPlayerBoard(arr);
        }
        static void TicHelp()
        {
            Console.Clear();
            Console.WriteLine("Avalible commands:\n");
            Console.WriteLine("rules    |- Lists all the rules");
            Console.WriteLine("exit     |- Exits the game and goes back to the main menu");
            Console.WriteLine("start    |- Starts game");
            Console.WriteLine("help     |- Lists all the commands avalible");
        }
        static void TicRules()
        {
            //TODO: Update rules of game
            Console.WriteLine("RULES:");
            Console.WriteLine("NYI");
        }
        static public int oWins = 0;
        static public int xWins = 0;
        static public int ties = 0;
        public static void StartTicTacToe()
        {
            Console.Clear();
            string command;
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            Console.WriteLine("Type 'start' to start the game, or 'rules' to list the rules, Good luck! ");
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                switch (command)
                {
                    case "stop":
                        //FIXME: Exit game does not work
                        //FIXME: Wont do it for now until TicTacToe is finnished, but its the loop in program.cs that is the issue
                        break;
                    case "start":
                        Console.Clear();
                        TicStartGame(oWins, xWins, ties);
                        break;
                    case "help":
                        TicHelp();
                        break;
                    case "rules":
                        TicRules();
                        break;
                    default:
                        Console.WriteLine($"'{command}' is not a valid comand, type 'help' to get comands or 'stop' to exit game!");
                        break;
                }

            }
            while (command != "stop");

        }
        public static void TicStartGame(int oWins, int xWins, int ties)
        {
            string[] playFieldArr = [" ", " ", " ", " ", " ", " ", " ", " ", " "];
            int i = 1;
            bool gameLoop = true;
            PrintPlayField();
            do
            {
                if (i % 2 == 0)
                {
                    PlayFieldPlayerUpdate("X", playFieldArr);
                    i++;
                }
                else if (i % 2 == 1)
                {
                    PlayFieldPlayerUpdate("O", playFieldArr);
                    i--;
                }
                CheckWin(ref oWins, ref xWins,ref ties,playFieldArr, ref gameLoop);
            }
            while (gameLoop);
            TicTacToe.oWins = oWins;
            TicTacToe.xWins = xWins;
            TicTacToe.ties = ties;
            Console.WriteLine("Type 'start' to play again, ");
        }
        public static void CheckWin(ref int oWins, ref int xWins, ref int ties, string[] playFieldArr, ref bool gameLoop)
        {
            //TODO: Refactor
            // horizontally
            if (playFieldArr[0] == playFieldArr[1] && playFieldArr[0] == playFieldArr[2] && (playFieldArr[0] == "O" || playFieldArr[0] == "X"))
                gameLoop = WhoWins(ref oWins, ref xWins, playFieldArr, 0);
            else if (playFieldArr[3] == playFieldArr[4] && playFieldArr[3] == playFieldArr[5] && (playFieldArr[3] == "O" || playFieldArr[3] == "X")) 
                gameLoop = WhoWins(ref oWins, ref xWins, playFieldArr, 3);
            else if (playFieldArr[6] == playFieldArr[7] && playFieldArr[6] == playFieldArr[8] && (playFieldArr[6] == "O" || playFieldArr[6] == "X"))
                gameLoop = WhoWins(ref oWins, ref xWins, playFieldArr, 6);
            //VERTICAL
            else if (playFieldArr[0] == playFieldArr[3] && playFieldArr[0] == playFieldArr[6] && (playFieldArr[0] == "O" || playFieldArr[0] == "X"))
                gameLoop = WhoWins(ref oWins, ref xWins, playFieldArr, 0);
            else if (playFieldArr[1] == playFieldArr[4] && playFieldArr[1] == playFieldArr[7] && (playFieldArr[1] == "O" || playFieldArr[1] == "X"))
                gameLoop = WhoWins(ref oWins, ref xWins, playFieldArr, 1);
            else if (playFieldArr[2] == playFieldArr[5] && playFieldArr[2] == playFieldArr[8] && (playFieldArr[2] == "O" || playFieldArr[2] == "X"))
                gameLoop = WhoWins(ref oWins, ref xWins, playFieldArr, 2);
            // DIAGONAL
            else if (playFieldArr[0] == playFieldArr[4] && playFieldArr[0] == playFieldArr[8] && (playFieldArr[0] == "O" || playFieldArr[0] == "X"))
                gameLoop = WhoWins(ref oWins, ref xWins, playFieldArr, 0);
            else if (playFieldArr[6] == playFieldArr[4] && playFieldArr[6] == playFieldArr[2] && (playFieldArr[6] == "O" || playFieldArr[6] == "X"))
                gameLoop = WhoWins(ref oWins, ref xWins, playFieldArr, 6);
            else if (playFieldArr[0] != " " && playFieldArr[1] != " " && playFieldArr[2] != " " && playFieldArr[3] != " " && playFieldArr[4] != " " && playFieldArr[5] != " " && playFieldArr[6] != " " && playFieldArr[7] != " " && playFieldArr[8] != " ")
            {
                Console.WriteLine("it's a tie...");
                ties++;
                gameLoop = false;
            }
        }

        private static bool WhoWins(ref int oWins, ref int xWins, string[] playFieldArr, int i)
        {
            bool gameLoop;
            {
                if (playFieldArr[i] == "O")
                {
                    Console.WriteLine("O Wins!");
                    oWins++;
                    gameLoop = false;
                }
                else
                {
                    Console.WriteLine("X Wins!");
                    xWins++;
                    gameLoop = false;
                }
            }
            return gameLoop;
        }

        public static void PrintWinLoss(int oWins, int xWins, int ties)
        {
            //TODO: Make the print look better, use padding?
            Console.WriteLine(" __________________________________");
            Console.WriteLine("|                                  |");
            Console.WriteLine("| Wins O:     Ties:        Wins X: |");
            Console.WriteLine($"|   {oWins}           {ties}             {xWins}    |");
            Console.WriteLine("|__________________________________|");
        }
        public static void PlayFieldPlayerUpdate(string player,string[] playFieldArr)
        {
            while (true)
            {
                Console.Write($"Player {player}: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int playerPos) && playerPos >= 1 && playerPos <= 9)
                {
                    playerPos--;
                    if (playFieldArr[playerPos] == " ")
                    {
                        playFieldArr[playerPos] = player;
                        break;
                    }
                    else Console.WriteLine("You can't place a game tile on a square that is not empty.");
                }
                else Console.WriteLine("Input must be a number between 1-9");
            }
            PrintPlayerBoard(playFieldArr);
        }

        public static void PrintPlayerBoard(string[] playFieldArr)
        {
            Console.Clear();
            PrintWinLoss(oWins, xWins, ties);
            Console.WriteLine("The playfield is a number between 1-9." +
                "\nType the number on the spot you want to place your game tile \n");
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {playFieldArr[0]}  |  {playFieldArr[1]}  |  {playFieldArr[2]}   ");
            Console.WriteLine($"_____|_____|_____ ");
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {playFieldArr[3]}  |  {playFieldArr[4]}  |  {playFieldArr[5]}   ");
            Console.WriteLine($"_____|_____|_____ ");
            Console.WriteLine($"     |     |      ");
            Console.WriteLine($"  {playFieldArr[6]}  |  {playFieldArr[7]}  |  {playFieldArr[8]}   ");
            Console.WriteLine($"     |     |      ");
        }
    }
}
