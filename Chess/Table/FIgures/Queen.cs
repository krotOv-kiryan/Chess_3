namespace Chess.Model.Pieces
{
    public class Queen : Slider
    {
        public Queen(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.Queen;
            Deltas = new Delta[]
            {
                new Delta(-1, -1), new Delta(1, 1),
                new Delta(-1, 1), new Delta(1, -1),
                new Delta(-1, 0), new Delta(1, 0),
                new Delta(0, 1), new Delta(0, -1),
            };
        }
    }
}
