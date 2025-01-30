# Problem: 
Given a character from the alphabet, print a diamond of its output with that character being the midpoint of the diamond.

Examples

    > diamond.exe A
      A

    > diamond.exe B
       A
      B B
       A

    > diamond.exe C
        A
       B B
      C   C
       B B
        A


# Solution:

Using TDD, I tested two approaches:
1. Using StringBuilder to generate the output (as seen in DiamondService)
2. Using Span<T> to possibly reduce the memory allocated and halve the iteration by mirroring the already identified lines. (AlternativeDiamondService)

I kept both as I found the first solution more readable and maintainable, but I was curious about the other idea. 

The unit tests can be applied to both services to test the implementations.
