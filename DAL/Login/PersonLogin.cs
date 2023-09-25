using DAL.DataContext;
using ENTITY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Login
{
    public class PersonLogin : IGenericLogin<Person>
    {
        //DB CONTEXT
        private readonly WebApiContext _webApiContext;

        //CONSTRUCTOR
        public PersonLogin(WebApiContext context)
        {
            _webApiContext = context;
        }

        //METODO EN LA DAL
        public async Task<string> Login(string uname, string pass)
        {
            var person = await _webApiContext.People.FirstOrDefaultAsync(p => p.UserName == uname && p.CPassword == pass);

            if (person == null)
            {
                string message = "Credenciales incorrectas";
                return message;
            }
            else
            {
                string message = "Login Correcto Bienvenido!";
                return message;
            }
        }
    }
}
