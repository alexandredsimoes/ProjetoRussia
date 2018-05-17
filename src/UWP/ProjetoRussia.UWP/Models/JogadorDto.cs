using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRussia.UWP.Models
{
    public class JogadorDto : BindableBase
    {
        private int _id;
        private int _timeId;
        private string _nome;
        private TimeDto _time;
        private FichaDto _ficha;

        public int Id { get => _id; set => SetProperty(ref _id , value); }
        public int TimeId { get => _timeId; set => SetProperty(ref _timeId , value); }
        public string Nome { get => _nome; set => SetProperty(ref _nome , value); }

        public TimeDto Time { get => _time; set => SetProperty(ref _time , value); }

        public FichaDto Ficha { get => _ficha; set => SetProperty(ref _ficha , value); }
    }
}
