using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipWU {
    class Square {
        public enum SquareType {
            SHIP,
            OCEAN,
        }
        public bool visibleForOpponent { get; set; }
        public string Fill { get; set; }
        //public int Row { get; private set; }
        //public int Column { get; private set; }

        public Square(SquareType type) {
            this.visibleForOpponent = false;
            if (type == SquareType.SHIP) {
                this.Fill = "X";
            }
            else {
                this.Fill = " ";
            }
        }
    }
}
