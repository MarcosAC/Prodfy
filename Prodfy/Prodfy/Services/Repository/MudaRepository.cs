using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MudaRepository : IRepository<Muda>
    {
        private readonly DataBase dataBase;

        public MudaRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Muda muda)
        {
            try
            {
                dataBase._conexao.Insert(muda);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Muda>();
        }        

        public Muda ObterDados()
        {
            var dadosMuda = dataBase._conexao.Table<Muda>().FirstOrDefault();
            return dadosMuda;
        }

        public Muda ObterDadosPorId(int id)
        {
            var dadosMuda = dataBase._conexao.Table<Muda>().FirstOrDefault(m => m.muda_id == id);
            return dadosMuda;
        }

        public List<Muda> ObterTodos()
        {
            return dataBase._conexao.Query<Muda>("SELECT " +
                                                    "muda_id, " +
                                                    "nome_interno, " +
                                                    "nome, " +
                                                    "especie_nome_comum, " +
                                                    "especie_nome_especie, " +
                                                    "especie_nome_cientifico, " +
                                                    "origem, " +
                                                    "viveiro, " +
                                                    "canaletao, " +
                                                    "linha, " +
                                                    "coluna, " +
                                                    "qtde " +
                                                 "FROM " +
                                                    $"Muda " +
                                                 "ORDER BY 2");
        }

        public string ObterMudaInfo(string mudaId)
        {
            int id = int.Parse(mudaId);

            var dadosMuda = dataBase._conexao.Table<Muda>().FirstOrDefault(m => m.muda_id == id);

            var mudaInfo = new
            {
                dadosMuda.muda_id,
                dadosMuda.nome_interno,
                dadosMuda.nome,
                dadosMuda.especie_nome_comum,
                dadosMuda.especie_nome_especie,
                dadosMuda.especie_nome_cientifico,
                dadosMuda.origem,
                dadosMuda.viveiro,
                dadosMuda.canaletao,
                dadosMuda.linha,
                dadosMuda.coluna,
                dadosMuda.qtde
            };

            string ret = string.Empty;

            if (mudaInfo.muda_id != 0)
            {
                ret = $"1||{mudaInfo.muda_id}|" +
                      $"{mudaInfo.nome_interno}|" +
                      $"{mudaInfo.nome}|" +
                      $"{mudaInfo.especie_nome_comum}|" +
                      $"{mudaInfo.especie_nome_especie}|" +
                      $"{mudaInfo.especie_nome_cientifico}|" +
                      $"{mudaInfo.origem}|" +
                      $"{mudaInfo.viveiro}|" +
                      $"{mudaInfo.canaletao}|" +
                      $"{mudaInfo.linha}|" +
                      $"{mudaInfo.coluna}|" +
                      $"{mudaInfo.qtde}|";
            }
            else
            {
                ret = "0|Registro não encontrado!|";
            }

            return ret;
        }

        public List<MudasEstoqueViveiro> ObterMudasEstoqueViveiro(int loteId)
        {
            string query = "SELECT " +
                                "AA.muda_id, " +
                                "M.nome_interno " +
                           "FROM " +
                                "Inv_Item AA " +
                           "INNER JOIN Muda M " +
                           "ON M.muda_id = AA.muda_id ";

            string where = string.Empty;
            string cap = string.Empty;

            if (loteId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.lote_id = {loteId}";
            }

            if (!string.IsNullOrEmpty(where))
                where = $"WHERE {where}";

            query += $"{where} GROUP BY AA.muda_id ORDER BY M.nome_interno";

            var listaMudas = dataBase._conexao.Query<MudasEstoqueViveiro>(query);

            return listaMudas;
        }
    }
}
