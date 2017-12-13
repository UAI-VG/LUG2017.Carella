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
        public MoveParaCommand(Piece Mover, Piece Movee,Board B)
        {
            TheOneThatMoved = Mover;
            TheOneThatGotMovedOn = Movee;
           
        }
        public void Move(Board B)
        {
            B.pieces[TheOneThatMoved.Position.Column, TheOneThatMoved.Position.Row]
                = TheOneThatMoved;
            B.pieces[TheOneThatGotMovedOn.Position.Column, TheOneThatGotMovedOn.Position.Row]
                = TheOneThatGotMovedOn;
        }
    }
   
   
}
