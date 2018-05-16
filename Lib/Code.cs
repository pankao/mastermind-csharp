using System.Collections.Immutable;
using System.Linq;

namespace Lib
{
    public class Code
    {
        public Code(Peg p0, Peg p1, Peg p2, Peg p3)
        {
            Pegs = ImmutableList.Create(p0, p1, p2, p3);
        }

        public IImmutableList<Peg> Pegs { get; }

        public override bool Equals(object rhs)
        {
            if (rhs is Code) return Pegs.SequenceEqual(((Code)rhs).Pegs);
            return false;
        }

        public override int GetHashCode()
        {
            return
                Pegs[0].GetHashCode() * 8976553 ^
                Pegs[1].GetHashCode() * 33456 ^
                Pegs[2].GetHashCode() * 57246351 ^
                Pegs[3].GetHashCode() * 1865874;
        }

        public override string ToString()
        {
            return $"{(int)Pegs[0]}{(int)Pegs[1]}{(int)Pegs[2]}{(int)Pegs[3]}";
        }
    }
}
