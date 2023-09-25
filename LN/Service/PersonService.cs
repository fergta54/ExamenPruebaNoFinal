using DAL.Login;
using DAL.Repository;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Service
{
    //Conexion a la otra interfaz
    public class PersonService : IPersonService
    {
        //INTERFACES
        private readonly IGenericRepository<Person> _personRep;
        private readonly IGenericLogin<Person> _personLog;

        //ctor + tab + tab
        //CONSTRUCTORES
        public PersonService(IGenericRepository<Person> personRepo)
        {
            _personRep = personRepo;
        }

        public PersonService(IGenericRepository<Person> personRep, IGenericLogin<Person> personLog) : this(personRep)
        {
            _personLog = personLog;
        }
        //METODOS
        public async Task<string> Login(string uname, string pass)
        {
            return await _personLog.Login(uname, pass);
        }

        public async Task<bool> AddUser(Person modelo)
        {
            return await _personRep.AddUser(modelo);
        }

        public async Task<bool> ChangeUser(Person modelo)
        {
            return await _personRep.ChangeUser(modelo);
        }

        public async Task<Person> Obtener(int id)
        {
            return await _personRep.Obtener(id);
        }

        public async Task<IQueryable<Person>> ObtenerTodos()
        {
            return await _personRep.ObtenerTodos();
        }

        //METODO PERSONALIZADO - IGNORAR
        public async Task<Person> ObtenerpPorNombre(string nombre)
        {
            IQueryable<Person> queryPersonSQL = await _personRep.ObtenerTodos();
            Person person = queryPersonSQL.Where(c => c.UserName == nombre ).FirstOrDefault();
            return person;
        }
    }
}
