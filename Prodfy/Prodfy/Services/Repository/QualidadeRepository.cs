using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class QualidadeRepository : IRepository<Qualidade>
    {
        private DataBase dataBase;

        public QualidadeRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Qualidade qualidade)
        {
            try
            {
                dataBase._conexao.Insert(qualidade);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Qualidade>();
        }

        public List<QualidadeEstoqueViveiro> ObterQualidadeEstoqueViveiro(int loteId, int mudaId)
        {
            string query = "SELECT " +
                                "Q.qualidade_id, " +
                                "Q.codigo, " +
                                "Q.titulo " +
                           "FROM " +
                                "Inv_Item AA " +
                           "INNER JOIN Qualidade Q " +
                           "ON Q.qualidade_id = AA.qualidade_id ";

            string where = string.Empty;
            string cap = string.Empty;

            if (loteId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.lote_id = {loteId}";
            }

            if (mudaId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.muda_id = {mudaId}";
            }

            if (!string.IsNullOrEmpty(where))
                where = $"WHERE {where}";

            query += $"{where} GROUP BY AA.qualidade_id ORDER BY 3";

            var listaQualidades = dataBase._conexao.Query<QualidadeEstoqueViveiro>(query);

            return listaQualidades;
        }

        public List<Qualidade> ObterTodos()
        {
            var listaQualidade = dataBase._conexao.Query<Qualidade>("SELECT qualidade_id, codigo, titulo FROM Qualidade ORDER BY 2");
            return listaQualidade;
        }

        public string ObterQualidadeInfo(int qualidadeId)
        {
            var dadosQualidade = dataBase._conexao.Table<Qualidade>().FirstOrDefault(q => q.qualidade_id == qualidadeId);

            var qualidadeInfo = new
            {
                dadosQualidade.qualidade_id,
                dadosQualidade.codigo,
                dadosQualidade.titulo,
            };

            string ret = string.Empty;

            if (qualidadeInfo.qualidade_id != 0)
                ret = $"1||{qualidadeInfo.qualidade_id}|{qualidadeInfo.codigo}|{qualidadeInfo.titulo}";
            else
                ret = "0|Registro não encontrado!|";

            return ret;
        }

        public TableQuery<Qualidade> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Qualidade entidade)
        {
            throw new NotImplementedException();
        }

        public Qualidade ObterDados()
        {
            throw new NotImplementedException();
        }

        public Qualidade ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
