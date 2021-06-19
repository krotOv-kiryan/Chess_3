using ReactiveUI;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace Chess.Model.Pieces
{
    public class King : PieceBase
    {
      //  private ObservableAsPropertyHelper<bool> castling;
       // private bool Castling => castling.Value;
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
            /* castling = this.WhenAny(x => x.Pos, _x => new bool())
             .Select(x => Pos.Rank == 7 && Player == Player.White || Pos.Rank == 0 && Player == Player.Black)
                 .ToProperty(this, x => x.Castling);*/
            //&& CS0117
            /* castling = this.WhenAny(y => y.Pos, _y => new bool()) 
           .Select(y => Pos.File == 4 && Player == Player.White || Pos.File == 4 && Player == Player.Black)
               .ToProperty(this, y => y.Castling);   */
        }

        public override IEnumerable<Square> GetPseudoLegalMoves(Board BoardState)
        {
            var Moves = new List<Square>();
            var S = Pos;
           
            foreach (Delta D in Deltas)
            {
                var O = BoardState.GetPiece(S + D);
                if ((O == null || O.Player != Player) && !(S + D).IsOffBoard())
                {
                    Moves.Add(S + D);
                   /* if (Castling)
                    {
                        Square N = Pos + D;
                        S += D;
                        Obstacle = BoardState.GetPiece(S);
                        if (Obstacle == null) Moves.Add(S);
                    }*/
                }
            }
            return Moves;
        }
    }
}
