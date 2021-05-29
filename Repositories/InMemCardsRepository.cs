using System;

namespace CardsAPI.Repositories
{
    public class InMemCardsRepository
    {    
        
        public static string CardNumGenerator(int length)
        {
            string cardnum = "";
            var rand= new Random();
            while(cardnum.Length
                < length)
            {
                cardnum+=rand.Next();
            }
            return cardnum;
        }
    }
}