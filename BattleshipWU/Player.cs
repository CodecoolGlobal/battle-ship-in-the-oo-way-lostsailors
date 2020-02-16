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

            List<string> shipTypesNames = new List<string> {"Carrier (5", "Battleship (4", "Cruiser (3",
                "Submarine (3", "Destroyer (2"};
            Ship.ShipType[] shipTypes = new Ship.ShipType[5] { Ship.ShipType.CA, Ship.ShipType.B, Ship.ShipType.CR, Ship.ShipType.S, Ship.ShipType.D };

            foreach (string type in shipTypesNames) {
                Console.WriteLine("\nPlease place " + type + " squares) on your ocean:");
                
                int positionX = -1;
                int positionY = -1;
                while (positionX == -1 || positionY == -1) {
                    Console.WriteLine("Position:");
                    string position = Console.ReadLine().ToUpper();

                    if (isLetter(position[0].ToString())) {
                        positionY = (int)position[0] - 65;
                        if (positionY >= ocean.Dimension) {
                            positionY = -1;
                            Console.WriteLine("Column index exceeded board dimension");
                        }
                        if (isNumeric(position.Substring(1))) {
                            positionX = Int32.Parse(position.Substring(1)) - 1;
                            if (positionX >= ocean.Dimension) {
                                positionX = -1;
                                Console.WriteLine("Row index exceeded board dimension");
                            }
                        } else {
                            Console.WriteLine("Invalid row number");
                        }
                    }
                    else {
                        Console.WriteLine("First input character must be a letter indcating column");
                    }
                }

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
