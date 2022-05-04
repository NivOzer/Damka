using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
namespace Damka.Classes
{
    class GameClass
    {
        private int turnCounter;
        public enum gamePhase { CharcterSelection, PostionSelecetion };
        private List<Button> _board;
        private List<Man> _blacks, _whites;
        private Position _current_player_position;
        private List<Man> _deadBlacks, _deadWhites;

        public GameClass()
        {
            this._board = new List<Button>();
            this._current_player_position= new Position();
            this._deadBlacks = new List<Man>();
            this._deadWhites = new List<Man>();
        }

        //Disables all the buttons
        public void disableAllButtons()
        {
            foreach (Button btn in _board)
            {
                btn.Enabled = false;
            }
        }
        
        //shows the legal moves for a piece to make
        public void ShowAvailablePieces()
        {
            if (turnCounter % 2 == (int)Man.Color.Black)
            {
                foreach (Man piece in _blacks)
                {
                    int index = piece.getListPos();
                    _board[index].Enabled = true;
                }
            }
            else
            {
                foreach (Man piece in _whites)
                {
                    int index = piece.getListPos();
                    _board[index].Enabled = true;
                }
            }
            
        }
        
        // Enables all the buttons the piece can move to
        public void ShowAvailableMoves()
        {
            foreach (Button btn in _board)
            {
                //
            }
        }

        // Remove from list, move to graveyard, update button
        public void gotEaten()
        {
            
        }

        // Checks if the game has ended
        public bool gameEnded()
        {
            return false;
        }
        
        // Initializes GUI's propeties
        public void gameInit()
        {
        }

    }
}
