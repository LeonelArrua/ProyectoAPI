using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Handlers;
using ProyectoAPI.Models;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPut]
        public void ModifyUser([FromBody]User usr)
        {
        }

        [HttpGet("/User")]

        public List<User> GetUsersFromDB()
        {
            return UserHandler.GetUsersFromDB();
        }
        

    }
}
