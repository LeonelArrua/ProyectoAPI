using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.SignalR;
using ProyectoAPI.Handlers;
using ProyectoAPI.Models;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
            //Nueva ventas
            [HttpPost("/Venta/{idUsuario}")]
            public void newSale([FromRoute] string idUsuario, [FromBody] List<Product> products)
            {
                long UserId = Convert.ToInt64(idUsuario);
                SaleHandler.insertSales(UserId, products);
            }
            //Traer Ventas
            [HttpGet("/Venta/{idUsuario}")]
             public List<Sale> GetSales([FromRoute]string idUsuario)
            {
            long id = Convert.ToInt64(idUsuario);
            return SaleHandler.getSalesFromDB(id);
            }

    }
}
