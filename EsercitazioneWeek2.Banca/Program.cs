using System;
using EsercitazioneWeek2.Lib;
using EsercitazioneWeek2.Lib.Movements;

namespace EsercitazioneWeek2.Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            // creazione di alcune banche
            #region Banche
            Bank unicredit = new Bank("Unicredit");
            Bank bpm = new Bank("Banco BPM");
            Bank sanpaolo = new Bank("Intesa Sanpaolo");
            #endregion

            // creazione di alcuni conti nelle varie banche
            #region Conti Unicredit
            Account c1Unicredit = unicredit.CreaConto();        // creazione di un conto a saldo 0
            Account c2Unicredit = unicredit.CreaConto(5000);    // creazione di un conto a saldo 5000
            Account c3Unicredit = unicredit.CreaConto(10000);   // creazione di un conto a saldo 10000

            Console.WriteLine(unicredit.VisualizzaConti());
            #endregion

            #region Conti BPM
            Account c1Bpm = bpm.CreaConto();
            Account c3Bpm = bpm.CreaConto(1000);
            Account c2Bpm = bpm.CreaConto(20000);

            Console.WriteLine(bpm.VisualizzaConti());
            #endregion

            #region Conti Intesa SanPaolo
            Console.WriteLine(sanpaolo.VisualizzaConti());
            #endregion

            #region Movimenti
            Movement m1 = new CashMovement(10, "bianco bianchi");
            Movement m2 = new CreditCardMovement(-20, TipologiaCarta.VISA, 10001);
            Movement m3 = new TransfertMovement(30, unicredit, bpm);

            c1Unicredit.AggiungiMovimento(m1);
            c1Unicredit.AggiungiMovimento(m2);
            c1Unicredit.AggiungiMovimento(m3);

            Console.WriteLine(c1Unicredit.ElencaMovimenti());
            Console.WriteLine();
            Console.WriteLine(unicredit.VisualizzaConti());

            Console.WriteLine();

            Movement m4 = new CashMovement(100, "pinco pallino");
            Movement m5 = new CreditCardMovement(-200, TipologiaCarta.MASTERCARD, 10002);
            Movement m6 = new TransfertMovement(300, unicredit, bpm);

            c1Bpm.AggiungiMovimento(m4);
            c1Bpm.AggiungiMovimento(m5);
            c1Bpm.AggiungiMovimento(m6);

            Console.WriteLine(c1Bpm.ElencaMovimenti());
            Console.WriteLine();
            Console.WriteLine(bpm.VisualizzaConti());
            #endregion

            Console.WriteLine("### Per vedere menù scommentare ###");
            // menù di selezione COMMENTATO (quasi completo)
            #region Menù di selezione
            //Bank banca;

            //do
            //{
            //    bool continua = false;
            //    do
            //    {
            //        Console.WriteLine("Seleziona una banca:");

            //        Console.WriteLine("1. Unicredit");
            //        Console.WriteLine("2. Banco BPM");
            //        Console.WriteLine("3. Intesa Sanpaolo");

            //        switch (Console.ReadKey().KeyChar)
            //        {
            //            case '1':
            //                banca = unicredit;
            //                continua = true;
            //                break;
            //            case '2':
            //                banca = bpm;
            //                continua = true;
            //                break;
            //            case '3':
            //                banca = sanpaolo;
            //                continua = true;
            //                break;
            //            default:
            //                Console.WriteLine("\nScelta non valida.");
            //                banca = null;
            //                break;
            //        }
            //    } while (!continua);

            //    do
            //    {

            //        Console.WriteLine("\nCosa vuoi fare?");

            //        Console.WriteLine("1. Crea un nuovo conto");
            //        Console.WriteLine("2. Preleva");
            //        Console.WriteLine("3. Versa");
            //        Console.WriteLine("4. Visualizza dettaglio conto");
            //        Console.WriteLine("5. Visualizza elenco conti");
            //        Console.WriteLine("6. Pagamenti [*** non testato ***]");
            //        Console.WriteLine("0. Esci");

            //        switch (Console.ReadKey().KeyChar)
            //        {
            //            case '1':
            //                CreaConto(banca);
            //                break;
            //            case '2':
            //                Preleva(banca);
            //                break;
            //            case '3':
            //                Versa(banca);
            //                break;
            //            case '4':
            //                VisualizzaAccount(banca);
            //                break;
            //            case '5':
            //                VisualizzaElencoConti(banca);
            //                break;
            //            case '6':
            //                InserisciPagamento(banca);
            //                break;
            //            case '0':
            //                return; // esce dal programma
            //            default:
            //                Console.WriteLine("Scelta non valida");
            //                break;
            //        }
            //    } while (true);
            //} while (true);
            #endregion
        }

        // metodi privati di supporto al menù di selezione
        #region Private Methods
        private static void CreaConto(Bank banca)
        {
            decimal saldo;
            do
            {
                Console.WriteLine("\nInserisci il saldo");
            } while (!decimal.TryParse(Console.ReadLine(), out saldo));

            banca.CreaConto(saldo);
        }

        private static void Preleva(Bank banca)
        {
            int id;
            do
            {
                Console.WriteLine();
                Console.Write("Numero conto da cui prelevare:");
            } while (!int.TryParse(Console.ReadLine(), out id));

            Account conto = banca.RecuperaConto(id);

            if (banca.Esiste(id))
            {
                decimal importo;
                do
                    Console.Write("Importo da prelevare: ");
                while (!decimal.TryParse(Console.ReadLine(), out importo));

                conto.Preleva(importo);
            }
            else
                Console.WriteLine($"Non esiste il conto n° {id}");
        }

        private static void Versa(Bank banca)
        {
            int id;
            do
            {
                Console.WriteLine();
                Console.Write("Numero conto in cui versare:");
            } while (!int.TryParse(Console.ReadLine(), out id));

            Account conto = banca.RecuperaConto(id);

            if (banca.Esiste(id)) // se il conto esiste
            {
                decimal importo;
                do
                    Console.Write("Importo da versare: ");
                while (!decimal.TryParse(Console.ReadLine(), out importo));

                conto.Versa(importo);
            }
            else
                Console.WriteLine($"Non esiste il conto n° {id}");
        }

        private static void InserisciPagamento(Bank banca)
        {
            int id;
            do
            {
                Console.WriteLine();
                Console.Write("Numero conto in cui inserire il pagamento:");
            } while (!int.TryParse(Console.ReadLine(), out id));

            Account conto;
            decimal importo;
            if (banca.Esiste(id)) // se il conto esiste
            {
                conto = banca.RecuperaConto(id);
                do
                {
                    Console.Write("Importo:");
                } while (!decimal.TryParse(Console.ReadLine(), out importo));
            }
            else
            {
                Console.WriteLine($"Non esiste il conto n° {id}");
                return;
            }

            do
            {
                
                Console.WriteLine("Quale tipo di pagamento vuoi inserire?");

                Console.WriteLine("1. Pagamento contanti");
                Console.WriteLine("2. Pagamento carta");
                Console.WriteLine("3. Bonifico bancario");

                switch (Console.ReadKey().KeyChar)
                {
                    // inizializzazione veloce dei vari tipi di movimento:
                    // ho definito costruttori nelle varie classi Movements molto basic
                    case '1':
                        conto.AggiungiMovimento(new CashMovement(importo));
                        return;
                    case '2':
                        conto.AggiungiMovimento(new CreditCardMovement(importo));
                        return;
                    case '3':
                        conto.AggiungiMovimento(new TransfertMovement(importo));
                        return;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
    
            } while (true);
        }

        private static void VisualizzaAccount(Bank banca)
        {
            int id;
            do
            {
                Console.WriteLine();
                Console.Write("Numero conto da visualizzare:");
            } while (!int.TryParse(Console.ReadLine(), out id));

            if (banca.Esiste(id))
            {
                Account conto = banca.RecuperaConto(id);

                Console.WriteLine("\n" + conto.Statement());
            }
            else
                Console.WriteLine($"Non esiste il conto n° {id}");

        }

        private static void VisualizzaElencoConti(Bank banca)
        {
            Console.WriteLine("\n" + banca.VisualizzaConti());
        }

        #endregion
    }
}
