using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class ConexaoViewModel : BaseViewModel
    {
        public ConexaoViewModel()
        {
            Title = "Conexão";
        }

        private string _linkConexao;
        public  string LinkCoenxao
        {
            get => _linkConexao;
            set => SetProperty(ref _linkConexao, value);
        }

        private Command _salvarConexaoCommand;
        public Command SalvarConexaoCommand =>
            _salvarConexaoCommand ?? (_salvarConexaoCommand = new Command(async () => await ExecuteSalvarConexaoCommand()));

        private Task ExecuteSalvarConexaoCommand()
        {
            throw new NotImplementedException();
        }
    }
}
