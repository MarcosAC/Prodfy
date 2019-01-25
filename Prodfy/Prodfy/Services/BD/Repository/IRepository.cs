using System.Collections.Generic;

namespace Prodfy.Services.BD.Repository
{
    public interface IRepository<T>
    {        
        void Adicionar(T entidade);
        void Deletar(T entidade);
        void Editar(T entidade);
        T ObterPorId(int id);
        List<T> ObterTodos();        
    }
}
