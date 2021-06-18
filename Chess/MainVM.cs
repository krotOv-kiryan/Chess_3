using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using Chess.Model;

namespace Chess.ViewModel
{
    public class MainVM : ReactiveObject
    {
        public Board Board { get; }

        public Player Turn { get; set; } //ход

        private Square SelectedPiecePos { get; set; }
        public IObservableCollection<Square> SelectedPieceMoves { get; }

        public ReactiveCommand<Square, Unit> ProcessSquareClick { get; set; }

        private Dictionary<Square, List<Square>> LegalMoves;//ходы

        private MoveGenerator MoveGen; 

        public MainVM()
        {
            Board = new Board();
            SelectedPieceMoves = new ObservableCollectionExtended<Square>();

            ProcessSquareClick = ReactiveCommand.Create<Square>(x => ProcessClick(x));

            MoveGen = new MoveGenerator();

            //ход и передача хода
            Turn = Player.White;
            SelectedPiecePos = null;
            LegalMoves = MoveGen.GenerateMoves(Board, Turn);
        }
        
        private void ProcessClick(Square S)
        {
            var ClickedPiece = Board.GetPiece(S);

            if (SelectedPiecePos != null && LegalMoves[SelectedPiecePos].Contains(S))
            {

                MakeMove(SelectedPiecePos, S);
            }

            else 
            if (ClickedPiece != null && ClickedPiece.Player == Turn)
            {

                SelectPiece(S);
            }
            else
                SelectPiece(null);
        }

        private void SelectPiece(Square S)
        {
            SelectedPiecePos = S;
            SelectedPieceMoves.Clear();

            if (SelectedPiecePos != null)
            {
                SelectedPieceMoves.Add(SelectedPiecePos);
                SelectedPieceMoves.AddRange(LegalMoves[SelectedPiecePos]);
            }
        }
        
        private void MakeMove(Square From, Square To)
        {
            Board.MovePiece(From, To);
            SelectPiece(null);

            //
            Turn = (Turn == Player.White) ? Player.Black : Player.White;
            LegalMoves = MoveGen.GenerateMoves(Board, Turn);
        }

        public void Square_clicked(Point P)
        {//границы

            int Rank = (int)Math.Floor(P.Y);
            int File = (int)Math.Floor(P.X);

            if (Rank < 0) Rank = 0;
            if (Rank > 7) Rank = 7;
            if (File < 0) File = 0;
            if (File > 7) File = 7;
            
            ProcessSquareClick.Execute(new Square(File, Rank)).Subscribe();
        }
    }
}
