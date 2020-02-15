using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipWU {
    class Player {
        public string Name { get; set; }

        public Player (string name) {
            this.Name = name;
        }


        public Ocean guessEnemyPositionAKAFire(string position, Ocean enemysOcean, Ocean myOcean) {
            /* PSEUDOCODE
            if enemyOcean[position] == ship {
                myOcean[position].color - zaznacz na znaleziony statek
            }
            else {
                myOcean[position].color - zaznacz ze nie ma statku
            }
            */
            return myOcean;
        }
    }
}
