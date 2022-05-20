using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Damka.Classes
{
    [Serializable]
    class Constants
    {
        // UI Elements
        public const int SCREEN_SIZE_WIDTH = 2560;
        public const int SCREEN_SIZE_HEIGHT = 1440;
        public const int PANEL_SIZE = 720;
        public const int BUTTON_SIZE = 90;
        public static Color LIGHT_BROWN = System.Drawing.Color.FromArgb(66, 43, 34); // being set at Damka.cs - it's a duplicate
        public static Color DARK_BROWN = System.Drawing.Color.FromArgb(113, 82, 60); // the same
        public static Color selectedColor = System.Drawing.Color.FromArgb(146, 111, 85);
        public static Color AVAILABLE_MOVE_COLOR = System.Drawing.Color.FromArgb(189, 168, 151);

        public const int NUM_OF_ROWS = 8;
        public const int NUM_OF_COLS = 8;


        public const int MALE_RANGE = 1;
        public enum GamePhase { SelectedAPiece, ChoseWhereToGo };
        public enum PlayerColor { White = 0, Black = 1 };
        public const int KING_EAT_COUNTER_NUMBER = 2;
    }
}