using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using ProjetoRussia.UWP.Models;
using ProjetoRussia.UWP.Services;
using Windows.UI.Popups;

namespace ProjetoRussia.UWP.ViewModels
{
    public class JogosCriarViewModel : ViewModelBase
    {
        private readonly IRussiaServiceApi _russiaServiceApi;
        private readonly INavigationService _navigationService;
        public JogosCriarViewModel(IRussiaServiceApi russiaServiceApi, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _russiaServiceApi = russiaServiceApi;
        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            Times = await _russiaServiceApi.ListarTimes();
            RaisePropertyChanged("Times");
        }

        private DelegateCommand _ConfirmarCommand;
        public DelegateCommand ConfirmarCommand =>
            _ConfirmarCommand ?? (_ConfirmarCommand = new DelegateCommand(ExecuteConfirmarCommand));

        async void ExecuteConfirmarCommand()
        {
            if(Jogo.Time_1 == null || Jogo.Time_2 == null)
            {
                await new MessageDialog("Escolha os dois times antes de continuar!").ShowAsync();
                return;
            }

            if (Jogo.Time_1 == Jogo.Time_2)
            {
                await new MessageDialog("Os times não devem ser iguais!").ShowAsync();
                return;
            }
            Jogo.Time1 = Jogo.Time_1.Id;
            Jogo.Time2 = Jogo.Time_2.Id;
            Jogo.Time_1 = null;
            Jogo.Time_2 = null;

            await _russiaServiceApi.CriarJogo(Jogo);
            _navigationService.GoBack();
        }

        public IEnumerable<TimeDto> Times { get; set; }

        private JogoDto _Jogo = new JogoDto() { Data = DateTime.Today };
        public JogoDto Jogo
        {
            get { return _Jogo; }
            set { SetProperty(ref _Jogo, value); }
        }
    }
}
