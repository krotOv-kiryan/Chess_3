using Chess.Model;
using System.Collections.Generic;
using System.Linq;

namespace Chess.ViewModel
{
    public class MoveGenerator //
    {
        public Dictionary<Square, List<Square>> GenerateMoves(Board Board, Player Turn)
        {
            var Moves = new Dictionary<Square, List<Square>>();
            var Friends = Board.Pieces.Where(x => x.Player == Turn);

            foreach (var Piece in Friends)
            {
                var PieceMoves = new List<Square>();
                Moves.Add(Piece.Pos, Piece.GetPseudoLegalMoves(Board).ToList());
            }
            return Moves;
        }
    }
}
