using UserCommunication;

namespace Game;

public class GuessingGame
{
    private readonly IDice _dice;
    private readonly IUserCommunication _userCommunication;
    private const int InitialTries = 3;

    public GuessingGame(
        IDice dice,
        IUserCommunication userCommunication)
    {
        _dice = dice;
        _userCommunication = userCommunication;
    }

    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        _userCommunication.ShowMessage(
            string.Format(
                Resource.GameStartMessage,
                InitialTries));

        var triesLeft = InitialTries;
        while (triesLeft > 0)
        {
            var guess = _userCommunication.ReadInteger(Resource.EnterNumberMessage);
            if (guess == diceRollResult)
            {
                return GameResult.Victory;
            }
            _userCommunication.ShowMessage(Resource.WrongNumberMessage);
            --triesLeft;
        }
        return GameResult.Loss;
    }

    public void PrintResult(GameResult gameResult)
    {
        string message = gameResult == GameResult.Victory
            ? Resource.VictoryMessage
            : Resource.LossMessage;

        _userCommunication.ShowMessage(message);
    }
}
