using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Tower : WhitePiece
    {
        public override string ToOut
        {
            get
            {
                string n;
                n = "D" + Position.ToString();
                return n;
            }
        }
        public override IEnumerable<Square> Moves
        {
            get
            {
                List<Square> moves = new List<Square>();

                // UP
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    while (true)
                    {
                        row += 1;
                        Square dest = new Square(col, row);
                        if (Board.IsInvalid(dest)) break;
                        if (Board.IsOccupied(dest))
                        {
                            if (Program.board.pieces[col, row].IsWhite) break;
                            else
                            {
                                moves.Add(dest);
                                break;
                            }
                        }
                        moves.Add(dest);
                    }
                }

                // LEFT
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    while (true)
                    {
                        col -= 1;
                        Square dest = new Square(col, row);
                        if (Board.IsInvalid(dest)) break;
                        if (Board.IsOccupied(dest))
                        {
                            if (Program.board.pieces[col, row].IsWhite) break;
                            else
                            {
                                moves.Add(dest);
                                break;
                            }
                        }
                        moves.Add(dest);
                    }
                }

                // RIGHT
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    while (true)
                    {
                        col += 1;
                        Square dest = new Square(col, row);
                        if (Board.IsInvalid(dest)) break;
                        if (Board.IsOccupied(dest))
                        {
                            if (Program.board.pieces[col, row].IsWhite) break;
                            else
                            {
                                moves.Add(dest);
                                break;
                            }
                        }
                        moves.Add(dest);
                    }
                }

                // DOWN
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    while (true)
                    {
                        row -= 1;
                        Square dest = new Square(col, row);
                        if (Board.IsInvalid(dest)) break;
                        if (Board.IsOccupied(dest))
                        {
                            if (Program.board.pieces[col, row].IsWhite) break;
                            else
                            {
                                moves.Add(dest);
                                break;
                            }
                        }
                        moves.Add(dest);
                    }
                }

                return moves;
            }
        }
    }
}
