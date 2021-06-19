using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.Pieces
{
    public struct Delta 
    {
        public int V;
        public int H;
        public Delta(int Vertical, int Horizontal)
        {
            V = Vertical;
            H = Horizontal;
        }
    }
}
