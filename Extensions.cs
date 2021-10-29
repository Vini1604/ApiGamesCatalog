using ApiGamesCatalog.Dtos;
using CatalogoJogos.Entities;

namespace ApiGamesCatalog
{
    public static class Extensions
    {
        public static GameDto AsDto(this Game game){
            if (game == null)
            {
                return null;
            }
            return new GameDto{
                Id = game.Id,
                GameName = game.GameName,
                Studio = game.Studio,
                Gender = game.Gender,
                Year = game.Year,
                Price = game.Price
            };
        }
    }
}