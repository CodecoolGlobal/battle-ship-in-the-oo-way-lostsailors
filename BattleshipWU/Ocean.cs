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

        public void DisplayOcean(Program.Status status) {
            // Display column names  A B C D E F .... J etc.
            // A-Z: ASCII values 65-90
            Console.Write(String.Format("{0,5}", ""));
            for (int i = 65; i < 65 + this.Dimension; i++) {
                Console.Write(" " + (char)i + " ");
            }
            Console.WriteLine();
            // Display horizontal line
            Console.Write(String.Format("{0,5}", ""));
            for (int i = 0; i < this.Dimension; i++) {
                Console.Write("---");
            }
            Console.WriteLine();

            // Display board of squares
            foreach (List<Square> sqList in this.Squares) {
                // First display row number + pipe symbol: e.g. 1 |     2 |     3 |     at the beginning of ech row
                string s = String.Format("{0,5}", (this.Squares.IndexOf(sqList) + 1) + " |");
                Console.Write(s);
                foreach (Square squareO in sqList) {
                    // For all game status except Fight print all Ocean content
                    if (status != Program.Status.FIGHT ) {
                        Console.Write(" " + squareO.Fill + " ");
                    }
                    // ONLY for game status = Fight print content only if Square is already visible
                    else {
                        if (squareO.visibleForOpponent is true){
                            Console.Write(" " + squareO.Fill + " ");
                        }
                        // otherwise print tylda - as unknown value
                        else {
                            Console.Write(" " + "~" + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public List<List<Square>> placeShipAtTheOcean(Ship ship, int positionX, int positionY) {
            if (canPlaceShip(ship, positionX, positionY)) {
                if (ship.ShipLayout == "VERTICAL") {
                    for (int i = positionX; i < positionX + ship.Size; i++) {

                        this.Squares[i][positionY] = new Square(Square.SquareType.SHIP);
                    }
                }
                else if (ship.ShipLayout == "HORIZONTAL") {
                    for (int j = positionY; j < positionY + ship.Size; j++) {
                        this.Squares[positionX][j] = new Square(Square.SquareType.SHIP);
                    }
                }
            }
            else {
                Console.WriteLine("Cannot place that ship in the ocean");
            }
            return this.Squares;
        }

        public bool canPlaceShip(Ship ship, int positionY, int positionX) {
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
                endY += ship.Size-1;
            }
            else {
                endX += ship.Size-1;
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