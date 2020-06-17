using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipWU {
    class Ship {

        public enum ShipType {
            CARRIER = 5,
            BATTLESHIP = 4,
            CRUISER = 3,
            SUBMARINE = 3,
            DESTROYER = 2
        }

        public ShipType Type { get; set; }
        public string ShipLayout { get; set; }
        
        public Ship(ShipType type, string shipLayout) {
            this.Type = type;
            this.ShipLayout = shipLayout;
        }
    }
}
