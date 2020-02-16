using System;
using System.Collections.Generic;
using System.Text;


namespace BattleshipWU {
    class Ocean {
        public int Dimension { get; set; }
        public List<List<Square>> Squares { get; private set; }

        public Ocean(int dimension) {
            this.Dimension = dimension;
            Square gameField = new Square(Square.SquareType.OCEAN);
            this.Squares = new List<List<Square>>();

            for (int i = 0; i < dimension; i++) {
                List<Square> row = new List<Square>();
                for (int j = 0; j < dimension; j++) {
                    row.Add(gameField);
                }
                this.Squares.Add(row);
            }
        }

        public void displayOcean() {
            //A-Z: ASCII values 65-90
            Console.Write(String.Format("{0,5}", ""));
            for (int i = 65; i < 65 + this.Dimension; i++) {
                Console.Write(" " + (char) i + " ");
            }
            Console.WriteLine();
            Console.Write(String.Format("{0,5}", ""));
            for (int i = 0; i < this.Dimension; i++) {
                Console.Write("---");
            }
            Console.WriteLine();

            foreach (List<Square> sqList in this.Squares) {
                string s = String.Format("{0,5}", (this.Squares.IndexOf(sqList) + 1)+" |");
                Console.Write(s);
                foreach (Square squareO in sqList) {
                    Console.Write(" " + squareO.Fill + " ");
                }
                Console.WriteLine();
            }
        }

        public List<List<Square>> placeShipAtTheOcean(Ship ship, int positionX, int positionY, Square squareShip) {
            if (canPlaceShip(ship, positionX, positionY)) {
                if (ship.ShipLayout == "VERTICAL") {
                    for (int i = positionX; i < positionX + ship.Size; i++) {
                        this.Squares[i][positionY] = squareShip;
                    }
                }
                else if (ship.ShipLayout == "HORIZONTAL") {
                    for (int j = positionY; j < positionY + ship.Size; j++) {
                        this.Squares[positionX][j] = squareShip;
                    }
                }
            }
            else {
                Console.WriteLine("Cannot place that ship in the ocean");
            }
            return this.Squares;
        }

        public bool canPlaceShip(Ship ship, int positionX, int positionY) {
            if (ship.ShipLayout == "VERTICAL") {
                if (positionX + ship.Size >= this.Dimension) {
                    return false;
                }
            }
            if (ship.ShipLayout == "HORIZONTAL") {
                if (positionY + ship.Size >= this.Dimension) {
                    return false;
                }
            }
            return true;
        }

        public bool checkIfShipsOverlap(Ship ship, int positionX, int positionY) {
            if (ship.ShipLayout == "VERTICAL") {
                for (int i = positionX; i < positionX + ship.Size; i++) {
                    if (this.Squares[i][positionY].Fill == "X") {
                        return true;
                    }
                }
            } else if (ship.ShipLayout == "HORIZONTAL") {
                for (int j = positionY; j < positionY + ship.Size; j++) {
                    if (this.Squares[positionX][j].Fill == "X") {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool checkIfShipsTouchEachOther(Ship ship, int positionX, int positionY) {
            //if (ship.ShipLayout == "VERTICAL") {
            //    for (int i = positionX; i < positionX + ship.Size; i++) {
            //        if (this.Squares[i][positionY].Fill == "X") {
            //            return true;
            //        }
            //    }
            //} else if (ship.ShipLayout == "HORIZONTAL") {
            //    for (int j = positionY; j < positionY + ship.Size; j++) {
            //        if (this.Squares[positionX][j].Fill == "X") {
            //            return true;
            //        }
            //    }
            //}
            return false;
        }
    }
}
