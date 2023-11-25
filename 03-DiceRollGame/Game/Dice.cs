namespace DiceRollGame.Game
{
    public class Dice
    {
        public int Number { get; private set; }
        private readonly Random _random;
        private const int MinNumber = 1;
        private const int MaxNumber = 6;

        public Dice(Random random)
        {
            _random = random;
        }

        public void Roll()
        {
            Number = _random.Next(MinNumber, MaxNumber + 1);
        }
    }

}