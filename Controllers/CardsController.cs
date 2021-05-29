using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CardsAPI.Models;
using CardsAPI.Repositories;
using CardsAPI.Data;

namespace CardsAPI.Controllers
{
    [Route("cards")]
    [ApiController]
    public class CardsController: ControllerBase
    {
        
        private readonly InMemCardsRepository repository;

        public CardsController()
        {
            repository = new InMemCardsRepository();
        }
          
        //Receber email/gerar Cartão
        [HttpGet]
        public string CreateCard(string email)
        {
            var newCard = new Card();
            newCard.Email=email;
            newCard.CreatedDate=DateTimeOffset.UtcNow ;
            newCard.NumCard=InMemCardsRepository.CardNumGenerator(8);
 
            var db = new CardsContext();
            db.Add(newCard);
            db.SaveChanges();

            return newCard.NumCard; 
        }
 
        [Route("mycards")]
        [HttpGet]
        public object GetMyCards(string email)
        {
            var db = new CardsContext();
            List<string> myCards = db.Card.Where(a => a.Email == email).OrderBy(a => a.CreatedDate)
            .Select(a => a.NumCard).ToList();
             
            if (!myCards.Any()) 
            {
                string msg = "Usuário não encontrado";
            return msg;
            }

            return myCards;

          
        }      
    }
}
