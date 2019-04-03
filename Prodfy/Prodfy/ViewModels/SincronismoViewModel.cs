using Prodfy.Models;
using Prodfy.Services.API;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class SincronismoViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        readonly DadosSincronismoService dadosSincronismo = new DadosSincronismoService();

        private Sincronismo sincronismo = null;
        private User user = null;
        public string estaSincronizado = "Não Sincronizado!";

        #region Implementação Repositorios

        private UserRepository userRepository;
        private AtividadeRepository atividadeRepository;
        private InventarioRepository inventarioRepository;
        private PerdaRepository perdaRepository;
        private HistoricoRepository historicoRepository;
        private EvolucaoRepository evolucaoRepository;
        private OcorrenciaRepository ocorrenciaRepository;
        private MedicaoRepository medicaoRepository;
        private ExpedicaoRepository expedicaoRepository;

        #endregion

        public SincronismoViewModel()
        {
            _dialogService = new DialogService();

            userRepository = new UserRepository();
            atividadeRepository = new AtividadeRepository();
            inventarioRepository = new InventarioRepository();
            perdaRepository = new PerdaRepository();
            historicoRepository = new HistoricoRepository();
            evolucaoRepository = new EvolucaoRepository();
            ocorrenciaRepository = new OcorrenciaRepository();
            medicaoRepository = new MedicaoRepository();
            expedicaoRepository = new ExpedicaoRepository();
        }

        #region Propriedades sincronismo

        //private string _dhtLastSincr;
        //public string DhtLastSincr { get => _dhtLastSincr = estaSincronizado; }
        //{
        //    get => "Não Sincronizado!";
        //    set
        //    {
        //        if (DhtLastSincr == null)
        //        {
        //            //SetProperty(ref _dhtLastSincr, value);
        //            OnPropertyChanged(nameof(DhtLastSincr));
        //        }                
        //    }


        //}
        private string _dhtLastSincr;
        public string DhtLastSincr { get => _dhtLastSincr = estaSincronizado; }

        public int? IndAtv { get => sincronismo?.ind_atv; }
        public int? IndInv { get => sincronismo?.ind_inv; }
        public int? IndPer { get => sincronismo?.ind_per; }
        public int? IndHist { get => sincronismo?.ind_hist; }
        public int? IndEvo { get => sincronismo?.ind_evo; }
        public int? IndOco { get => sincronismo?.ind_oco; }
        public int? IndMnt { get => sincronismo?.ind_mnt; }
        public int? IndExp { get => sincronismo?.ind_mnt; }
        public int? IndIdent { get => sincronismo?.ind_mnt; }        

        #endregion 

        private bool CanExecuteSincronizarCommand()
        {
            return LoginViewModel.estaLogado;
        }

        private Command _sincronozarCommand;
        public Command SincronizarCommand =>
            _sincronozarCommand ?? (_sincronozarCommand = new Command(ExecuteSincronizarCommand, CanExecuteSincronizarCommand));

        private async void ExecuteSincronizarCommand()
        {
            IsBusy = true;
            try
            {
                if (VerificaConexaoInternet.VerificaConexao())
                {
                    if (UploadDados().Count > 0)
                    {
                        var dadosResponse = await dadosSincronismo.UploadDadosParaSincronisar(userRepository.ObterDados().app_key, userRepository.ObterDados().lang, UploadDados());

                        if (dadosResponse.ind_atv != null) // Atividade
                        {
                            if (dadosResponse.ind_atv == 1)
                                atividadeRepository.Deletar();
                        }

                        if (dadosResponse.ind_evo != null) // Evolução
                        {
                            if (dadosResponse.ind_evo == 1)
                                evolucaoRepository.Deletar();
                        }

                        if (dadosResponse.ind_exp != null) // Expedição
                        {
                            if (dadosResponse.ind_exp == 1)
                                expedicaoRepository.Deletar();
                        }

                        if (dadosResponse.ind_hist != null) // Historico
                        {
                            if (dadosResponse.ind_hist == 1)
                                historicoRepository.Deletar();
                        }

                        if (dadosResponse.ind_inv != null) // Inventario
                        {
                            if (dadosResponse.ind_inv == 1)
                                inventarioRepository.Deletar();
                        }

                        if (dadosResponse.ind_mnt != null) // Mediçã0
                        {
                            if (dadosResponse.ind_mnt == 1)
                                medicaoRepository.Deletar();
                        }

                        if (dadosResponse.ind_oco != null) // Ocorrencia
                        {
                            if (dadosResponse.ind_oco == 1)
                                ocorrenciaRepository.Deletar();
                        }

                        if (dadosResponse.ind_per != null) // Perda
                        {
                            if (dadosResponse.ind_per == 1)
                                perdaRepository.Deletar();
                        }
                    }
                    else
                    {
                        var _dadosSincronismo = await dadosSincronismo.ObterDadosSincronismo(userRepository.ObterDados().app_key, userRepository.ObterDados().lang);

                        user = new User
                        {
                            ind_ident = _dadosSincronismo.ind_ident,
                            ind_inv = _dadosSincronismo.ind_inv,
                            ind_per = _dadosSincronismo.ind_per,
                            ind_hist = _dadosSincronismo.ind_hist,
                            ind_evo = _dadosSincronismo.ind_evo,
                            ind_mnt = _dadosSincronismo.ind_mnt,
                            ind_exp = _dadosSincronismo.ind_exp,
                            ind_atv = _dadosSincronismo.ind_atv,
                            dth_last_sincr = _dadosSincronismo.sinc_date,
                            uso_liberado = _dadosSincronismo.uso_liberado
                        };
                        userRepository.Editar(user);
                    }
                }                
            }
            catch (Exception)
            {
                await _dialogService.AlertAsync("Erro", "Sem conexão com a internet!", "Ok");
            }

            IsBusy = false;
        }

        private ArrayList UploadDados()
        {
            #region Listas do Indicadores

            List<Contagem> dadosContagem = new List<Contagem>();
            List<Perda> dadosPerda = new List<Perda>();
            List<Historico> dadosHistorico = new List<Historico>();
            List<Evolucao> dadosEvolucao = new List<Evolucao>();
            List<Monit_Ocorr> dadosOcorrencias = new List<Monit_Ocorr>();
            List<Monit_Med> dadosMedicao = new List<Monit_Med>();
            List<Expedicao> dadosExpedicao = new List<Expedicao>();
            List<Atividade> dadosAtividade = new List<Atividade>();

            #endregion

            ArrayList dadosSincronismo = new ArrayList();

            #region Dados para teste
            //dadosContagem.Add(new Contagem() { idContagem= 01,  disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", proc = "Deu certo", ponto_controle_id = "01", estagio_id = "01", data_selecao = "01/03/2019", data_inicio = "01/03/2019", data_fim = "03/03/2019", data_estaq = "03/03/2019", colab_estaq_id = "01", colab_sel_id = "6000", qualidade_id = "01", latitude = "010203", longitude = "010203", last_update = "03/03/2019", ind_sinc  = 1});
            //dadosContagem.Add(new Contagem() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", proc = "Deu certo" });
            //dadosContagem.Add(new Contagem() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", proc = "Deu certo" });

            //dadosPerda.Add(new Perda() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", motivo_id = "Tabela Perdas" });
            //dadosPerda.Add(new Perda() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", motivo_id = "Tabela Perdas" });
            //dadosPerda.Add(new Perda() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", motivo_id = "Tabela Perdas" });

            //dadosAtividade.Add(new Atividade() { disp_Id = "01", colaborador_id = "01", lista_atv_id = "01", data_inicio = "01/01/2019", data_fim = "30/01/2019", obs = "Deu certo:D!!!" });
            //dadosAtividade.Add(new Atividade() { disp_Id = "02", colaborador_id = "02", lista_atv_id = "02", data_inicio = "01/02/2019", data_fim = "30/03/2019", obs = "Deu certo:D!!!" });
            //dadosAtividade.Add(new Atividade() { disp_Id = "03", colaborador_id = "03", lista_atv_id = "03", data_inicio = "01/03/2019", data_fim = "30/04/2019", obs = "Deu certo:D!!!" });
            //dadosAtividade.Add(new Atividade() { disp_Id = "04", colaborador_id = "04", lista_atv_id = "04", data_inicio = "01/04/2019", data_fim = "30/05/2019", obs = "Deu certo:D!!!" });
            //dadosAtividade.Add(new Atividade() { disp_Id = "05", colaborador_id = "05", lista_atv_id = "05", data_inicio = "01/06/2019", data_fim = "30/07/2019", obs = "Deu certo:D!!!" });

            //if (dadosContagem.Count() > 0)
            //{
            //    dadosSincronismo.Add(dadosContagem);
            //}

            //if (dadosPerda.Count() > 0)
            //{
            //    dadosSincronismo.Add(dadosPerda);
            //}

            //if (dadosAtividade.Count() > 0)
            //{
            //    dadosSincronismo.Add(dadosAtividade);
            //}
            #endregion

            #region Verifica se existe dados nas tabelas de indicadores

            // dadosContagem = Inventários
            if (inventarioRepository.ObterTodos().Count() > 0)
            {
                dadosContagem = inventarioRepository.ObterTodos();

                dadosSincronismo.Add(dadosContagem);
            }

            if (perdaRepository.ObterTodos().Count() > 0)
            {
                dadosPerda = perdaRepository.ObterTodos();

                dadosSincronismo.Add(dadosPerda);
            }

            if (historicoRepository.ObterTodos().Count() > 0)
            {
                dadosHistorico = historicoRepository.ObterTodos();

                dadosSincronismo.Add(dadosHistorico);
            }

            if (evolucaoRepository.ObterTodos().Count() > 0)
            {
                dadosEvolucao = evolucaoRepository.ObterTodos();

                dadosSincronismo.Add(dadosEvolucao);
            }

            if (ocorrenciaRepository.ObterTodos().Count() > 0)
            {
                dadosOcorrencias = ocorrenciaRepository.ObterTodos();

                dadosSincronismo.Add(dadosOcorrencias);
            }

            if (medicaoRepository.ObterTodos().Count() > 0)
            {
                dadosMedicao = medicaoRepository.ObterTodos();

                dadosSincronismo.Add(dadosMedicao);
            }

            if (expedicaoRepository.ObterTodos().Count() > 0)
            {
                dadosExpedicao = expedicaoRepository.ObterTodos();

                dadosSincronismo.Add(dadosExpedicao);
            }

            if (atividadeRepository.ObterTodos().Count() > 0)
            {
                dadosAtividade = atividadeRepository.ObterTodos();

                dadosSincronismo.Add(dadosAtividade);
            }

            #endregion

            return dadosSincronismo;
        }

        private Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(async () => await RefreshCommandExecute()));

        private async Task RefreshCommandExecute()
        {
            await Task.FromResult<object>(null);

            SincronizarCommand.ChangeCanExecute();

            try
            {
                var dadosUser = userRepository.ObterDados();

                if (dadosSincronismo != null)
                {
                    sincronismo = new Sincronismo
                    {
                        ind_atv = atividadeRepository.ObterTotalDeRegistros(),
                        ind_inv = inventarioRepository.ObterTotalDeRegistros(),
                        ind_per = perdaRepository.ObterTotalDeRegistros(),
                        ind_hist = historicoRepository.ObterTotalDeRegistros(),
                        ind_evo = evolucaoRepository.ObterTotalDeRegistros(),
                        ind_oco = ocorrenciaRepository.ObterTotalDeRegistros(),
                        ind_mnt = medicaoRepository.ObterTotalDeRegistros(),
                        ind_exp = expedicaoRepository.ObterTotalDeRegistros(),
                        sinc_date = dadosUser.dth_last_sincr
                    };

                    OnPropertyChanged(nameof(IndAtv));
                    OnPropertyChanged(nameof(IndInv));
                    OnPropertyChanged(nameof(IndPer));
                    OnPropertyChanged(nameof(IndHist));
                    OnPropertyChanged(nameof(IndEvo));
                    OnPropertyChanged(nameof(IndOco));
                    OnPropertyChanged(nameof(IndMnt));
                    OnPropertyChanged(nameof(IndExp));
                    OnPropertyChanged(nameof(IndIdent));

                    if (dadosUser.dth_last_sincr != null)
                    {
                        estaSincronizado = dadosUser.dth_last_sincr;
                        OnPropertyChanged(nameof(DhtLastSincr));
                    }                    
                }
                else
                {
                    return;
                }                
            }
            catch (Exception)
            {
                return;
            }
        }
        
        //private User DataUltimaSincrinismo()
        //{
        //    try
        //    {
        //        var dataSincronismo = userRepository.ObterDados();

        //        if (dataSincronismo.dht_last_sincr != null)
        //        {
        //            var sincronismo = new User
        //            {                        
        //                dht_last_sincr = dataSincronismo.dht_last_sincr
        //            };
        //        }

        //        return user;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //private Sincronismo CarregarDadosSincronismo()
        //{
        //    try
        //    {
        //        var dadosUser = userRepository.ObterDados();

        //        if (dadosSincronismo != null)
        //        {
        //            var sincronismo = new Sincronismo
        //            {
        //                ind_atv = atividadeRepository.ObterTotalDeRegistros(),
        //                ind_inv = inventarioRepository.ObterTotalDeRegistros(),
        //                ind_per = perdaRepository.ObterTotalDeRegistros(),
        //                ind_hist = historicoRepository.ObterTotalDeRegistros(),
        //                ind_evo = evolucaoRepository.ObterTotalDeRegistros(),
        //                ind_oco = ocorrenciaRepository.ObterTotalDeRegistros(),
        //                ind_mnt = medicaoRepository.ObterTotalDeRegistros(),
        //                ind_exp = expedicaoRepository.ObterTotalDeRegistros(),
        //                dht_last_sincr = dadosUser.dht_last_sincr
        //            };
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        return;
        //    }
        //}
    }
}





