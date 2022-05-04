using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Damka
{
    public partial class Damka : Form
    {
        const int NUM_OF_COLS = 8;
        const int BUTTON_SIZE = 90;
        
        public Damka()
        {
            InitializeComponent();
            gameLoad();
        }

        private void gameLoad()
        {
            drawBoard();
            //placePlayers();
            //gameLoop();
        }

        private void drawBoard()
        {
            int count = 0;
            for (int i = 0; i < 64; i++)
            {
                Button btn = new Button();
                btn.Text = count.ToString();
                btn.Name = count.ToString();
                btn.Size = new Size(35,35);
                btn.Location = new Point(40,40*i);
                Controls.Add(btn);

            }
        }

    }
}
