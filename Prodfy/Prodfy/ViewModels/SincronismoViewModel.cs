using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class SincronismoViewModel : BaseViewModel
    {
        //Atividade
        private string _indAtv;
        public string IndAtv
        {
            get => _indAtv;
            set => SetProperty(ref _indAtv, value);
        }

        //Inventário
        private string _indInv;
        public string IndInv
        {
            get => _indInv;
            set => SetProperty(ref _indInv, value);
        }

        //Perdas
        private string _indPer;
        public string IndPer
        {
            get => _indPer;
            set => SetProperty(ref _indPer, value);
        }

        //Histórico
        private string _indHist;
        public string IndHist
        {
            get => _indHist;
            set => SetProperty(ref _indHist, value);
        }

        //Evolução
        private string _indEvo;
        public string IndEvo
        {
            get => _indEvo;
            set => SetProperty(ref _indEvo, value);
        }

        //Falta propriedade referente ao campo Medições.

        //Medição
        private string _indMnt;
        public string IndMnt
        {
            get => _indMnt;
            set => SetProperty(ref _indMnt, value);
        }

        //Expedições
        private string _indExp;
        public string IndExp
        {
            get => _indExp;
            set => SetProperty(ref _indExp, value);
        }

        //Identificação
        private string _indIdent;
        public string IndIdent
        {
            get => _indIdent;
            set => SetProperty(ref _indIdent, value);
        }

        private string _idUser;
        public string IdUser
        {
            get => _idUser;
            set => SetProperty(ref _idUser, value);
        }

        //DispositivoID
        private string _dispId;
        public string DispId
        {
            get => _dispId;
            set => SetProperty(ref _dispId, value);
        }

        //DispositivoNumero
        private string _dispNum;
        public string DispNum
        {
            get => _dispNum;
            set => SetProperty(ref _dispNum, value);
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _sobrenome;
        public string Sobrenome
        {
            get => _sobrenome;
            set => SetProperty(ref _sobrenome, value);
        }

        private string _empresa;
        public string Empresa
        {
            get => _empresa;
            set => SetProperty(ref _empresa, value);
        }

        private string _autoSinc;
        public string AutoSinc
        {
            get => _autoSinc;
            set => SetProperty(ref _autoSinc, value);
        }

        private string _autoSincTime;
        public string AutoSincTime
        {
            get => _autoSincTime;
            set => SetProperty(ref _autoSincTime, value);
        }

        private string _sincUrl;
        public string SincUrl
        {
            get => _sincUrl;
            set => SetProperty(ref _sincUrl, value);
        }

        private string _appKey;
        public string AppKey
        {
            get => _appKey;
            set => SetProperty(ref _appKey, value);
        }        

        private string _usoLiberado;
        public string UsoLiberado
        {
            get => _usoLiberado;
            set => SetProperty(ref _usoLiberado, value);
        }

        private string _dhtLastSincr;
        public string DhtlastSincr
        {
            get => _dhtLastSincr;
            set => SetProperty(ref _dhtLastSincr, value);
        }

        private Command _sincronizarCommand;
        public Command SincronizarCommand =>
            _sincronizarCommand ?? (_sincronizarCommand = new Command(async () => await ExecuteSincronizarCommand()));

        private Task ExecuteSincronizarCommand()
        {
            throw new NotImplementedException();
        }
    }
}
