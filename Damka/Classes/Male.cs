using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Damka.Classes
{
    //added an image attribute
    class Male
    {
        protected Position _pos;
        public enum Color { White = 0, Black = 1 };
        protected Color _color;
        protected int _range;
        //Constructor
        public Male(Position pos, Color color, int range)
        {
            this._pos = pos;
            this._color = color;
            this._range = range;
        }
        //Copy constructor
        public Male(Male old)
        {
            this._pos = old._pos;
            this._color = old._color;
            this._range = old._range;
            // this._buttonPos = old._buttonPos;
        }

        public Bitmap getImage()
        {
            if (_color == (int)Color.White)
                return global::Damka.Properties.Resources.White_male;
            else
                return global::Damka.Properties.Resources.Black_male;
        }

        // Update to new postion
        public void updatePosition(int index)
        {
            this._pos.updatePosition(index);
        }

        public int getRow()
        {
            return _pos.getRow();
        }

        public int getCol()
        {
            return _pos.getCol();
        }

        public int getIndex()
        {
            return _pos.getIndex();
        }
    }

}
