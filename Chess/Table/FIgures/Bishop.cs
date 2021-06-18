namespace Chess.Model.Pieces
{
    public class Bishop : Slider
    {
        public Bishop(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.Bishop;
            Deltas = new Delta[]
            {
                new Delta(-1, -1), new Delta(1, 1),
                new Delta(-1, 1), new Delta(1, -1),
            };
        }
    }
}
