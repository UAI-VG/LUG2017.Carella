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
        public static Stack<MoveParaCommand> Dones = new Stack<MoveParaCommand>();
        public static Stack<MoveParaCommand> Undones = new Stack<MoveParaCommand>();
       
        static string StringParaARchivoOut(List<Piece> Lista)
        {
            string paraRetornar="";
            bool NotTheFirstOne=false;
            foreach (Piece P in Lista)
            {
                if (NotTheFirstOne)
                {
                    paraRetornar+=",";
                }
                paraRetornar += P.ToOut;
                NotTheFirstOne = true;
            }
            return paraRetornar;
        }
        static void Main(string[] args)

        {
            //------------------------------------------------------------------------
            using (StreamReader reader = new StreamReader(@"C:\Users\User\Desktop\In.txt",
                Encoding.UTF8))
            //so far so good
            {
               
                    LineaBlanca = reader.ReadLine();
                    LineaNegra = reader.ReadLine();
            }

            Console.WriteLine(LineaBlanca);
                Console.WriteLine(LineaNegra);
                do
                {
                if (LineaBlanca.Length>1)
                    blancas.Add(MiraLoQueMeHacesHacerRicardo(LineaBlanca, NextToComma));
                    Console.WriteLine(NextToComma);
                   
                } while (NextToComma!=0);
                do
                {
                if (LineaNegra.Length > 1)
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
                //------------------------------------------------------------------------
                bool ParaWhile = true;
                while (ParaWhile)
            {
                int PieceNumber = 0;
                foreach (Piece piece in board.Pieces)
                {
                    Console.WriteLine("La pieza {1} {0} puede moverse a:", piece, PieceNumber);
                    PieceNumber++;
                    int MoveNumber = 0;
                    foreach (Square s in piece.Moves)
                    {
                        Console.WriteLine("Movimiento {1}: {0}", s, MoveNumber);
                        MoveNumber++;
                    }
                    Console.WriteLine();
                }
                RecibirInputParaMovimientos();
                RecibirInputParaUndo();

                //------------------------------------------------------------------------

                Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(@"C:\Users\User\Desktop\Out.txt", false,
                  Encoding.UTF8))
                {
                    writer.WriteLine(StringParaARchivoOut(PiezasAmenazadas));
                }
                List<Piece> ListaDeBlancasParaExportar = new List<Piece>();
                List<Piece> ListaDeNegrasParaExportar = new List<Piece>();
                foreach (Piece P in board.pieces)
                {
                    try
                    {
                        if (P.IsWhite)
                        {
                            ListaDeBlancasParaExportar.Add(P);
                        }
                        else
                        {
                            ListaDeNegrasParaExportar.Add(P);
                        }
                    }
                    catch
                    {
                        //
                    }

                }
                using (StreamWriter Writer = new StreamWriter(@"C:\Users\User\Desktop\In.txt", false,
                 Encoding.UTF8))
                {
                    Writer.WriteLine(StringParaARchivoOut(ListaDeBlancasParaExportar));
                    Writer.WriteLine(StringParaARchivoOut(ListaDeNegrasParaExportar));
                }
            }


        }

        private static void RecibirInputParaUndo()
        {
            Console.WriteLine("undo- 1 Redo- 2");
              switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        if (Dones.Count < 1)
                        {
                            Console.WriteLine("no hay movimientos que deshacer");
                        }
                        else
                        {
                            Dones.Peek().Undo(board, Undones);
                            Dones.Pop();
                        }
                       
                        break;
                    }
                case 2:
                    {
                        if (Undones.Count < 1)
                        {
                            Console.WriteLine("no flashees richo");
                        }
                        else
                        {
                            Undones.Peek().Redo(board, Dones);
                            Undones.Pop();
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
              
            
        }

        private static void RecibirInputParaMovimientos()
        {
            Console.WriteLine("moves? 1 para si");
                if (int.Parse(Console.ReadLine())==1)
            {
                Undones.Clear();
                Console.WriteLine("que pieza? (manda numero)");
                int Input1 = int.Parse(Console.ReadLine());
                Console.WriteLine("que numero de movimiento (manda numero)");
                int Input2 = int.Parse(Console.ReadLine());
                int PieceNumber = 0;
                foreach (Piece piece in board.Pieces)
                {
                    if (PieceNumber == Input1)
                    {
                        int MoveNumber = 0;
                        foreach (Square s in piece.Moves)
                        {
                            if (MoveNumber == Input2)
                            {
                                Console.WriteLine(piece.Position.Row + " " + piece.Position.Column);
                                Console.WriteLine(s.Row + " " + s.Column);
                                MoveParaCommand M = new MoveParaCommand(piece, board.pieces[s.Column, s.Row], board, s);
                                Dones.Push(M);
                            }
                            MoveNumber++;
                        }
                        Console.WriteLine();
                    }
                    PieceNumber++;
                }
            }
        }
        private static void IntentoViejoDeCommand()
        {
            Console.WriteLine("Que Pieza Moves? Pone el numero de columna (cagate en notacion algebraica)");
            int numeroP = int.Parse(Console.ReadLine());
            Console.WriteLine("Que Pieza Moves? Pone el numero de fila (cagate en notacion algebraica)");
            int numeroPY = int.Parse(Console.ReadLine());
            Console.WriteLine("A que columna? Cagate en notacion algebraica");
            int numeroM = int.Parse(Console.ReadLine());
            Console.WriteLine("A que fila? Cagate en notacion algebraica");
            int numeroMY = int.Parse(Console.ReadLine());
        //    MoveParaCommand Comandino = new MoveParaCommand();
          //  Comandino.Icono = board.pieces[numeroP, numeroPY].ToOut[0];
            //Comandino.PosX = numeroP;
            //Comandino.PosY = numeroPY;
            try
            {
              //  Comandino.Iconocomido = board.pieces[numeroM, numeroMY].ToOut[0];
            }
            catch
            {
                //Comandino.Iconocomido = '0';
            }

        //    Comandino.PosXC = numeroM;
          //  Comandino.PosYC = numeroMY;
            //Dones.Push(Comandino);
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

      public  static Piece GetPiece(char Tipo)
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
                    case '0': return null;
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
      public  static Piece GetBlackPiece (char Tipo)
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
