namespace DiamondLetters.Console;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class DiamondServicesBenchmark
{
    private readonly DiamondService diamondService = new();
    private readonly AlternativeDiamondService alternativeDiamondService = new();

    [Benchmark]
    public void CreateDiamondLowerCaseZ()
    {
        diamondService.CreateDiamond('z');
    }

    [Benchmark]
    public void CreateAlternativeDiamondLowerCaseZ()
    {
        alternativeDiamondService.CreateDiamond('z');
    }

    [Benchmark]
    public void CreateDiamondUpperCaseZ()
    {
        diamondService.CreateDiamond('Z');
    }

    [Benchmark]
    public void CreateAlternativeDiamondUpperCaseZ()
    {
        alternativeDiamondService.CreateDiamond('Z');
    }

    [Benchmark]
    public void CreateDiamondUpperCaseA()
    {
        diamondService.CreateDiamond('A');
    }

    [Benchmark]
    public void CreateAlternativeDiamondUpperCaseA()
    {
        alternativeDiamondService.CreateDiamond('A');
    }

    [Benchmark]
    public void CreateDiamondUpperCaseM()
    {
        diamondService.CreateDiamond('M');
    }

    [Benchmark]
    public void CreateAlternativeDiamondUpperCaseM()
    {
        alternativeDiamondService.CreateDiamond('M');
    }
}
