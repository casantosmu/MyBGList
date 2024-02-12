using Microsoft.AspNetCore.Mvc;
using MyBGList.Dto;

namespace MyBGList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardGamesController(ILogger<BoardGamesController> logger) : ControllerBase
    {
        private readonly ILogger<BoardGamesController> _logger = logger;

        [HttpGet(Name = "GetBoardGames")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public RestDto<BoardGame[]> Get()
        {
            return new RestDto<BoardGame[]>()
            {
                Data = new[]
                {
                    new BoardGame()
                    {
                        Id = 1,
                        Name = "Axis & Allies",
                        Year = 1981,
                    },
                    new BoardGame()
                    {
                        Id = 2,
                        Name = "Citadels",
                        Year = 2000,
                    },
                    new BoardGame()
                    {
                        Id = 3,
                        Name = "Terraforming Mars",
                        Year = 2016,
                    }
                },
                Links = [new LinkDto(Url.Action(null, "BoardGames", null, Request.Scheme)!, "self", "GET")]
            };
        }
    }
}