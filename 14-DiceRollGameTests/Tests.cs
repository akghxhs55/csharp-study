namespace DiceRollGameTests;

[TestFixture]
public class Tests
{
    private Mock<IDice> _diceMock;
    private Mock<IUserCommunication> _userCommunicationMock;
    private GuessingGame _cut;

    [SetUp]
    public void Setup()
    {
        _diceMock = new Mock<IDice>();
        _userCommunicationMock = new Mock<IUserCommunication>();
        _cut = new GuessingGame(_diceMock.Object, _userCommunicationMock.Object);
    }

    [Test]
    public void Play_ReturnsVictory_WhenUserGuessesCorrectlyInFirstTry()
    {
        const int correctGuess = 3;
        _diceMock.Setup(mock => mock.Roll()).Returns(correctGuess);
        _userCommunicationMock
            .Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(correctGuess);

        var result = _cut.Play();

        Assert.That(result, Is.EqualTo(GameResult.Victory));
    }

    [Test]
    public void Play_ReturnsVictory_WhenUserGuessesCorrectlyInSecondTry()
    {
        const int correctGuess = 4;
        const int wrongGuess = 3;
        _diceMock.Setup(mock => mock.Roll()).Returns(correctGuess);
        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(wrongGuess)
            .Returns(correctGuess);

        var result = _cut.Play();

        Assert.That(result, Is.EqualTo(GameResult.Victory));
    }

    [Test]
    public void Play_ReturnsVictory_WhenUserGuessesCorrectlyInThirdTry()
    {
        const int correctGuess = 5;
        const int firstWrongGuess = 3;
        const int secondWrongGuess = 4;
        _diceMock.Setup(mock => mock.Roll()).Returns(correctGuess);
        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(firstWrongGuess)
            .Returns(secondWrongGuess)
            .Returns(correctGuess);

        var result = _cut.Play();

        Assert.That(result, Is.EqualTo(GameResult.Victory));
    }

    [Test]
    public void Play_ReturnsLoss_WhenUserNeverGuessesCorrectly()
    {
        const int correctGuess = 2;
        const int wrongGuess = 3;
        _diceMock.Setup(mock => mock.Roll()).Returns(correctGuess);
        _userCommunicationMock
            .Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(wrongGuess);

        var result = _cut.Play();

        Assert.That(result, Is.EqualTo(GameResult.Loss));
    }

    [Test]
    public void Play_ReturnsLoss_WhenUserGuessesCorrectlyInFourthTry()
    {
        const int correctGuess = 6;
        const int firstWrongGuess = 3;
        const int secondWrongGuess = 4;
        const int thirdWrongGuess = 5;
        _diceMock.Setup(mock => mock.Roll()).Returns(correctGuess);
        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(firstWrongGuess)
            .Returns(secondWrongGuess)
            .Returns(thirdWrongGuess)
            .Returns(correctGuess);

        var result = _cut.Play();

        Assert.That(result, Is.EqualTo(GameResult.Loss));
    }

    [Test]
    [TestCase(GameResult.Victory, "You win!")] // Resource.VictoryMessage
    [TestCase(GameResult.Loss, "You lose :(")] // Resource.LossMessage
    public void PrintResult_ShowsCorrectMessage(GameResult gameResult, string expectedMessage)
    {
        _cut.PrintResult(gameResult);

        _userCommunicationMock.Verify(mock => mock.ShowMessage(expectedMessage));
    }

    [Test]
    public void Play_ShallShowWelcomeMessage()
    {
        _cut.Play();

        _userCommunicationMock.Verify(
            mock => mock.ShowMessage(
                string.Format(Resource.GameStartMessage, 3)));
    }

    [Test]
    public void Play_ShallAskUserForInputThreeTimes_WhenUserNeverGuessesCorrectly()
    {
        const int correctGuess = 2;
        const int wrongGuess = 3;
        _diceMock.Setup(mock => mock.Roll()).Returns(correctGuess);
        _userCommunicationMock
            .Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(wrongGuess);

        _cut.Play();

        _userCommunicationMock.Verify(
            mock => mock.ReadInteger(
                Resource.EnterNumberMessage),
            Times.Exactly(3));
    }

    [Test]
    public void Play_ShallShowWrongNumberThreeTimes_WhenUserNeverGuessesCorrectly()
    {
        const int correctGuess = 2;
        const int wrongGuess = 3;
        _diceMock.Setup(mock => mock.Roll()).Returns(correctGuess);
        _userCommunicationMock
            .Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(wrongGuess);

        _cut.Play();

        _userCommunicationMock.Verify(
            mock => mock.ShowMessage(
                Resource.WrongNumberMessage),
            Times.Exactly(3));
    }
}