using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek2.Lib.Movements
{
    public class CashMovement : Movement
    {
        #region Properties
        public string Esecutore { get; }
        #endregion

        #region Ctors
        // costruttore che prende in input tutti i parametri necessari per la definizione delle proprietà
        public CashMovement(decimal importo, string esecutore) : base(importo) // richiamo al costruttore della classe base
        {
            Esecutore = esecutore;
        }

        // definito al volo per menù del Program
        public CashMovement(decimal importo) : this(importo, "") { }
        #endregion

        #region ToString implementation
        public override string ToString()
        {
            return base.ToString() +
                $"\n  Tipologia di pagamento: pagamento in contanti" +
                $"\n  Esecutore: {Esecutore}";
        }
        #endregion
    }
}
