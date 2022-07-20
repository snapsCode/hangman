using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;
            while (restart)
            {
                var wordList = new List<Word>()
                {
                    new Word("Mario"),
                    new Word("Sonic"),
                    new Word("Pikachu"),
                    new Word("Eevee"),
                    new Word("Charizard"),
                    new Word("Lucario"),
                    new Word("Shantae"),
                    new Word("Link"),
                    new Word("Lonk"),
                    new Word("Zelda")
                };

                Random random = new Random();
                int rng = random.Next(0, wordList.Count);
                Word word = wordList[rng];

                int lives = 5;

                while (lives > 0 && word.lines.Contains('_'))
                {
                    //Beginning message
                    Console.Clear();
                    Console.WriteLine("Guess the word!");
                    //Console.WriteLine("The word is " + word.word);
                    word.lines.ForEach(x => Console.Write(x + " "));

                    // Input the letter
                    Console.WriteLine($"\n\nYou have {lives} live(s) left.");
                    Console.Write("\nEnter a letter: ");
                    string input = Console.ReadLine();
                    char letter;

                    while (!char.TryParse(input, out letter) || !Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("\nInvalid input! You must type a letter and one letter only.");
                        Console.Write("\nEnter a letter: ");

                        input = Console.ReadLine();
                    }

                    char upperChar = char.ToUpper(letter);

                    //Validating input
                    //Console.WriteLine("\nThe char is {0}", input);
                    if (word.msg.Contains(upperChar))
                    {
                        var letterCount = word.msg.FindAll(x => x.Equals(upperChar))
                            .Count;
                        if (word.lines.Contains(upperChar) && letterCount == 1)
                        {
                            lives--;
                        }

                        //Replace all instances of the character
                        for (int i = 0; i < word.msg.Count; i++)
                        {
                            if (word.msg[i].Equals(upperChar))
                            {
                                word.lines[i] = word.msg[i];

                                //If you want to only replace the first instance of the character
                                /*word.msg[i] = ' ';
                                break;*/
                            }
                        }
                    }
                    else
                    {
                        lives--;
                    }

                    //Prompt user to press any key to continue
                    /*Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();*/
                }

                //Say what the word was
                Console.Clear();
                Console.WriteLine("The word was \"{0}\"", word);

                //If user got the letters correct or not, respond accordingly
                Console.WriteLine();
                Console.WriteLine(lives == 0 ? "Too bad..." : "Congrats!");
                Console.Write("Wanna try again? Press Y to restart, enter any other character to exit...");
                ConsoleKeyInfo k = Console.ReadKey();
                Console.WriteLine();

                restart = k.Key == ConsoleKey.Y ? true : false;
            }
        }
    }

}
