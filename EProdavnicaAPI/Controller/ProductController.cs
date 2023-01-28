using CoreClassLib.Model.Entitis;
using EProdavnicaAPI.Data;
using Infrascture.InfrasctureClassLib.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EProdavnicaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EProdavnicaDbContext _eProdavnicaDbContext;
        public ProductController(EProdavnicaDbContext eProdavnicaDbContext)
        {
          _eProdavnicaDbContext=eProdavnicaDbContext;

        }
        
        [HttpGet("getAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts() 
        {

            var result = await _eProdavnicaDbContext.Prodcts.ToListAsync();

            return result;
        }


        [HttpGet("getProductById/{id}")]
        public async Task<ActionResult<List<Product>>> GetAllProductById(int id)
        {

            var result = await _eProdavnicaDbContext.Prodcts.Where(x=>x.Id==id).FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("insertNewProduct")]
        public async Task<Product> InsertProducts([FromBody] Product product)
        {
         await _eProdavnicaDbContext.AddAsync(product);
            await _eProdavnicaDbContext.SaveChangesAsync();
            var result = await _eProdavnicaDbContext.Prodcts.FirstOrDefaultAsync(x => x.Name == product.Name);

            return result;
        }


    }

        //[HttpPut("updateProduct")]
        //public async Task<ActionResult<List<Product>>> UpdateProducts()
        //{

        //    return await UpdateProducts();

        //}

}
