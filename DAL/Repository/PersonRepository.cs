using DAL.DataContext;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PersonRepository : IGenericRepository<Person>
    {
        private readonly WebApiContext _webApiContext;

        // ctor + tab
        public PersonRepository(WebApiContext context)
        {
            _webApiContext = context;
        }

        //Metodos de contrato
        public async Task<bool> AddUser(Person modelo)
        {
            _webApiContext.People.Add(modelo);
            await _webApiContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeUser(Person modelo)
        {
            _webApiContext.People.Update(modelo);
            await _webApiContext.SaveChangesAsync();
            return true;
        }

        //ELIMINAR NO USAR
        /*
        public async Task<Person> Delete(int id)
        {
            Person modelo = dbcontext.People.First(c=>.IdContacto == id);
            _webApiContext.People.Remove(modelo);
            await _webApiContext.SaveChangesAsync();
            return true;
        }
        */

        public async Task<Person> Obtener(int id)
        {
            return await _webApiContext.People.FindAsync(id);
        }

        public async Task<IQueryable<Person>> ObtenerTodos()
        {
            IQueryable<Person> queryPeopleSQL = _webApiContext.People;
            return queryPeopleSQL;
        }
    }
}
