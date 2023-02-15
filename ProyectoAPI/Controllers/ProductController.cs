using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Handlers;
using ProyectoAPI.Models;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        [HttpGet("/productos")]

        public List<Product> getProductsFromDB() {
            return Handlers.ProductHandler.getProductsFromDB();
        }
        [HttpPost]

        public void createProduct(Product product) {
            ProductHandler.createProduct(product);
        }
        [HttpPut]
        public void updateProduct(Product product) {
            ProductHandler.updateProduct(product);
        }
        [HttpDelete("{id}")]
        public void deleteProduct([FromBody]int id) {
            SoldProductHandler.deleteSoldProduct(id);
            ProductHandler.deleteProduct(id);
        }











    }
}
