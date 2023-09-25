using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//INTERFAZ LN
namespace LN.Service
{
    public interface IPersonService
    {
        //contrato para este selvicio - lo copiamos del dal
        Task<bool> AddUser(Person modelo);
        Task<bool> ChangeUser(Person modelo);
        //Task<bool> Delete(int id);
        Task<Person> Obtener(int id);
        Task<IQueryable<Person>> ObtenerTodos(); //listar

        //metodo personalizado
        Task<Person> ObtenerpPorNombre(string nombre); //listar

        Task<string> Login(string uname, string pass);//login
    }
}
