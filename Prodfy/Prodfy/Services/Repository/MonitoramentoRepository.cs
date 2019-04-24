using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MonitoramentoRepository : IRepository<Monit>
    {
        private DataBase _dataBase;

        public MonitoramentoRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = _dataBase._conexao.Table<Monit>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }

        public void Adicionar(Monit entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Monit> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Monit entidade)
        {
            throw new NotImplementedException();
        }

        public Monit ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Monit> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public Monit ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
