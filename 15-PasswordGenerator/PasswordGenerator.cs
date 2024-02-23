public class PasswordGenerator
{
    private readonly IRandom _rand;

    public PasswordGenerator(IRandom rand)
    {
        _rand = rand;
    }
    
    public string Generate(
        int minLength, int maxLength, bool shallUseSpecialCharacter)
    {
        ValidateLengths(minLength, maxLength);

        var lengthToGenerate = GenerateRandomLength(minLength, maxLength);

        var charactersToBeUsed = shallUseSpecialCharacter ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return GeneratePasswordBy(charactersToBeUsed, lengthToGenerate);
    }
    
    private void ValidateLengths(int minLength, int maxLength)
    {
        if (minLength < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"minLength must be greater than 0");
        }
        if (maxLength < minLength)
        {
            throw new ArgumentOutOfRangeException(
                $"minLength must be smaller than maxLength");
        }
    }
    
    private int GenerateRandomLength(int minLength, int maxLength)
    {
        return _rand.Next(minLength, maxLength + 1);
    }
    
    private string GeneratePasswordBy(string charactersToBeUsed, int lengthToGenerate)
    {
        return new string(
            Enumerable.Repeat(charactersToBeUsed, lengthToGenerate)
                .Select(characters => characters[_rand.Next(characters.Length)])
                .ToArray());
    }
}