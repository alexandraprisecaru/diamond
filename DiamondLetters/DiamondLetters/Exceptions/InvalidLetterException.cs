namespace DiamondLetters.Exceptions;

public class InvalidLetterException(char c) : Exception($"Input character {c} is not a letter");
