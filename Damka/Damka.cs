using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Damka.Classes;

using System.IO;
using System.Runtime.Serialization;//!!!!!!
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace Damka
{
    public partial class Damka : Form
    {
        GameClass game = new GameClass();
        Panel gamePanel = new Panel();
        Panel deadWhites = new Panel();
        Panel deadBlacks = new Panel();
        public Damka()
        {
            InitializeComponent();
            gameLoad();
        }

        private void gameLoad()
        {
            drawBoard();
            game.setGamePhase();
            game.ShowAvailablePieces();
            game.initializeMine();
            createGraveYards();
        }

        // Draws all the buttons and adds them to game List<Button> _board
        private void drawBoard()
        {
            gamePanel.Width = Constants.PANEL_SIZE;
            gamePanel.Height = Constants.PANEL_SIZE;
            gamePanel.BackColor = Color.Yellow;
            gamePanel.Anchor = AnchorStyles.None;
            gamePanel.Left = Constants.PANEL_SIZE - 230;
            gamePanel.Top = Constants.SCREEN_SIZE_HEIGHT / 10 - 75;
            this.Controls.Add(gamePanel);
            for (int row = 0; row < Constants.NUM_OF_ROWS; row++)
            {
                for (int col = 0; col < Constants.NUM_OF_COLS; col++)
                {
                    Button btn = new Button();
                    btn.ForeColor = Color.White;
                    // btn.Text = (row * Constants.NUM_OF_COLS + col).ToString();
                    btn.Name = (row * Constants.NUM_OF_COLS + col).ToString();
                    btn.Size = new Size(Constants.BUTTON_SIZE, Constants.BUTTON_SIZE);
                    btn.Location = new Point(col * Constants.BUTTON_SIZE, row * Constants.BUTTON_SIZE);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackgroundImageLayout = ImageLayout.Center;
                    btn.BackColor = game.getButtonColor(row, col);
                    btn.Click += new EventHandler(boardClick);
                    btn.MouseLeave += new EventHandler(mouseLeaveEvent);
                    btn.MouseEnter += new EventHandler(mouseEnterEvent);
                    gamePanel.Controls.Add(btn);
                    game.addButtonToBoard(btn);
                    game.initializePlayers(btn, col, row);
                }
            }
        }

        public void createBoardToLoad()
        {
            for (int row = 0; row < Constants.NUM_OF_ROWS; row++)
            {
                for (int col = 0; col < Constants.NUM_OF_COLS; col++)
                {
                    Button btn = new Button();
                    btn.ForeColor = Color.White;
                    // btn.Text = (row * Constants.NUM_OF_COLS + col).ToString();
                    btn.Name = (row * Constants.NUM_OF_COLS + col).ToString();
                    btn.Size = new Size(Constants.BUTTON_SIZE, Constants.BUTTON_SIZE);
                    btn.Location = new Point(col * Constants.BUTTON_SIZE, row * Constants.BUTTON_SIZE);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackgroundImageLayout = ImageLayout.Center;
                    btn.BackColor = game.getButtonColor(row, col);
                    btn.Click += new EventHandler(boardClick);
                    btn.MouseLeave += new EventHandler(mouseLeaveEvent);
                    btn.MouseEnter += new EventHandler(mouseEnterEvent);
                    gamePanel.Controls.Add(btn);
                    game.addButtonToBoard(btn);
                }
            }
        }

        public void createGraveYards()
        {
            // Black's Grave
            deadBlacks.Width = Constants.BUTTON_SIZE * 2;
            deadBlacks.Height = Constants.BUTTON_SIZE * 6 + 40;
            deadBlacks.Anchor = AnchorStyles.None;
            deadBlacks.Left = (gamePanel.Location.X - deadBlacks.Width) / 2;
            deadBlacks.Top = (gamePanel.Location.Y * 2 + gamePanel.Height - deadBlacks.Height) / 2;
            deadBlacks.BackColor = System.Drawing.Color.Transparent;
            deadBlacks.Name = "BlackGrave";
            this.Controls.Add(deadBlacks);
            Label lblBlack = new Label();
            lblBlack.Text = "  Dead Blacks  ";
            labelDesign(lblBlack);
            deadBlacks.Controls.Add(lblBlack);
            createGraveButtons(deadBlacks);

            deadWhites.Width = deadBlacks.Width;
            deadWhites.Height = deadBlacks.Height;
            deadWhites.Anchor = AnchorStyles.None;
            deadWhites.Left = gamePanel.Location.X - (deadBlacks.Location.X + deadBlacks.Width) + gamePanel.Location.X + gamePanel.Width;
            deadWhites.Top = deadBlacks.Top;
            deadWhites.BackColor = System.Drawing.Color.Transparent;
            deadWhites.Name = "WhiteGrave";
            this.Controls.Add(deadWhites);
            Label lblWhite = new Label();
            lblWhite.Text = "  Dead Whites  ";
            labelDesign(lblWhite);
            deadWhites.Controls.Add(lblWhite);
            createGraveButtons(deadWhites);
        }

        private void labelDesign(Label lbl)
        {
            lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbl.AutoSize = true;
            lbl.ForeColor = System.Drawing.Color.Snow;
            lbl.BackColor = System.Drawing.Color.Transparent;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.Font = new System.Drawing.Font("Perpetua Titling MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        }

        public void createGraveButtons(Panel panel)
        {
            int x = 0, y = 40;
            for (int i = 0; i < 12; i++)
            {
                Button btn = new Button();
                btn.Location = new Point(x, y);
                btn.Size = new Size(Constants.BUTTON_SIZE, Constants.BUTTON_SIZE);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackgroundImageLayout = ImageLayout.Center;
                btn.Name = (i).ToString();
                panel.Controls.Add(btn);
                if (i % 2 != 0)
                {
                    y += Constants.BUTTON_SIZE;
                    x = 0;
                }
                else
                    x = Constants.BUTTON_SIZE;
                btn.BackColor = game.getButtonColor(i, i / 2);
                btn.Enabled = false;

                if (panel.Name == "BlackGrave")
                    game.addToBlacksGrave(btn);
                else
                    game.addToWhitesGrave(btn);
            }
        }

        public void removeButtons()
        {
            foreach (Control item in gamePanel.Controls.OfType<Button>().ToList())
                gamePanel.Controls.Remove(item);

            foreach (Control item in deadBlacks.Controls.OfType<Button>().ToList())
                deadBlacks.Controls.Remove(item);

            foreach (Control item in deadWhites.Controls.OfType<Button>().ToList())
                deadWhites.Controls.Remove(item);
        }

        private void boardClick(object sender, EventArgs e)
        {
            int pressedIndex = int.Parse(((Button)sender).Name);
            game.nextGamePhase(pressedIndex);
        }

        private void mouseLeaveEvent(object sender, EventArgs e)
        {
            ((Button)sender).Cursor = System.Windows.Forms.Cursors.Arrow;
        }

        private void mouseEnterEvent(object sender, EventArgs e)
        {
            ((Button)sender).Cursor = System.Windows.Forms.Cursors.Hand;
        }

        //--- SAVE --
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //!!!!
                    formatter.Serialize(stream, game);
                }
            }
        }

        //--- LOAD --
        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            openFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                removeButtons();
                game = (GameClass)binaryFormatter.Deserialize(stream);
                game.setBoard(null);
                createBoardToLoad();// leaves a blank board
                game.loadFromFile();
                game.initGraves();
                createGraveYards();
                game.loadGraves();
                game.disableAllButtons();
                if (game.getCurrentGamePhase() == Constants.GamePhase.SelectedAPiece)
                {
                    game.ShowAvailablePieces();
                    game.ShowAvailableMoves();
                }
                else
                    game.ShowAvailablePieces();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameMenu gameScreen = new GameMenu();
            gameScreen.Show();
        }

    }
}
