using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Damka.Classes
{
    [Serializable]
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

        public new List<int> getAvailableMoves(List<Button> board, int startIndex, GameClass game)
        {
            List<int> result = new List<int>();
            int fromIndex = startIndex, toIndex, counter = 0;
            bool isEmpty = true;

            do
            {
                counter++;
                fromIndex = startIndex + (counter - 1) * -7;
                toIndex = startIndex - (7 * counter);
                if (board[toIndex].Image == null)
                { // can go left
                    result.Add(toIndex);
                    if (isEmpty == false) break;
                }
                else
                {
                    if (isEmpty == false) break;
                    Male temp = game.getPlayerMaleByIndex(toIndex);
                    if (temp.color == this._color) break;
                    else
                        isEmpty = false;
                }
            } while (isValidMove(fromIndex, toIndex));


            //         //             result.Add(startIndex - 7);
            //         //             {
            //         //                 else
            //         //                 {
            //         //                     if (isValidMove(startIndex - 7, startIndex - 14))
            //         //                     {
            //         //                         if (board[startIndex - 14].Image == null)
            //         //                         { // White can eat left
            //         //                             result.Add(startIndex - 14);
            //         //                         }
            //         //                     }
            //         //                 }
            //         //             }
            //         //             if (isValidMove(startIndex, startIndex - 9))
            //         //             {
            //         //                 if (board[startIndex - 9].Image == null)
            //         //                 { // White can go right
            //         //                     result.Add(startIndex - 9);
            //         //                 }
            //         //                 else
            //         //                 {
            //         //                     if (isValidMove(startIndex - 9, startIndex - 18))
            //         //                     {
            //         //                         if (board[startIndex - 18].Image == null)
            //         //                         { // White can eat right
            //         //                             result.Add(startIndex - 18);
            //         //                         }
            //         //                     }
            //         //                 }
            //         //             }
            //         //         }
            //         //             else
            //         //             {
            //         //                 if (isValidMove(startIndex, startIndex + 7))
            //         //                 {
            //         //                     if (board[startIndex + 7].Image == null)
            //         //                     { // White can go left
            //         //                         result.Add(startIndex + 7);
            //         //                     }
            //         //                     else
            //         //                     {
            //         //                         if (isValidMove(startIndex + 7, startIndex + 14))
            //         //                         {
            //         //                             if (board[startIndex + 14].Image == null)
            //         //                             { // White can eat left
            //         //                                 result.Add(startIndex + 14);
            //         //                             }
            //         //                         }
            //         //                     }
            //         //                 }
            //         //                 if (isValidMove(startIndex, startIndex + 9))
            //         // {
            //         //     if (board[startIndex + 9].Image == null)
            //         //     { // White can go right
            //         //         result.Add(startIndex + 9);
            //         //     }
            //         //     else
            //         //     {
            //         //         if (isValidMove(startIndex + 9, startIndex + 18))
            //         //         {
            //         //             if (board[startIndex + 18].Image == null)
            //         //             { // White can eat right
            //         //                 result.Add(startIndex + 18);
            //         //             }
            return result;
        }
        public new bool isUpgradeable()
        {
            if (this._eatCounter == Constants.KING_EAT_COUNTER_NUMBER) return true;

            return false;
        }

        public void ateAPlayer()
        {
            _eatCounter++;
        }
    }
}
