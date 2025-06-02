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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

            return View(cardViewModel);
        }

       
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok(new { message = "Hello from .NET Core!" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
