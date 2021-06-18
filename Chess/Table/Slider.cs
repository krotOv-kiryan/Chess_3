using System.Collections.Generic;

namespace Chess.Model.Pieces
{
    public class Slider : PieceBase
    {
        public Slider(Square Position, Player Player) : base(Position, Player) { }

        public override IEnumerable<Square> GetPseudoLegalMoves(Board BoardState)
        {
            var Moves = new List<Square>();
            foreach (var D in Deltas)
            {
                Square CurrentSqaure = Pos;
                IPiece Obstacle = null;

                while (!(CurrentSqaure += D).IsOffBoard() && Obstacle == null)
                {
                    Obstacle = BoardState.GetPiece(CurrentSqaure);

                    if ((Obstacle == null || Obstacle.Player != Player) && !CurrentSqaure.IsOffBoard())
                        Moves.Add(CurrentSqaure);
                }

            }
            return Moves;
        }
    }
}
