using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp8
{
    public class SpravceUkolu
    {
        public ObservableCollection<Ukol> Ukoly { get; set; }

        public SpravceUkolu()
        {
            Ukoly = new ObservableCollection<Ukol>();
        }

        public void PridatUkol(string nazev)
        {
            Ukol novyUkol = new Ukol(nazev);
            Ukoly.Add(novyUkol);
            Console.WriteLine("Nový úkol přidán: " + nazev); // Kontrolní výpis do konzole
        }

        public void OznacitUkolHotovo(Ukol ukol)
        {
            ukol.JeHotovo = true;
        }

        public void OdstranitUkol(Ukol ukol)
        {
            Ukoly.Remove(ukol);
        }
    }

    public class Ukol
    {
        public string Nazev { get; set; }
        public bool JeHotovo { get; set; }

        public Ukol(string nazev)
        {
            Nazev = nazev;
            JeHotovo = false;
        }
    }
}
