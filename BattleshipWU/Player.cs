using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipWU {
    class Player {
        public string Name { get; set; }
        public Ocean MyOcean { get; set; }

        public Player (string name) {
            this.Name = name;
        }

        public Ocean getShipsPositions(Ocean ocean) {

            List<string> shipTypesNames = new List<string> {"Carrier (5", "Battleship (4", "Cruiser (3",
                "Submarine (3", "Destroyer (2"};
            Ship.ShipType[] shipTypes = new Ship.ShipType[5] { Ship.ShipType.CA, Ship.ShipType.B, Ship.ShipType.CR, Ship.ShipType.S, Ship.ShipType.D };

            foreach (string type in shipTypesNames) {
                Console.WriteLine("\nPlease place " + type + " squares) on your ocean:");
                Console.WriteLine("Position:");
                string position = Console.ReadLine().ToUpper();
                Console.WriteLine("Layout (horizontal/vertical):");
                string layout = Console.ReadLine().ToUpper();

                char[] shipPosition = position.ToCharArray();
                int positionX = shipPosition[1] - 49;
                int positionY = (int)shipPosition[0] - 65;

                int index = shipTypesNames.IndexOf(type);
                Ship ship = new Ship(shipTypes[index], layout);

                ocean.placeShipAtTheOcean(ship, positionX, positionY, new Square(Square.SquareType.SHIP));
                ocean.displayOcean();
            }

            return ocean;
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
