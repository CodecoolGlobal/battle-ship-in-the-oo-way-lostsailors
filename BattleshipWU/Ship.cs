using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipWU {
    class Ship {
        public enum Layout {
            HORIZONTAL,
            VERTICAL
        }
        public int Size { get; set; }
        public Layout ShipLayout { get; set; }
        public Ship(int size, Layout shipLayout) {
            this.Size = size;
            this.ShipLayout = shipLayout;
        }   
    }
}
