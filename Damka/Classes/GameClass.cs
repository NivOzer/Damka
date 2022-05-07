﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace Damka.Classes
{
    class GameClass
    {
        const int PANEL_SIZE = 720;
        const int MALE_RANGE = 1;
        private int turnCounter;
        //decides what gamephase the user has chosen : 0 is character selection , 1 is for position selection
        public enum GamePhase { CharacterSelection, PostionSelection };
        private GamePhase _gamePhase;
        private List<Button> _board;
        private List<Male> _blacks, _whites;
        private int _current_player_index;
        private List<Male> _deadBlacks, _deadWhites;
        public GameClass()
        {
            // Generates a button grid for the board
            this._board = new List<Button>();
            this._current_player_index = 0;
            //Initialize memory for 12 black and white pieces
            this._blacks = new List<Male>();
            this._whites = new List<Male>();
            //Stacks the dead players in there own array
            this._deadBlacks = new List<Male>();
            this._deadWhites = new List<Male>();
        }
        public void addButtonToPanel(Button btn)
        {
        }
        public void addButtonToBoard(Button btn)
        {
            this._board.Add(btn);
        }

        public GamePhase getCurrentGamePhase()
        {
            return this._gamePhase;
        }

        public void initializePlayers(Button btn,int col,int row)
        {
            int whiteindex = 0, blackindex = 0 ;
            if (((row + col) % 2 == 0) && btn.Image == null && row <= 2)
            {
                Position p = new Position(row, col);
                Male m = new Male(p, Male.Color.White, MALE_RANGE,btn);
                this._whites.Add(m);
            }
            else if (((row + col) % 2 == 0) && btn.Image == null && row >= 5) // till 5 cause <8 is 7 so 3 lines is 5,6,7
            {
                Position p = new Position(row, col);
                Male m = new Male(p, Male.Color.Black, MALE_RANGE,btn);
                this._blacks.Add(m);
            }

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
            //pressed.BackColor = System.Drawing.Color.FromArgb(51 , 5, 5);
            nextGamePhase();
        }
        //A Specific player has been pressed event
        public void playerSelectedPiece(Button pressed)
        {

            //Logic here
            Color selectedColor = System.Drawing.Color.FromArgb(230, 220, 254);
            Color LIGHT_BROWN = System.Drawing.Color.FromArgb(66, 43, 34);
            Color DARK_BROWN = System.Drawing.Color.FromArgb(113, 82, 60);

            if (((pressed.Left / 90) + (pressed.Bottom / 90)) % 2 == 0 && pressed.BackColor == selectedColor)
                pressed.BackColor = DARK_BROWN;
            else if (((pressed.Left / 90) + (pressed.Bottom / 90)) % 2 != 0 && pressed.BackColor == selectedColor)
                pressed.BackColor = LIGHT_BROWN;
            else
                pressed.BackColor = selectedColor;

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
