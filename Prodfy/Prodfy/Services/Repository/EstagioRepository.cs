using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services.Dialog;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodfy.Services.Repository
{
    public class EstagioRepository : IRepository<Estagio>
    {
        private DataBase dataBase;

        private readonly IDialogService dialogService;

        public EstagioRepository()
        {
            dataBase = new DataBase();

            dialogService = new DialogService();
        }

        public void Adicionar(Estagio estagio)
        {
            try
            {
                dataBase._conexao.Insert(estagio);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async Task<List<Estagio>> ListaLocalEstagio(int pontoControleId, int loteId, int mudaId, DateTime dataEstaq)
        {
            string query = "SELECT distinct " +
                                "PCE.produto_id, " +
                                "PCE.ponto_controle_id, " +
                                "PCE.estagio_id, PCE.codigo, " +
                                "PCE.titulo, " +
                                "PCE.unidade, " +
                                "PCE.maturacao, " +
                                "PCE.maturacao_seg, " +
                                "PCE.ind_alertas, " +
                                "PCE.ordem " +
                           "FROM Estagio PCE " +
                           "INNER JOIN Inv_Item I1 ON I1.ponto_controle_id = PCE.ponto_controle_id AND I1.estagio_id = PCE.estagio_id " +
                           "WHERE I1.lote_id = " + "'" + loteId + "'" + " " +
                           "AND I1.ponto_controle_id = " + "'" + pontoControleId + "'" + " " +
                           "AND I1.muda_id = " + "'" + mudaId + "'" + " " +
                           "AND date(I1.data_estaq) = " + "'" + dataEstaq + "'" + " " +
                           "AND (IFNULL((SELECT sum(I2.qtde) " +
                                         "FROM Inv_Item I1 " +
                                         "INNER JOIN Inv I2 ON I2.inv_item_id = I1.inv_item_id " +
                                         "WHERE I1.ponto_controle_id = PCE.ponto_controle_id " +
                                         "AND I1.estagio_id = PCE.estagio_id),0) - " +
                           "IFNULL((SELECT sum(IE.qtde_amostragem) " +
                                    "FROM Inv_Evo IE " +
                                    "INNER JOIN Inv_Item I1 ON I1.inv_item_id = IE.inv_item_id " +
                                    "WHERE IE.ponto_controle_ori_id = PCE.ponto_controle_id " +
                                    "AND IE.estagio_ori_id = PCE.estagio_id),0) ) > 0 " +
                           "ORDER BY PCE.ordem";

            List<Estagio> listaLocalEstagio = new List<Estagio>();

            try
            {
                var dados = dataBase._conexao.Query<Estagio>(query);

                for (int i = 0; i < dados.Count; i++)
                {
                    listaLocalEstagio.Add(dados[i]);
                }
            }
            catch (Exception erro)
            {
                await dialogService.AlertAsync("Erro", erro.ToString(), "Ok");
            }

            return listaLocalEstagio;
        }

        public async Task<string> LocalQuantidadeMudasNoEstagio(int estagioId, int loteId, int mudaId, DateTime dataEstaq)
        {
            string query = "SELECT " +
                                "IFNULL(I2.qtde,0) " +
                           "FROM Inv_Item AA " +
                           "INNER JOIN " +
                                "Inv I2 ON I2.inv_item_id = AA.inv_item_id " +
                           "WHERE AA.estagio_id = " + "'" + estagioId + "'" + " " +
                           "AND AA.lote_id = " + "'" + loteId + "'" + " " +
                           "AND AA.muda_id = " + "'" + mudaId + "'" + " " +
                           "AND date(AA.data_estaq) =" + "'" + mudaId + "'" + " " +
                           "LIMIT 1";

            string quantidade = string.Empty;

            try
            {
                List<Inv> dados = dataBase._conexao.Query<Inv>(query);

                for (int i = 0; i < dados.Count; i++)
                    quantidade = dados[0].ToString();
            }
            catch (Exception erro)
            {
                await dialogService.AlertAsync("Erro", erro.ToString(), "Ok");
            }

            return quantidade;
        }

        public List<EstoqueViveiroEstagio> ObterEstoqueViveiroEstagio(int loteId,
                                                                      int mudaId,
                                                                      int qualidadeId,
                                                                      int pontoControleId,
                                                                      string dataEstaqueamento = null,
                                                                      string dataSelecao = null)
        {
            string query = "SELECT distinct " +
                             "PC.produto_id, " +
                             "PC.ponto_controle_id, " +
                             "PCE.estagio_id, " +
                             "PCE.codigo, " +
                             "PCE.titulo, " +
                             "PCE.unidade, " +
                             "PCE.maturacao, " +
                             "PCE.maturacao_seg, " +
                             "PCE.ind_alertas, " +
                             "PCE.ordem, " +
                             "AA.data_estaq, " +
                             "AA.data_selecao " +
                           "FROM Inv_Item AA " +
                           "INNER JOIN Ponto_Controle PC " +
                           "ON PC.ponto_controle_id = AA.ponto_controle_id " +
                           "INNER JOIN Estagio PCE " +
                           "ON PCE.ponto_controle_id = AA.ponto_controle_id " +
                           "AND PCE.estagio_id = AA.estagio_id ";

            string where = string.Empty;
            string cap = string.Empty;

            if (pontoControleId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.ponto_controle_id = {pontoControleId} ";
            }

            if (loteId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.lote_id = {loteId} ";
            }

            if (mudaId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.muda_id = {mudaId} ";
            }

            if (qualidadeId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.qualidade_id = {qualidadeId} ";
            }

            if (!string.IsNullOrEmpty(where))
                where = $"WHERE {where}";

            query += $"{where} GROUP BY AA.ponto_controle_id, AA.estagio_id ORDER BY PC.ordem, PCE.ordem";

            var dadosEstoqueViveiroEstagio = dataBase._conexao.Query<EstoqueViveiroEstagio>(query);

            if (!string.IsNullOrEmpty(dataEstaqueamento) && !string.IsNullOrEmpty(dataSelecao))
            {
                var listaEstoqueViveiroEstagio = new List<EstoqueViveiroEstagio>();

                foreach (EstoqueViveiroEstagio item in dadosEstoqueViveiroEstagio)
                {
                    if (item.data_estaq.Equals(Convert.ToDateTime(dataEstaqueamento)) && item.data_selecao.Equals(Convert.ToDateTime(dataSelecao)))
                    {
                        listaEstoqueViveiroEstagio.Add(item);
                    }
                }

                return listaEstoqueViveiroEstagio;
            }
            else if (!string.IsNullOrEmpty(dataEstaqueamento))
            {
                var listaEstoqueViveiroEstagio = new List<EstoqueViveiroEstagio>();

                foreach (EstoqueViveiroEstagio item in listaEstoqueViveiroEstagio)
                {
                    if (item.data_estaq.Equals(Convert.ToDateTime(dataEstaqueamento)))
                    {
                        listaEstoqueViveiroEstagio.Add(item);
                    }
                }

                return listaEstoqueViveiroEstagio;
            }
            else if (!string.IsNullOrEmpty(dataSelecao))
            {
                var listaEstoqueViveiroEstagio = new List<EstoqueViveiroEstagio>();

                foreach (EstoqueViveiroEstagio item in listaEstoqueViveiroEstagio)
                {
                    if (item.data_selecao.Equals(Convert.ToDateTime(dataSelecao)))
                    {
                        listaEstoqueViveiroEstagio.Add(item);
                    }
                }

                return listaEstoqueViveiroEstagio;
            }

            return dadosEstoqueViveiroEstagio;
        }

        public string ObterInformacoesParaIdentificacao(int pontoControleId, int estagioId)
        {
            var dadosEstagioInfo = dataBase._conexao.Query<Estagio>("SELECT " +
                                                "AA.estagio_id, " +
                                                "AA.produto_id, " +
                                                "AA.ponto_controle_id, " +
                                                "AA.codigo, " +
                                                "AA.titulo, " +
                                                "AA.unidade, " +
                                                "AA.maturacao, " +
                                                "AA.maturacao_seg, " +
                                                "AA.ind_alertas, " +
                                                "AA.ordem " +
                                             "FROM " +
                                                "Estagio AA " +
                                             "WHERE " +
                                                $"AA.ponto_controle_id = '{pontoControleId}' " +
                                             "AND " +
                                                $"AA.estagio_id = '{estagioId}' LIMIT 1");

            var estagioInfo = new
            {
                dadosEstagioInfo[0].estagio_id,
                dadosEstagioInfo[0].produto_id,
                dadosEstagioInfo[0].ponto_controle_id,
                dadosEstagioInfo[0].codigo,
                dadosEstagioInfo[0].titulo,
                dadosEstagioInfo[0].unidade,
                dadosEstagioInfo[0].maturacao,
                dadosEstagioInfo[0].maturacao_seg,
                dadosEstagioInfo[0].ind_alertas,
                dadosEstagioInfo[0].ordem
            };

            string ret = string.Empty;

            if (estagioInfo.estagio_id != 0)
            {
                ret = $"1||{estagioInfo.estagio_id}|" +
                      $"{estagioInfo.produto_id}|" +
                      $"{estagioInfo.ponto_controle_id}|" +
                      $"{estagioInfo.codigo}|" +
                      $"{estagioInfo.titulo}|" +
                      $"{estagioInfo.unidade}|" +
                      $"{estagioInfo.maturacao}|" +
                      $"{estagioInfo.maturacao_seg}|" +
                      $"{estagioInfo.ind_alertas}|" +
                      $"{estagioInfo.ordem}|";
            }
            else
            {
                ret = "0|Registro não encontrado!|";
            }

            return ret;
        }

        public List<Estagio> ObterTodos(int pontoControleId)
        {
            if (pontoControleId != 0)
                return dataBase._conexao.Table<Estagio>().Where(e => e.ponto_controle_id == pontoControleId).OrderBy(e => e.ordem).ToList();

            return null;
        }

        public List<Estagio> ObterTodos()
        {
            return dataBase._conexao.Table<Estagio>().ToList();
        }

        public TableQuery<Estagio> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Estagio>();
        }

        public void Editar(Estagio entidade)
        {
            throw new NotImplementedException();
        }

        public Estagio ObterDados()
        {
            throw new NotImplementedException();
        }

        public Estagio ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterMudaInfo(int codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterLoteInfo(string codigo)
        {
            throw new NotImplementedException();
        }        

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
