using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : WhitePiece
    {
        public override string ToOut
        {
            get
            {
                string n;
                n = "R" + Position.ToString();
                return n;
            }
        }
        public override IEnumerable<Square> Moves
        {
            get
            {
                List<Square> Amenazadas = new List<Square>();
                    List<Square> moves = new List<Square>();
                //fase de checkeo de casillas amenazadas
                {
                    if (!KingRequest)
                    {
                        IsRequesting = true;
                        foreach (Piece Pieza in Program.board.Pieces)
                        {
                            if (Pieza.IsRequesting==false)
                            {
                                Pieza.KingRequest = true;
                                Amenazadas.AddRange(Pieza.Moves);
                                Pieza.KingRequest = false;
                            }

                        }
                        IsRequesting = false;
                    }
                }
                    // UPPER RIGHT
                    {
                        int col = Position.Column;
                        int row = Position.Row;
                        
                            col += 1;
                            row += 1;
                            Square dest = new Square(col, row);
                        if (!Board.IsInvalid(dest) &&( !Board.IsOccupied(dest)||
                        !Program.board.pieces[col, row].IsWhite))
                        {
                            moves.Add(dest);
                        }
                    }

                    // UPPER LEFT
                    {
                        int col = Position.Column;
                        int row = Position.Row;
                       
                            col -= 1;
                            row += 1;
                            Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                         !Program.board.pieces[col, row].IsWhite))
                    {
                        moves.Add(dest);
                    }
                }

                    // BOTTOM RIGHT
                    {
                        int col = Position.Column;
                        int row = Position.Row;
                       
                            col += 1;
                            row -= 1;
                            Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                          !Program.board.pieces[col, row].IsWhite))
                    {
                        moves.Add(dest);
                    }
                }

                    // BOTTOM LEFT
                    {
                        int col = Position.Column;
                        int row = Position.Row;
                       
                            col -= 1;
                            row -= 1;
                            Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                         !Program.board.pieces[col, row].IsWhite))
                    {
                        moves.Add(dest);
                    }

                }

                    // UP
                    {
                        int col = Position.Column;
                        int row = Position.Row;
                       
                            row += 1;
                            Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                         !Program.board.pieces[col, row].IsWhite))
                    {
                        moves.Add(dest);
                    }

                }

                    // LEFT
                    {
                        int col = Position.Column;
                        int row = Position.Row;
                       
                            col -= 1;
                            Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                        !Program.board.pieces[col, row].IsWhite))
                    {
                        moves.Add(dest);
                    }

                }

                    // RIGHT
                    {
                        int col = Position.Column;
                        int row = Position.Row;
                       
                            col += 1;
                            Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                         !Program.board.pieces[col, row].IsWhite))
                    {
                        moves.Add(dest);
                    }


                }

                    // DOWN
                    {
                        int col = Position.Column;
                        int row = Position.Row;
                       
                            row -= 1;
                            Square dest = new Square(col, row);
                    if (!Board.IsInvalid(dest) && (!Board.IsOccupied(dest) ||
                        !Program.board.pieces[col, row].IsWhite))
                    {
                        moves.Add(dest);
                    }

                }
                //seguramente alla una forma menos pt de hacer lo que estas por leer
                //pero son las 5:30 am, plz no me cagues a tiros
                List<Square> Auxiliarmoves = new List<Square>();
                foreach (Square Frustracion in moves)
                {
                    Auxiliarmoves.Add(Frustracion);
                }
                foreach (Square CasillaAmenazada in Amenazadas)
                {
                    foreach (Square CasillaEnRango in moves)
                    {
                        if(CasillaAmenazada.Column==CasillaEnRango.Column&&
                            CasillaAmenazada.Row==CasillaEnRango.Row)
                        {
                           Auxiliarmoves.Remove(CasillaEnRango);
                        }
                    }
                }
                    
                    return Auxiliarmoves ;
                }
            }
        }
    }

