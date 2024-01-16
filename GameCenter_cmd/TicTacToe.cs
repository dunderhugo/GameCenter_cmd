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
            //TODO: Game board
            
            int i = 1;
            int oWins = 0;
            int xWins = 0;
            int ties = 0;
            Console.WriteLine("The playfield is a number between 1-9, type the number on the spot you want to place your game tile ");
            PrintWinLoss(5, 3, 11);
            do
            {
                //TODO: update gameboard
                if (i % 2 == 0)
                {
                    Console.Write("Player X: ");
                    Console.ReadLine();
                    i++;
                }
                else if (i % 2 == 1)
                {
                    Console.Write("Player O: ");
                    Console.ReadLine();
                    i--;
                }
            //TODO: Check if the game is over, won/tie
            }
            while (true);
        }
    }
}
