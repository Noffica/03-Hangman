// See https://aka.ms/new-console-template for more information

namespace _03_Hangman;

internal abstract class Program
{
    const int MAX_WRONG_GUESSES = 6;
    private static void Main()
    {
        // List of possible words
        List<string> words = [
            "alpha", "bravo", "charlie", "delta", "echo", "foxtrot", "golf", "hotel"
        ];

        // Choose a random word from the list
        int randomIndex = new Random().Next(words.Count);
        string word = words[randomIndex];

        // Initialise the game
        char[] guessedLetters = new char[word.Length];
        for (int i = 0; i < word.Length; i++) {
            guessedLetters[i] = '_';
        }
        int wrongGuesses = 0;
        List<char> guessedChars = new List<char>();

        // Principal loop
        while (wrongGuesses < MAX_WRONG_GUESSES && Array.IndexOf(guessedLetters, '_') != -1) {
            Console.Clear();
            Console.WriteLine("A game of 'Hangman'");
            Console.WriteLine($"Word: {new string(guessedLetters)}");
            Console.WriteLine($"Wrong guesses: {wrongGuesses} / {MAX_WRONG_GUESSES}");
            Console.WriteLine($"Guessed letters: {string.Join(", ", guessedChars)}");

            Console.Write("Guess a letter: ");
            char guess = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (guessedChars.Contains(guess)) {
                Console.WriteLine("You have already guessed that letter. Please try again.");
                Console.ReadKey();
                continue; //restart the loop
            }

            guessedChars.Add(guess);

            bool correctGuess = false;
            for (int i = 0; i < word.Length; i++) {
                if (word[i] == guess) {
                    guessedLetters[i] = guess;
                    correctGuess = true;
                }
            }

            if (!correctGuess) {
                wrongGuesses++;
                Console.WriteLine("Wrong guess!");
                Console.ReadKey();
            }
        } //end of principal loop 

        Console.Clear();
        if (wrongGuesses == MAX_WRONG_GUESSES) {
            Console.WriteLine($"You have lost the game. The correct word was: {word}");
        }
        else {
            Console.WriteLine($"Well done! You guessed the word: {word}");
        }

        Console.ReadKey();
    }
}
