using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace Damka.Classes
{
    [Serializable]
    class GameClass
    {
        private int _turnCounter;
        //decides what gamePhase the user has chosen : 0 is Character selection , 1 is for Position selection
        private Constants.GamePhase _gamePhase;
        [NonSerialized()] private List<Button> _board;
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

        // --- GETTERS --
        public Constants.GamePhase getCurrentGamePhase() { return this._gamePhase; }
        public List<Button> getBoard() { return _board; }
        public Color getButtonColor(int index)
        {
            Position point = new Position(index);
            if ((point.getRow() + point.getCol()) % 2 == 0)
                return Constants.LIGHT_BROWN;
            return Constants.DARK_BROWN;
        }
        public Color getButtonColor(int row, int col)
        {
            if ((row + col) % 2 == 0)
                return Constants.LIGHT_BROWN;
            return Constants.DARK_BROWN;
        }
        public Male getPlayerMaleByIndex(int index)
        {
            foreach (Male piece in _blacks)
                if (piece.getIndex() == index) return piece;
            foreach (Male piece in _whites)
                if (piece.getIndex() == index) return piece;
            return null; // for maintanace
        }

        // --- SETTERS --

        public void setGamePhase(Constants.GamePhase gamePhase = Constants.GamePhase.ChoseWhereToGo) { _gamePhase = gamePhase; } // sets current gamephase
        public void setBoard(List<Button> btns = null) //given a board - if empty creates a new one , else adds the buttons to the board
        {
            if (btns == null) _board = new List<Button>();
            else _board = btns;
        }

        // Game Functionality

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
            Random rnd = new Random();


            disableAllButtons();
        }
        public void addButtonToBoard(Button btn) { this._board.Add(btn); }
        public void nextGamePhase(int pressedIndex)
        {
            if (_gamePhase == Constants.GamePhase.SelectedAPiece)
            { // Player was in character selection
                // Logic here
                disableAllButtons();
                if (pressedIndex == _current_player_index || getPlayerMaleByIndex(pressedIndex) != null)
                {
                    //restores original color
                    if (_board[_current_player_index].BackColor == Constants.selectedColor)
                        _board[_current_player_index].BackColor = getButtonColor(_current_player_index);
                    ShowAvailablePieces();
                    _gamePhase = Constants.GamePhase.ChoseWhereToGo;
                    return;
                }
                playerMoved(pressedIndex);
                //gameEnded(); // ******* TODO
                // if no moves are available end game
                _turnCounter++;
                _gamePhase = Constants.GamePhase.ChoseWhereToGo;
                ShowAvailablePieces();
            }
            else
            { // Player was in ChoseWhereToGo OR first turn of the game
                disableAllButtons();
                playerSelectedPiece(pressedIndex);
                ShowAvailablePieces();
                _gamePhase = Constants.GamePhase.SelectedAPiece;
            }
        }// Updates the GamePhase and Invokes necessary function to progress the game
        public void ShowAvailablePieces()
        {
            if (_turnCounter % 2 == (int)Constants.PlayerColor.Black)
            {
                foreach (Male piece in _blacks)
                {
                    int index = piece.getIndex();
                    if (piece.getAvailableMoves(_board, index, this).Count > 0)
                        _board[index].Enabled = true;
                }
            }
            else
            {
                foreach (Male piece in _whites)
                {
                    int index = piece.getIndex();
                    if (piece.getAvailableMoves(_board, index, this).Count > 0)
                        _board[index].Enabled = true;
                }
            }
        } //shows the legal moves for a piece to make
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
        }//A Specific player has been pressed event
        public void ShowAvailableMoves()
        {
            // List<int> moves;
            List<KeyValuePair<int, int>> moves = new List<KeyValuePair<int, int>>();
            Male current = getPlayerMaleByIndex(_current_player_index);
            moves = current.getAvailableMoves(_board, _current_player_index, this);
            enableButtons(moves);
            _board[_current_player_index].Enabled = true;
        }// Enables all the buttons the piece can move to
        public void playerMoved(int pressedIndex)//actions to do After a player has moved
        {
            bool gotEaten = false;

            Male current = getPlayerMaleByIndex(_current_player_index);
            List<KeyValuePair<int, int>> moves = new List<KeyValuePair<int, int>>();
            moves = current.getAvailableMoves(_board, _current_player_index, this);

            foreach (KeyValuePair<int, int> move in moves)
            {
                if (move.Key == pressedIndex && move.Value != -1)
                {
                    Male gotKilled = getPlayerMaleByIndex(move.Value);
                    if (gotKilled._color == Constants.PlayerColor.White)
                        _whites.Remove(gotKilled);
                    else
                        _blacks.Remove(gotKilled);
                    _board[move.Value].Image = null;

                    current.ateAPlayer();

                    if (gotKilled.gotEaten())
                    { // Mine killed attacker
                        gotEaten = true;
                        if (Constants.PlayerColor.Black == current.color)
                            _blacks.Remove(current);
                        else
                            _whites.Remove(current);
                    }
                }
            }
            //Logic here
            _board[pressedIndex].Image = _board[_current_player_index].Image;
            _board[_current_player_index].Image = null;

            // restore original color
            if (_board[_current_player_index].AccessibleDescription == "DARK_BROWN")
                _board[_current_player_index].BackColor = Constants.DARK_BROWN;
            else
                _board[_current_player_index].BackColor = Constants.LIGHT_BROWN;

            current.setByIndex(pressedIndex);
            _current_player_index = pressedIndex;



            //checks for an upgrade
            if (gotEaten == false)
            {
                if (current.isUpgradeable())
                {
                    if (current.GetType() == typeof(Classes.Male))
                    {
                        King temp = new King(current);
                        _board[pressedIndex].Image = temp.getImage();

                        upgradePiece(current, temp);
                    }

                    if (current.GetType() == typeof(Classes.King))
                    {
                        Random rnd = new Random();

                        int result = rnd.Next(2);
                        if (result == 1)
                        {
                            HorizontalKing temp = new HorizontalKing((King)current);
                            upgradePiece(current, temp);
                            _board[pressedIndex].Image = temp.getImage();
                        }
                        else
                        {
                            VerticalKing temp = new VerticalKing((King)current);
                            upgradePiece(current, temp);
                            _board[pressedIndex].Image = temp.getImage();
                        }
                    }
                }
            }
        }
        public void upgradePiece(Male old, Male upgraded)
        {
            if (Constants.PlayerColor.Black == old.color)
            {
                _blacks.Remove(old);
                _blacks.Add(upgraded);
            }
            else
            {
                _whites.Remove(old);
                _whites.Add(upgraded);
            }
        }
        public void disableAllButtons()
        {
            foreach (Button btn in _board)
                btn.Enabled = false;

        }//Disables all the buttons
        private void enableButtons(List<KeyValuePair<int, int>> moves)
        {
            foreach (KeyValuePair<int, int> move in moves)
            {
                _board[(move.Key)].Enabled = true;
            }
        } // Enables all the buttons in the List (by index)
        public void loadFromFile()
        {
            foreach (Button btn in _board) btn.Image = null;
            foreach (Male w in _whites) _board[w.getIndex()].Image = w.getImage();
            foreach (Male b in _blacks) _board[b.getIndex()].Image = b.getImage();
        }// Initializes GUI's properties


        // vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv TO  DO vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        // ********************************************************** TO  DO *****************************************************************
        // vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv TO  DO vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

        // Remove from list, move to graveyard, update button
        public void initializeMine()
        {
            Random rnd = new Random();
            int index = rnd.Next(12);
            Mine temp = new Mine(_whites[index]);
            upgradePiece(_whites[index], temp);
            _board[_whites[index].getIndex()].Image = temp.getImage();

            index = rnd.Next(12);
            temp = new Mine(_blacks[index]);
            upgradePiece(_blacks[index], temp);
            _board[_blacks[index].getIndex()].Image = temp.getImage();
        }

        // Checks if the game has ended
        public bool gameEnded()
        {
            if (_blacks.Count == 0 || _whites.Count == 0)
                return true;
            return false;
        }
    }
}
