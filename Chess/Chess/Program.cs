using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        //le agregue public aca para usarlo con el king
        public static Board board = new Board();
        public static List<string> blancas=new List<string>();
        public static List<string> negras=new List<string>();
        public static string LineaBlanca;
        public static string LineaNegra;
        public static int NextToComma=0;
        public static List<Piece> PiezasAmenazadas=new List<Piece>();

        static void Main(string[] args)

        {
            using (StreamReader reader = new StreamReader(@"C:\Users\User\Desktop\In.txt",
                Encoding.UTF8))
            //so far so good
            {
               
                    LineaBlanca = reader.ReadLine();
                    LineaNegra = reader.ReadLine();

               
                Console.WriteLine(LineaBlanca);
                Console.WriteLine(LineaNegra);
                do
                {
                    blancas.Add(MiraLoQueMeHacesHacerRicardo(LineaBlanca, NextToComma));
                    Console.WriteLine(NextToComma);
                   
                } while (NextToComma!=0);
                do
                {
                    negras.Add(MiraLoQueMeHacesHacerRicardo(LineaNegra, NextToComma));
                    Console.WriteLine(NextToComma);

                } while (NextToComma != 0);
               

                //te fixie un bug pero prolly ya lo fixeaste en clase.
                int NumeroDePiezas = blancas.Count();
                for (int i = 0; i <NumeroDePiezas; i++)
                {
                    PlacePieceOnBoard(GetPiece(blancas[i][0]),blancas[i].Substring(1,2));
                }
                int NumeroDePiezasN = negras.Count();
                for (int i = 0; i < NumeroDePiezasN; i++)
                {
                    PlacePieceOnBoard(GetBlackPiece(negras[i][0]), negras[i].Substring(1, 2));
                }

                foreach (Piece piece in board.Pieces)
                {
                    Console.WriteLine("La pieza {0} puede moverse a:", piece);
                    foreach (Square s in piece.Moves)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                }

                Console.ReadLine();
             
            }
        }

        //---------------------------------------------------------------------------------
       static string MiraLoQueMeHacesHacerRicardo(string text,int Start)
        {
             int charLocation = text.IndexOf(",", Start, StringComparison.Ordinal);
            NextToComma = charLocation+1;
            if (NextToComma!=0)
            {
                return text.Substring(Start , charLocation - Start);
            }
            else
            {
                return text.Substring(Start, 3);
            }
        }
   //-------------------------------------------------------------------------------

        static void PlacePieceOnBoard(Piece p,string NotacionAlgebraica)
        {
            board.Put(p, GetSquare(NotacionAlgebraica));
            /*
            try
            {
                board.Put(p, GetSquare());
            }
            catch
            {
                Console.WriteLine("Posición inválida");
                PlacePieceOnBoard(p);
            }
            */
        }

        static Square GetSquare(string NotacionAlgebraica)
        {
            return Square.FromString(NotacionAlgebraica);
            /*
            try
            {
                Console.WriteLine("Ingrese casillero (notación algebraica):");
                string input = Console.ReadLine();
                return Square.FromString(input);
            }
            catch
            {
                Console.WriteLine("ERROR!");
                return GetSquare();
            }
            */
        }

        static Piece GetPiece(char Tipo)
        {
            //try
            {
               /* Console.WriteLine("Elija un tipo de pieza:");
                Console.WriteLine("1) Alfil Blanco");
                Console.WriteLine("2) Torre Blanco");
                Console.WriteLine("3) Dama Blanco");
                Console.WriteLine("4) Caballo Blanco");
                Console.WriteLine("5) Peon Blanco");
                Console.WriteLine("6) Rey Blanco");

                Console.WriteLine("7) Alfil Negro");
                Console.WriteLine("8) Torre Negro");
                Console.WriteLine("9) Dama Negro");
                Console.WriteLine("10) Caballo Negro");
                Console.WriteLine("11) Peon Negro");
                Console.WriteLine("12) Rey Negro");

                int n = int.Parse(Console.ReadLine());
                */
                switch (Tipo)
                {
                    case 'A': return new Bishop();
                    case 'T': return new Tower();
                    case 'D': return new Queen();
                    case 'C': return new Knight();
                    case 'P': return new Pawn();
                    case 'K': return new King();
                    default: throw new Exception();
                }
            }
           /* catch
            {
                Console.WriteLine("Tipo de pieza inválido");
                return new King();
            }
            */
        }
        static Piece GetBlackPiece (char Tipo)
        {
            switch (Tipo)
            {
                case 'A': return new BlackBishop();
                case 'T': return new BTower();
                case 'D': return new BQueen();
                case 'C': return new BKnight();
                case 'P': return new BPawn();
                case 'K': return new Bking();
                default: throw new Exception();
            }
        }
        static int GetNumberOfPieces()
        {
            /*
            try
            {
                Console.WriteLine("Ingrese número de piezas:");
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("El número ingresado es inválido.");
                return GetNumberOfPieces();
            }
            */
            return blancas.Count();
        }
    }
}
