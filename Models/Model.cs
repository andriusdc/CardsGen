using System;


namespace CardsAPI.Models
{
    public record Card
    {
        public Guid Id { get; init; }

        public string Email { get; set; }

        public string NumCard { get; set; }

        public DateTimeOffset CreatedDate { get; set; }


    }
}