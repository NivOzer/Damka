﻿using System;
using System.Collections.Generic;
using System.Text;
namespace Damka.Classes
{
    class Freezer:Man
    {
        private int freezeDuration;
        public Freezer(Position pos, Color color, int range) :base(pos,color,range)
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
