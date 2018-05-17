using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRussia.UWP.Models
{
    public class TimeDto : BindableBase
    {
        private string _pais;
        private int _id;
        private byte[] _bandeira;
        private string _nMTecnico;
        private ICollection<JogadorDto> _jogadores;

        public TimeDto()
        {
            Jogadores = new List<JogadorDto>();
        }

        public int Id { get => _id; set => SetProperty(ref _id, value); }
        public string Pais { get => _pais; set => SetProperty(ref _pais, value); }
        public byte[] Bandeira { get => _bandeira; set => SetProperty(ref _bandeira , value); }
        public string NMTecnico { get => _nMTecnico; set => SetProperty(ref _nMTecnico , value); }
        public virtual ICollection<JogadorDto> Jogadores { get => _jogadores; set => SetProperty(ref _jogadores , value); }
    }
}
