using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class AtividadeRepository : IRepository<Atividade>
    {
        private DataBase dataBase;

        public AtividadeRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = dataBase._conexao.Table<Atividade>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Atividade atividade)
        {
            try
            {
                dataBase._conexao.Insert(atividade);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Atividade> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.Execute("Delete From Atividade");
        }

        public List<ListaAtividades> ListaDeAtividades(string filtro)
        {
            var lista = dataBase._conexao.Query<ListaAtividades>("SELECT " +
                                                                    "AA.idatividade, " +
                                                                    "AA.colaborador_id, " +
                                                                    "CB.nome_interno, " +
                                                                    "AA.lista_atv_id, " +
                                                                    "LA.codigo, " +
                                                                    "LA.titulo, " +
                                                                    "AA.data_inicio, " +
                                                                    "AA.data_fim " +
                                                                 "FROM " +
                                                                    "Atividade AA " +
                                                                 "LEFT JOIN " +
                                                                    "Colaborador CB ON CB.colaborador_id = AA.colaborador_id " +
                                                                 "LEFT JOIN " +
                                                                    "Lista_Atv LA ON LA.lista_atv_id = AA.lista_atv_id " +
                                                                 "ORDER BY AA.data_inicio");
            return lista;
        }

        public void Editar(Atividade entidade)
        {
            throw new NotImplementedException();
        }

        public Atividade ObterDados()
        {
            if (dataBase._conexao.Table<Atividade>().Count() > 0)
            {
                var dadosAtividade = dataBase._conexao.Table<Atividade>().FirstOrDefault();
                return dadosAtividade;
            }

            return null;
        }

        public List<Atividade> ObterTodos()
        {            
            List<Atividade> lista = new List<Atividade>();
            lista = dataBase._conexao.Table<Atividade>().OrderBy(a => a.idAtividade).ToList();
            return lista;
        }

        public string ObterInformacoesParaIdentificacao(int codigo)
        {
            throw new NotImplementedException();
        }

        public Atividade ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
