# polynomials-pratt-algorithm
Parsing polynomials using pratt algorithm
![Build and test](https://github.com/davidelettieri/polynomials-pratt-algorithm/workflows/Build%20and%20test/badge.svg)

Using a Pratt parser I aim to parse expressions like this `x^2+y^2-1, x=1, y=1` and `xy, x=2, y=3`. Parsing mathematical expressions it's not hard but it already contains some interesting behaviour such as associativity between operators `x+y*z` is equal to `x+(y*z)` and not `(x+y)*z`. For no particular reason I decided to put the variable assignments after the polynomial. The expression `x^2+y^2-1, x=1, y=1` is to be interpreted as you would with this pseudo code
```
x=1
y=1
print (x*2+y^2+1)
```

The Pratt algorithm allows to create a "general purpose parser" in which is possible to plug in all the parser rules needed for your language or grammar. In my implementation I decided to build a parsed with fixed parsing rules by adding them into the constructors. But as you can see in the Java example (see references) it's easy to create a generic parser and plug the rules by subclassing it. 

## References 

I came across the Pratt parsing algorithm while reading https://craftinginterpreters.com/, which is a great resource on interpreters and compilers. From the same author, a java implementation of a Pratt parser http://journal.stuffwithstuff.com/2011/03/19/pratt-parsers-expression-parsing-made-easy/.

More formal resources are the paper from Pratt in which he explains the algorithm for the first time https://dl.acm.org/doi/10.1145/512927.512931 and a thesis which is more approachable http://vandevanter.net/mlvdv/publications/a-formalization-and-proof-o.html
