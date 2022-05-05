using System;
using System.Collections.Generic;
using System.Text;

namespace Damka.Classes
{
    class Dasher : Male
    {
        private int numberOfDashes;
        public Dasher(Position pos, Color color, int range) : base(pos, color, range)
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
