using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Handlers;
using ProyectoAPI.Models;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldProductController : ControllerBase
    {
        [HttpGet("/ProductoVendido/{idUsuario}")]
        public List<SoldProduct> GetSoldProducts([FromRoute]string idUsuario) {
            long id = Convert.ToInt64(idUsuario);
            return SoldProductHandler.getSoldProductFromDB(id);
        }

    }
}
