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

            [HttpPost("{UserId}")]
            public void newSale([FromRoute] string UserId, [FromBody] List<Product> products)
            {
                long id = Convert.ToInt64(UserId);
                SaleHandler.insertSales(id, products);
            }
        
    }
}
