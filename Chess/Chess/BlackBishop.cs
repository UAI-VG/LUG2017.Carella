using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class BlackBishop : BlackPiece
    {
        public override string ToOut
        {
            get
            {
                string n;
                n = "A" + Position.ToString();
                return n;
            }
        }
        public override IEnumerable<Square> Moves
        {
            get
            {
                List<Square> moves = new List<Square>();

                // UPPER RIGHT
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    while (true)
                    {
                        col += 1;
                        row += 1;
                        Square dest = new Square(col, row);
                        if (Board.IsInvalid(dest)) break;
                        if (Board.IsOccupied(dest))
                        {
                            if (!Program.board.pieces[col, row].IsWhite) break;
                            else
                            {
                                moves.Add(dest);
                                break;
                            }
                        }
                        moves.Add(dest);
                    }
                }

                // UPPER LEFT
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    while (true)
                    {
                        col -= 1;
                        row += 1;
                        Square dest = new Square(col, row);
                        if (Board.IsInvalid(dest)) break;
                        if (Board.IsOccupied(dest))
                        {
                            if (!Program.board.pieces[col, row].IsWhite) break;
                            else
                            {
                                moves.Add(dest);
                                break;
                            }
                        }
                        moves.Add(dest);
                    }
                }

                // BOTTOM RIGHT
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    while (true)
                    {
                        col += 1;
                        row -= 1;
                        Square dest = new Square(col, row);
                        if (Board.IsInvalid(dest)) break;
                        if (Board.IsOccupied(dest))
                        {
                            if (!Program.board.pieces[col, row].IsWhite) break;
                            else
                            {
                                moves.Add(dest);
                                break;
                            }
                        }
                        moves.Add(dest);
                    }
                }

                // BOTTOM LEFT
                {
                    int col = Position.Column;
                    int row = Position.Row;
                    while (true)
                    {
                        col -= 1;
                        row -= 1;
                        Square dest = new Square(col, row);
                        if (Board.IsInvalid(dest)) break;
                        if (Board.IsOccupied(dest))
                        {
                            if (!Program.board.pieces[col, row].IsWhite) break;
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
