using ENTITY;
using Examen.ViewModels;
using LN.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    //CONTROLADOR EN BLANCO - HOME
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        //METODO DE LOGIN
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string uname, string pass)
        {
            string respuesta = await _personService.Login(uname, pass);
            return StatusCode(StatusCodes.Status200OK, respuesta);
        }

        //METODO DE LISTADO
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Person> queryPersonSQL = await _personService.ObtenerTodos();
            List<VistaMPerson> lista = queryPersonSQL.Select(c => new VistaMPerson()
            {
                Id = c.Id,
                UserName = c.UserName,
                CPassword = c.CPassword,
                CName = c.CName,
                CSurname = c.CSurname,
                Email = c.Email
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        //OBTENER SOLO UNO
        [HttpGet]
        [Route("Obtener")]
        public async Task<IActionResult> Obtener(int id)
        {
            Person newperson = await _personService.Obtener(id);
            return StatusCode(StatusCodes.Status200OK, newperson);
        }

        //INSERTAR UN NUEVO
        [HttpPost]
        [Route("Insertar")]
        public async Task<IActionResult> AddUser([FromBody] Person modelo)
        {
            Person newperson = new Person()
            {
                UserName = modelo.UserName,
                CPassword = modelo.CPassword,
                CName = modelo.CName,
                CSurname = modelo.CSurname,
                Email = modelo.Email
            };

            bool respuesta = await _personService.AddUser(newperson);

            return StatusCode(StatusCodes.Status200OK, new {valor = respuesta});
        }

        //ACTUALIZAR UNO 
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> ChangeUser([FromBody] Person modelo)
        {
            Person newperson = new Person()
            {
                Id=modelo.Id,
                UserName = modelo.UserName,
                CPassword = modelo.CPassword,
                CName = modelo.CName,
                CSurname = modelo.CSurname,
                Email = modelo.Email
            };

            bool respuesta = await _personService.ChangeUser(newperson);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        //BORRAR DESACTIVADO
        /*
        [HttpDelete]
        [Route("Borrar")]
        public async Task<IActionResult> Delete(int id)
        {
            bool respuesta = await _personService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
        */

    }
}
