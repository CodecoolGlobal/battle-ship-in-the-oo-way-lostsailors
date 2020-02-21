using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BattleshipWU {
    class Player {
        public string Name { get; set; }
        public Ocean MyOcean { get; set; }

        public Player (string name) {
            this.Name = name;
        }

        public Ocean getShipsPositions(Ocean ocean) {

            // Ship names needed for printing and ship types list
            List<string> shipTypesNames = new List<string> {
                "Carrier (5",
                "Battleship (4",
                "Cruiser (3",
                "Submarine (3",
                "Destroyer (2"};
            Ship.ShipType[] shipTypes = new Ship.ShipType[5] {
                Ship.ShipType.CA,
                Ship.ShipType.B,
                Ship.ShipType.CR,
                Ship.ShipType.S,
                Ship.ShipType.D};

            // Get data from user where to place each type of the ship
            foreach (string type in shipTypesNames) {
                
                Console.WriteLine("\nPlease place " + type + " squares) on your ocean:");

                // Ask for ship position (top left Square of the ship) and layout (horizontal/vertical)
                // until the ship can be placed on the ocean (1. is inside board, 2. not overlap with
                // another ship, 3. do not touch another ship)
                bool shipPlacedInTheOcean = false;
                while (shipPlacedInTheOcean == false) {

                    int[] position = getShipPositionInput(ocean);
                    string layout = getShipLayoutInput();

                    // Create new ship object from the input
                    int index = shipTypesNames.IndexOf(type);
                    Ship ship = new Ship(shipTypes[index], layout);

                    // Check if ship can be placed in the ocean
                    shipPlacedInTheOcean = ocean.canPlaceShip(ship, position[0], position[1]);
                    // TODO
                    // Here add check if ships not overlap
                    // Here add check if ships do not touch each other

                    if (shipPlacedInTheOcean == false) {
                        Console.WriteLine("Not possible to place the ship in the ocean, try again");
                    } else {
                        ocean.placeShipAtTheOcean(ship, position[0], position[1], new Square(Square.SquareType.SHIP));
                        ocean.displayOcean();
                    }
                }
            }

            return ocean;
        }
//cokolwiek
        private int[] getShipPositionInput(Ocean ocean) {
            int positionX = -1;
            int positionY = -1;
            while (positionX == -1 || positionY == -1) {
                Console.WriteLine("Position:");
                string position = Console.ReadLine().ToUpper();

                if (isLetter(position[0].ToString())) {
                    positionY = (int) position[0] - 65;
                    if (positionY >= ocean.Dimension) {
                        positionY = -1;
                        Console.WriteLine("Column index exceeded board dimension");
                    }
                    if (position.Substring(1) != "" && isNumeric(position.Substring(1))) {
                        positionX = Int32.Parse(position.Substring(1)) - 1;
                        if (positionX >= ocean.Dimension) {
                            positionX = -1;
                            Console.WriteLine("Row index exceeded board dimension");
                        }
                    } else {
                        Console.WriteLine("Invalid row number");
                    }
                } else {
                    Console.WriteLine("First input character must be a letter indcating column");
                }
            }

            int[] positionInput = new int[2] { positionX, positionY };

            return positionInput;

        }

        private string getShipLayoutInput() {

            string layout = null;
            
            while (layout == null) {
                Console.WriteLine("Layout (h - horizontal/v - vertical):");
                string layoutInput = Console.ReadLine().ToLower();
                
                if (layoutInput == "h") {
                    layout = "HORIZONTAL";
                } else if (layoutInput == "v") {
                    layout = "VERTICAL";
                } else {
                    Console.WriteLine("Wrong input");
                }
            }

            return layout;
        
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

        public static bool isNumeric(string strToCheck) {
            Regex rg = new Regex(@"^[0-9\s,]*$");
            return rg.IsMatch(strToCheck);
        }

        public static bool isLetter(string strToCheck) {
            Regex rg = new Regex(@"^[a-zA-Z\s,]*$");
            return rg.IsMatch(strToCheck);
        }
    }
}
