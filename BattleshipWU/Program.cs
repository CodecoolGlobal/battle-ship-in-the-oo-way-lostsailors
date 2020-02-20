using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace BattleshipWU {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("That is battleship game!");

            Console.WriteLine("\nPlease tell me Player1 name:");
            Player player1 = new Player(Console.ReadLine());
            Ocean ocean1 = new Ocean(10);
            Console.WriteLine("\nPlease tell me Player2 name:");
            Player player2 = new Player(Console.ReadLine());
            Ocean ocean2 = new Ocean(10);

            Console.WriteLine("Player1 - put your ships on the board\n" +
                "Player2 - please step out");
            Thread.Sleep(300);
            Ship.displayShipTypes();

            ocean1 = player1.getShipsPositions(ocean1);

            Console.WriteLine("Player2 - put your ships on the board\n" +
                "Player1 - please step out");
            Thread.Sleep(300);
            Ship.displayShipTypes();

            ocean2 = player2.getShipsPositions(ocean2);
        }
    }
}
//s