namespace GameCenter_cmd
{
    internal class Program
    {
        static void PrintHelp()
        {
            Console.WriteLine("*****    Commands:   *****");
            Console.WriteLine("list -   Lists all the games avalible");
            Console.WriteLine("start -  Starts game");
            Console.WriteLine("    e.g start tic-tac-toe    ");
            Console.WriteLine("quit -   Quits the program");
        }
        static void PrintGames()
        {
            Console.WriteLine("These are all the games that is avalible:");
            Console.WriteLine("Tic-Tac-Toe");
            Console.WriteLine("Hangman      - In Progress");          //NYI
            Console.WriteLine("Yatzee       - NYI");         //NYI
            Console.WriteLine("Maze game    - NYI");        //NYI
            //TODO: When done, more games to implement
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hugo's game center!");
            Console.WriteLine("Type 'help' for commands, or 'list' to list all games avalible");
            string comand;
            string[] cmd;

            while (true)
            {
                HangMan.StartHangman();
                Console.Write("> ");
                comand = Console.ReadLine();
                cmd = comand.Split();
                //TODO: Refactor
                //FIXME: Input error handling
                if (cmd[0] == "quit") break;
                else if (cmd[0] == "start")
                {
                    if (cmd.Length == 1) Console.WriteLine("There needs to be a game to start, type 'games' to list all the games avalible");
                    else
                    {
                        if (cmd[1] == "tic-tac-toe") TicTacToe.StartTicTacToe();
                        else if (cmd[1] == "hangman") HangMan.StartHangman();
                        else if (cmd[1] == "yatzee") Console.WriteLine("Yatzee      NYI");
                        else if (cmd[1] == "maze") Console.WriteLine("Maze game     NYI");
                        else Console.WriteLine($"{comand} is not a valid comand, type 'help' to get all the avalible commands");
                    }
                }
                else if (cmd[0] == "games") PrintGames();
                else if (cmd[0] == "help") PrintHelp();
                else Console.WriteLine($"{comand} is not a valid comand, type 'help' to get all the avalible commands");
            }
        }
    }
}
