using System.Collections.Generic;

namespace Chess.Model.Pieces
{
    public interface IPiece
    {
        Square Pos { get; set; }
        PieceType Type { get; }
        Player Player { get; }
        Delta[] Deltas { get; }
        IEnumerable<Square> GetPseudoLegalMoves(Board BoardState);
    }
}
