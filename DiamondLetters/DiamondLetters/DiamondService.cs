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

        var sb = new StringBuilder();

        int lineNumber = 0;
        char currentLetter = char.IsUpper(letter) ? 'A' : 'a';
        int diamondSize = 2 * alphabetIndex + 1;

        while (lineNumber < diamondSize)
        {
            bool isBoundary = lineNumber == 0 || lineNumber == diamondSize - 1;

            int currentLetterIndex = GetAlphabetIndex(currentLetter)!.Value;
            int lettersPerLine = isBoundary ? 1 : 2;
            int middleWhiteSpace = isBoundary ? 0 : 2 * currentLetterIndex - 1;
            int marginWhiteSpace = (diamondSize - lettersPerLine - middleWhiteSpace) / 2;

            AppendDiamondLine(sb, marginWhiteSpace, middleWhiteSpace, lineNumber, diamondSize, currentLetter);

            if (lineNumber >= diamondSize / 2)
                currentLetter--;
            else
                currentLetter++;

            if (lineNumber < diamondSize - 1)
            {
                sb.AppendLine();
            }

            lineNumber++;
        }

        return sb.ToString();
    }

    private static void AppendDiamondLine(StringBuilder sb, int margin, int middle, int lineNumber, int diamondSize, char letter)
    {
        sb.Append(WhiteSpace, margin);
        sb.Append(letter);

        if (lineNumber > 0 && lineNumber < diamondSize - 1)
        {
            sb.Append(WhiteSpace, middle);
            sb.Append(letter);
        }

        sb.Append(WhiteSpace, margin);
    }

    private static int? GetAlphabetIndex(char letter)
        => char.IsLetter(letter) ? char.ToUpperInvariant(letter) - 'A' : null;
}
