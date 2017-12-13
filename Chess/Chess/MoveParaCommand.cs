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
        private Square WhereToMove;
        public MoveParaCommand(Piece Mover, Piece Movee,Board B, Square StoM)
        {
            if (Mover.IsWhite)
            TheOneThatMoved = Program.GetPiece(Mover.ToOut[0]);
            else
            TheOneThatMoved = Program.GetBlackPiece(Mover.ToOut[0]);
            TheOneThatMoved.Position = new Square(Mover.Position.Column, Mover.Position.Row);
            TheOneThatGotMovedOn = Movee;
            WhereToMove = StoM;
            Move(B, null, Mover.Position);
            Move(B, Mover, StoM);
            
           
        }
        //el bool random lo meti por que el compilador me hacia cosas raras sino, si queres preguntame en clase
        //o te hago un video, por ahora lo dejo asi para sacarme el tp de encima
       public MoveParaCommand (Board B,Piece Respawn, Piece MoveBack, bool sobrecargademierda, Square S)
        {
            if (MoveBack.IsWhite)
            TheOneThatMoved = Program.GetPiece(MoveBack.ToOut[0]);
            else
            TheOneThatMoved = Program.GetBlackPiece(MoveBack.ToOut[0]);
            TheOneThatMoved.Position = new Square(MoveBack.Position.Column, MoveBack.Position.Row);
            TheOneThatGotMovedOn = Respawn;
            WhereToMove = S;
            Move(B, Respawn, S);
            Move(B, MoveBack,MoveBack.Position);
        }
        private void Move(Board B,Piece P, Square S)
        {
            B.MovePiece(S,P);
        }
        public void Undo(Board B, Stack<MoveParaCommand> Coleccion)
        {
          Coleccion.Push(  new MoveParaCommand(B, TheOneThatGotMovedOn, TheOneThatMoved, true, WhereToMove));
            /*
            Move(B, TheOneThatMoved, TheOneThatMoved.Position);
            if (TheOneThatGotMovedOn != null)
                Move(B, TheOneThatGotMovedOn, TheOneThatGotMovedOn.Position);
            else
                Move(B, null, WhereToMove);
                */
        }
        public void Redo(Board B, Stack<MoveParaCommand> Coleccion)
        {
            Coleccion.Push(new MoveParaCommand(TheOneThatMoved, TheOneThatGotMovedOn, B, WhereToMove));
        }
    }
   
   
}
