using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackjackClassLibrary.CardSuit;

namespace BlackjackClassLibrary
{
    public class Deck
    {

        private List<Card> Card = new List<Card>();
        private object createDeck;

        public Deck()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    BlackJackCard blackJackCard = new BlackJackCard((CardFace)i, (CardSuit)j);
                }
                Card.Add(Factory.CreateCard(CardFace.Ace, CardSuit.Clubs));
            }
        }

        public Deck(object createDeck)
        {
            this.createDeck = createDeck;
        }

        public List<Card> CreateDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {

                    BlackJackCard blackJackCard = new BlackJackCard((CardFace)i, (CardSuit)j);
                }

            }
            return Card;
        }

        public Card Deal()
        {
            Card first = Card.Count > 0 ? Card[0] : null;
            if (Card.Count > 0)
            {
                first = Card[0];
                Card.RemoveAt(0);
            }
            else
            {
                Card = CreateDeck();
                Shuffle();
            }
            return first;

        }
        public void Shuffle()
        {
            Random rand = new Random();

            int n = Card.Count;
            int randSwitch = 0;
            for (int i = 0; i < n; i--)
            {

                randSwitch = rand.Next(n - 1) + 1;
                Card on = Card[randSwitch];
                Card[randSwitch] = Card[n - 1];
                Card[n - 1] = on;
            }
        }



        public void Print()
        {
            for (int ndx = 0; ndx < Card.Count; ndx++)
            {
                if (ndx == 0)
                {
                    Console.Write(" ");
                }

                if (ndx % 4 != 3)
                {
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"| {Card[ndx].Face} - {Card[ndx].Suit} |");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"| {Card[ndx].Face} - {Card[ndx].Suit} |");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            }
        }
    }
}


