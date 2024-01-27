using System.Runtime.CompilerServices;
using System.Linq;
using System.Xml;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Data;
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

        public static void StartHangman()
        {
            Console.Clear();
            // Hangman 7 guesses (Maybe change if harder/easier difficulties?)
            //TODO?: different difficulties?
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
                    
                    case "start":
                        Console.Clear();
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
        public static string RandomWord()
        {
            string defaultFile = "..\\..\\..\\HangmanWords.txt";
            string[] word = File.ReadAllLines(defaultFile);
            Random rnd = new Random();
            int i = rnd.Next(word.Length);
            return word[i];
        }
        public static void StartTheGame()
        {
            Console.Write("Loading word");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Clear();
            //TODO: Better UI
            string chosenWord = RandomWord();
            int guesses = 0;
            int lives = 7;
			
			var guessedLetter = new List<string>();
			PrintGame(lives, guesses, guessedLetter);
			do
            {                
                bool lettersLeft = false;
				foreach (char c in chosenWord)
				{
					var letters = c.ToString();
					if (guessedLetter.Contains(letters))
					{
						Console.Write(letters);

					}
					else
					{
						Console.Write("_");
                        lettersLeft = true;
					}
				}
                if (!lettersLeft)
                    break;

				Console.Write("\n\nGuess a letter: ");
                string input = Console.ReadLine().ToLower();
				if (input.Length != 1 || input.All(char.IsDigit))
                {
                    Console.WriteLine("Input can only be one letter");
                    continue;
                }
                if (guessedLetter.Contains(input))
                {
                    Console.WriteLine("You have already tried that letter...");
                }
                guessedLetter.Add(input);
                if (!chosenWord.Contains(input))
                {
                    Console.WriteLine("Wrong guess");
                    lives--;
                }
                guesses++;
                PrintGame(lives, guesses, guessedLetter);
            }
            while (lives > 0);
            if (lives == 0) Console.WriteLine("You loose, the correct word was: " + chosenWord);
            else Console.WriteLine($"\nCongratulations! You won the game with {lives} lives left & with {guesses} guesses!\n" + win);
        }
        public static void PrintGame(int lives, int guesses, List<string> guessedWord)
        {
            Console.Clear();
            Console.WriteLine(" ---------------------------\n" +
                              "|          Hangman          |\n" +
                              " ---------------------------");
            Console.WriteLine(stages[lives]);
            Console.WriteLine("Guessed letters: ");
            foreach (string s in guessedWord) Console.Write(s + " ");
			Console.WriteLine($"\nGuesses: {guesses}\n" +
					$"Lives: {lives}\n");
        }


        // TODO: If different difficulties, use different array for more/less guesses
        public static string[] stages =
        {
			@"
                   --------
                   |      |
                   |      O
                   |     \|/
                   |      |
                   |     / \
                  ___
                 /   \
            ",
			@"
                   --------
                   |      |
                   |      O
                   |     \|/
                   |      
                   |     
                  ___
                 /   \
            ",
			@"
                   --------
                   |      |
                   |      O
                   |     
                   |      
                   |     
                  ___
                 /   \
            ",
			@"
                   -------
                   |      
                   |     
                   |     
                   |     
                   |     
                  ___
                 /   \
            ",
			@"
                   ---
                   |      
                   |      
                   |     
                   |     
                   |     
                  ___
                 /   \
            ",
			@"
                   
                   |      
                   |     
                   |     
                   |    
                   |     
                  ___
                 /   \
            ",
			@"
                   
                    
                         
                        
                         
                        
                  ___
                 /   \
            ",
			@"
                   
                    
                         
                        
                         
                        
                  
                 
            ",
		};
        public static string win = @" 
__   __                _    _  _         _ 
\ \ / /               | |  | |(_)       | |
 \ V /   ___   _   _  | |  | | _  _ __  | |
  \ /   / _ \ | | | | | |/\| || || '_ \ | |
  | |  | (_) || |_| | \  /\  /| || | | ||_|
  \_/   \___/  \__,_|  \/  \/ |_||_| |_|(_)";

	}
}
