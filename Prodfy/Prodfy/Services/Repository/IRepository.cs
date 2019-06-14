using SQLite;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T entidade);
        void DeletarTodos();
        void Editar(T entidade);
        string ObterInformacoesParaIdentificacao(int id);
        string ObterInformacoesParaIdentificacao(string codigo);
        T ObterDados();
        T ObterDadosPorId(string id);
        List<T> ObterTodos();
        TableQuery<T> AsQueryable();
        int ObterTotalDeRegistros();
        //IQueryable<T> ObterPorId(int id);
    }
}
