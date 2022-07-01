using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_INIS4_PR2._2_z4
{
    class Model
    {
        /*Prawdopodobnie brakuje jawnego pola z listą, właściwości jawnie zaimplementowanej i notyfikacji o zmianie*/
        public LinkedList<Osoba> Lista { get; set; } = new LinkedList<Osoba>(new Osoba[] {
            new Osoba() {
                Tytul = "Transformers",
                Rezyser = "Wiśniewski",
                Nosnik="Płyta CD",
                Wydawca="Sony",
                DataWydania = DateTime.Parse("1.01.1990")
            },
             new Osoba() {
                Tytul = "Transformers 2",
                Rezyser = "Kowal",
                Nosnik="Cyfrowo",
                Wydawca="Sony",
                DataWydania = DateTime.Parse("1.01.2000")
            },

        });

        internal void OtwórzSzczegóły(Osoba wybrany)
        {
            Szczegóły szczegóły = new Szczegóły(wybrany);
            szczegóły.Show();
        }
        internal void DodajNowy()
        {
            Osoba nowa = new Osoba();
            Lista.AddLast(nowa);
            Szczegóły szczegóły = new Szczegóły(nowa);
            szczegóły.Show();
            /*aktualizowanie widoku samej listy*/
        }
    }
}
