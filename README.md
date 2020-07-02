## Description

C# implementation of Knuth's algorithm to solve Mastermind within 5 guesses.

## TODO

* [x] Implement `RandomSecret`
* [x] Figure out why the non-parallel code is so slow
  * Answer: fix hot spot by optimising `EvaluateScore` - avoid LINQ in favour of simpler but faster code
* [ ] Implement command line args
* [ ] Implement parallelisation

## Links

* [Mastermind (board game)](https://en.wikipedia.org/wiki/Mastermind_(board_game))
* [Five-guess algorithm](https://en.wikipedia.org/wiki/Mastermind_(board_game)#Worst_case:_Five-guess_algorithm)
* [Knuth's mastermind algorithm](https://math.stackexchange.com/questions/1192961/knuths-mastermind-algorithm)
* [An implementation of Knuth's five-guess algorithm to solve a mastermind code](https://gist.github.com/firebus/2153677)
* [knuth-mastermind.pdf](https://www.cs.uni.edu/~wallingf/teaching/cs3530/resources/knuth-mastermind.pdf)
* [Mastermind web app using SVG and Vue.js](https://mastermind-svg-vue.herokuapp.com)
  * [Autosolve mode (using a web worker)](https://mastermind-svg-vue.herokuapp.com?autosolve)
  * [Code repo](https://github.com/taylorjg/mastermind-svg-vue)
