namespace Mastermind
{
    public enum Peg
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black,
        White
    }

    public static class PegExtensions
    {
        public static string ToFriendlyString(this Peg peg)
        {
            switch (peg)
            {
                case Peg.Red: return "R";
                case Peg.Green: return "G";
                case Peg.Blue: return "B";
                case Peg.Yellow: return "Y";
                case Peg.Black: return "b";
                case Peg.White: return "w";
                default: return "?";
            }
        }
    }
}
