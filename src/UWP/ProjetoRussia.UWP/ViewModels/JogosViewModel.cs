using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using ProjetoRussia.UWP.Models;
using ProjetoRussia.UWP.Services;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjetoRussia.UWP.ViewModels
{
    public class JogosViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRussiaServiceApi _russiaServiceApi;

        public JogosViewModel(INavigationService navigationServiceInstance,
           IRussiaServiceApi russiaServiceApi)
        {
            _russiaServiceApi = russiaServiceApi;
            _navigationService = navigationServiceInstance;
        }

        private JogoDto _selected;

        public JogoDto Selected
        {
            get => _selected;
            set => SetProperty(ref _selected, value);
        }

        public ObservableCollection<JogoDto> Jogos { get; } = new ObservableCollection<JogoDto>();

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            var data = await _russiaServiceApi.ListarJogos();
            Jogos.Clear();

            foreach (var item in data)
            {
                Jogos.Add(item);
            }

            Selected = Jogos.FirstOrDefault();
        }
        public string Teste()
        {
            return "";
        }       

        private DelegateCommand _criarJogoCommand;
        public DelegateCommand CriarJogoCommand =>
            _criarJogoCommand ?? (_criarJogoCommand = new DelegateCommand(ExecuteCriarJogoCommand));

        void ExecuteCriarJogoCommand()
        {
            _navigationService.Navigate(PageTokens.JogosCriarPage, null);
        }
    }
}
