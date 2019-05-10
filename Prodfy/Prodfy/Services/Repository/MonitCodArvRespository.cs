using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MonitCodArvRespository : IRepository<Monit_Cod_Arv>
    {
        public void Adicionar(Monit_Cod_Arv entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Monit_Cod_Arv> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Monit_Cod_Arv entidade)
        {
            throw new NotImplementedException();
        }

        public Monit_Cod_Arv ObterDados()
        {
            throw new NotImplementedException();
        }

        public Monit_Cod_Arv ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Monit_Cod_Arv> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
