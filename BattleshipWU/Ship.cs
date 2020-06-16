using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipWU {
    class Ship {
        public enum Layout {
            HORIZONTAL,
            VERTICAL
        }

        public enum ShipType {
            CA, B, CR, S, D
        }
            /* Carrier (occupies 5 squares) - Type abbreviation: CA
            * Battleship(4) - B
            * Cruiser(3) - CR
            * Submarine(3) - S
            * Destroyer(2) - D */

        public ShipType Type { get; set; }
        public int Size { get; set; }
        public string ShipLayout { get; set; }
        
        public Ship(ShipType type, string shipLayout) {
            this.Type = type;
            this.ShipLayout = shipLayout;
            switch (type) {
                case ShipType.CA:
                    this.Size = 5;
                    break;
                case ShipType.B:
                    this.Size = 4;
                    break;
                case ShipType.CR:
                case ShipType.S:
                    this.Size = 3;
                    break;
                case ShipType.D:
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
