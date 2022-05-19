using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Damka.Classes
{
    class Mine : Male
    {
        public Mine(Male old) : base(old.pos, old.color)
        { // Upgrade from Male
        }

        public Mine(Position pos, Constants.PlayerColor color) : base(pos, color)
        {
        }
        public override bool gotEaten() { return true; }

        public override Bitmap getImage()
        {
            if (this._color == Constants.PlayerColor.White)
                return global::Damka.Properties.Resources.Bomber_Fixed_size;
            else
                return global::Damka.Properties.Resources.BlackMine;
        }

        public override bool isUpgradeable() { return false; }
    }
}
