// See https://aka.ms/new-console-template for more information

namespace _03_Hangman;

class Program
{
    static void Main(string[] args)
    {
        // List of possible words
        List<string> words = new List<string> { "computer", "programming", "algorithm", "software", "hardware", "database", "network", "internet", "cybersecurity", "artificial" };

        // Choose a random word from the list
        Random random = new Random();
        int randomIndex = random.Next(words.Count);
        string word = words[randomIndex];

        // Initialize the game state
        char[] guessedLetters = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            guessedLetters[i] = '_';
        }
        int wrongGuesses = 0;
        int maxWrongGuesses = 6;
        List<char> guessedChars = new List<char>();

        // Game loop
        while (wrongGuesses < maxWrongGuesses && Array.IndexOf(guessedLetters, '_') != -1)
        {
            Console.Clear();
            Console.WriteLine("Hangman Game");
            Console.WriteLine("Word: " + new string(guessedLetters));
            Console.WriteLine("Wrong guesses: " + wrongGuesses + "/" + maxWrongGuesses);
            Console.WriteLine("Guessed letters: " + string.Join(", ", guessedChars));

            Console.Write("Guess a letter: ");
            char guess = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (guessedChars.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter. Try again.");
                Console.ReadKey();
                continue;
            }

            guessedChars.Add(guess);

            bool correctGuess = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == guess)
                {
                    guessedLetters[i] = guess;
                    correctGuess = true;
                }
            }

            if (!correctGuess)
            {
                wrongGuesses++;
                Console.WriteLine("Wrong guess!");
                Console.ReadKey();
            }
        }

        Console.Clear();
        if (wrongGuesses == maxWrongGuesses)
        {
            Console.WriteLine("You lost! The word was: " + word);
        }
        else
        {
            Console.WriteLine("Congratulations! You guessed the word: " + word);
        }

        Console.ReadKey();
    }
}