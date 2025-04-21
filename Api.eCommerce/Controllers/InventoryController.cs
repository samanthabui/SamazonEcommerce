//API
using Microsoft.AspNetCore.Mvc;
using Library.eCommerce.Models;
using Library.eCommerce.Models.DTO;

namespace Api.eCommerce.Controllers
{
    //API: MAP OF ROUTE TO FUNCTIONS.
    [ApiController]
    //API: ASSIGNING ROUTE TO CLASS. SQUARE BRACKETS MEAN TAKE AWAY STRING LITERAL.
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Item?> Get()
        {
            return new List<Item?>            
            {
                //DTO
                new Item{ Product = new ProductDTO{ID = 1, Name ="PILOT LOGBOOK"}, ID = 1, Quantity = 10},
                new Item{ Product = new ProductDTO{ID = 2, Name ="AVIATION HEADPHONES"}, ID = 2, Quantity = 10},
                new Item{ Product = new ProductDTO{ID = 3, Name ="AVIATOR SUNGLASSES"}, ID = 3, Quantity = 10},
                new Item{ Product = new ProductDTO{ID = 4, Name ="FLIGHT BAG"}, ID = 4, Quantity = 10}
            };
        }
    }
}