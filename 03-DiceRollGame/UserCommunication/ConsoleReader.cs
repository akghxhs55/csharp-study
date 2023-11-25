namespace DiceRollGame.UserCommunication
{
    public static class ConsoleReader
    {
        public static int ReadInt()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Incorrect input.");
            }

            return result;
        }

        public static int ReadInt(string prompt)
        {
            int result;
            do
            {
                Console.WriteLine(prompt);
            } while (!int.TryParse(Console.ReadLine(), out result));

            return result;
        }
    }

}