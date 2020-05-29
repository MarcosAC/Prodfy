using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class AtividadeRepository
    {
        private readonly DataBase dataBase;

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

        public void DeletarTodos()
        {
            dataBase._conexao.Execute("Delete From Atividade");
        }

        public List<ListaAtividades> ObterTodasAtividades()
        {
            return dataBase._conexao.Query<ListaAtividades>("SELECT " +
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

            if (string.IsNullOrEmpty(filtro))
                return ObterTodasAtividades();

            return lista.FindAll(l => l.nome_interno.Contains(filtro));
        }

        public Atividade ObterDadosAtividade()
        {
            if (dataBase._conexao.Table<Atividade>().Count() > 0)
            {
                var dadosAtividade = dataBase._conexao.Table<Atividade>().FirstOrDefault();
                return dadosAtividade;
            }

            return null;
        }

        public List<Atividade> ListaAtvidadesOrdenasPorId()
        {            
            List<Atividade> lista = new List<Atividade>();
            lista = dataBase._conexao.Table<Atividade>().OrderBy(a => a.idAtividade).ToList();
            return lista;
        }

        public void DeletarAtividadePorId(int id)
        {
            dataBase._conexao.Delete<Atividade>(id);
        }
    }
}
