using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    class BlackJackCard
    {


        public int Value { get; set; }

        public BlackJackCard(CardFace face, CardSuit suit) 
        {
            switch (face)
            {
                case CardFace.Ace:
                    Value = 11;
                    break;
                case CardFace.Two:
                    Value = 2;
                    break;
                case CardFace.Three:
                    Value = 3;
                    break;
                case CardFace.Four:
                    Value = 4;
                    break;
                case CardFace.Five:
                    Value = 5;
                    break;
                case CardFace.Six:
                    Value = 6;
                    break;
                case CardFace.Seven:
                    Value = 7;
                    break;
                case CardFace.Eight:
                    Value = 8;
                    break;
                case CardFace.Nine:
                    Value = 9;
                    break;
                case CardFace.Ten:
                case CardFace.Jack:
                case CardFace.Queen:
                case CardFace.King:
                    Value = 10;
                    break;
            }
        }
    }
}

