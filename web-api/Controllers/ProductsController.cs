using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_api.database;
using web_api.database.Entities;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var result = _context.Products.FirstOrDefault(p => p.Id == id);
            return result;
        }

        // POST api/values
        [HttpPost]
        public async Task<int> Post([FromBody] Product value)
        {
            var result = _context.Products.Add(value);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
