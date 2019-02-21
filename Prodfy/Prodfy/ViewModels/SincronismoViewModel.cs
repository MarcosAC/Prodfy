using Prodfy.Models;
using Prodfy.Services.API;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Utils;
using System;
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

        private UserRepository userRepository;
        private AtividadeRepository atividadeRepository;
        private InventarioRepository inventarioRepository;
        private PerdaRepository perdaRepository;
        private HistoricoRepository historicoRepository;
        private EvolucaoRepository evolucaoRepository;
        private OcorrenciaRepository ocorrenciaRepository;
        private MedicaoRepository medicaoRepository;
        private ExpedicaoRepository expedicaoRepository;

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

        private bool _logado;
        public bool Logado
        {
            get { return _logado; }
            set { SetProperty(ref _logado, value); SincronizarCommand.ChangeCanExecute(); }
        }

        private bool VerificarUsuarioLogado()
        {
            if (user?.senha != null)
                if (user?.senha == user?.senha)
                    return true;

            return false;
        }

        public Command SincronizarCommand { get; }

        private bool CanExecuteSincronizarCommand()
        {
            return VerificarUsuarioLogado() == true;
        }

        private async void ExecuteSincronizarCommand()
        {
            if (VerificaConexaoInternet.VerificaConexao())
            {
                // UploadDados();
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
                    uso_liberado = _dadosSincronismo.uso_liberado
                };
                userRepository.Editar(user);
            }
            else
            {
                await _dialogService.AlertAsync("Erro", "Sem conexão com a internet!", "Ok");
            }
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

            string[][] dadosSincronismo = new string[][] { contagem, perda, hist, evo, oco, med, exp, atv };

            if (atividadeRepository.ObterTotalDeRegistros() > 0)
            {
                executarSincronismo = true;
                var dados = atividadeRepository.ObterTodos();

                Atividade dadosAtividade;

                foreach (var item in dados)
                {
                    dadosAtividade = new Atividade
                    {
                        disp_Id = item.disp_Id,
                        colaborador_id = item.colaborador_id,
                        lista_atv_id = item.lista_atv_id,
                        data_inicio = item.data_inicio,
                        data_fim = item.data_fim,
                        obs = item.obs
                    };
                }
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





