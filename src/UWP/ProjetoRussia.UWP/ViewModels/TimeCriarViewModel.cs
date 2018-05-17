using System;
using System.Collections.Generic;
using System.IO;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using ProjetoRussia.UWP.Models;
using ProjetoRussia.UWP.Services;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjetoRussia.UWP.ViewModels
{
    public class TimeCriarViewModel : ViewModelBase
    {
        private readonly IRussiaServiceApi _russiaServiceApi;
        private readonly INavigationService _navigationService;

        public TimeCriarViewModel(IRussiaServiceApi russiaServiceApi, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _russiaServiceApi = russiaServiceApi ?? throw new ArgumentNullException(nameof(russiaServiceApi));
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (e.Parameter == null)
            {
                Time = new TimeDto();
            }
        }

        private DelegateCommand _selecionarImagemCommand;
        public DelegateCommand SelecionarImagemCommand =>
            _selecionarImagemCommand ?? (_selecionarImagemCommand = new DelegateCommand(ExecuteSelecionarImagemCommand));

        async void ExecuteSelecionarImagemCommand()
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.ViewMode = PickerViewMode.Thumbnail;
            fop.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fop.FileTypeFilter.Add(".jpg");
            fop.FileTypeFilter.Add(".jpeg");
            fop.FileTypeFilter.Add(".png");
            var file = await fop.PickSingleFileAsync();
            if (file != null)
            {
                var stream = await file.OpenStreamForReadAsync();
                var bytes = new byte[(int)stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                Time.Bandeira = bytes;
                RaisePropertyChanged("Time.Bandeira");
                RaisePropertyChanged("Time");
                RaisePropertyChanged();

            }
        }

        private DelegateCommand _SalvarCommand;
        public DelegateCommand SalvarCommand =>
            _SalvarCommand ?? (_SalvarCommand = new DelegateCommand(ExecuteSalvarCommand));

        async void ExecuteSalvarCommand()
        {
            if (await _russiaServiceApi.CriarTime(Time))
            {
                if (_navigationService.CanGoBack())
                    _navigationService.GoBack();
            }
        }

        private TimeDto _Time;
        public TimeDto Time
        {
            get { return _Time; }
            set { SetProperty(ref _Time, value); }
        }

        public object ObterImagem()
        {
            return Time?.Bandeira;
        }

        private string _NomeJogador;
        public string NomeJogador
        {
            get { return _NomeJogador; }
            set { SetProperty(ref _NomeJogador, value); }
        }

        private int _NumeroCamisa;
        public int NumeroCamisa
        {
            get { return _NumeroCamisa; }
            set { SetProperty(ref _NumeroCamisa, value); }
        }

        private string _PosicaoJogador;
        public string PosicaoJogador
        {
            get { return _PosicaoJogador; }
            set { SetProperty(ref _PosicaoJogador, value); }
        }

        private DelegateCommand _AdicionarJogadorCommand;
        public DelegateCommand AdicionarJogadorCommand =>
            _AdicionarJogadorCommand ?? (_AdicionarJogadorCommand = new DelegateCommand(ExecuteAdicionarJogadorCommand));

        void ExecuteAdicionarJogadorCommand()
        {
            Time?.Jogadores.Add(new JogadorDto()
            {
                Nome = NomeJogador,
                Ficha = new FichaDto()
                {
                    Altura = 1.90M,
                    Naturalidade = "Sem",
                    Posicao = PosicaoJogador,
                    Camisa = NumeroCamisa
                }
            });

            RaisePropertyChanged("Time");
            RaisePropertyChanged("Time.Jogadores");
        }
    }
}
