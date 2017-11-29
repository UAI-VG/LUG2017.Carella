using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class BPawn : BlackPiece
    {
        public override string ToOut
        {
            get
            {
                string n;
                n = "P" + Position.ToString();
                return n;
            }
        }
        public override IEnumerable<Square> Moves
        {
            get
            {
                List<Square> moves = new List<Square>();

                //Standar move
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col -= 0;
                    row -= 1;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest) && !Board.IsOccupied(dest))
                    {
                        moves.Add(dest);
                    }

                }
                //from starting position
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    if (row == 1)
                    {
                        col -= 0;
                        row -= 2;
                        Square dest = new Square(col, row);
                        if (!Board.IsInvalid(dest) && !Board.IsOccupied(dest))
                        {
                            moves.Add(dest);
                        }
                    }


                }
                //Take enemy piece
                return moves;
            }
        }
    }
}
