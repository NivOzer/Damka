using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

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
        private List<Male> _deadBlacks, _deadWhites;
        [NonSerialized()] private List<Button> _blacksGrave;
        [NonSerialized()] private List<Button> _whitesGrave;
        private int _current_player_index;
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
            this._blacksGrave = new List<Button>();
            this._whitesGrave = new List<Button>();
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
        public List<Male> deadWhites
        {
            get { return this._deadWhites; }
        }
        public List<Male> deadBlacks
        {
            get { return this.deadBlacks; }
        }
        public Color getButtonColor(int row, int col)
        {
            if ((row + col) % 2 == 0)
                return Constants.LIGHT_BROWN;
            return Constants.DARK_BROWN;
        }
        // If no player is found returns null
        public Male getPlayerMaleByIndex(int index)
        {
            foreach (Male piece in _blacks)
                if (piece.getIndex() == index) return piece;
            foreach (Male piece in _whites)
                if (piece.getIndex() == index) return piece;
            return null;
        }

        // --- SETTERS --

        public void setGamePhase(Constants.GamePhase gamePhase = Constants.GamePhase.ChoseWhereToGo) { _gamePhase = gamePhase; } // sets current gamephase
        public void setBoard(List<Button> btns = null) //given a board - if empty creates a new one , else adds the buttons to the board
        {
            if (btns == null) _board = new List<Button>();
            else _board = btns;
        }
        public void initGraves()
        {
            _whitesGrave = new List<Button>();
            _blacksGrave = new List<Button>();
        }

        // Game Functionality
        public void initializePlayers(Button btn, int col, int row)
        {
            if (((row + col) % 2 == 0) && btn.BackgroundImage == null && row <= 2)
            {
                Position p = new Position(row, col);
                Male m = new Male(p, Constants.PlayerColor.White);
                _board[p.getIndex()].BackgroundImage = m.getImage();
                this._whites.Add(m);
                
            }
            else if (((row + col) % 2 == 0) && btn.BackgroundImage == null && row >= 5) // till 5 cause <8 is 7 so 3 lines is 5,6,7
            {
                Position p = new Position(row, col);
                Male m = new Male(p, Constants.PlayerColor.Black);
                _board[p.getIndex()].BackgroundImage = m.getImage();
                this._blacks.Add(m);
            }
            disableAllButtons();
        }
        public void addButtonToBoard(Button btn) { this._board.Add(btn); }
        public void addToBlacksGrave(Button btn) { this._blacksGrave.Add(btn); }
        public void addToWhitesGrave(Button btn) { this._whitesGrave.Add(btn); }
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
            int counter = 0;
            if (_turnCounter % 2 == (int)Constants.PlayerColor.Black)
            {
                foreach (Male piece in _blacks)
                {
                    int index = piece.getIndex();
                    if (piece.getAvailableMoves(_board, index, this).Count > 0)
                    {
                        _board[index].Enabled = true;
                        counter++;
                    }
                }
            }
            else
            {
                foreach (Male piece in _whites)
                {
                    int index = piece.getIndex();
                    if (piece.getAvailableMoves(_board, index, this).Count > 0)
                    {
                        _board[index].Enabled = true;
                        counter++;
                    }
                }
            }
            if (counter == 0) endGame(); // End Game
        } //shows the legal moves for a piece to make
        public void playerSelectedPiece(int pressedIndex)
        {
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
            bool exploded = false;

            Male current = getPlayerMaleByIndex(_current_player_index);
            List<KeyValuePair<int, int>> moves = new List<KeyValuePair<int, int>>();
            moves = current.getAvailableMoves(_board, _current_player_index, this);

            foreach (KeyValuePair<int, int> move in moves)
            {
                if (move.Key == pressedIndex && move.Value != -1)
                { // a kill move
                    Male gotKilled = getPlayerMaleByIndex(move.Value);
                    exploded = gotKilled.gotEaten();
                    playerKilled(gotKilled, move.Value);

                    current.ateAPlayer();
                    if (exploded) { playerKilled(current, _current_player_index); } // Attacker killed a mine
/*                    if (exploded)
                    { // Attacker killed a mine 
                        if (Constants.PlayerColor.Black == current.color)
                            _blacks.Remove(current);
                        else
                            _whites.Remove(current);
                        _board[_current_player_index].BackgroundImage = null;
                    }*/
                }
            }

            // restore original color
            // if (_board[_current_player_index].AccessibleDescription == "DARK_BROWN")
            //     _board[_current_player_index].BackColor = Constants.DARK_BROWN;
            // else
            //     _board[_current_player_index].BackColor = Constants.LIGHT_BROWN;
            _board[_current_player_index].BackColor = getButtonColor(_current_player_index);

            if (exploded == false)
            {
                _board[pressedIndex].BackgroundImage = _board[_current_player_index].BackgroundImage;
                _board[_current_player_index].BackgroundImage = null;

                current.setByIndex(pressedIndex);
                _current_player_index = pressedIndex;

                if (current.isUpgradeable())
                { //checks for an upgrade
                    if (current.GetType() == typeof(Classes.Male))
                    {
                        King temp = new King(current);
                        _board[pressedIndex].BackgroundImage = temp.getImage();
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
                            _board[pressedIndex].BackgroundImage = temp.getImage();
                        }
                        else
                        {
                            VerticalKing temp = new VerticalKing((King)current);
                            upgradePiece(current, temp);
                            _board[pressedIndex].BackgroundImage = temp.getImage();
                        }
                    }
                }
            }
        }

        private void playerKilled(Male killed, int index)
        {
            if (killed._color == Constants.PlayerColor.White)
            {
                _whitesGrave[_deadWhites.Count].BackgroundImage = killed.getImage();
                _deadWhites.Add(killed);
                _whites.Remove(killed);
            }
            else
            {
                _blacksGrave[_deadBlacks.Count].BackgroundImage = killed.getImage();
                _deadBlacks.Add(killed);
                _blacks.Remove(killed);
            }
            _board[index].BackgroundImage = null;
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
            {
                btn.Enabled = false;
                btn.BackColor = getButtonColor(int.Parse(btn.Name));
            }

        }//Disables all the buttons
        private void enableButtons(List<KeyValuePair<int, int>> moves)
        {
            foreach (KeyValuePair<int, int> move in moves)
            {
                _board[(move.Key)].Enabled = true;
                _board[move.Key].BackColor = Constants.AVAILABLE_MOVE_COLOR;
            }
        } // Enables all the buttons in the List (by index)
        public void loadGraves()
        {
            int count = 0;
            foreach (Male w in _deadWhites) _whitesGrave[count++].BackgroundImage = w.getImage();
            count = 0;
            foreach (Male bl in _deadBlacks) _blacksGrave[count++].BackgroundImage = bl.getImage();
        }
        public void loadFromFile()
        {
            foreach (Button btn in _board) btn.BackgroundImage = null;
            foreach (Male w in _whites) _board[w.getIndex()].BackgroundImage = w.getImage();
            foreach (Male b in _blacks) _board[b.getIndex()].BackgroundImage = b.getImage();
        }// Initializes GUI's properties
        public void initializeMine()
        {
            Random rnd = new Random();
            int index = rnd.Next(12);
            Mine temp = new Mine(_whites[index]);
            upgradePiece(_whites[index], temp);
            _board[_whites[_whites.Count - 1].getIndex()].BackgroundImage = temp.getImage();

            index = rnd.Next(12);
            temp = new Mine(_blacks[index]);
            upgradePiece(_blacks[index], temp);
            _board[_blacks[_blacks.Count - 1].getIndex()].BackgroundImage = temp.getImage();
        }

        public void endGame()
        {
            string winMessage = "Game Ended\n";
            if (_whites.Count != 0 && _blacks.Count != 0)
                winMessage += "It's a tie!\nBetter luck next time!";
            else
            {
                if (_turnCounter % 2 == 0)
                    winMessage += "Black Has Won!!!";
                else
                    winMessage += "White Has Won!!!";
            }
            MessageBox.Show(winMessage);
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@"D:\לימודים\endvideo.mp4")
            {
                UseShellExecute = true
            };
            p.Start();
            disableAllButtons();
        }
    }
}