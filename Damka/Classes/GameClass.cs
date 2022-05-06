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
        public enum GamePhase { CharacterSelection, PostionSelection };
        private GamePhase _gamePhase;
        private List<Button> _board;
        private List<Male> _blacks, _whites;
        private int _current_player_index;
        private List<Male> _deadBlacks, _deadWhites;

        public GameClass()
        {
            this._board = new List<Button>();
            this._current_player_index = 0;
            this._blacks = new List<Male>();
            this._whites = new List<Male>();
            this._deadBlacks = new List<Male>();
            this._deadWhites = new List<Male>();
        }

        public void addButtonToBoard(Button btn)
        {
            this._board.Add(btn);
        }

        public GamePhase getCurrentGamePhase()
        {
            return this._gamePhase;
        }

        // Updates the GamePhase and Invokes necessary function to progress the game
        private void nextGamePhase()
        {
            if (_gamePhase == GamePhase.CharacterSelection)
            {
                // Logic here
                _gamePhase = GamePhase.PostionSelection;
            }
            else
            {
                // Logic here
                _gamePhase = GamePhase.CharacterSelection;
            }
        }

        public void playerMoved(Button pressed)
        {
            //Logic here
             pressed.BackColor = System.Drawing.Color.FromArgb(51 , 5, 5);
            nextGamePhase();
        }

        public void playerSelectedPiece(Button pressed)
        {
            //Logic here
            pressed.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            nextGamePhase();
        }

        //Disables all the buttons
        private void disableAllButtons()
        {
            foreach (Button btn in _board)
            {
                btn.Enabled = false;
            }
        }

        //shows the legal moves for a piece to make
        private void ShowAvailablePieces()
        {
            if (turnCounter % 2 == (int)Male.Color.Black)
            {
                foreach (Male piece in _blacks)
                {
                    int index = piece.getIndex();
                    _board[index].Enabled = true;
                }
            }
            else
            {
                foreach (Male piece in _whites)
                {
                    int index = piece.getIndex();
                    _board[index].Enabled = true;
                }
            }

        }

        // Enables all the buttons the piece can move to
        private void ShowAvailableMoves()
        {
            foreach (Button btn in _board)
            {
                //
            }
        }

        // Remove from list, move to graveyard, update button
        private void gotEaten()
        {

        }

        // Checks if the game has ended
        private bool gameEnded()
        {
            return false;
        }

        // Initializes GUI's properties
        public void gameInit()
        {
        }

    }
}
