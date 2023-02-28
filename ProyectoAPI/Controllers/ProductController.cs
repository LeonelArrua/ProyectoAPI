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
        //Traer Productos
        [HttpGet("/Producto")]
        public List<Product> getProductsFromDB() {
            return ProductHandler.getProductsFromDB();
        }
        //Crear Producto
        [HttpPost("/Producto")]
        public void createProduct(Product product) {
            ProductHandler.insertProduct(product);
        }
        //Modificar Producto
        [HttpPut("/Producto")]
        public void updateProduct(Product product) {
            ProductHandler.updateProduct(product);
        }
        //Eliminar Producto
        [HttpDelete("/Producto/{idUsuario}")]
        public void deleteProduct([FromRoute]int id) {
            SoldProductHandler.deleteSoldProduct(id);
            ProductHandler.deleteProduct(id);
        }
    }
}
