using System;
using System.Collections.Generic;
using System.Text;


namespace BattleshipWU {
    class Ocean {
        public int Dimension { get; set; }
        public List<List<Square>> Squares { get; private set; }

        public Ocean(int dimension) {
            
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
            foreach (List<Square> sqList in this.Squares) {
                foreach (Square squareO in sqList) {
                    Console.Write(" " + squareO.Fill + " ");
                }
                Console.WriteLine();
            }
        }

        /*public List<List<Square>> createEmptyOcean(int dimension, Square ocean) {
            for (int i = 0; i < dimension; i++) {
                for (int j = 0; j < dimension; j++) {
                    this.Squares[i][j] = ocean;
                }
            }
            return this.Squares;
        }*/
            
        public List<List<Square>> placeShipAtTheOcean(Ship ship, int positionX, int positionY, Square squareShip, Square squareOcean) {
            if (ship.ShipLayout == Ship.Layout.HORIZONTAL) {
                for (int i = positionX; i < positionX + ship.Size; i++) {
                    this.Squares[positionY - 1][i] = squareShip;
                }
            }
            else if (ship.ShipLayout == Ship.Layout.VERTICAL) {
                for (int j = positionY; j < positionY + ship.Size; j++) {
                    this.Squares[j][positionX - 1] = squareShip;
                }
            }
            return this.Squares;
        }
    }
}
