using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek2.Lib.Movements
{
    public enum TipologiaCarta
    {
        AMEX,
        VISA,
        MASTERCARD,
        OTHER
    }

    public class CreditCardMovement : Movement
    {
        #region Properties
        public TipologiaCarta TipoCarta { get; }
        public long NumeroCarta { get; }
        #endregion

        #region Ctors
        // costruttore che prende in input tutti i parametri necessari per la definizione delle proprietà
        public CreditCardMovement(decimal importo, TipologiaCarta tipoCarta, long numeroCarta)
            : base(importo) // richiamo al costruttore della classe base
        {
            TipoCarta = tipoCarta;
            NumeroCarta = numeroCarta;
        }

        // definito al volo per menù del Program
        public CreditCardMovement(decimal importo) : this(importo, TipologiaCarta.OTHER, 00000) { } 
        #endregion

        #region ToString implementation
        public override string ToString()
        {
            return base.ToString() +
                $"\n  Tipologia di pagamento: pagamento con carta" +
                $"\n  Tipo di carta: {TipoCarta} " +
                $"\n  Numero carta: {NumeroCarta}";
        }
        #endregion
    }
}
