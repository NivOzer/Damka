using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace Damka.Classes
{
    class GameClass
    {
        private int _turnCounter;
        //decides what gamePhase the user has chosen : 0 is character selection , 1 is for position selection
        private Constants.GamePhase _gamePhase;
        private List<Button> _board;
        private List<Male> _blacks, _whites;
        private int _current_player_index;
        private List<Male> _deadBlacks, _deadWhites;
        public GameClass()
        {
            // Generates a button grid for the board
            this._board = new List<Button>();
            this._current_player_index = 0;
            //a list for 12 black and white pieces
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

        public Constants.GamePhase getCurrentGamePhase()
        {
            return this._gamePhase;
        }

        public void initializePlayers(Button btn, int col, int row)
        {
            if (((row + col) % 2 == 0) && btn.Image == null && row <= 0)
            {
                Position p = new Position(row, col);
                Male m = new Male(p, Constants.PlayerColor.White);
                _board[p.getIndex()].Image = m.getImage();
                this._whites.Add(m);
            }
            else if (((row + col) % 2 == 0) && btn.Image == null && row >= 7) // till 5 cause <8 is 7 so 3 lines is 5,6,7
            {
                Position p = new Position(row, col);
                Male m = new Male(p, Constants.PlayerColor.Black);
                _board[p.getIndex()].Image = m.getImage();
                this._blacks.Add(m);
            }
            disableAllButtons();
        }
        // Updates the GamePhase and Invokes necessary function to progress the game
        public void nextGamePhase(int pressedIndex)
        {
            if (_gamePhase == Constants.GamePhase.SelectedAPiece)
            { // Player was in character selection
                // Logic here
                disableAllButtons();
                playerMoved(pressedIndex);
                //gameEnded(); // ******* TODO
                _turnCounter++;
                _gamePhase = Constants.GamePhase.ChoseWhereToGo;
                ShowAvailablePieces();
            }
            else
            { // Player was in ChoseWhereToGo OR first turn of the game
                disableAllButtons();
                playerSelectedPiece(pressedIndex);
                _gamePhase = Constants.GamePhase.SelectedAPiece;
            }
        }

        public void playerMoved(int pressedIndex)
        {
            //Logic here

            _board[pressedIndex].Image = _board[_current_player_index].Image;
            _board[_current_player_index].Image = null;

            Male current = getPlayerMaleByIndex(_current_player_index);
            current.setByIndex(pressedIndex);
            _current_player_index = pressedIndex;

            // if (current.GetType() == typeof(Classes.King))
            // {
            //     // (King)current.ateAPlayer();
            //     King temp = (King)getPlayerMaleByIndex(_current_player_index);
            //     temp.ateAPlayer();
            // }

            // if (current.isUpgradeable())
            // {
            //     if (current.GetType() == typeof(Classes.Male))
            //     {
            //         King temp = new King(current);
            //         _board[pressedIndex].Image = temp.getImage();

            //         if (Constants.PlayerColor.Black == current.color)
            //         {
            //             _blacks.Remove(current);
            //             _blacks.Add(temp);
            //         }
            //         else
            //         {
            //             _whites.Remove(current);
            //             _whites.Add(temp);
            //         }
            //     }
            // }

            _board[pressedIndex].Text = "I have been here";

        }
        //A Specific player has been pressed event
        public void playerSelectedPiece(int pressedIndex)
        {

            //Logic here

            if (((_board[pressedIndex].Left / Constants.BUTTON_SIZE) + (_board[pressedIndex].Bottom / Constants.BUTTON_SIZE)) % 2 == 0 && _board[pressedIndex].BackColor == Constants.selectedColor)
                _board[pressedIndex].BackColor = Constants.DARK_BROWN;
            else if (((_board[pressedIndex].Left / Constants.BUTTON_SIZE) + (_board[pressedIndex].Bottom / Constants.BUTTON_SIZE)) % 2 != 0 && _board[pressedIndex].BackColor == Constants.selectedColor)
                _board[pressedIndex].BackColor = Constants.LIGHT_BROWN;
            else
                _board[pressedIndex].BackColor = Constants.selectedColor;

            _current_player_index = pressedIndex;
            ShowAvailableMoves();
        }

        //Disables all the buttons
        private void disableAllButtons()
        {
            foreach (Button btn in _board)
            {
                btn.Enabled = false;
            }
        }

        // Enables all the buttons in the List (by index)
        private void enableButtons(List<int> moves)
        {
            foreach (int move in moves)
            {
                _board[move].Enabled = true;
                // _board[move].Text = "click me";

            }
        }
        //shows the legal moves for a piece to make
        public void ShowAvailablePieces()
        {
            if (_turnCounter % 2 == (int)Constants.PlayerColor.Black)
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
            List<int> moves;

            // MessageBox.Show("Show moves");
            Male current = getPlayerMaleByIndex(_current_player_index);
            moves = current.getAvailableMoves(_board, _current_player_index, this);
            enableButtons(moves);
        }

        public List<Button> getBoard()
        {
            return _board;
        }

        public Male getPlayerMaleByIndex(int index)
        {
            if (_turnCounter % 2 == (int)Constants.PlayerColor.Black)
            {
                foreach (Male piece in _blacks)
                {
                    if (piece.getIndex() == _current_player_index)
                    {
                        return piece;
                    }
                }
            }
            else
            {
                foreach (Male piece in _whites)
                {
                    if (piece.getIndex() == _current_player_index)
                    {
                        return piece;
                    }
                }
            }
            MessageBox.Show("No Player found");
            return null; // will never here - just to solve 
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

        // set current game phase is empty set as 'PostionSelection' 
        public void setGamePhase(Constants.GamePhase gamePhase = Constants.GamePhase.ChoseWhereToGo)
        {
            _gamePhase = gamePhase;
        }

        // Initializes GUI's properties
        public void gameInit()
        {
        }
    }
}
