using System.Collections.Generic;

namespace Chess.Model.Pieces
{
    public class Knight : PieceBase
    {
        public Knight(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.Knight;
            Deltas = new Delta[]
            {
                // Г
                new Delta(-2, -1), new Delta(-2, 1),
                new Delta(-1, 2), new Delta(1, 2),
                new Delta(2, 1), new Delta(2, -1),
                new Delta(1, -2), new Delta(-1, -2)
            };
        }

        public override IEnumerable<Square> GetPseudoLegalMoves(Board BoardState)
        {
            var Moves = new List<Square>();
            var S = Pos;

            foreach (Delta D in Deltas)
            {
                var Obstacle = BoardState.GetPiece(S + D);
                if ((Obstacle == null || Obstacle.Player != Player) && !(S + D).IsOffBoard())
                    Moves.Add(S + D);
            }
            return Moves;
        }
    }
}
