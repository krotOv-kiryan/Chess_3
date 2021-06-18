namespace Chess.Model.Pieces
{
    public class Rook : Slider
    {
        public Rook(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.Rook;
            Deltas = new Delta[]
            {
                new Delta(-1, 0), new Delta(1, 0),
                new Delta(0, 1), new Delta(0, -1),
            };
        }
    }
}
