using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class Code
    {
        public Code(Peg peg0, Peg peg1, Peg peg2, Peg peg3)
        {
            Pegs = new[] { peg0, peg1, peg2, peg3 };
        }

        public IEnumerable<Peg> Pegs { get; }

        public override bool Equals(object rhs)
        {
            if (rhs is Code) return Pegs.SequenceEqual(((Code)rhs).Pegs);
            return false;
        }

        public override int GetHashCode()
        {
            var ps = Pegs.ToList();
            return
                ps[0].GetHashCode() * 8976553 ^
                ps[1].GetHashCode() * 33456 ^
                ps[2].GetHashCode() * 57246351 ^
                ps[3].GetHashCode() * 1865874;
        }

        public override string ToString()
        {
            var ps = Pegs.Cast<int>().ToList();
            return $"{ps[0]}{ps[1]}{ps[2]}{ps[3]}";
        }
    }
}
