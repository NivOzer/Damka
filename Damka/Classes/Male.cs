using System;
using System.Collections.Generic;
using System.Text;
namespace Damka.Classes
{
    class Male
    {
        private Position _pos;
        public enum Color { White = 0, Black = 1 };
        private Color _color;
        private int _range;

        public Male(Position pos, Color color, int range)
        {
            this._pos =   pos;
            this._color = color;
            this._range = range;
        }

        // Update to new postion
        public void updatePosition()
        {

        }

        public int getRow()
        {
            return _pos.getRow();
        }

        public int getCol()
        {
            return _pos.getCol();
        }

        public int getListPos()
        {
            return _pos.getListPos();
        }
    }

}
