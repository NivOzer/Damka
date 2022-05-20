using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Damka.Classes
{
    class HorizontalKing : King
    {
        public HorizontalKing(King old) : base(old._pos, old._color)
        {
            _range = old._range;
            _eatCounter = old._eatCounter;
        }

        public override List<KeyValuePair<int, int>> getAvailableMoves(List<Button> board, int startIndex, GameClass game)
        {
            List<KeyValuePair<int, int>> result = base.getAvailableMoves(board, startIndex, game);
            Male temp;
            int moveBy = 0;
            Position from = new Position(startIndex);
            Position to = new Position(startIndex);
            bool isEmpty = true;

            moveBy -= 2;
            to.setByIndex(startIndex + moveBy);
            while (isValidMove(to.getIndex()) && from.getRow() == to.getRow())
            {
                if (board[to.getIndex()].Image == null)
                { // can go left
                    result.Add(new KeyValuePair<int, int>(to.getIndex(), -1));
                    if (isEmpty == false)
                    {
                        result.Add(new KeyValuePair<int, int>(to.getIndex(), to.getIndex() + 2));
                        break;
                    }
                }
                else
                {
                    if (isEmpty == false) break;
                    temp = game.getPlayerMaleByIndex(to.getIndex());
                    if (temp._color == this._color) break;
                    else
                        isEmpty = false;
                }
                moveBy -= 2;
                to.setByIndex(startIndex + moveBy);
            }

            moveBy = 2;
            isEmpty = true;
            to.setByIndex(startIndex + moveBy);
            while (isValidMove(to.getIndex()) && from.getRow() == to.getRow())
            {
                if (board[to.getIndex()].Image == null)
                { // can go left
                    result.Add(new KeyValuePair<int, int>(to.getIndex(), -1));
                    if (isEmpty == false)
                    {
                        result.Add(new KeyValuePair<int, int>(to.getIndex(), to.getIndex() - 2));
                        break;
                    }
                }
                else
                {
                    if (isEmpty == false) break;
                    temp = game.getPlayerMaleByIndex(to.getIndex());
                    if (temp._color == this._color) break;
                    else
                        isEmpty = false;
                }
                moveBy += 2;
                to.setByIndex(startIndex + moveBy);
            }
            return result;
        }

        public override Bitmap getImage()
        {
            if (this._color == Constants.PlayerColor.White)
                return global::Damka.Properties.Resources.KING_Horizontal;
            else
                return global::Damka.Properties.Resources.KING_Horizontal_Black;
        }
        public override bool isUpgradeable()
        {
            return false;
        }

        public bool isValidMove(int toIndex)
        {
            if (toIndex < 0 || toIndex > Constants.NUM_OF_COLS * Constants.NUM_OF_ROWS)
                return false;
            return true;
        }
    }
}
