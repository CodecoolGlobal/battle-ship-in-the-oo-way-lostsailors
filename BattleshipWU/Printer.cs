using System;
using System.Collections.Generic;


namespace BattleshipWU {
    static class Printer {
        public static void Print(Ocean ocean, Program.Status status) {
            // Display column names  A B C D E F .... J etc.
            // A-Z: ASCII values 65-90
            Console.Write(String.Format("{0,5}", ""));
            for (int i = 65; i < 65 + ocean.Dimension; i++) {
                Console.Write(" " + (char)i + " ");
            }
            Console.WriteLine();
            // Display horizontal line
            Console.Write(String.Format("{0,5}", ""));
            for (int i = 0; i < ocean.Dimension; i++) {
                Console.Write("---");
            }
            Console.WriteLine();

            // Display board of squares
            foreach (List<Square> sqList in ocean.Squares) {
                // First display row number + pipe symbol: e.g. 1 |     2 |     3 |     at the beginning of ech row
                string s = String.Format("{0,5}", (ocean.Squares.IndexOf(sqList) + 1) + " |");
                Console.Write(s);
                foreach (Square squareO in sqList) {
                    // For all game status except Fight print all Ocean content
                    if (status != Program.Status.FIGHT ) {
                        Console.Write(" " + squareO.Fill + " ");
                    }
                    // ONLY for game status = Fight print content only if Square is already visible
                    else {
                        if (squareO.VisibleForOpponent is true){
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
    
        public static void Print(string message) {
            Console.WriteLine(message);
        }
    }
}