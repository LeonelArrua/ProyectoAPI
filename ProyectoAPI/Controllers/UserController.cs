using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoAPI.Handlers;
using ProyectoAPI.Models;
using System.Data.SqlClient;
using System;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Crear usuario
        [HttpPost("/Usuario")]
        public void CreateUser([FromBody] User usr) {
            UserHandler.InsertUser(usr);
        }
        //Modificar Usuario
        [HttpPut]
        public void ModifyUser([FromBody] User usr)
        {
            UserHandler.ModifyUser(usr);
        }
        //Inicio de sesión
        [HttpGet("/Usuario/{usuario}/{contrasena})")]
        public User LogginUser([FromRoute] string usuario, [FromRoute] string contrasena)
        {
            return UserHandler.LogginUser(usuario, contrasena);
        }
        [HttpGet("/Usuario")]
        public User GetUserFromDB()
        {
            return UserHandler.GetUserFromDB();
        }

    }

}
