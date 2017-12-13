using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        //muerte al encapsulamiento.
        public Piece[,] pieces = new Piece[8, 8];

        private int Width { get { return pieces.GetUpperBound(0); } }
        private int Height { get { return pieces.GetUpperBound(1); } }

        public IEnumerable<Piece> Pieces
        {
            get
            {
                List<Piece> result = new List<Piece>();
                for (int c = 0; c < Width; c++)
                {
                    for (int r = 0; r < Height; r++)
                    {
                        if (pieces[c, r] != null)
                        {
                            result.Add(pieces[c, r]);
                        }
                    }
                }
                return result;  
            }
        }

        public void Put(Piece piece, Square position)
        {
            if (IsOccupied(position)) throw new Exception("Invalid position");
            pieces[position.Column, position.Row] = piece;
            piece.Position = position;
            piece.Board = this;
        }
        public void MovePiece( Square position, Piece piece)
        {
            pieces[position.Column, position.Row] = piece;
            if (piece == null) return;
            piece.Position = position;
            piece.Board = this;
        }

        public bool IsInvalid(Square position)
        {
            return position.Column < 0 
                || position.Column >= Width 
                || position.Row < 0 
                || position.Row >= Height;
        }

        public bool IsOccupied(Square position)
        {
            return pieces[position.Column, position.Row] != null;
        }
        //creo que esto al final no lo use, never mind
        //para poder comer fichas n' shit
        public bool IsOccupiedByBlack(Square position)
        {
            return pieces[position.Column, position.Row] != null;
        }
    }
}
