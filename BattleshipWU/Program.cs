using System;
using System.IO;
using System.Collections.Generic;

namespace BattleshipWU {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("That is battleship game!");

            Console.WriteLine("\nPlease tell me Player1 name:");
            Player player1 = new Player(Console.ReadLine());
            Console.WriteLine("\nPlease tell me Player2 name:");
            Player player2 = new Player(Console.ReadLine());

            Ocean ocean1 = new Ocean(10);
            Ship ship1 = new Ship(Ship.ShipType.S, Ship.Layout.HORIZONTAL);
            ocean1.placeShipAtTheOcean(ship1, 2, 2, new Square(Square.SquareType.SHIP), new Square(Square.SquareType.OCEAN));
            ocean1.displayOcean();
        }
    }
}
