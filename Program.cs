using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
     class Program
    {
        static void Main() {

            string[] words = ReadWordsFromFile(@"File/Words.txt");

          


            string wordToGuess = SelectRandomWord(words);
            string guessedWord = new string('_', wordToGuess.Length);
            int guessingAttempts = 6;

            Console.WriteLine("Welcome to hangman");
            Console.WriteLine("You will have 6 attempts to guess the word");
            

            while (guessingAttempts > 0) { 

                Console.WriteLine($"Word to guess: {guessedWord}");
                

                char guess = GetGuess();

                if (wordToGuess.Contains(guess)) {

                    for (int i = 0; i < wordToGuess.Length; i++) {

                        if (wordToGuess[i] == guess) {
                            guessedWord = guessedWord.Remove(i, 1).Insert(i, guess.ToString());
                        }

                    }

                    if (wordToGuess == guessedWord) {

                        Console.WriteLine("Well done, you guessed the word correctly");
                        break;
                   
                    }

                }
                else {

                    guessingAttempts--;
                    Console.WriteLine("Sorry that is incorrect, please try again");

                }
            }

            if (guessingAttempts == 0) {

                Console.WriteLine($"You are out of attempts. The word was:{wordToGuess }");

            }

          

        }


        

        static string[] ReadWordsFromFile(string filename)
        {
            try
            {
                return File.ReadAllLines(filename);
            }
            catch (IOException)
            {
                return new string[0];
            }
        }
        static string SelectRandomWord(string[] words)
        {
            Random random = new Random();
            return words[random.Next(0, words.Length)].ToLower();
        }

        static char GetGuess() {

            Console.Write("Enter your guess: ");
            string input = Console.ReadLine().ToLower();
            if (input.Length == 1 && char.IsLetter(input[0]))
            {
                return input[0];
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
                return GetGuess();
            }
        }
    }
}
