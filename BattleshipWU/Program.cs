using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace BattleshipWU {
    class Program {
        static void Main(string[] args) {

            bool endGame = false;
            Status gameStatus = Status.START;
            while (!endGame) {

                switch (gameStatus) {


                    case Status.START:
                        Console.Clear();
                        Console.Write("That is battleship game! Welcome!\n\n" +
                            "MENU:\n" +
                            "\t1 - START GAME\n" +
                            "\t2 - EXIT GAME\n\n" +
                            "Please input what do you want to do?\n");
                        string userChoice = Console.ReadLine();
                        if (userChoice == "1") { gameStatus = Status.SHIPS_POSITIONING; } else if (userChoice == "2") { gameStatus = Status.EXIT; } else { Console.WriteLine("Incorrect input"); }
                        break;


                    case Status.SHIPS_POSITIONING:
                        var playersNamesInitial = new List<string> { "Player1", "Player2"};
                        var playersObjects = new Player[2];
                        var playersOceans = new Ocean[2];

                        foreach (string player in playersNamesInitial) {
                            Console.Clear();
                            Console.WriteLine($"\nPlease tell me {player} name: ");
                            int index = playersNamesInitial.IndexOf(player);
                            playersObjects[index] = new Player(Console.ReadLine());
                            playersOceans[index] = new Ocean(10);
                            Console.WriteLine($"{player} - put your ships on the board\n" +
                            "The other player - please step out!!");
                            Thread.Sleep(3000);
                            Ship.displayShipTypes();
                            playersOceans[index] = playersObjects[index].getShipsPositions(playersOceans[index]);
                        }
                        Console.Clear();
                        Console.WriteLine("\n\nAllright! - All ships are in the oceans! Time to play!");
                        Thread.Sleep(5000);
                        gameStatus = Status.FIGHT;
                        break;


                    case Status.FIGHT:
                        break;


                    case Status.WIN:
                        break;


                    case Status.EXIT:
                        Console.Clear();
                        Console.WriteLine("Thanks for playing! Come again soon.");
                        endGame = true;
                        break;
                }
            }
        }

        enum Status {
            START,
            SHIPS_POSITIONING,
            FIGHT,
            WIN,
            EXIT,
        }   
    }
}
