
using Prism.Mvvm;

namespace ProjetoRussia.UWP.Models
{
    public class FichaDto : BindableBase
    {
        private int _jogadorId;
        private string _posicao;
        private string _naturalidade;
        private decimal _altura;
        private int _camisa;
        private JogadorDto _jogador;

        public int JogadorId { get => _jogadorId; set => SetProperty(ref _jogadorId , value); }
        public string Posicao { get => _posicao; set => SetProperty(ref _posicao, value); }
        public string Naturalidade { get => _naturalidade; set => SetProperty(ref _naturalidade, value); }
        public decimal Altura { get => _altura; set => SetProperty(ref _altura, value); }

        public int Camisa { get => _camisa; set => SetProperty(ref _camisa, value); }

        public virtual JogadorDto Jogador { get => _jogador; set => SetProperty(ref _jogador , value); }
    }
}
