namespace DiamondLetters;

public class DiamondService
{
    public string GetDiamondRepresentation(char letter)
    {
        int alphabetIndex = GetAlphabetIndex(letter)
                            ?? throw new ArgumentException("Character is not a letter");

        if (alphabetIndex == 0)
        {
            return letter.ToString();
        }

        return null!;
    }

    private static int? GetAlphabetIndex(char letter)
    {
        if (char.IsLetter(letter))
        {
            return char.ToUpperInvariant(letter) - 'A';
        }

        return null;
    }
}
