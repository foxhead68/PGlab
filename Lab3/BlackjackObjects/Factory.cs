using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    class Factory
    {
        internal static Card CreateCard(CardFace ace, CardSuit clubs)
        {
            Card card = new Card();
            return card;
        }
    }
}


       





