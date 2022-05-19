using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Damka.Classes
{
    class King : Male
    {
        private int _eatCounter;
        // public King(Position pos, Constants.PlayerColor color) : base(pos, color)
        // {
        //     //
        // }

        public King(Male old) : base(old.pos, old.color)
        {
            _range = 8;
            _eatCounter = 0;
        }

        public override List<int> getAvailableMoves(List<Button> board, int startIndex, GameClass game)
        {
            List<int> result = new List<int>();
            Male temp;
            int fromIndex = startIndex, toIndex, counter = 1;
            bool isEmpty = true;

            fromIndex = startIndex + (counter - 1) * -7;
            toIndex = startIndex - (7 * counter);
            while (isValidMove(fromIndex, toIndex))
            {
                if (board[toIndex].Image == null)
                { // can go right up
                    result.Add(toIndex);
                    if (isEmpty == false) break;
                }
                else
                {
                    if (isEmpty == false) break;
                    temp = game.getPlayerMaleByIndex(toIndex);
                    if (temp._color == this._color) break;
                    else
                        isEmpty = false;
                }
                counter++;
                fromIndex = startIndex + (counter - 1) * -7;
                toIndex = startIndex - (7 * counter);
            }

            counter = 1;
            isEmpty = true;
            fromIndex = startIndex + (counter - 1) * -9;
            toIndex = startIndex - (9 * counter);
            while (isValidMove(fromIndex, toIndex))
            {
                if (board[toIndex].Image == null)
                { // can go left up
                    result.Add(toIndex);
                    if (isEmpty == false) break;
                }
                else
                {
                    if (isEmpty == false) break;
                    temp = game.getPlayerMaleByIndex(toIndex);
                    if (temp._color == this._color) break;
                    else
                        isEmpty = false;
                }
                counter++;
                fromIndex = startIndex + (counter - 1) * -9;
                toIndex = startIndex - (9 * counter);
            }

            counter = 1;
            isEmpty = true;
            fromIndex = startIndex + (counter - 1) * 7;
            toIndex = startIndex + (7 * counter);
            while (isValidMove(fromIndex, toIndex))
            {
                if (board[toIndex].Image == null)
                { // can go left up
                    result.Add(toIndex);
                    if (isEmpty == false) break;
                }
                else
                {
                    if (isEmpty == false) break;
                    temp = game.getPlayerMaleByIndex(toIndex);
                    if (temp._color == this._color) break;
                    else
                        isEmpty = false;
                }
                counter++;
                fromIndex = startIndex + (counter - 1) * 7;
                toIndex = startIndex + (7 * counter);
            }

            counter = 1;
            isEmpty = true;
            fromIndex = startIndex + (counter - 1) * 9;
            toIndex = startIndex + (9 * counter);
            while (isValidMove(fromIndex, toIndex))
            {
                if (board[toIndex].Image == null)
                { // can go left up
                    result.Add(toIndex);
                    if (isEmpty == false) break;
                }
                else
                {
                    if (isEmpty == false) break;
                    temp = game.getPlayerMaleByIndex(toIndex);
                    if (temp._color == this._color) break;
                    else
                        isEmpty = false;
                }
                counter++;
                fromIndex = startIndex + (counter - 1) * 9;
                toIndex = startIndex + (9 * counter);
            }
            return result;
        }

        public override Bitmap getImage()
        {
            if (this._color == Constants.PlayerColor.White)
                return global::Damka.Properties.Resources.KING;
            else
                return global::Damka.Properties.Resources.Black_King;
        }
        public override bool isUpgradeable()
        {
            if (this._eatCounter == Constants.KING_EAT_COUNTER_NUMBER) return true;
            return false;
        }

        public override void ateAPlayer() { _eatCounter++; }
    }
}
