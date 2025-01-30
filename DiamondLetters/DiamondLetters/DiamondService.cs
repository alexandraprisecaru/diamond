namespace DiamondLetters;

using System.Text;
using DiamondLetters.Exceptions;

public class DiamondService
{
    private const char WhiteSpace = ' ';

    public string CreateDiamond(char letter)
    {
        int alphabetIndex = GetAlphabetIndex(letter)
                            ?? throw new InvalidLetterException(letter);

        if (alphabetIndex == 0)
        {
            return letter.ToString();
        }

        int diamondSize = 2 * alphabetIndex + 1;
        var sb = new StringBuilder();

        int lineNumber = 0;

        char currentLetter = char.IsUpper(letter) ? 'A' : 'a';
        while (lineNumber < diamondSize)
        {
            int currentLetterIndex = GetAlphabetIndex(currentLetter)!.Value;
            int lettersPerLine = lineNumber == 0 || lineNumber == diamondSize - 1 ? 1 : 2;
            int middleWhiteSpace = lineNumber == 0 || lineNumber == diamondSize - 1 ? 0 : 2 * currentLetterIndex - 1;
            int marginWhiteSpace = (diamondSize - lettersPerLine - middleWhiteSpace) / 2;

            sb.Append(WhiteSpace, marginWhiteSpace);
            sb.Append(currentLetter);

            if (lineNumber > 0 && lineNumber < diamondSize - 1)
            {
                sb.Append(WhiteSpace, middleWhiteSpace);
                sb.Append(currentLetter);
            }

            sb.Append(WhiteSpace, marginWhiteSpace);
            if (lineNumber >= diamondSize / 2)
            {
                currentLetter--;
            }
            else
            {
                currentLetter++;
            }

            if (lineNumber < diamondSize - 1)
            {
                sb.AppendLine();
            }

            lineNumber++;
        }

        return sb.ToString();
    }

    private static int? GetAlphabetIndex(char letter)
        => char.IsLetter(letter) ? char.ToUpperInvariant(letter) - 'A' : null;
}
