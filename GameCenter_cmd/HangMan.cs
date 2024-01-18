using System.Runtime.CompilerServices;
using System.Linq;
namespace GameCenter_cmd
{
    internal class HangMan
    {
        static void Help()
        {
            Console.WriteLine("List of all commands:\n");
            Console.WriteLine("'start'  |- Starts the game");
            Console.WriteLine("'help'   |- List of all commands");
            Console.WriteLine("'rules'  |- Game rules");
            Console.WriteLine("'add'    |- Adds custom word to the game");
            Console.WriteLine("'remove  |- Remove word from game'");
            Console.WriteLine("'list'   |- Lists all words that are in the game");
            Console.WriteLine("'change' |- Change txt file, to play from another file");
            //TODO?: a method to add a txt file with custom words, from cmd
            Console.WriteLine("'exit'   |- Exits hangman");
        }
        public static string RandomWord()
        {
            string defaultFile = "..\\..\\..\\HangmanWords.txt";
            string[] word = File.ReadAllLines(defaultFile);
            Random rnd = new Random();
            int i = rnd.Next(word.Length);
            return word[i];
        }
        public static void StartHangman()
        {
            Console.Clear();
            
            //string [] wordsArr = ReadReturnFile(defaultFile);
            //string wordToGuess = RandomWord(wordsArr);

            //Hangman 7 guesses
            //TODO?: different difficulties?
            //TODO: Random word picker
            //TODO: Guess loop
            //TODO: User Interface
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Type 'start' to start game, or 'help' to list all commands!");
            bool hangmanExit = true;
            do
            {
                Console.Write("> ");
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    
                    case "start":   //NYI
                        StartTheGame();
                        break;                 
                    case "help":
                        Help();
                        break;
                    case "rules":   //NYI
                        Console.WriteLine("Rules - NYI");
                        break;
                    case "exit":
                        Console.WriteLine("Exiting Hangman...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        hangmanExit=false;
                        break;
                    case "add":     //NYI
                        Console.WriteLine("Adds word to hangman - NYI");
                        break;
                    case "remove":  //NYI
                        Console.WriteLine("Removes word in hangman - NYI");
                        break;
                    case "list":    //NYI
                        Console.WriteLine("Lists all words... not for cheating - NYI");
                        break;
                    case "change":  //NYI
                        Console.WriteLine("Change file to play from");
                        break;
                    default: 
                        Console.WriteLine($"'{command}' is not an avalible command, type 'help' to list all commands"); 
                        break;
                }
            }
            while (hangmanExit);
        }
        public static void StartTheGame()
        {
            //TODO: Better UI
            Console.WriteLine("Hangman!");
            string chosenWord = RandomWord();
            int guesses = 0;
            int lives = 7;
            bool gameOver = false;
            string[] chosenWordArr = new string[chosenWord.Length];
            string[] filler = new string[chosenWord.Length];

            int i = 0;
            foreach (char c in chosenWord)
            {
                chosenWordArr[i] = c.ToString();
                filler[i] = "_";
                i++;
            }
            
            do
            {
                Console.Write("Guess a letter: ");
                string input = Console.ReadLine().ToLower();
                if (input.Length != 1 || input.All(char.IsDigit))
                {
                    Console.WriteLine("Input can only be one letter");
                }
                else
                {
                    


                }
            }
            while (!gameOver);




        }
        public void PrintGame()
        {
            Console.Clear();
        }
    }
}
