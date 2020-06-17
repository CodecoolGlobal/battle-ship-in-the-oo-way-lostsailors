using System;
using System.Collections.Generic;
using System.Text;


namespace BattleshipWU {
    class Ocean {
        public int Dimension { get; set; }
        public List<List<Square>> Squares { get; private set; }

        public Ocean(int dimension) {
            this.Dimension = dimension;
            this.Squares = new List<List<Square>>();

            // Square gameField = new Square(Square.SquareType.OCEAN);
            for (int i = 0; i < dimension; i++) {
                List<Square> row = new List<Square>();
                for (int j = 0; j < dimension; j++) {
                    row.Add(new Square(Square.SquareType.OCEAN));
                }
                this.Squares.Add(row);
            }
        }

        public List<List<Square>> PlaceShipAtTheOcean(Ship ship, int positionX, int positionY) {
            if (CanPlaceShip(ship, positionX, positionY)) {
                if (ship.ShipLayout == "VERTICAL") {
                    for (int i = positionX; i < positionX + (int)ship.Type; i++) {

                        this.Squares[i][positionY] = new Square(Square.SquareType.SHIP);
                    }
                }
                else if (ship.ShipLayout == "HORIZONTAL") {
                    for (int j = positionY; j < positionY + (int)ship.Type; j++) {
                        this.Squares[positionX][j] = new Square(Square.SquareType.SHIP);
                    }
                }
            }
            else {
                Printer.Print("Cannot place that ship in the ocean");
            }
            return this.Squares;
        }

        public bool CanPlaceShip(Ship ship, int positionY, int positionX) {
            // TBC - STILL SOME ERRORS WHEN YOU PUT A10 etc

            var dimension = Dimension - 1;

            var startX = positionX;
            if (startX > 0) {
                startX--;
            }
            var startY = positionY;
            if (startY > 0) {
                startY--;
            }

            var endX = positionX;
            var endY = positionY;

            if (ship.ShipLayout == "VERTICAL") {
                endY += (int)ship.Type-1;
            }
            else {
                endX += (int)ship.Type-1;
            }
            // if end point is not the last coordinate check one past it.
            if (endY < dimension) {
                endY++;
            }

            if (endX < dimension) {
                endX++;
            }

            if (startX < 0 || startY < 0 || endX > dimension || endY > dimension) {
                return false;
            } 

            for (int y = startY; y <= endY; y++) {
                for (int x = startX; x <= endX; x++) {
                    if ("X" == Squares[y][x].Fill) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}