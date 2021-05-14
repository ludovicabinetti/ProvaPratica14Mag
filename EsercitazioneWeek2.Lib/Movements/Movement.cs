using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek2.Lib.Movements
{
    public class Movement : IMovement
    {
        #region Properties
        public decimal Importo { get; }
        public DateTime DatatMovimento { get; }
        #endregion

        #region Ctors
        // costruttore che prende in input tutti i parametri necessari per la definizione delle proprietà
        // (NB: la DataMovimento è la data corrente in cui il movimento viene effettuato)
        public Movement(decimal importo)
        {
            Importo = importo;
            DatatMovimento = DateTime.Now;
        }
        #endregion

        #region ToString implementation
        public override string ToString()
        {
            return $"- Importo: {Importo}\n  Data di esecuzione: {DatatMovimento.ToShortDateString()}";
        }
        #endregion
    }
}
