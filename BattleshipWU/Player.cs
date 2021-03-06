﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace BattleshipWU {
    class Player {
        public string Name { get; set; }
        public Ocean MyOcean { get; set; }
        public Ocean MyEnemysOcean { get; set; }

        public Player (string name) {
            this.Name = name;
            this.MyOcean = new Ocean(10);
        }

        public Ocean GetShipsPositionsAndPlaceShipsOnBoard(Ocean ocean) {

            // Ship names needed for printing and ship types list
            List<string> shipTypesNames = new List<string> {
                "Carrier (5",
                "Battleship (4",
                "Cruiser (3",
                "Submarine (3",
                "Destroyer (2"};
            Ship.ShipType[] shipTypes = new Ship.ShipType[5] {
                Ship.ShipType.CARRIER,
                Ship.ShipType.BATTLESHIP,
                Ship.ShipType.CRUISER,
                Ship.ShipType.SUBMARINE,
                Ship.ShipType.DESTROYER};

            // Get data from user where to place each type of the ship
            foreach (string type in shipTypesNames) {
                
                Printer.Print("\nPlease place " + type + " squares) on your ocean:");

                // Ask for ship position (top left Square of the ship) and layout (horizontal/vertical)
                // until the ship can be placed on the ocean (1. is inside board, 2. not overlap with
                // another ship, 3. do not touch another ship)
                bool shipPlacedInTheOcean = false;
                while (shipPlacedInTheOcean == false) {

                    int[] position = GetShipPositionInput(ocean);
                    string layout = GetShipLayoutInput();

                    // Create new ship object from the input
                    int index = shipTypesNames.IndexOf(type);
                    Ship ship = new Ship(shipTypes[index], layout);

                    // Check if ship can be placed in the ocean
                    shipPlacedInTheOcean = ocean.CanPlaceShip(ship, position[0], position[1]);
                    // TODO
                    // Here add check if ships not overlap
                    // Here add check if ships do not touch each other

                    if (shipPlacedInTheOcean == false) {
                        Printer.Print("Not possible to place the ship in the ocean, try again");
                    } else {
                        ocean.PlaceShipAtTheOcean(ship, position[0], position[1]);
                        Printer.Print(ocean, Program.Status.SHIPS_POSITIONING);
                        // ocean.DisplayOcean(Program.Status.SHIPS_POSITIONING);
                    }
                }
            }

            return ocean;
        }

        private int[] GetShipPositionInput(Ocean ocean) {
            int positionX = -1;
            int positionY = -1;
            while (positionX == -1 || positionY == -1) {
                Printer.Print("Position:");
                string position = GetUserInput().ToUpper();

                if (position != null && IsLetter(position[0].ToString())) {
                    positionY = ConvertLetterToInt(position[0]);
                    if (positionY >= ocean.Dimension) {
                        positionY = -1;
                        Printer.Print("Column index exceeded board dimension");
                    }
                    if (position.Substring(1) != "" && IsNumeric(position.Substring(1))) {
                        positionX = Int32.Parse(position.Substring(1)) - 1;
                        if (positionX >= ocean.Dimension) {
                            positionX = -1;
                            Printer.Print("Row index exceeded board dimension");
                        }
                    } else {
                        Printer.Print("Invalid row number");
                    }
                } else {
                    Printer.Print("First input character must be a letter indcating column");
                }
            }

            int[] positionInput = new int[2] { positionX, positionY };

            return positionInput;

        }

        private string GetShipLayoutInput() {

            string layout = null;
            
            while (layout == null) {
                Printer.Print("Layout (h - horizontal/v - vertical):");
                string layoutInput = GetUserInput().ToLower();
                
                if (layoutInput == "h") {
                    layout = "HORIZONTAL";
                } else if (layoutInput == "v") {
                    layout = "VERTICAL";
                } else {
                    Printer.Print("Wrong input");
                }
            }

            return layout;
        
        }

        public Ocean GuessEnemyPositionAKAFire(string position, Ocean enemysOcean) {
            int[] position1 = GetShipPositionInput(enemysOcean);
            /* PSEUDOCODE
            if enemyOcean[position] == ship {
                myOcean[position].color - zaznacz na znaleziony statek
            }
            else {
                myOcean[position].color - zaznacz ze nie ma statku
            }*/
            enemysOcean.Squares[position1[0]][position1[1]].VisibleForOpponent = true;
            if (enemysOcean.Squares[position1[0]][position1[1]].Fill == "X") {
                Printer.Print("hit");
                Thread.Sleep(2000);
            }
            else{
                Printer.Print("miss");
                Thread.Sleep(2000);
            }

            return enemysOcean;
        }

        public bool HasWon(Ocean enemysOcean) {
            for (int i = 0; i < enemysOcean.Dimension; i++) {
                for (int j = 0; j < enemysOcean.Dimension; j++) {
                    if (enemysOcean.Squares[i][j].Fill == "X" && enemysOcean.Squares[i][j].VisibleForOpponent == false) {
                        return false;
                    }
                }
            }
            return true;
        }
       
       
        // HELPER METHODS
        private static bool IsNumeric(string strToCheck) {
            Regex rg = new Regex(@"^[0-9\s,]*$");
            return rg.IsMatch(strToCheck);
        }

        private static bool IsLetter(string strToCheck) {
            Regex rg = new Regex(@"^[a-zA-Z\s,]*$");
            return rg.IsMatch(strToCheck);
        }
    
        private static int ConvertLetterToInt(char letter) {
            return (int)letter - 65;
        }

        private static string GetUserInput() {
            return Console.ReadLine();
        }
    }
}
