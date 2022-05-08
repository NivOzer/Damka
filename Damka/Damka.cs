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
        const int PANEL_SIZE = 720;
        const int NUM_OF_COLS = 8;
        const int NUM_OF_ROWS = 8;
        const int BUTTON_SIZE = 90;
        public Color LIGHT_BROWN = System.Drawing.Color.FromArgb(66, 43, 34);
        public Color DARK_BROWN = System.Drawing.Color.FromArgb(113, 82, 60);
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
            gamePanel.Width = PANEL_SIZE;
            gamePanel.Height = PANEL_SIZE;
            gamePanel.BackColor = Color.Yellow;
            this.Controls.Add(gamePanel);
            for (int row = 0; row < NUM_OF_ROWS; row++)
            {
                for (int col = 0; col < NUM_OF_COLS; col++)
                {
                    Button btn = new Button();
                    // btn.Width = 90; // Setting size with new Size at **
                    // btn.Height = 90;
                    btn.ForeColor = Color.White;
                    btn.Text = (row * NUM_OF_COLS + col).ToString();
                    btn.Name = (row * NUM_OF_COLS + col).ToString();
                    btn.Size = new Size(BUTTON_SIZE, BUTTON_SIZE); // ** 
                    btn.Location = new Point(col * BUTTON_SIZE, row * BUTTON_SIZE);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    if ((row + col) % 2 == 0)
                        btn.BackColor = LIGHT_BROWN;
                    else
                        btn.BackColor = DARK_BROWN;
                    btn.Click += new EventHandler(boardClick);
                    gamePanel.Controls.Add(btn);
                    game.addButtonToBoard(btn);
                    game.initializePlayers(btn, col, row);

                }
            }
        }

        // Checks the current GamePhase and initiate a proper response
        private void boardClick(object sender, EventArgs e)
        {
            Button pressed = ((Button)sender);
            if (game.getCurrentGamePhase() == GameClass.GamePhase.CharacterSelection) //CharacterSelection
            {
                // pressed.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                game.playerMoved(pressed); // we should send the index instead
            }
            else //PostionSelection
            {
                // pressed.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                game.playerSelectedPiece(pressed); // we should send the index instead
            }
        }

    }
}
