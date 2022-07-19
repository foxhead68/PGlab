using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    public class BlackjackHand
    {
       
     
        public int Score { get; private set; }
        public bool IsDealer { get; set; }
        public BlackjackHand(bool isDealer = false)
        {
            this.IsDealer = isDealer;
        }
       void AddCard(Card _card)

        {
            AddCard(_card);
            int aceCounter = 0;
            int Score = 0;
            for (int i = 0; i < aceCounter - 1; i++)
            {
                if ((Score + 11) < 21)
                {
                    Score += 11;
                }
                else
                {
                    Score += 1;
                }
            }

        }

        void Print(int x, int y, Card card, Card newCard)
        {

            int originalPosition = x;
            if (IsDealer == true)
            {
               
                Console.SetCursorPosition(x + 6, y);

                Console.WriteLine($"\nScore: {Score}");

            }
        }
    }
}
