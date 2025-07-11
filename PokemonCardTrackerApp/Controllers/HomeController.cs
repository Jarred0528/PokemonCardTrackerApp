using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using PokemonCardTrackerApp.Models;
using PokemonTcgSdk.Standard.Features.FilterBuilder.Pokemon;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients;
using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;
using System.Diagnostics;

namespace PokemonCardTrackerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            string APIKey = "d055fa14-e9d3-44d8-9c0d-54a1199e1cc0";
            PokemonApiClient pokeClient = new PokemonApiClient(APIKey);
            var cardViewModel = new PokemonCardViewModel();

            try
            {
                var filter = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai");
                var cards = await pokeClient.GetApiResourceAsync<PokemonCard>(filter);
                var cardmodels = cards.Results.ToList();

                cardViewModel.CardName = cardmodels.FirstOrDefault().Name;
                cardViewModel.CardImageUrl = cardmodels.FirstOrDefault().Images.Small.AbsoluteUri;

                Console.WriteLine($"Found {cards.Count} cards matching 'darkrai':\n");

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return Ok(cardViewModel);
            //return View(cardViewModel);
        }


        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok(new { message = "Hello from .NET Core! WooHoo!!" });
        }

        [HttpGet("card")]
        public async Task<IActionResult> GetCard()
        {
            string APIKey = "d055fa14-e9d3-44d8-9c0d-54a1199e1cc0";
            PokemonApiClient pokeClient = new PokemonApiClient(APIKey);
            var cardViewModel = new PokemonCardViewModel();

            try
            {
                var filter = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai");
                var cards = await pokeClient.GetApiResourceAsync<PokemonCard>(filter);
                var cardmodels = cards.Results.ToList();

                cardViewModel.CardName = cardmodels.FirstOrDefault().Name;
                cardViewModel.CardImageUrl = cardmodels.FirstOrDefault().Images.Small.AbsoluteUri;

                Console.WriteLine($"Found {cards.Count} cards matching 'darkrai':\n");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return Ok(cardViewModel);
        }


    }
}
