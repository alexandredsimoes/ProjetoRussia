using Prism.Mvvm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoRussia.UWP.Models
{
    public class GolDto : BindableBase
    {
        private int _id;
        private int _jogoId;
        private int _timeId;
        private int _jogadorId;
        private System.TimeSpan _hora;
        private JogoDto _jogo;
        private TimeDto _time;
        private JogadorDto _jogador;

        public int Id { get => _id; set => SetProperty(ref _id , value); }

        public int JogoId { get => _jogoId; set => SetProperty(ref _jogoId, value); }

        public int TimeId { get => _timeId; set => SetProperty(ref _timeId, value); }

        public int JogadorId { get => _jogadorId; set => SetProperty(ref _jogadorId, value); }

        public System.TimeSpan Hora { get => _hora; set => SetProperty(ref _hora, value); }

        public JogoDto Jogo { get => _jogo; set => SetProperty(ref _jogo, value); }

        public TimeDto Time { get => _time; set => SetProperty(ref _time, value); }

        public JogadorDto Jogador { get => _jogador; set => SetProperty(ref _jogador, value); }
    }
}
