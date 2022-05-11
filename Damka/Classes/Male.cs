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
        protected Constants.PlayerColor _color;
        protected int _range;
        protected bool _canGoUp;
        protected bool _canGoDown;
        //Constructor
        public Male(Position pos, Constants.PlayerColor color)
        {
            this._pos = pos;
            this._color = color;
            this._range = Constants.MALE_RANGE;

            // if (_color == Constants.PlayerColor.Black)
            // {
            //     _canGoDown = false;
            //     _canGoUp = true;
            // }
            // else
            // {
            //     _canGoDown = true;
            //     _canGoUp = false;
            // }
        }
        //Copy constructor
        public Male(Male old)
        {
            this._pos = old._pos;
            this._color = old._color;
            this._range = old._range;
        }

        public Bitmap getImage()
        {
            if (_color == (int)Constants.PlayerColor.White)
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

        public int getRange()
        {
            return this._range;
        }

        public List<int> ShowAvailableMoves(List<Button> board, int startIndex)
        {
            List<int> result = new List<int>();


            if (_color == Constants.PlayerColor.Black)
            {
                if (board[startIndex - 9].Image != null)
                { // Black can go left
                    result.Add(startIndex - 9);
                }
                if (board[startIndex - 7].Image != null)
                { // Black can go right
                    result.Add(startIndex - 7);
                }
            }
            else
            {
                if (board[startIndex + 7].Image != null)
                { // White can go left
                    result.Add(startIndex + 7);
                }
                if (board[startIndex + 9].Image != null)
                { // White can go right
                    result.Add(startIndex + 9);
                }
            }
            return result;
        }

        // public bool canGoUp()
        // {
        //     return this._canGoUp;
        // }

        // public bool canGoDown()
        // {
        //     return this._canGoDown;
        // }
    }

}
