using System;
using System.Collections.Generic;
using ApiGamesCatalog.Dtos;
using CatalogoJogos.Entities;

namespace ApiGamesCatalog.Repositories
{
    public interface IGamesRepository
    {
         IEnumerable<Game> GetGames(int page, int elements);
         Game GetGame(Guid id);
         IEnumerable<Game> GetGamesByName(string gameName);
         void CreateGame(Game game);
         void UpdateGame(Game game);
         void DeleteGame(Guid id);
          
    }
}