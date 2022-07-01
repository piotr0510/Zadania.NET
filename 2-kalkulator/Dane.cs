using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_INIS4_PR2._2_z2
{
    public class Dane : INotifyPropertyChanged
    {
        bool
            flagaUłamka = false,
            flagaPrzecinka = false,
            flagaWyniku = false,
            flagaUjemnegoZnaku = false
            ;
        double wynik = 0;
        double?
            pierwsza = null,
            druga = null
            ;
        string działanie = null;
        public string Wynik
        {
            get { 
                if(flagaUjemnegoZnaku && wynik == 0)
                    return "-" + Convert.ToString(wynik);
                else
                    return Convert.ToString(wynik);
            }
            set
            {
                wynik = Convert.ToDouble(value);
                OnPropertyChanged();
            }
        }

        public void Dopisz(string znak)
        {
            if (flagaWyniku)
                Zeruj();
            if (znak == ",")
                if (flagaUłamka)
                    ;
                else
                    flagaPrzecinka = true;
            else if (flagaPrzecinka)
            {
                Wynik += "," + znak;
                flagaPrzecinka = false;
                flagaUłamka = true;
            }
            else
                Wynik += znak;
        }
        public void ZmieńZnak()
        {
            if (flagaWyniku)
                Zeruj();
            flagaUjemnegoZnaku = !flagaUjemnegoZnaku;
            Wynik = Convert.ToString(-wynik);
        }
        public void Zeruj()
        {
            flagaPrzecinka = flagaPrzecinka = flagaWyniku = flagaUjemnegoZnaku = false;
            druga = null;
            Wynik = "0";
        }
        public void Resetuj()
        {
            Zeruj();
            pierwsza = null;
            działanie = null;
        }
        public void Działanie(string działanie)
        {
            if (pierwsza == null)
            {
                pierwsza = wynik;
                this.działanie = działanie;
                Zeruj();
            }
            else
            {
                druga = wynik;
                Wykonaj();
                this.działanie = działanie;
            }
        }
        public void Wykonaj()
        {
            if (działanie == null)
                return;
            else if (druga == null)
                druga = wynik;

            double p1 = Convert.ToDouble(pierwsza);
            double d1 = Convert.ToDouble(druga);

            if (działanie == "+")
                Wynik = Convert.ToString(pierwsza + druga);
            if (działanie == "-")
                Wynik = Convert.ToString(pierwsza - druga);
            if (działanie == "*")
                Wynik = Convert.ToString(pierwsza * druga);
            if (działanie == "/")
                Wynik = Convert.ToString(pierwsza / druga);
            if (działanie == "x%y")
                Wynik = Convert.ToString(pierwsza % druga);
            if (działanie == "x^y")
            { 
                
            }
                

            flagaWyniku = true;
            pierwsza = wynik;
        }

        public void Funkcja(string funkcja)
        {
            if (funkcja == null)
                return;
            double p1 = Convert.ToDouble(pierwsza);

            if (funkcja == "x^2")
                Wynik = Convert.ToString(pierwsza* pierwsza);
            if (funkcja == "√x")
                Wynik = Convert.ToString(Math.Round(Math.Sqrt(p1), 2));
            if (funkcja == "%")
                Wynik = Convert.ToString(pierwsza/100);
            if (funkcja == "1/x")
                Wynik = Convert.ToString(1 / pierwsza);
            if (funkcja == "ln")
                Wynik = Convert.ToString(Math.Log(p1));



            flagaWyniku = true;
            pierwsza = wynik;

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
