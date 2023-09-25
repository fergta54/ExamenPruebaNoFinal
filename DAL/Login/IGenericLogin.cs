using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//INTERFAZ DEL LOGIN
namespace DAL.Login
{
    public interface IGenericLogin<TEntityModel> where TEntityModel : class
    {
        //ESTO ES PARA UTILIZARSE EN TODAS PARTES
        Task<string> Login(string uname, string pass);
    }
}
