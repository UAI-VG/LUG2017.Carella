using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : WhitePiece
    {
        public override string ToOut
        {
            get
            {
                string n;
                n = "C" + Position.ToString();
                return n;
            }
        }
        public override IEnumerable<Square> Moves
        {
            get
            {
                List<Square> moves = new List<Square>();

                // Up and right
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col -= 2;
                    row+=1;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest))
                    if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                        !Program.board.pieces[col, row].IsWhite))
                    {
                            try
                            {
                                if (Program.board.pieces[col, row].IsWhite)
                                    Program.PiezasAmenazadas.Add(Program.board.pieces[col, row]);
                            }
                            catch
                            {
                                //
                            }
                            moves.Add(dest);
                    }
                    
                }

                // Up and left
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col -= 2;
                    row -= 1;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest))
                        if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                         !Program.board.pieces[col, row].IsWhite))
                    {
                            try
                            {
                                if (Program.board.pieces[col, row].IsWhite)
                                    Program.PiezasAmenazadas.Add(Program.board.pieces[col, row]);
                            }
                            catch
                            {
                                //
                            }
                            moves.Add(dest);
                    }
                }

                // Right and up
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col -= 1;
                    row += 2;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest))
                        if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                        !Program.board.pieces[col, row].IsWhite))
                    {
                            try
                            {
                                if (Program.board.pieces[col, row].IsWhite)
                                    Program.PiezasAmenazadas.Add(Program.board.pieces[col, row]);
                            }
                            catch
                            {
                                //
                            }
                            moves.Add(dest);
                    }

                }

                // Left and up
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col -= 1;
                    row -= 2;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest))
                        if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                        !Program.board.pieces[col, row].IsWhite))
                    {
                            try
                            {
                                if (Program.board.pieces[col, row].IsWhite)
                                    Program.PiezasAmenazadas.Add(Program.board.pieces[col, row]);
                            }
                            catch
                            {
                                //
                            }
                            moves.Add(dest);
                    }

                }
                // Down and right
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col += 2;
                    row += 1;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest))
                        if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                         !Program.board.pieces[col, row].IsWhite))
                    {
                            try
                            {
                                if (Program.board.pieces[col, row].IsWhite)
                                    Program.PiezasAmenazadas.Add(Program.board.pieces[col, row]);
                            }
                            catch
                            {
                                //
                            }
                            moves.Add(dest);
                    }

                }
                // Down and left
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col += 2;
                    row -= 1;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest))
                        if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                         !Program.board.pieces[col, row].IsWhite))
                    {
                            try
                            {
                                if (Program.board.pieces[col, row].IsWhite)
                                    Program.PiezasAmenazadas.Add(Program.board.pieces[col, row]);
                            }
                            catch
                            {
                                //
                            }
                            moves.Add(dest);
                    }

                }
                //Right and down
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col += 1;
                    row += 2;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest))
                        if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                         !Program.board.pieces[col, row].IsWhite))
                    {
                            try
                            {
                                if (Program.board.pieces[col, row].IsWhite)
                                    Program.PiezasAmenazadas.Add(Program.board.pieces[col, row]);
                            }
                            catch
                            {
                                //
                            }
                            moves.Add(dest);
                    }

                }
                //Left and down
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    col += 1;
                    row -= 2;
                    Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest))
                        if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                        !Program.board.pieces[col, row].IsWhite))
                    {
                            try
                            {
                                if (Program.board.pieces[col, row].IsWhite)
                                    Program.PiezasAmenazadas.Add(Program.board.pieces[col, row]);
                            }
                            catch
                            {
                                //
                            }
                            moves.Add(dest);
                    }

                }
                return moves;
            }
        }
    }
}
