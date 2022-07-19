using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackjackClassLibrary.CardSuit;

namespace BlackjackClassLibrary
{
    public class Card
    {

        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }


        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;


            switch (suit)
            {
                case CardSuit.Spades:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"|♠");
                    break;
                case CardSuit.Hearts:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"|♥");
                    break;
                case CardSuit.Clubs:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"|♣");
                    break;
                case CardSuit.Diamonds:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"|♦");
                    break;
            }
            switch (face)
            {
                case CardFace.Ten:
                    Console.Write($"10 ");
                    break;
                case CardFace.Jack:
                    Console.Write($"J ");
                    break;
                case CardFace.Queen:
                    Console.Write($"Q ");
                    break;
                case CardFace.King:
                    Console.Write($"K ");
                    break;
                case CardFace.Ace:
                    Console.Write($"11 ");
                    break;
                default:
                    Console.Write($" {(int)face + 1} ");
                    break;
            }
        }
        public void Print(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }


        public Card()
        {
        }
    }
}


        











