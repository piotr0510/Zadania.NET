using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_INIS4_PR2._2_z4
{
    public class Osoba : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly static Dictionary<string, string[]> relatedProperties = new Dictionary<string, string[]>()
        {
            ["Tytul"] = new string[] { "Wydawcax", "FormatListy" },
            ["Rezyser"] = new string[] { "Wydawcax", "FormatListy" },
            ["Nosnik"] = new string[] {"FormatListy" },
            ["Wydawca"] = new string[] { "FormatListy" },
            ["DataWydania"] = new string[] { "FormatListy" }
        };
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if(relatedProperties.ContainsKey(propertyName))
                foreach(string relatedProperty in relatedProperties[propertyName])
                    OnPropertyChanged(relatedProperty);
           
        }

        static uint następneID = 0;
        /*uint wiek = 0;*/
        string
            tytul,
            rezyser,
            nosnik,
            wydawca
            ;
        DateTime?
            
            dataWydania = null
            ;

        public string Tytul
        {
            get => tytul;
            set
            {
                tytul = value;
                OnPropertyChanged();
            }
        }
        public string Rezyser
        {
            get => rezyser;
            set
            {
                rezyser = value;
                OnPropertyChanged();
            }
        }
        public string Wydawca
        {
            get => wydawca;
            set
            {
                wydawca = value;
                OnPropertyChanged();
            }
        }
        public string Nosnik
        {
            get => nosnik;
            set
            {
                nosnik = value;
                OnPropertyChanged();
            }
        }
       
        public DateTime? DataWydania
        {
            get => dataWydania;
            set
            {
                dataWydania = value;
                OnPropertyChanged();
            }
        }
        public string Wydawcax { get => $"{Wydawca} {Rezyser}"; }
        public string FormatListy { get => $"{Tytul} Reżyser: {Rezyser} nośnik: {Nosnik} Wydane: {DataWydania}"; }
        public uint ID { get; } = następneID++;
        public string FormatID { get => "ID: " + ID; }
    }
}
