using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoRussia.UWP.Models
{
    public class GolDto
    {
        public int Id { get; set; }

        public int JogoId { get; set; }

        public int TimeId { get; set; }

        public int JogadorId { get; set; }

        public System.TimeSpan Hora { get; set; }

        public JogoDto Jogo { get; set; }

        public TimeDto Time { get; set; }

        public JogadorDto Jogador { get; set; }
    }
}
