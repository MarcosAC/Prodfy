using Prodfy.Models;
using Prodfy.Services.API;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
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

            SincronizarCommand = new Command(ExecuteSincronizarCommand, CanExecuteSincronizarCommand);
        }

        #region Propriedades

        public string DhtLastSincr { get => "Não Sincronizado!"; }
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

        private bool _logado;
        public bool Logado
        {
            get { return _logado; }
            set { SetProperty(ref _logado, value); SincronizarCommand.ChangeCanExecute(); }
        }                

        public Command SincronizarCommand { get; }

        private bool VerificarUsuarioLogado()
        {
            var dadosUser = userRepository.ObterDados();

            if (dadosUser?.senha != null)
                if (dadosUser?.senha == dadosUser?.senha)
                    return true;

            return false;
        }

        private bool CanExecuteSincronizarCommand()
        {
            return VerificarUsuarioLogado() == true;
        }

        private async void ExecuteSincronizarCommand()
        {
            UploadDados();

            //if (VerificaConexaoInternet.VerificaConexao())
            //{
            //    UploadDados();
            //    var _dadosSincronismo = await dadosSincronismo.ObterDadosSincronismo(userRepository.ObterDados().app_key, userRepository.ObterDados().lang);

            //    user = new User
            //    {
            //        ind_ident = _dadosSincronismo.ind_ident,
            //        ind_inv = _dadosSincronismo.ind_inv,
            //        ind_per = _dadosSincronismo.ind_per,
            //        ind_hist = _dadosSincronismo.ind_hist,
            //        ind_evo = _dadosSincronismo.ind_evo,
            //        ind_mnt = _dadosSincronismo.ind_mnt,
            //        ind_exp = _dadosSincronismo.ind_exp,
            //        ind_atv = _dadosSincronismo.ind_atv,
            //        uso_liberado = _dadosSincronismo.uso_liberado
            //    };
            //    userRepository.Editar(user);
            //}
            //else
            //{
            //    await _dialogService.AlertAsync("Erro", "Sem conexão com a internet!", "Ok");
            //}
            //await _dialogService.AlertAsync("Erro", "Sem conexão com a internet!", "Ok");
        }

        private Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(async () => await RefreshCommandExecute()));

        private async Task RefreshCommandExecute()
        {
            await Task.FromResult<object>(null);

            RefreshCommand.ChangeCanExecute();            

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
                        dht_last_sincr = dadosUser.dht_last_sincr
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
                    OnPropertyChanged(nameof(DhtLastSincr));
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void UploadDados()
        {
            bool executarSincronismo = false;

            string[] contagem = { };
            string[] perda = { };
            string[] hist = { };
            string[] evo = { };
            string[] oco = { };
            string[] med = { };
            string[] exp = { };
            string[] atv = { };

                        

            if (atividadeRepository.ObterTotalDeRegistros() >= 0)
            {
                executarSincronismo = true;

               // var dados = atividadeRepository.ObterTodos();

                List<Atividade> dadosAtividade = new List<Atividade>();

                dadosAtividade.Add(new Atividade() { disp_Id = "01", colaborador_id = "01", lista_atv_id = "01", data_inicio = "01/01/2019", data_fim = "30/01/2019", obs = "Deu certo:D!!!" });
                dadosAtividade.Add(new Atividade() { disp_Id = "02", colaborador_id = "02", lista_atv_id = "02", data_inicio = "01/02/2019", data_fim = "30/03/2019", obs = "Deu certo:D!!!" });
                dadosAtividade.Add(new Atividade() { disp_Id = "03", colaborador_id = "03", lista_atv_id = "03", data_inicio = "01/03/2019", data_fim = "30/04/2019", obs = "Deu certo:D!!!" });
                dadosAtividade.Add(new Atividade() { disp_Id = "04", colaborador_id = "04", lista_atv_id = "04", data_inicio = "01/04/2019", data_fim = "30/05/2019", obs = "Deu certo:D!!!" });
                dadosAtividade.Add(new Atividade() { disp_Id = "05", colaborador_id = "05", lista_atv_id = "05", data_inicio = "01/06/2019", data_fim = "30/07/2019", obs = "Deu certo:D!!!" });

                List<Atividade> dadosAtividade2 = new List<Atividade>();

                dadosAtividade2.Add(new Atividade() { disp_Id="01", colaborador_id="01", lista_atv_id="01", data_inicio="01/01/2019", data_fim="30/01/2019", obs="Deu certo:D!!!" });
                dadosAtividade2.Add(new Atividade() { disp_Id = "02", colaborador_id = "02", lista_atv_id = "02", data_inicio = "01/02/2019", data_fim = "30/03/2019", obs = "Deu certo:D!!!" });
                dadosAtividade2.Add(new Atividade() { disp_Id = "03", colaborador_id = "03", lista_atv_id = "03", data_inicio = "01/03/2019", data_fim = "30/04/2019", obs = "Deu certo:D!!!" });
                dadosAtividade2.Add(new Atividade() { disp_Id = "04", colaborador_id = "04", lista_atv_id = "04", data_inicio = "01/04/2019", data_fim = "30/05/2019", obs = "Deu certo:D!!!" });
                dadosAtividade2.Add(new Atividade() { disp_Id = "05", colaborador_id = "05", lista_atv_id = "05", data_inicio = "01/06/2019", data_fim = "30/07/2019", obs = "Deu certo:D!!!" });

                //List<List<string>> dadosSincronismo = new List<List<string>>();                

                ArrayList dados = new ArrayList
                {
                    dadosAtividade,
                    dadosAtividade2
                };

                ArrayList dadosSincronismo = new ArrayList();

                foreach (var item in dados)
                {
                    //string[] atv = { item.disp_Id, item.disp_Id, item.lista_atv_id, item.data_inicio, item.data_fim, item.obs };                    

                    //atv[0] = item.disp_Id;
                    //atv[1] = item.colaborador_id;
                    //atv[2] = item.lista_atv_id;
                    //atv[3] = item.data_inicio;
                    //atv[4] = item.data_fim;
                    //atv[5] = item.obs;
                    dadosSincronismo.Add(dados);
                }

                

                //string[][] dadosSincronismo = new string[][] {contagem, perda, hist, evo, oco, med, exp, atv};

                //string[] arrayTemporario = { };

                //Array.Copy(dadosSincronismo, arrayTemporario, 8);
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





