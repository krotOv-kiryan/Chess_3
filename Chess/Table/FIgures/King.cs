using ReactiveUI;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Chess.Model.Pieces
{
    public class King : PieceBase
    {
        private ObservableAsPropertyHelper<bool> castling;
        private bool Castling => castling.Value;

        public King(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.King;
            Deltas = new Delta[]
            {
                new Delta(-1, -1), new Delta(1, 1),
                new Delta(-1, 1), new Delta(1, -1),
                new Delta(-1, 0), new Delta(1, 0),
                new Delta(0, 1), new Delta(0, -1),
            };
            //доделать рокировку...там надо брать ещё rook(лево+ право)
            castling = this.WhenAny(x => x.Pos, _ => new bool())
            .Select(x => Pos.Rank == 6 && Player == Player.White || Pos.Rank == 1 && Player == Player.Black)
                .ToProperty(this, x => x.Castling);
        }

        public override IEnumerable<Square> GetPseudoLegalMoves(Board BoardState)
        {
            var Moves = new List<Square>();
            var S = Pos;


            foreach (Delta D in Deltas)
            {
                var Obstacle = BoardState.GetPiece(S + D);
                if ((Obstacle == null || Obstacle.Player != Player) && !(S + D).IsOffBoard())
                {
                    Moves.Add(S + D);
                    if (Castling)
                    {
                        S += D;
                        Obstacle = BoardState.GetPiece(S);
                        if (Obstacle == null) Moves.Add(S);
                    }
                }

            }
            return Moves;
           
        }
    }
}
