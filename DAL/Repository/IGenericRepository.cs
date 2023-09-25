using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//INTERFAZ
namespace DAL.Repository
{
    //Aqui va el contrato - metodos utilizados - COLOCAR PUBLIC

//prueba comentario pusha
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        //METODOS A USAR
        //COMMIT PRUEBA
        Task<bool> AddUser(TEntityModel modelo);
        Task<bool> ChangeUser(TEntityModel modelo);
        //Task<bool> Delete(int id);
        Task<TEntityModel> Obtener(int id);
        Task<IQueryable<TEntityModel>> ObtenerTodos(); //listar
    }
}
