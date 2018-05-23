using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRussia.UWP.Models
{
    public class ValueChangedEventArgs : EventArgs
    {
        public string Command { get; private set; }
        public double State { get; private set; }
        public ValueChangedEventArgs(string command, double state)
        {
            Command = command;
            State = state;
        }
    }
}
