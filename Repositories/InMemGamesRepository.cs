using System;
using System.Collections.Generic;
using System.Linq;
using ApiGamesCatalog.Dtos;
using CatalogoJogos.Entities;

namespace ApiGamesCatalog.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {
        private readonly List<Game> games = new List<Game>(){

            new Game{ Id = Guid.NewGuid(), GameName = "Fifa 21", Studio = "EA", Gender = "Sports", Year = 2020, Price = 200},
            new Game{ Id = Guid.NewGuid(), GameName = "Fifa 20", Studio = "EA", Gender = "Sports", Year = 2019, Price = 190},
            new Game{ Id = Guid.NewGuid(), GameName = "Street Fighter V", Studio = "Capcom", Gender = "Adventure", Year = 2013, Price = 80},
            new Game{ Id = Guid.NewGuid(), GameName = "Grand Theft Auto V", Studio = "Rockstar", Gender = "Fight", Year = 2018, Price = 190}
        };
        public void CreateGame(Game game)
        {
            games.Add(game);
        }

        public void DeleteGame(Guid id)
        {
            var index = games.FindIndex(existingItem => existingItem.Id == id);
            games.RemoveAt(index);
        }

        public Game GetGame(Guid id)
        {
            if (games.Where(x => x.Id == id).Equals(null))
            {
                return null;
            }
            return games.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<Game> GetGames(int page, int elements)
        {
            List<Game> gamePage = new List<Game>();
            int i = (page-1)*elements;
            int aux = i;
            while(i < aux + elements){
                if (i < games.Count())
                {
                    gamePage.Add(games[i]);
                }
                i++;
            }
            return gamePage;

        }

        public IEnumerable<Game> GetGamesByName(string gameName)
        {
            var gameList = games.Where(x => x.Id.Equals(gameName));
            return gameList;
        }

        public void UpdateGame(Game game)
        {
            var index = games.FindIndex(existingGame => existingGame.Id == game.Id);
            games[index] = game;
        }

    }
}