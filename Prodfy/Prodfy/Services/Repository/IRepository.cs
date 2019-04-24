using SQLite;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T entidade);
        void Deletar();
        void Editar(T entidade);
        string ObterInformacoesParaIdentificacao(string codigo);
        T ObterDados();        
        List<T> ObterTodos();
        TableQuery<T> AsQueryable();
        int ObterTotalDeRegistros();
        //IQueryable<T> ObterPorId(int id);
    }
}
