using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Model.Pieces;
using ReactiveUI;

namespace Chess.Model
{
    public class Square : ReactiveObject, IEquatable<Square>
    {
        public static char[] Ranks = { '8', '7', '6', '5', '4', '3', '2', '1' };
        public static char[] Files = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        private int rank;
        public int Rank
        {
            get => rank; 
            set => this.RaiseAndSetIfChanged(ref rank, value);  
        }
        private int file;
        public int File
        {
            get => file;
            set => this.RaiseAndSetIfChanged(ref file, value);
        }
        public Square()
        {
            File = 0;
            Rank = 0;
        }
        public Square(int Vertical, int Horizontal)
        {
            File = Vertical;
            Rank = Horizontal;
        }
        public Square(Square S)
        {
            File = S.File;
            Rank = S.Rank;
        }
        public static Square operator +(Square S, Delta D)
        {
            return new Square(S.File + D.H, S.Rank + D.V);
        }
        public static Square operator +(Delta D, Square S)
        {
            return new Square(S.File + D.H, S.Rank + D.V);
        }
        public bool IsOffBoard()
        {
            return (file < 0 || file > 7 || rank < 0 || rank > 7) ? true : false;
        }
        public override bool Equals(object obj)
        {
            Square o = obj as Square;//other
            if (o == null) return false;
            if (o.File == File && o.Rank == Rank) return true;
            return false;
        }
        public bool Equals(Square other)
        {
            return other != null &&
                   rank == other.rank &&
                   file == other.file;
        }
        public override int GetHashCode()
        {
            var hashCode = file;
            hashCode <<= 16;
            hashCode += rank;
            return hashCode;
        }

        public override string ToString()
        {
            if (IsOffBoard()) return "Square is off board.";
            return $"{Files[File]}{Ranks[Rank]}";
        }

    }
}
