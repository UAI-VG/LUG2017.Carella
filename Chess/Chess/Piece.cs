using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess 
{
    abstract class Piece : object
    {
        //me cague en el encapsulamiento por que sino no podia hardcodear el false por default
        //osea, se que esta mal pero me acostumbre a tener false por default el año pasado en c++
        //y nada, paja hacerlo bien.
        public abstract string ToOut { get; }
        public bool KingRequest = false;
        public Square Position { get; set; }
        public Board Board { get; set; }
        public abstract bool IsWhite { get;}
        public abstract IEnumerable<Square> Moves { get; }
        public bool IsRequesting = false;
        public override string ToString()
        {
            return base.ToString() + "(" + Position.ToString() + ")";
        }
    }
}
