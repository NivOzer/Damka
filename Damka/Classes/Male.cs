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
        //Constructor
        public Male(Position pos, Constants.PlayerColor color)
        {
            this._pos = pos;
            this._color = color;
            this._range = Constants.MALE_RANGE;
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
            if (_color == Constants.PlayerColor.White)
                return global::Damka.Properties.Resources.White_male;
            else
                return global::Damka.Properties.Resources.Black_male;
        }

        // Update to new postion
        public void setByIndex(int index)
        {
            this._pos.setByIndex(index);
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

        public Position pos
        {
            get
            {
                return _pos;
            }
        }

        public Constants.PlayerColor color
        {
            get
            {
                return _color;
            }
        }
        public List<int> getAvailableMoves(List<Button> board, int startIndex, GameClass game)
        {
            List<int> result = new List<int>();
            //Position pos = new Position(startIndex);

            if (_color == Constants.PlayerColor.Black)
            {
                if (isValidMove(startIndex, startIndex - 7))
                {
                    if (board[startIndex - 7].Image == null)
                    { // black can go right
                        result.Add(startIndex - 7);
                    }
                    else
                    {
                        if (isValidMove(startIndex - 9, startIndex - 18))
                        {
                            if (board[startIndex - 18].Image == null)
                            { // black can eat left
                                result.Add(startIndex - 18);
                            }
                        }
                    }
                }
                if (isValidMove(startIndex, startIndex - 9))
                {
                    if (board[startIndex - 9].Image == null)
                    { // White can go right
                        result.Add(startIndex - 9);
                    }
                    else
                    {
                        if (isValidMove(startIndex - 9, startIndex - 18))
                        {
                            if (board[startIndex - 18].Image == null)
                            { // White can eat right
                                result.Add(startIndex - 18);
                            }
                        }
                    }
                }
            }
            else
            {
                if (isValidMove(startIndex, startIndex + 7))
                {
                    if (board[startIndex + 7].Image == null)
                    { // White can go left
                        result.Add(startIndex + 7);
                    }
                    else
                    {
                        if (isValidMove(startIndex + 7, startIndex + 14))
                        {
                            if (board[startIndex + 14].Image == null)
                            { // White can eat left
                                result.Add(startIndex + 14);
                            }
                        }
                    }
                }
                if (isValidMove(startIndex, startIndex + 9))
                {
                    if (board[startIndex + 9].Image == null)
                    { // White can go right
                        result.Add(startIndex + 9);
                    }
                    else
                    {
                        if (isValidMove(startIndex + 9, startIndex + 18))
                        {
                            if (board[startIndex + 18].Image == null)
                            { // White can eat right
                                result.Add(startIndex + 18);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public bool isValidMove(int startIndex, int desiredLocationIndex)
        {
            if (startIndex % Constants.NUM_OF_COLS == 0 && desiredLocationIndex % 8 == 7) return false;
            if (startIndex % Constants.NUM_OF_COLS == 7 && desiredLocationIndex % 8 == 0) return false;
            if (desiredLocationIndex >= Constants.NUM_OF_COLS * Constants.NUM_OF_ROWS || desiredLocationIndex <= 0) return false;
            return true;
        }

        public bool isUpgradeable()
        {
            bool result = false;
            if (_color == Constants.PlayerColor.Black && _pos.getRow() == 0) result = true;
            if (_color == Constants.PlayerColor.White && _pos.getRow() == Constants.NUM_OF_ROWS - 1) result = true;

            return result;

        }
    }
}
