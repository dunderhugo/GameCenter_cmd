namespace GameCenter_cmd
{
    internal class TicTacToe
    {
        public static void PrintWinLoss(int oWins, int xWins, int ties)
        {
            Console.WriteLine("________________________________");
            Console.WriteLine("|Wins O:     Ties:        Wins X:|");
            Console.WriteLine($"|    {oWins}      {ties}            {xWins}         |");
            Console.WriteLine("|________________________________|");
        }
        public static void PrintPlayField()
        {
            Console.WriteLine("The playfield is a number between 1-9, type the number on the spot you want to place your game tile ");
            Console.WriteLine($"1|2|3");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"4|5|6");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"7|8|9");
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
        public static void StartTicTacToe()
        {
            int oWins = 0;
            int xWins = 0;
            int ties = 0;
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
                        TicStartGame();
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
        public static void TicStartGame()
        {
            string[] playFieldArr = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            PrintPlayField();
            //TODO: Game board
            int i = 1;
            PrintWinLoss(5, 3, 11);
            do
            {
                //TODO: update gameboard
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
                //TODO: Check if the game is over, won/tie
            }
            while (true);
        }

        public static void PlayFieldPlayerUpdate(string player,string[] playFieldArr)
        {
            //FIXME: Input can crash if empty & a string
            while (true)
            {
                Console.Write($"Player {player}: ");
                int playerPos = int.Parse(Console.ReadLine()) - 1;
                if ((playerPos <= 8 && playerPos >= 0) && (playFieldArr[playerPos] == " "))
                {
                    playFieldArr[playerPos] = player;
                    break;
                }
                else if (playFieldArr[playerPos] != " ") Console.WriteLine("You can't place a game tile on a square that is not empty.");
                else if (playerPos < 0 || playerPos > 9) Console.WriteLine("Input must be a number between 1-9");
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
