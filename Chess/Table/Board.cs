using Chess.Model.Pieces;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Linq;

namespace Chess.Model
{
    public class Board : ReactiveObject
    {// класс доски - спавн и тд
        private SourceCache<IPiece, Square> pieces;
        public IObservableCollection<IPiece> Pieces { get; }//set;

        public Board()
        {
            pieces = new SourceCache<IPiece, Square>(k => k.Pos);
            pieces.AddOrUpdate(new IPiece[] {
                //спавн
                new Pawn(new Square(0, 6), Player.White),
                new Pawn(new Square(1, 6), Player.White),
                new Pawn(new Square(2, 6), Player.White),
                new Pawn(new Square(3, 6), Player.White),
                new Pawn(new Square(4, 6), Player.White),
                new Pawn(new Square(5, 6), Player.White),
                new Pawn(new Square(6, 6), Player.White),
                new Pawn(new Square(7, 6), Player.White),

                new Rook(new Square(0, 7), Player.White),
                new Knight(new Square(1, 7), Player.White),
                new Bishop(new Square(2, 7), Player.White),
                new Queen(new Square(3, 7), Player.White),
                new King(new Square(4, 7), Player.White),
                new Bishop(new Square(5, 7), Player.White),
                new Knight(new Square(6, 7), Player.White),
                new Rook(new Square(7, 7), Player.White),
                //
                //
                new Pawn(new Square(0, 1), Player.Black),
                new Pawn(new Square(1, 1), Player.Black),
                new Pawn(new Square(2, 1), Player.Black),
                new Pawn(new Square(3, 1), Player.Black),
                new Pawn(new Square(4, 1), Player.Black),
                new Pawn(new Square(5, 1), Player.Black),
                new Pawn(new Square(6, 1), Player.Black),
                new Pawn(new Square(7, 1), Player.Black),

                new Rook(new Square(0, 0), Player.Black),
                new Knight(new Square(1, 0), Player.Black),
                new Bishop(new Square(2, 0), Player.Black),
                new Queen(new Square(3, 0), Player.Black),
                new King(new Square(4, 0), Player.Black),
                new Bishop(new Square(5, 0), Player.Black),
                new Knight(new Square(6, 0), Player.Black),
                new Rook(new Square(7, 0), Player.Black)
                });
            //
            Pieces = new ObservableCollectionExtended<IPiece>();
            pieces.Connect().Bind(Pieces).Subscribe();//подписываем обработчик на последовательность
        }

        public IPiece GetPiece(Square S) => pieces.Items.SingleOrDefault(p => p.Pos.Equals(S));

        public void KillPiece(Square S) { pieces.Remove(S); }

        public void MovePiece(Square From, Square To)
        {
            IPiece PieceToMove = GetPiece(From);
            if (PieceToMove != null)
            {
                if (GetPiece(To) != null) KillPiece(To);
                PieceToMove.Pos = To;
                pieces.AddOrUpdate(PieceToMove);
                pieces.RemoveKey(From);
            }
        }

        public void PutPiece(IPiece Piece) { pieces.AddOrUpdate(Piece); }
    }
}
