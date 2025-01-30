namespace DiamondLetters;

public class DiamondService
{
    public string GetDiamondRepresentation(char letter)
    {
        if (letter == 'A')
        {
            return letter.ToString();
        }
        
        if (!char.IsLetter(letter))
        {
            throw new ArgumentException("Character is not a letter");
        }

        return null!;
    }
}
