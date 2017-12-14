using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Square
    {
        
        public static Square FromString(string input)
        {
            char colChar = input[0];
            char rowChar = input[1];

            string columns = "abcdefgh";
            int col = columns.IndexOf(colChar);
            if (col < 0) throw new Exception("Invalid column");

            string rows = "12345678";
            int row = rows.IndexOf(rowChar);
            if (row < 0) throw new Exception("Invalid row");

            return new Square(col, row);
        }

        public Square(int col, int row)
        {
            Column = col;
            Row = row;
        }
        public int Value = 0;
        public int Column { get; }
        public int Row { get; }

        public override string ToString()
        {
            string columns = "abcdefgh";
            string rows = "12345678";
            return string.Format("{0}{1}", 
                columns[Column], 
                rows[Row]);
        }
    }
}
