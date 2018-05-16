namespace Lib
{
    public class Score
    {
        public Score(int blacks, int whites)
        {
            Blacks = blacks;
            Whites = whites;
        }

        public int Blacks { get; }
        public int Whites { get; }

        public override bool Equals(object rhs)
        {
            if (rhs is Score) return Blacks == ((Score)rhs).Blacks && Whites == ((Score)rhs).Whites;
            return false;
        }

        public override int GetHashCode()
        {
            return
                Blacks.GetHashCode() * 8976553 ^
                Whites.GetHashCode() * 33456;
        }

        public override string ToString()
        {
            return $"{Blacks}{Whites}";
        }
    }
}
