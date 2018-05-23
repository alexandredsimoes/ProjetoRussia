using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoRussia.UWP.Models
{
    public class JogoDto : BindableBase
    {
        private int _id;
        private int _time1;
        private int _time2;
        private DateTime _data;
        private TimeDto _time_1;
        private TimeDto _time_2;
        private ICollection<GolDto> _gols;

        public JogoDto()
        {
            _gols = new List<GolDto>();
        }

        public int Id { get => _id; set => SetProperty(ref _id, value); }

        public int Time1 { get => _time1; set => SetProperty(ref _time1 , value); }

        public int Time2 { get => _time2; set => SetProperty(ref _time2, value); }

        public DateTime Data { get => _data; set => SetProperty(ref _data, value); }

        public virtual TimeDto Time_1 { get => _time_1; set => SetProperty(ref _time_1, value); }

        public virtual TimeDto Time_2 { get => _time_2; set => SetProperty(ref _time_2, value); }

        public virtual ICollection<GolDto> Gols { get => _gols; set => SetProperty(ref _gols, value); }
    }
}
