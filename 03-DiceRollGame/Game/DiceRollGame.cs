using DiceRollGame.UserCommunication;

namespace DiceRollGame.Game
{
    public class GuessingGame
    {
        private readonly Dice _dice;
        private const int MaxChance = 3;

        public GuessingGame(Dice dice)
        {
            _dice = dice;
        }

        public GameResult Play()
        {
            _dice.Roll();

            Console.WriteLine($"Dice rolled. Guess what number is shows in {MaxChance} tries.");

            int chance = MaxChance;
            while (chance > 0)
            {
                int guess = ConsoleReader.ReadInt("Enter a number:");

                if (guess == _dice.Number)
                {
                    return GameResult.Win;
                }
                else
                {
                    Console.WriteLine("Wrong number.");
                    chance--;
                }
            }

            return GameResult.Lose;
        }

        public static void PrintResult(GameResult gameResult)
        {
            switch (gameResult)
            {
                case GameResult.Win:
                    Console.WriteLine("You win!");
                    break;
                case GameResult.Lose:
                    Console.WriteLine("You lose :(");
                    break;
            }
        }
    }
}