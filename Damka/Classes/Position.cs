using System;
using System.Collections.Generic;
using System.Text;

namespace Damka.Classes
{
    class Position
    {
        static int NUM_OF_COLS = 8;
        private int _row;
        private int _col;
        public Position()
        {
            this._row = 0;
            this._col = 0;
        }
        public Position(int row, int col)
        {
            this._row = row;
            this._col = col;
        }

        public int getRow()
        {
            return _row;
        }

        public int getCol()
        {
            return _col;
        }

        public int getIndex()
        {
            return this._row * NUM_OF_COLS + this._col;
        }

        public void setByIndex(int index)
        {
            this._row = index / NUM_OF_COLS;
            this._col = index % NUM_OF_COLS;
        }

    }
}
