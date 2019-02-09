using Prodfy.Models;
using Prodfy.Services.API;
using Prodfy.Services.Repository;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class SincronismoViewModel : BaseViewModel
    {
        readonly DadosSincronismoService dadosSincronismo = new DadosSincronismoService();
        private readonly Sincronismo _sincronismo = null;
        private UserRepository _userRepository;
        private User user = null;

        public SincronismoViewModel()
        {
            _userRepository = new UserRepository();

            _sincronismo = CarregarDadosSincronismo();
        }
        
        public int? IndAtv
        {
            get { return _sincronismo?.ind_atv; }
            set { _sincronismo.ind_atv = value; OnPropertyChanged(); }
        }

        
        public int? IndInv
        {
            get { return _sincronismo?.ind_inv; }
            set { _sincronismo.ind_inv = value; OnPropertyChanged(); }
        }

        public int? IndPer
        {
            get { return _sincronismo?.ind_per; }
            set { _sincronismo.ind_per = value; OnPropertyChanged(); }
        }

       
        public int? IndHist
        {            
            get { return _sincronismo?.ind_hist; }
            set { _sincronismo.ind_hist = value; OnPropertyChanged(); }
        }

       
        public int? IndEvo
        {
            get { return _sincronismo?.ind_evo; }
            set { _sincronismo.ind_evo = value; OnPropertyChanged(); }
        }

        //Falta propriedade referente ao campo Medições.
       
        public int? IndMnt
        {
            get { return _sincronismo?.ind_mnt; }
            set { _sincronismo.ind_mnt = value; OnPropertyChanged(); }
        }
        
        public int? IndExp
        {
            get { return _sincronismo?.ind_mnt; }
            set { _sincronismo.ind_mnt = value; OnPropertyChanged(); }
        }
        
        public int? IndIdent
        {
            get { return _sincronismo?.ind_mnt; }
            set { _sincronismo.ind_mnt = value; OnPropertyChanged(); }
        }       

        private Command _sincronizarCommand;
        public Command SincronizarCommand =>
            _sincronizarCommand ?? (_sincronizarCommand = new Command(async () => await ExecuteSincronizarCommand()));

        private async Task ExecuteSincronizarCommand()
        {            
            var _dadosSincronismo = await dadosSincronismo.ObterDadosSincronismo(_userRepository.ObterDados().app_key, _userRepository.ObterDados().lang);            

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
            _userRepository.Editar(user);            
        }

        private Sincronismo CarregarDadosSincronismo()
        {
            var dadosSincronismo = _userRepository.ObterDados();

            if (dadosSincronismo != null)
            {
                var sincronismo = new Sincronismo
                {
                    ind_ident = dadosSincronismo.ind_ident,
                    ind_inv = dadosSincronismo.ind_inv,
                    ind_per = dadosSincronismo.ind_per,
                    ind_hist = dadosSincronismo.ind_hist,
                    ind_evo = dadosSincronismo.ind_evo,
                    ind_mnt = dadosSincronismo.ind_mnt,
                    ind_exp = dadosSincronismo.ind_exp,
                    ind_atv = dadosSincronismo.ind_atv,
                    uso_liberado = dadosSincronismo.uso_liberado
                };
                return sincronismo;
            }
            return null;
        }
    }
}