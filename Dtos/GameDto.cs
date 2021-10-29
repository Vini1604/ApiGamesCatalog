using System;

namespace ApiGamesCatalog.Dtos
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public string Studio { get; set; }
        public string Gender { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
    }
}