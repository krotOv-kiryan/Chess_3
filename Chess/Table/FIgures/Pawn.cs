using ReactiveUI;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Chess.Model.Pieces
{
    public class Pawn : PieceBase
    {
        private Delta[] attacks;

        private ObservableAsPropertyHelper<bool> longMove;
       
        private ObservableAsPropertyHelper<bool> transformation;
        private bool LongMove => longMove.Value;
        //private bool Transformation => transformation.Value;
        public Pawn(Square Position, Player Player) : base(Position, Player)
        {
            Type = PieceType.Pawn;
            if (Player == Player.White)
            {
                Deltas = new Delta[] { new Delta(-1, 0) };
                attacks = new Delta[] { new Delta(-1,-1), new Delta(-1, 1)};
            }
            else
            {
                Deltas = new Delta[] { new Delta(1, 0) };
                attacks = new Delta[] { new Delta(1, -1), new Delta(1, 1) };
            }
            longMove = this.WhenAny(x => x.Pos, _ => new bool())
                .Select(x => Pos.Rank == 6 && Player == Player.White || Pos.Rank == 1 && Player == Player.Black)
                .ToProperty(this, x => x.LongMove);
            
           /* transformation = this.WhenAny(x => x.Pos, _ => new bool())
            .Select(x => Pos.Rank == 0 && Player == Player.White || Pos.Rank == 7 && Player == Player.Black)
                .ToProperty(this, x => x.Transformation);*/
            
        }

        public override IEnumerable<Square> GetPseudoLegalMoves(Board BoardState)
        {
            var Moves = new List<Square>();
            var D = Deltas[0];

            Square S = Pos + D;

            var O = BoardState.GetPiece(S);
            if (O == null)
            {
                Moves.Add(S);
                if (LongMove)
                {
                    S += D;
                    O = BoardState.GetPiece(S);
                    if (O == null) Moves.Add(S);
                }
                /*if (Transformation)
                {
                    S += D;
                    O = BoardState.GetPiece(S);
                    if (O == null) Moves.Add(S);
                }*/
            }

            S = Pos;
            foreach (Delta A in attacks)
            {
                O = BoardState.GetPiece(S + A);
                if (O != null && O.Player != Player) Moves.Add(S + A);
            }
            return Moves;
        }
    }
}
