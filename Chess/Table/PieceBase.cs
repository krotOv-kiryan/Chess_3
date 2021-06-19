using ReactiveUI;
using System.Collections.Generic;

namespace Chess.Model.Pieces
{
    public abstract class PieceBase : ReactiveObject, IPiece
    {
        private Square pos;
        public Square Pos
        {
            get => pos; set => this.RaiseAndSetIfChanged(ref pos, value);
        }
        public PieceType Type { get; protected set; }
        public Player Player { get; protected set; }
        public Delta[] Deltas { get; protected set; }
        public PieceBase(Square Position, Player Player)
        {
            pos = Position;
            this.Player = Player;
        }
        public abstract IEnumerable<Square> GetPseudoLegalMoves(Board BoardState);
    }
}
