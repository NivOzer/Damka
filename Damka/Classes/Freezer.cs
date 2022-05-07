using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Damka.Classes
{
    class Freezer:Male
    {
        private int freezeDuration;
        public Freezer(Position pos, Color color, int range,Button b) :base(pos,color,range,b)
        {
            this.freezeDuration = 2;
        }

        // 
        public void freezeAPlayer(GameClass game)
        {
            //
        }
    }
}
