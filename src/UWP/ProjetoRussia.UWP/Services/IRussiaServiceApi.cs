using ProjetoRussia.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRussia.UWP.Services
{
    public interface IRussiaServiceApi
    {
        Task<IEnumerable<TimeDto>> ListarTimes();
        Task<bool> CriarTime(TimeDto time);
    }
}
