using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class BlackPiece : Piece
    {
        public override bool IsWhite
        {
            get
            {
                return false;
            }
        }
    }
}
