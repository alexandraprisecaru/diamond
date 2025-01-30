namespace DiamondLetters.UnitTests;

using DiamondLetters.Exceptions;

public class DiamondServiceTests
{
    readonly DiamondService diamondService = new();

    [Fact]
    public void CreateDiamond_OnInvalidCharacter_ThrowInvalidLetterException()
    {
        Assert.Throws<InvalidLetterException>(() => diamondService.GetDiamondRepresentation('1'));
    }

    [Fact]
    public void CreateDiamond_OnCharacterA_ReturnsTheSameCharacterAsString()
    {
        string result = diamondService.GetDiamondRepresentation('A');
        Assert.Equal("A", result);
    }

    [Fact]
    public void CreateDiamond_OnLowerCharacterA_ReturnsTheSameCharacterAsString()
    {
        string result = diamondService.GetDiamondRepresentation('a');
        Assert.Equal("a", result);
    }

    [Fact]
    public void CreateDiamond_OnCharacterB_ReturnsDiamondThatHasBInTheMiddle()
    {
        string expectedDiamond = @"
 A 
B B
 A ".TrimStart('\n');

        string result = diamondService.GetDiamondRepresentation('B');
        Assert.Equal(expectedDiamond.Length, result.Length);
        Assert.Equal(expectedDiamond, result);
    }

    [Fact]
    public void CreateDiamond_OnCharacterC_ReturnsDiamondThatHasCInTheMiddle()
    {
        string expectedDiamond = @"
  A  
 B B 
C   C
 B B 
  A  ".TrimStart('\n');

        string result = diamondService.GetDiamondRepresentation('C');
        Assert.Equal(expectedDiamond.Length, result.Length);
        Assert.Equal(expectedDiamond, result);
    }

    [Fact]
    public void CreateDiamond_OnCharacterZ_ReturnsDiamondThatHasZInTheMiddle()
    {
        string expectedDiamond = @"
                         A                         
                        B B                        
                       C   C                       
                      D     D                      
                     E       E                     
                    F         F                    
                   G           G                   
                  H             H                  
                 I               I                 
                J                 J                
               K                   K               
              L                     L              
             M                       M             
            N                         N            
           O                           O           
          P                             P          
         Q                               Q         
        R                                 R        
       S                                   S       
      T                                     T      
     U                                       U     
    V                                         V    
   W                                           W   
  X                                             X  
 Y                                               Y 
Z                                                 Z
 Y                                               Y 
  X                                             X  
   W                                           W   
    V                                         V    
     U                                       U     
      T                                     T      
       S                                   S       
        R                                 R        
         Q                               Q         
          P                             P          
           O                           O           
            N                         N            
             M                       M             
              L                     L              
               K                   K               
                J                 J                
                 I               I                 
                  H             H                  
                   G           G                   
                    F         F                    
                     E       E                     
                      D     D                      
                       C   C                       
                        B B                        
                         A                         ".TrimStart('\n');


        string result = diamondService.GetDiamondRepresentation('Z');
        Assert.Equal(expectedDiamond.Length, result.Length);
        Assert.Equal(expectedDiamond, result);
    }

    [Fact]
    public void CreateDiamond_OnLowerCharacter_ReturnsDiamondThatHasLowerCharacters()
    {
        string expectedDiamond = @"
    a    
   b b   
  c   c  
 d     d 
e       e
 d     d 
  c   c  
   b b   
    a    ".TrimStart('\n');

        string result = diamondService.GetDiamondRepresentation('e');
        // Assert.Equal(expectedDiamond.Length, result.Length);
        Assert.Equal(expectedDiamond, result);
    }
}
