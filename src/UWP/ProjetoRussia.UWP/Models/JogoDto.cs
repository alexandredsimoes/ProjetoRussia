using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoRussia.UWP.Models
{
    public class JogoDto
    {
        public int Id { get; set; }

        public int Time1 { get; set; }

        public int Time2 { get; set; }

        public DateTime Data { get; set; }

        public virtual TimeDto Time_1 { get; set; }

        public virtual TimeDto Time_2 { get; set; }

        public virtual ICollection<GolDto> Gols { get; set; }
    }
}
