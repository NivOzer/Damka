using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Damka.Classes;


namespace Damka
{
    public partial class Damka : Form
    {
        GameClass game = new GameClass();

        public Damka()
        {
            InitializeComponent();
            gameLoad();
        }

        private void gameLoad()
        {
            drawBoard();
            //placePlayers();
        }

        // Draws all the buttons and adds them to game List<Button> _board
        private void drawBoard()
        {
            Panel gamePanel = new Panel();
            gamePanel.Width = Constants.PANEL_SIZE;
            gamePanel.Height = Constants.PANEL_SIZE;
            gamePanel.BackColor = Color.Yellow;
            this.Controls.Add(gamePanel);
            for (int row = 0; row < Constants.NUM_OF_ROWS; row++)
            {
                for (int col = 0; col < Constants.NUM_OF_COLS; col++)
                {
                    Button btn = new Button();
                    btn.ForeColor = Color.White;
                    btn.Text = (row * Constants.NUM_OF_COLS + col).ToString();
                    btn.Name = (row * Constants.NUM_OF_COLS + col).ToString();
                    btn.Size = new Size(Constants.BUTTON_SIZE, Constants.BUTTON_SIZE);
                    btn.Location = new Point(col * Constants.BUTTON_SIZE, row * Constants.BUTTON_SIZE);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    if ((row + col) % 2 == 0)
                        btn.BackColor = Constants.LIGHT_BROWN;
                    else
                        btn.BackColor = Constants.DARK_BROWN;
                    btn.Click += new EventHandler(boardClick);
                    gamePanel.Controls.Add(btn);
                    game.addButtonToBoard(btn);
                    game.initializePlayers(btn, col, row);
                    game.setGamePhase();
                    game.ShowAvailablePieces();
                }
            }
        }

        // Checks the current GamePhase and initiate a proper response
        private void boardClick(object sender, EventArgs e)
        {
            int pressedIndex = int.Parse(((Button)sender).Name);
            if (game.getCurrentGamePhase() == Constants.GamePhase.CharacterSelection)
            { // CharacterSelection

                MessageBox.Show("Moves");
                game.playerMoved(pressedIndex);
            }
            else
            { // PostionSelection

                MessageBox.Show("Pieces");
                game.playerSelectedPiece(pressedIndex);
            }
        }

    }
}
