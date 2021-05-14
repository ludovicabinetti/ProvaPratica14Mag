using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneWeek2.Lib
{
    // classe che si occupa della gestione degli Account
    public class Bank
    {
        #region Properties
        public int IdConti { get; private set; }
        public string NomeBanca { get; }
        public List<Account> Conti { get; } = new List<Account>();
        #endregion

        #region Ctors
        public Bank(string nomeBanca)
        {
            NomeBanca = nomeBanca;
        }
        #endregion

        #region Methods
        public Account CreaConto()
        {
            Account conto = new Account(++IdConti, NomeBanca);
            Conti.Add(conto);

            return conto;
        }

        public Account CreaConto(decimal saldo)
        {
            Account conto = new Account(++IdConti, NomeBanca, saldo);
            Conti.Add(conto);

            return conto;
        }

        public string VisualizzaConti()
        {
            if (Conti.Count != 0)
            {
                string s = $"Conti in {NomeBanca}:\n";
                foreach (Account conto in Conti)
                    s += "-- " + conto.ToString() + "\n";
                return s;
            }

            return $"Nessun conto registrato in {NomeBanca}. \n";
        }

        public bool Esiste(int id)
        {
            foreach (Account conto in Conti) // non molto efficiente (si potrebbe sistemare rendendo conti un Dictionary)
                if (conto.NumeroConto == id)
                    return true;

            return false;
        }
        
        public Account RecuperaConto(int id)
        {
            foreach (Account conto in Conti) // non molto efficiente (si potrebbe sistemare rendendo conti un Dictionary)
                if (conto.NumeroConto == id)
                    return conto;

            return null;
        }
        #endregion

        #region ToString Implementation
        public override string ToString()
        {
            return $"{NomeBanca}";
        }
        #endregion
    }
}
