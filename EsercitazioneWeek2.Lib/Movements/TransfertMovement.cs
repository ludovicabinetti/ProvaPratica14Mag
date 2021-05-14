using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek2.Lib.Movements
{
    public class TransfertMovement : Movement
    {
        #region Properties
        public Bank BancaDiOrigine { get; }
        public Bank BancaDiDestinazione { get; }
        #endregion

        #region Ctors
        // costruttore che prende in input tutti i parametri necessari per la definizione delle proprietà
        public TransfertMovement(decimal importo, Bank bancaDiOrigine, Bank bancaDiDestinazione) 
            : base(importo) // richiamo al costruttore della classe base
        {
            BancaDiOrigine = bancaDiOrigine;
            BancaDiDestinazione = bancaDiDestinazione;
        }

        // definito al volo per menù del Program
        public TransfertMovement(decimal importo) : this(importo, null, null) { }
        #endregion

        #region ToString implementation
        public override string ToString()
        {
            return base.ToString() +
                $"\n  Tipologia di pagamento: bonifico bancario" +
                $"\n  Banca di origine: {BancaDiOrigine} " +
                $"\n  Banca di destinazione: {BancaDiDestinazione}";
        }
        #endregion
    }
}
