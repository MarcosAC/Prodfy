using System.Collections.Generic;
using System.Linq;

namespace Prodfy.Services.BD.Repository
{
    public interface IRepository<T> where T : class
    {        
        void Adicionar(T entidade);
        void Deletar(T entidade);
        void Editar(T entidade);
        //IQueryable<T> ObterPorId(int id);
        List<T> ObterTodos();        
    }
}
