using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Damka.Classes
{
    class Constants
    {
        public const int PANEL_SIZE = 720;
        public const int MALE_RANGE = 1;
        public enum GamePhase { CharacterSelection, PostionSelection };

        public const int NUM_OF_ROWS = 8;
        public const int NUM_OF_COLS = 8;


        public static Color LIGHT_BROWN = System.Drawing.Color.FromArgb(66, 43, 34); // being set at Damka.cs - it's a duplicate
        public static Color DARK_BROWN = System.Drawing.Color.FromArgb(113, 82, 60); // the same
        public static Color selectedColor = System.Drawing.Color.FromArgb(230, 220, 254);
        public enum PlayerColor { White = 0, Black = 1 };
        public const int BUTTON_SIZE = 90;
    }
}
