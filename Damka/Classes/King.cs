using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Damka.Classes
{
    [Serializable]
    class King : Male
    {
        internal int _eatCounter;
        public King(Male old) : base(old.pos, old.color)
        { // Upgrade from Male
            _range = 8;
            _eatCounter = 0;
        }

        public King(Position pos, Constants.PlayerColor color) : base(pos, color)
        {
            _range = 8;
            _eatCounter = 0;
        }

        public King(King old) : base(old._pos, old._color)
        { // getting Upgrade to special King
            this._range = old._range;
            this._eatCounter = old._eatCounter;
        }

        public override List<KeyValuePair<int, int>> getAvailableMoves(List<Button> board, int startIndex, GameClass game)
        {
            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();
            Male temp;
            int fromIndex = startIndex, toIndex, counter = 1;
            bool isEmpty = true;

            fromIndex = startIndex + (counter - 1) * -7;
            toIndex = startIndex - (7 * counter);
            while (isValidMove(fromIndex, toIndex))
            {
                if (board[toIndex].Image == null)
                { // can go right up
                    result.Add(new KeyValuePair<int, int>(toIndex, -1));
                    // result.Add(toIndex);
                    if (isEmpty == false)
                    {
                        result.Add(new KeyValuePair<int, int>(toIndex, toIndex - 7));
                        break;
                    }
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
                    result.Add(new KeyValuePair<int, int>(toIndex, -1));
                    // result.Add(toIndex);
                    if (isEmpty == false)
                    {
                        result.Add(new KeyValuePair<int, int>(toIndex, toIndex - 9));
                        break;
                    }
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
                    result.Add(new KeyValuePair<int, int>(toIndex, -1));
                    // result.Add(toIndex);
                    if (isEmpty == false)
                    {
                        result.Add(new KeyValuePair<int, int>(toIndex, toIndex + 7));
                        break;
                    }
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
                    result.Add(new KeyValuePair<int, int>(toIndex, -1));
                    // result.Add(toIndex);
                    if (isEmpty == false)
                    {
                        result.Add(new KeyValuePair<int, int>(toIndex, toIndex + 9));
                        break;
                    }
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
