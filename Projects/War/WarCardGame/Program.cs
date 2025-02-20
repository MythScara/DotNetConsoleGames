using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> deck = new List<string>();
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        // Create the deck
        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                deck.Add(rank + " of " + suit);
            }
        }

        // Shuffle the deck
        Random rand = new Random();
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            string temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }

        int player1Points = 0;
        int player2Points = 0;

        // Play the game
        for (int i = 0; i < 52; i += 2)
        {
            string card1 = deck[i];
            string card2 = deck[i + 1];
            Console.WriteLine($"Player 1 plays {card1}");
            Console.WriteLine($"Player 2 plays {card2}");

            int card1Value = GetCardValue(card1);
            int card2Value = GetCardValue(card2);

            if (card1Value > card2Value)
            {
                player1Points++;
                Console.WriteLine("Player 1 wins this round!\n");
            }
            else if (card2Value > card1Value)
            {
                player2Points++;
                Console.WriteLine("Player 2 wins this round!\n");
            }
            else
            {
                Console.WriteLine("It's a tie!\n");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        Console.WriteLine($"Final Score:\nPlayer 1: {player1Points}\nPlayer 2: {player2Points}");
        if (player1Points > player2Points)
        {
            Console.WriteLine("Player 1 wins the game!");
        }
        else if (player2Points > player1Points)
        {
            Console.WriteLine("Player 2 wins the game!");
        }
        else
        {
            Console.WriteLine("The game is a tie!");
        }
    }

    static int GetCardValue(string card)
    {
        string rank = card.Split(' ')[0];
        switch (rank)
        {
            case "2": return 2;
            case "3": return 3;
            case "4": return 4;
            case "5": return 5;
            case "6": return 6;
            case "7": return 7;
            case "8": return 8;
            case "9": return 9;
            case "10": return 10;
            case "J": return 11;
            case "Q": return 12;
            case "K": return 13;
            case "A": return 14;
            default: return 0;
        }
    }
}