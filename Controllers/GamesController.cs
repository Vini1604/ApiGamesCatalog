using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApiGamesCatalog.Dtos;
using ApiGamesCatalog.Repositories;
using CatalogoJogos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiGamesCatalog.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _repository;
        public GamesController(IGamesRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Search by a page
        /// </summary>
        /// <remarks>
        /// Cannot return a game without paging
        /// </remarks>
        /// <param name="page">Shows the page. Min 1</param>
        /// <param name="elements">Shows number of element per page Min 1 and max 50</param>
        /// <response code="200">Retrieve a list of games</response>
        /// <response code="204">If there isn't a game</response>  
        [HttpGet]
        public ActionResult<IEnumerable<GameDto>> GetGames([FromQuery, Range(1, int.MaxValue)] int page = 1, [FromQuery, Range(1, 50)] int elements = 5) {
            var games = _repository.GetGames(page, elements).Select(game => game.AsDto());

            if (games.Count() == 0)
                return NoContent();

            return Ok(games);
        }

        /// <summary>
        /// Search by Id
        /// </summary>
        /// <param name="idGame">Game Id</param>
        /// <response code="200">Retrive a game</response>
        /// <response code="404">If there isn't a game</response>
        [HttpGet("{idGame:guid}")]
        public ActionResult<GameDto> GetGame([FromRoute] Guid idGame) {
            var game =  _repository.GetGame(idGame).AsDto();

            if (game == null)
                return NotFound("Não existe este jogo");

            return Ok(game);
         }
        /// <summary>
        /// Create a game
        /// </summary>
        /// <param name="createdGame">Information of a game</param>
        /// <response code="200">Created successful</response>
        [HttpPost]
         public ActionResult<GameDto> CreateGame(CreateUpdateGameDto createdGame){
            Game game = new Game{
                Id = Guid.NewGuid(),
                GameName = createdGame.GameName,
                Studio = createdGame.Studio,
                Gender = createdGame.Gender,
                Year = createdGame.Year,
                Price = createdGame.Price
            };
            _repository.CreateGame(game);
            return game.AsDto();
         }

        /// <summary>
        /// Update a game
        /// </summary>
        /// /// <param name="id">Game Id</param>
        /// <param name="game">Updated data</param>
        /// <response code="200">Updated successful</response>
        /// <response code="404">If there isn't a game</response> 
        [HttpPut("{id}")]
         public ActionResult UpdateGame(Guid id, CreateUpdateGameDto game){
            var existingGame = _repository.GetGame(id);
            if (existingGame == null)
            {
                return NotFound("Não existe este Jogo para ser atualizado");
            }
            existingGame.GameName = game.GameName;
            existingGame.Gender = game.Gender;
            existingGame.Studio = game.Studio;
            existingGame.Year = game.Year;
            existingGame.Price = game.Price;
            _repository.UpdateGame(existingGame);
            return NoContent();

         }

        /// <summary>
        /// Delete a game
        /// </summary>
        /// /// <param name="id">Game Id</param>
        /// <response code="200">Deleted successful</response>
        /// <response code="404">If there isn't a game</response>  
        [HttpDelete("{id}")]
         public ActionResult DeleteGame(Guid id){
             var existingGame = _repository.GetGame(id);
            if (existingGame == null)
            {
                return NotFound("Não existe este jogo para ser deletado!");
            }
            _repository.DeleteGame(id);
            return NoContent();
         }
  
    }
}