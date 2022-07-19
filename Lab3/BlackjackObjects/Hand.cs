using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackjackClassLibrary.CardSuit;

namespace BlackjackClassLibrary
{
    class Hand
    {

        protected List<Card> _cards = new List<Card>();

        public Hand(bool isDealer)
        {
            IsDealer = isDealer;
        }

        public bool IsDealer { get; }

        public virtual void AddCard(Card _card)

        {
            _cards.Add(_card);
            _cards.Add(Factory.CreateCard(CardFace.Ace, CardSuit.Clubs));
        }

        public virtual void Print(int x, int y)
        {
            int originalPosition = x;
            for (int i = 0; i < _cards.Count; i++)
            {

                
                x += 6;
                if (i % 5 == 0 && i != 0)
                {
                    y += 3;
                    x = originalPosition;
                }
            }
        }
    }
}


