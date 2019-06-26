﻿using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroAtividadeViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly ColaboradorRepository colaboradorRepositorio;
        private readonly ListaAtvRepository listaAtvRepositorio;
        private readonly AtividadeRepository atividadeRepositorio;

        public CadastroAtividadeViewModel()
        {
            Title = "Atividades";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            colaboradorRepositorio = new ColaboradorRepository();
            listaAtvRepositorio = new ListaAtvRepository();
            atividadeRepositorio = new AtividadeRepository();

            Colaboradores();
            ListaAtividades();
        }

        public List<Colaborador> listaColaboradores { get; set; }
        public List<Lista_Atv> listaAtividades { get; set; }

        private string _dispId;
        public string DispId
        {
            get => _dispId;
            set => SetProperty(ref _dispId, value);
        }

        private string _colaboradorId;
        public string ColaboradorId
        {
            get => _colaboradorId;
            set => SetProperty(ref _colaboradorId, value);
        }

        private Colaborador _colaboradorSelecionado;
        public Colaborador ColaboradorSelecionado
        {
            get => _colaboradorSelecionado;
            set => SetProperty(ref _colaboradorSelecionado, value);
        }

        private string _listaAtvId;
        public string ListaAtvId
        {
            get => _listaAtvId;
            set => SetProperty(ref _listaAtvId, value);
        }

        private Lista_Atv _listaAtividadeSelecionada;
        public Lista_Atv ListaAtividadeSelecionada
        {
            get => _listaAtividadeSelecionada;
            set => SetProperty(ref _listaAtividadeSelecionada, value);
        }

        private DateTime _dataInicio;
        public DateTime DataInicio
        {
            get => _dataInicio = DateTime.Now;
            set => SetProperty(ref _dataInicio, value);
        }

        private DateTime _dataFim;
        public DateTime DataFim
        {
            get => _dataFim = DateTime.Now;
            set => SetProperty(ref _dataFim, value);
        }

        private string _obs;
        public string Obs
        {
            get => _obs;
            set => SetProperty(ref _obs, value);
        }

        private string _lastUpdate;
        public string LastUpdate
        {
            get => _lastUpdate;
            set => SetProperty(ref _lastUpdate, value);
        }

        private string _indSinc;
        public string IndSinc
        {
            get => _indSinc;
            set => SetProperty(ref _indSinc, value);
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _cancelarCadastroCommand;
        public Command CancelarCadastroCommand =>
            _cancelarCadastroCommand ?? (_cancelarCadastroCommand = new Command(async () => await ExecuteCancelarCadastroCommand()));

        private Task ExecuteCancelarCadastroCommand()
        {
            throw new NotImplementedException();
        }

        private Command _salvarCadastroCommand;
        public Command SalvarCadastroCommand =>
            _salvarCadastroCommand ?? (_salvarCadastroCommand = new Command(async () => await ExecuteSalvarCadastroCommandAsync()));

        private async Task ExecuteSalvarCadastroCommandAsync()
        {
            try
            {
                var atividade = new Atividade
                {
                    colaborador_id = ColaboradorSelecionado.colaborador_id,
                    lista_atv_id = ListaAtividadeSelecionada.lista_atv_id,
                    data_inicio = DataInicio,
                    data_fim = DataFim
                };

                bool atividadeAceite = await dialogService.AlertAsync("ATIVIDADES", "Deseja salvar os dados informados?", "Sim", "Não");

                if (atividadeAceite)
                {
                    try
                    {
                        atividadeRepositorio.Adicionar(atividade);
                        await dialogService.AlertAsync("ATIVIDADES", "Dados salvos com sucesso!", "Ok");
                    }
                    catch (Exception)
                    {
                        await dialogService.AlertAsync("ATIVIDADES", "Erro ao salvar dados!", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await dialogService.AlertAsync("ATIVIDADES", ex.Message, "OK");
            }
        }

        private List<Colaborador> Colaboradores()
        {
            return listaColaboradores = colaboradorRepositorio.ObterTodos();
        }

        private List<Lista_Atv> ListaAtividades()
        {
            return listaAtividades = listaAtvRepositorio.ObterTodos();
        }
    }
}