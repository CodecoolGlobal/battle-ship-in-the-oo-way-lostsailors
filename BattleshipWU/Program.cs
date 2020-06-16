using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace BattleshipWU {
    class Program {
        static void Main(string[] args) {

            bool endGame = false;
            Status gameStatus = Status.START;
            var playersNamesInitial = new List<string> { "Player1", "Player2" };
            var playersObjects = new Player[2];
            string winnerName = "";

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

                        foreach (string player in playersNamesInitial) {
                            Console.Clear();
                            Console.WriteLine($"\nPlease tell me {player} name: ");
                            int index = playersNamesInitial.IndexOf(player);
                            playersObjects[index] = new Player(Console.ReadLine());
                            Console.WriteLine($"{player} - put your ships on the board\n" +
                            "The other player - please step out!!");
                            Thread.Sleep(3000);
                            Ship.DisplayShipTypes();
                            playersObjects[index].MyOcean = playersObjects[index].GetShipsPositionsAndPlaceShipsOnBoard(playersObjects[index].MyOcean);
                        }
                        Console.Clear();
                        Console.WriteLine("\n\nAllright! - All ships are in the oceans! Time to play!");
                        Thread.Sleep(5000);
                        playersObjects[0].MyEnemysOcean = playersObjects[1].MyOcean;
                        playersObjects[1].MyEnemysOcean = playersObjects[0].MyOcean;
                        gameStatus = Status.FIGHT;
                        break;


                    case Status.FIGHT:
                        bool winStatus = false;
                        while (winStatus == false) {
                            foreach (Player player in playersObjects) {
                                Console.Clear();
                                Console.WriteLine($"\nThis is the status of {player.Name} current shoots:\n\n");
                                System.Console.WriteLine("Before");
                                player.MyEnemysOcean.DisplayOcean(Status.FIGHT);
                                // TUTAJ DISPLAY BOARDA Z HIT/MISS TYLKO
                                Console.WriteLine("\nPlease input where do you want to shoot");
                                player.MyOcean = player.GuessEnemyPositionAKAFire("sth", player.MyEnemysOcean);
                                // COLLECT INPUT (IF SHIP -> DISPLAY HIT, ELSE -> DISPLAY MISS)
                                System.Console.WriteLine("\nAfter:");
                                player.MyEnemysOcean.DisplayOcean(Status.FIGHT);
                                Thread.Sleep(1000);
                                // DISPLAY AGAIN UPDATED BOARD
                                // CHECK ISWIN -> save winnerName = player.Name
                                if (player.HasWon(player.MyEnemysOcean)) {
                                    winStatus = true;
                                    gameStatus = Status.WIN;
                                    winnerName = player.Name;
                                    break;
                                }
                            }
                        }
                        break;

                    case Status.WIN:
                        Console.Clear();
                        Console.WriteLine($"\nCongrats!! {winnerName} is the champion!!");
                        Thread.Sleep(5000);
                        gameStatus = Status.START;
                        break;


                    case Status.EXIT:
                        Console.Clear();
                        Console.WriteLine("Thanks for playing! Come again soon.");
                        endGame = true;
                        break;
                }
            }
        }

        public enum Status {
            START,
            SHIPS_POSITIONING,
            FIGHT,
            WIN,
            EXIT,
        }   
    }
}
//ss