using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek2.Lib.Movements
{
    // interfaccia che definisce il "contratto" per le classi di tipo Movement
    public interface IMovement
    {
        public decimal Importo { get; }
        public DateTime DatatMovimento { get; }
    }
}
