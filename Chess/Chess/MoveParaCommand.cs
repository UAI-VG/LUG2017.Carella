using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class MoveParaCommand
    {
        private Piece TheOneThatMoved;
        private Piece TheOneThatGotMovedOn;
        public MoveParaCommand(Piece Mover, Piece Movee,Board B, Square StoM)
        {
            TheOneThatMoved = Mover;
            TheOneThatGotMovedOn = Movee;
            Move(B, null, Mover.Position);
            Move(B, Mover, StoM);
            
           
        }
        public void Move(Board B,Piece P, Square S)
        {
            B.MovePiece(S,P);
        }
    }
   
   
}
