using System;
using System.Collections.Generic;
using System.Text;

namespace Damka.Classes
{
    class Immortal
    {
        private int numberOfLives;
        public Immortal()
        {
            this.numberOfLives = 2;
        }
        public bool checkImmortality()
        {
            if (this.numberOfLives >= 1)
                return true;
            return false;
        }
        
        // Spcecial ability
        public void removeLive(GameClass game)
        {
            this.numberOfLives--;
        }
    }

}
