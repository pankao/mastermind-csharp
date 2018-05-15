using System.Collections.Generic;

namespace Lib
{
    public class Code
    {
        public Code(Peg peg0, Peg peg1, Peg peg2, Peg peg3)
        {
            Pegs = new[] { peg0, peg1, peg2, peg3 };
        }

        public IEnumerable<Peg> Pegs { get; }
    }
}
