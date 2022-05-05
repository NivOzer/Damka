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
        const int NUM_OF_COLS = 8;
        const int NUM_OF_ROWS = 8;
        const int BUTTON_SIZE = 50;
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

        // Draw all the buttons and adds them to game List<Button> _board
        private void drawBoard()
        {
            for (int row = 0; row < NUM_OF_ROWS; row++)
            {
                for (int col = 0; col < NUM_OF_COLS; col++)
                {
                    Button btn = new Button();
                    btn.Text = (row * NUM_OF_COLS + col).ToString();
                    btn.Name = (row * NUM_OF_COLS + col).ToString();
                    btn.Size = new Size(BUTTON_SIZE, BUTTON_SIZE);
                    btn.Location = new Point(col * BUTTON_SIZE, row * BUTTON_SIZE);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += new EventHandler(boardClick);

                    if ((row + col) % 2 == 0)
                        btn.BackColor = System.Drawing.Color.FromArgb(66, 43, 34);
                    else
                        btn.BackColor = System.Drawing.Color.FromArgb(113, 82, 60);
                    Controls.Add(btn);// **TODO: add buttons to a panel
                    game.addButtonToBoard(btn);
                }
            }
        }

        // Checks the current GamePhase and initiate a proper response
        private void boardClick(object sender, EventArgs e)
        {
            Button pressed = ((Button)sender);

            if (game.getCurrentGamePhase() == GameClass.GamePhase.CharacterSelection)
            {
                // pressed.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                game.playerMoved(pressed);
            }
            else
            {
                // pressed.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                game.playerSelectedPiece(pressed);
            }
        }

    }
}
