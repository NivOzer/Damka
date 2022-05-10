using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Damka.Classes
{
    class Dasher : Male
    { // just an example of the changes - regardless if we use the dasher or not
        private int numberOfDashes;
        public Dasher(Position pos, Constants.PlayerColor color) : base(pos, color)
        { // again I think the button is unnecessary
            this.numberOfDashes = 2;
        }

        // Special ability
        public void Dash(GameClass game)
        {
            //
        }

        public new Bitmap getImage()
        {
            if (base._color == (int)Constants.PlayerColor.White)
                return global::Damka.Properties.Resources.KING_Horizontal;
            else
                return global::Damka.Properties.Resources.KING_Horizontal_Black;
        }
    }
}
