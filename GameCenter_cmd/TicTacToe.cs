namespace GameCenter_cmd
{
    internal class TicTacToe
    {
        public static void PrintPlayField()
        {
            Console.WriteLine("The playfield is a number between 1-9, type the number on the spot you want to place your game tile \n");
            Console.WriteLine($"|1|2|3|");
            Console.WriteLine($"|-+-+-|");
            Console.WriteLine($"|4|5|6|");
            Console.WriteLine($"|-+-+-|");
            Console.WriteLine($"|7|8|9|\n");
        }
        static void TicHelp()
        {
            //TODO: Update text on commands
            Console.WriteLine("Avalible comands:");
            Console.WriteLine("rules -  NYI");
            Console.WriteLine("stop - NYI");
            Console.WriteLine("start - Starts game");
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
            string comand;
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            Console.WriteLine("Type 'start' to start the game, or 'rules' to list the rules, Good luck! ");
            do
            {
                Console.Write("> ");
                comand = Console.ReadLine();
                switch (comand)
                {
                    case "stop":
                        //FIXME: Exit game does not work
                        break;
                    case "start":
                        TicStartGame(oWins, xWins, ties);
                        break;
                    case "help":
                        TicHelp();
                        break;
                    case "rules":
                        TicRules();
                        break;
                    default:
                        Console.WriteLine($"'{comand}' is not a valid comand, type 'help' to get comands or 'stop' to exit game!");
                        break;
                }

            }
            while (comand != "stop");

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
                //TODO: Check if the game is over, tie
                CheckWin(ref oWins, ref xWins,ref ties,playFieldArr, ref gameLoop);
            }
            while (gameLoop);
            TicTacToe.oWins = oWins;
            TicTacToe.xWins = xWins;
            TicTacToe.ties = ties;
            PrintWinLoss(oWins, xWins, ties);

        }
        public static void CheckWin(ref int oWins, ref int xWins, ref int ties, string[] playFieldArr, ref bool gameLoop)
        {
            //TODO: Finnish win con
            //TODO: Refactor
            // horizontally
            if (playFieldArr[0] == playFieldArr[1] && playFieldArr[0] == playFieldArr[2] && (playFieldArr[0] == "O" || playFieldArr[0] == "X"))
            {
                if (playFieldArr[0] == "O")
                {
                    Console.WriteLine("O Wins!");
                    oWins++;
                    gameLoop = false;
                }
                if (playFieldArr[0] == "X")
                {
                    xWins++;
                    gameLoop = false;
                }
            }
            if (playFieldArr[3] == playFieldArr[4] && playFieldArr[3] == playFieldArr[5] && (playFieldArr[3] == "O" || playFieldArr[3] == "X"))
            {
                Console.WriteLine(playFieldArr[3] + " has won!!");
            }
            if (playFieldArr[6] == playFieldArr[7] && playFieldArr[6] == playFieldArr[8] && (playFieldArr[6] == "O" || playFieldArr[6] == "X"))
            {
                Console.WriteLine(playFieldArr[6] + " has won!!");
            }
            //VERTICAL
            if (playFieldArr[0] == playFieldArr[3] && playFieldArr[0] == playFieldArr[6] && (playFieldArr[0] == "O" || playFieldArr[0] == "X"))
            {
                Console.WriteLine(playFieldArr[0] + " has won!!");
            }
            if (playFieldArr[1] == playFieldArr[4] && playFieldArr[1] == playFieldArr[7] && (playFieldArr[1] == "O" || playFieldArr[1] == "X"))
            {
                Console.WriteLine(playFieldArr[1] + " has won!!");
            }
            if (playFieldArr[2] == playFieldArr[5] && playFieldArr[2] == playFieldArr[8] && (playFieldArr[2] == "O" || playFieldArr[2] == "X"))
            {
                Console.WriteLine(playFieldArr[2] + " has won!!");
            }
            // DIAGONAL
            if (playFieldArr[0] == playFieldArr[4] && playFieldArr[0] == playFieldArr[8] && (playFieldArr[0] == "O" || playFieldArr[0] == "X"))
            {
                Console.WriteLine(playFieldArr[0] + " has won!!");
            }
            if (playFieldArr[6] == playFieldArr[4] && playFieldArr[6] == playFieldArr[2] && (playFieldArr[6] == "O" || playFieldArr[6] == "X"))
            {
                Console.WriteLine(playFieldArr[6] + " has won!!");
            }
        }
        public static void PrintWinLoss(int oWins, int xWins, int ties)
        {
            //TODO: Make the print look better, use padding?
            Console.WriteLine(" ________________________________");
            Console.WriteLine("|Wins O:     Ties:        Wins X:|");
            Console.WriteLine($"|  {oWins}           {ties}             {xWins}   |");
            Console.WriteLine("|________________________________|");
        }
        public static void PlayFieldPlayerUpdate(string player,string[] playFieldArr)
        {
            //FIXME: playerPos can crash if empty || a string
            while (true)
            {
                Console.Write($"Player {player}: ");
                int playerPos = int.Parse(Console.ReadLine()) - 1;
                if ((playerPos <= 8 && playerPos >= 0) && (playFieldArr[playerPos] == " "))
                {
                    playFieldArr[playerPos] = player;
                    break;
                }
                else if ((playerPos < 0 || playerPos > 8) || (playFieldArr[playerPos] != " "))
                {
                    if (playerPos < 0 || playerPos > 8) Console.WriteLine("Input must be a number between 1-9");
                    else if (playFieldArr[playerPos] != " ") Console.WriteLine("You can't place a game tile on a square that is not empty.");
                }
                else Console.WriteLine("ERROR");

            }
            Console.WriteLine($"|{playFieldArr[0]}|{playFieldArr[1]}|{playFieldArr[2]}|");
            Console.WriteLine($"|-+-+-|");
            Console.WriteLine($"|{playFieldArr[3]}|{playFieldArr[4]}|{playFieldArr[5]}|");
            Console.WriteLine($"|-+-+-|");
            Console.WriteLine($"|{playFieldArr[6]}|{playFieldArr[7]}|{playFieldArr[8]}|");
        }
    }
}
