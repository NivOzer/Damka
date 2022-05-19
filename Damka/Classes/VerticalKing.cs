﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Damka.Classes
{
    class VerticalKing : King
    {
        public VerticalKing(King old) : base(old._pos, old._color)
        {
            _range = old._range;
            _eatCounter = old._eatCounter;
        }

        public override List<KeyValuePair<int, int>> getAvailableMoves(List<Button> board, int startIndex, GameClass game)
        {

            List<KeyValuePair<int, int>> result = base.getAvailableMoves(board, startIndex, game);
            Male temp;
            int fromIndex = startIndex, toIndex, counter = 1;
            bool isEmpty = true;

            fromIndex = startIndex - (counter - 1) * (Constants.NUM_OF_COLS * 2);
            toIndex = startIndex - (Constants.NUM_OF_COLS * 2 * counter);
            while (isValidMove(fromIndex, toIndex))
            {
                if (board[toIndex].Image == null)
                { // can go  up
                    // result.Add(toIndex);
                    result.Add(new KeyValuePair<int, int>(toIndex, -1));
                    if (isEmpty == false)
                    {
                        result.Add(new KeyValuePair<int, int>(toIndex, fromIndex));
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
                fromIndex = startIndex - (counter - 1) * (Constants.NUM_OF_COLS * 2);
                toIndex = startIndex - (Constants.NUM_OF_COLS * 2 * counter);
            }

            counter = 1;
            isEmpty = true;
            fromIndex = startIndex + (counter - 1) * (Constants.NUM_OF_COLS * 2);
            toIndex = startIndex + (Constants.NUM_OF_COLS * 2 * counter);
            while (isValidMove(fromIndex, toIndex))
            {
                if (board[toIndex].Image == null)
                { // can go down
                    // result.Add(toIndex);
                    result.Add(new KeyValuePair<int, int>(toIndex, -1));
                    if (isEmpty == false)
                    {
                        result.Add(new KeyValuePair<int, int>(toIndex, fromIndex));
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
                fromIndex = startIndex + (counter - 1) * (Constants.NUM_OF_COLS * 2);
                toIndex = startIndex + (Constants.NUM_OF_COLS * 2 * counter);
            }
            return result;
        }

        public override Bitmap getImage()
        {
            if (this._color == Constants.PlayerColor.White)
                return global::Damka.Properties.Resources.KING_Verical_new;
            else
                return global::Damka.Properties.Resources.KING_Verical_Black;
        }
        public override bool isUpgradeable()
        {
            return false;
        }
    }
}
