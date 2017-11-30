using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class MoveParaCommand
    {
     public   char Icono;
      public  int PosX;
       public int PosY;
       public char Iconocomido;
       public int PosXC;
       public int PosYC;
        public void Hacer()
        {
            Program.board.pieces[PosX, PosY] = null;
           // Program.board.pieces[PosXC,PosYC]=Program.
        }
        public void Deshacer()
        {

        }

    }
   
   
}
