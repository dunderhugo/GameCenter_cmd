namespace GameCenter_cmd
{
    internal class Program
    {
        static void PrintHelp()
        {
            Console.WriteLine("*****    Commands:   *****");
            Console.WriteLine("list -   Lists all the games avalible");
            Console.WriteLine("start -  Starts game");
            Console.WriteLine("quit -   Quits the program");
        }
        static void PrintGames()
        {
            Console.WriteLine("These are all the games that is avalible:");
            Console.WriteLine("Tic-Tac-Toe  - In Progress");   //NYI
            Console.WriteLine("Hangman      - NYI");       //NYI
            Console.WriteLine("Yatzee       - NYI");        //NYI
            Console.WriteLine("Maze game    - NYI");     //NYI
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
                Console.Write("> ");
                comand = Console.ReadLine();
                cmd = comand.Split();
                //TODO: Refactor
                //FIXME: Input error handling
                if (cmd[0] == "quit") break;
                else if (cmd[0] == "start")
                {
                    TicTacToe.StartTicTacToe();
                    if (cmd[1] == "tic") TicTacToe.StartTicTacToe();
                    else if (cmd[1] == "hangman") Console.WriteLine("Hangman    NYI");
                    else if (cmd[1] == "Yatzee") Console.WriteLine("Yatzee      NYI");
                    else if (cmd[1] == "Maze") Console.WriteLine("Maze game     NYI");
                    else Console.WriteLine($"{comand} is not a valid comand, type 'help' to get all the avalible commands");
                }
                else if (cmd[0] == "list") PrintGames();
                else if (cmd[0] == "help") PrintHelp();
                else Console.WriteLine($"{comand} is not a valid comand, type 'help' to get all the avalible commands");
            }
        }
    }
}
