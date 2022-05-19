using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Damka.Classes
{
    //added an image attribute
    [Serializable]
    class Male
    {
        internal Position _pos;
        internal Constants.PlayerColor _color;
        internal int _range;
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

        public virtual Bitmap getImage()
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
        public virtual List<int> getAvailableMoves(List<Button> board, int startIndex, GameClass game)
        {
            List<int> result = new List<int>();
            Male otherPlayer;

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
                        if (isValidMove(startIndex - 7, startIndex - 14) && board[startIndex - 14].Image == null)
                        {
                            otherPlayer = game.getPlayerMaleByIndex(startIndex - 7);
                            if (otherPlayer._color != this._color) result.Add(startIndex - 14); // black can eat left
                        }
                    }
                }
                if (isValidMove(startIndex, startIndex - 9))
                {
                    if (board[startIndex - 9].Image == null)
                    { // black can go left
                        result.Add(startIndex - 9);
                    }
                    else
                    {
                        if (isValidMove(startIndex - 9, startIndex - 18) && board[startIndex - 18].Image == null)
                        {
                            otherPlayer = game.getPlayerMaleByIndex(startIndex - 9);
                            if (otherPlayer._color != this._color) result.Add(startIndex - 18); // White can eat right
                        }
                    }
                }
            }
            else
            { // White turn
                if (isValidMove(startIndex, startIndex + 7))
                {
                    if (board[startIndex + 7].Image == null)
                    { // White can go left
                        result.Add(startIndex + 7);
                    }
                    else
                    {
                        if (isValidMove(startIndex + 7, startIndex + 14) && board[startIndex + 14].Image == null)
                        {
                            otherPlayer = game.getPlayerMaleByIndex(startIndex + 7);
                            if (otherPlayer._color != this._color) result.Add(startIndex + 14); // White can eat left
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
                        if (isValidMove(startIndex + 9, startIndex + 18) && board[startIndex + 18].Image == null)
                        {
                            otherPlayer = game.getPlayerMaleByIndex(startIndex + 9);
                            if (otherPlayer._color != this._color) result.Add(startIndex + 18); // White can eat right
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
            if (desiredLocationIndex >= Constants.NUM_OF_COLS * Constants.NUM_OF_ROWS || desiredLocationIndex < 0) return false;
            return true;
        }

        public virtual bool isUpgradeable()
        {
            // return true;
            bool result = false;
            if (_color == Constants.PlayerColor.Black && _pos.getRow() == 0) result = true;
            if (_color == Constants.PlayerColor.White && _pos.getRow() == Constants.NUM_OF_ROWS - 1) result = true;
            return result;
        }

        public virtual void ateAPlayer() { }
        public virtual void gotEaten() { }
    }
}
