using System;

namespace HangmanGame
{
    class Player
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }

        public Player(string name, string alias)
        {
            Name = name;
            Alias = alias;
            Wins = 0;
            Losses = 0;
        }

        public void AddWin()
        {
            Wins++;
        }

        public void AddLoss()
        {
            Losses++;
        }

        public string GetPlayerInfo()
        {
            return " Alias: " + Alias + " Name: " + Name + " Wins: " + Wins + " Losses: " + Losses;
        }
    }

    class Game
    {
        public Player player;
        public string wordToGuess;
        public char[] guessedWord;
        public char[] wrongGuesses = new char[10];
        public int wrongGuessCount = 0;
        public int maxAttempts = 6;
        

        public Game(Player player)
        {
            this.player = player;
        }

        public void Init()
        {
            Console.WriteLine("Introdu cuvântul pentru joc (nu va fi afisat)!");
            Console.Write("Cuvânt de ghicit: ");
            wordToGuess = Console.ReadLine().ToLower();


            guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            wrongGuessCount = 0;

            Console.Clear();
            Console.WriteLine("Jocul a început!");
        }

        public void Start()
        {
            Console.WriteLine("Salut, " + player.Alias + "!");
            while (true)
            {
                Console.WriteLine("\nCuvânt: " + new string(guessedWord));
                Console.Write("Litere gresite: ");
                for (int i = 0; i < wrongGuessCount; i++)
                {
                    Console.Write(wrongGuesses[i] + ",");
                }
                Console.WriteLine();
                Console.WriteLine("Attempts left: " + (maxAttempts - wrongGuessCount));

                Console.Write("Ghiceste o literă: ");
                string input = Console.ReadLine().ToLower();

                char guess = input[0];
                bool found = false;

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                        found = true;
                    }
                }

                if (!found)
                {
                    bool alreadyGuessed = false;
                    for (int i = 0; i < wrongGuessCount; i++)
                    {
                        if (wrongGuesses[i] == guess)
                        {
                            alreadyGuessed = true;
                            break;
                        }
                    }

                    if (!alreadyGuessed && wrongGuessCount < wrongGuesses.Length)
                    {
                        wrongGuesses[wrongGuessCount] = guess;
                        wrongGuessCount++;
                    }
                }

                if (new string(guessedWord) == wordToGuess)
                {
                    Console.WriteLine("\nFelicitări! Ai ghicit cuvântul!");
                    player.AddWin();
                    break;
                }

                if (wrongGuessCount >= maxAttempts)
                {
                    Console.WriteLine("\nAi pierdut! Cuvântul era: " + wordToGuess);
                    player.AddLoss();
                    break;
                }
            }
        }

        public void End()
        {
            Console.WriteLine("\nJoc încheiat.");
            Console.WriteLine(player.GetPlayerInfo());
        }
    }

    class Manager
    {
        public void CreateNewGame()
        {
            Console.Write("Nume jucător: ");
            string name = Console.ReadLine();
            Console.Write("Alias jucător: ");
            string alias = Console.ReadLine();

            Player player = new Player(name, alias);
            Game game = new Game(player);

            game.Init();
            game.Start();
            game.End();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            bool playAgain = true;

            while (playAgain)
            {
                manager.CreateNewGame();

                Console.Write("\nVrei să joci din nou? (da/nu): ");
                string answer = Console.ReadLine().Trim().ToLower();
                playAgain = (answer == "da");
            }
        }
    }
}
