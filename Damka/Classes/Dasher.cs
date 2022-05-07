using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Damka.Classes
{
    class Dasher : Male
    {
        private int numberOfDashes;
        public Dasher(Position pos, Color color, int range,Button b) : base(pos, color, range,b)
        {
            this.numberOfDashes = 2;
        }
        
        // Special ability
        public void Dash(GameClass game)
        {
            //
        }
    }
}
