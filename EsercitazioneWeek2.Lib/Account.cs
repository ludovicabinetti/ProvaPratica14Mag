using System;
using System.Collections;
using System.Collections.Generic;
using EsercitazioneWeek2.Lib.Movements;

namespace EsercitazioneWeek2.Lib
{
    public class Account : IEnumerable
    {
        #region Properties
        public int NumeroConto { get; }
        public string NomeBanca { get; }
        public decimal Saldo { get; private set; }
        public DateTime DataUltimaOperazione { get; private set; }
        public List<Movement> ListaMovimenti { get; } = new List<Movement>();

        #endregion

        #region Ctors
        // costruttore che inizializza di default il Saldo a 0
        public Account(int numeroConto, string nomeBanca) : this(numeroConto, nomeBanca, 0) { }

        // costruttore che prende in input tutti i parametri necessari per la definizione delle proprietà
        // (NB: al momento della creazione di un Account non sembra strettamente necessario passare come parametro una
        // dataUltimaOperazione in quanto si può inizializzare in automatico)
        public Account(int numeroConto, string nomeBanca, decimal saldo)
        {
            NumeroConto = numeroConto;
            NomeBanca = nomeBanca;
            Saldo = saldo;
            DataUltimaOperazione = DateTime.Now;
        }
        #endregion

        #region Methods

        public void AggiornaSaldo(decimal importo) // metodo che aggiorna il saldo
        {
            Saldo += importo;
        }

        public void AggiungiMovimento(Movement movimento)
        {
            ListaMovimenti.Add(movimento); // si aggiunge l'istanza alla lista dei movimenti

            AggiornaSaldo(movimento.Importo); // si aggiorna del saldo

            DataUltimaOperazione = movimento.DatatMovimento; // aggiornamento della data di ultima operazione
        }

        public List<Movement> Versa(decimal importo)
        {
            // sulla base dell'importo viene creata un'istanza di Movement
            Movement movimento = new Movement(importo);

            ListaMovimenti.Add(movimento); // si aggiunge l'istanza alla lista dei movimenti

            AggiornaSaldo(movimento.Importo); // si aggiorna del saldo

            DataUltimaOperazione = movimento.DatatMovimento; // aggiornamento della data di ultima operazione

            return ListaMovimenti;
        }

        public List<Movement> Preleva(decimal importo)
        {
            return Versa(-importo); // Preleva() altro non è che il complementare di Versa().
                                    // Si suppone che il fruitore della Console App, quando 
                                    // voglia prelevare, inserisca una cosa del tipo "conto - 10"
                                    // intendendo che si vuole prelevare una cifra di soldi pari a 10
        }

        public string ElencaMovimenti()
        {
            string s = $"Elenco movimenti conto n° {NumeroConto} di {NomeBanca}:\n";
            //if (this != null) // ** da controllare cosa succede
                foreach (var movimento in this)
                    s += movimento.ToString() + "\n";

            return s;
        }
        public string Statement()
        {
            return $"Prospetto del conto n° {NumeroConto}:\n" +
                $"  Banca di appartenenza: {NomeBanca}\n" +
                $"  Saldo: {Saldo}\n" +
                $"  Data e ora ultima operazione: {DataUltimaOperazione}\n" +
                $"  Lista dei movimenti:\n {this.ElencaMovimenti()}";
            //return this.ToString(); // richiamo all'override di ToString()
        }

        #endregion

        #region Overloading operators + / -
        public static List<Movement> operator +(Account conto, decimal importo)
        {
            return conto.Versa(importo); // esempio di input: conto + 10
        }
        public static List<Movement> operator -(Account conto, decimal importo)
        {
            return conto.Preleva(importo); // esempio di input: conto - 10
        }
        #endregion

        #region IEnumerable implementation
        public IEnumerator GetEnumerator()
        {
            foreach (var movimento in ListaMovimenti)
                yield return movimento;
        }
        #endregion

        #region ToString implementation
        public override string ToString()
        {
            return $"Conto n°: {NumeroConto} Saldo: {Saldo}";
        }
        #endregion
    }
}
