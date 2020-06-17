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
        public int Size { get; set; }
        public string ShipLayout { get; set; }
        
        public Ship(ShipType type, string shipLayout) {
            this.Type = type;
            this.ShipLayout = shipLayout;
            switch (type) {
                case ShipType.CARRIER:
                    this.Size = 5;
                    break;
                case ShipType.BATTLESHIP:
                    this.Size = 4;
                    break;
                case ShipType.CRUISER: // covers as well ship type SUBMARINE
                    this.Size = 3;
                    break;
                case ShipType.DESTROYER:
                    this.Size = 2;
                    break;
            }
        }

        public static void DisplayShipTypes() {
            Console.WriteLine("\nAvailable ship types:\n" +
                "Carrier (occupies 5 squares) - Type: CA\n" +
                "Battleship(4) - Type: B\n" +
                "Cruiser(3) - Type: CR\n" +
                "Submarine(3) - Type: S\n" +
                "Destroyer(2) - Type: D\n");
        }
    }
}
