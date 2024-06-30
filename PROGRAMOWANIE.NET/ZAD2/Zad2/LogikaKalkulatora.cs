using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    internal class LogikaKalkulatora : INotifyPropertyChanged
    {
        private double?
            lewyOperand = null,
            prawyOperand = null
            ;
        private string? operacja = null;
        private bool flagaDziałania = false;

        private string wyświetlanaLiczba = "0";
        public string WyświetlanaLiczba
        {
            get => wyświetlanaLiczba;
            set
            {
                wyświetlanaLiczba = value;
                PropertyChanged?.Invoke(this, new(nameof(WyświetlanaLiczba)));
            }
        }

        public string WyświetlaneDziałanie
            => $"{lewyOperand} {operacja} {prawyOperand}";

        public event PropertyChangedEventHandler? PropertyChanged;

        internal void KasujWszystko()
        {
            lewyOperand = prawyOperand = null;
            operacja = null;
            WyświetlanaLiczba = "0";
            PropertyChanged?.Invoke(this, new("WyświetlaneDziałanie"));
        }

        internal void KasujLiczbę()
            => WyświetlanaLiczba = "0";

        internal void KasujZnak()
        {
            if (WyświetlanaLiczba.Length == 1)
                WyświetlanaLiczba = "0";
            else
                WyświetlanaLiczba = WyświetlanaLiczba.Substring(0, WyświetlanaLiczba.Length - 1);
        }

        internal void WprowadźCyfrę(string? cyfra)
        {
            if (flagaDziałania)
                KasujWszystko();
            if (WyświetlanaLiczba == "0")
                WyświetlanaLiczba = cyfra;
            else
                WyświetlanaLiczba += cyfra;
        }

        internal void WprowadźDziałanieDwuargumentowe(string? działanie)
        {
            if (flagaDziałania)
            {
                prawyOperand = null;
                flagaDziałania = false;
            }
            else if (operacja == null)
                lewyOperand = Convert.ToDouble(WyświetlanaLiczba);
            else
            {
                WykonajDziałanie();
                prawyOperand = null;
                flagaDziałania = false;
            }
            operacja = działanie;
            PropertyChanged?.Invoke(this, new("WyświetlaneDziałanie"));
            wyświetlanaLiczba = "0";
        }

        internal void WykonajDziałanie()
        {
            if (prawyOperand == null)
                prawyOperand = Convert.ToDouble(WyświetlanaLiczba);

            PropertyChanged?.Invoke(this, new("WyświetlaneDziałanie"));

            switch (operacja)
            {
                case "+":
                    WyświetlanaLiczba = $"{lewyOperand + prawyOperand}";
                    break;
                case "-":
                    WyświetlanaLiczba = $"{lewyOperand - prawyOperand}";
                    break;
                case "×":
                    WyświetlanaLiczba = $"{lewyOperand * prawyOperand}";
                    break;
                case "÷":
                    WyświetlanaLiczba = $"{lewyOperand / prawyOperand}";
                    break;
                case "^":
                    WyświetlanaLiczba = $"{Math.Pow((double)lewyOperand, (double)prawyOperand)}";
                    break;
                case "%":
                    WyświetlanaLiczba = $"{lewyOperand * prawyOperand / 100}";
                    break;
                case "mod":
                    WyświetlanaLiczba = $"{lewyOperand % prawyOperand}";
                    break;
            }
            lewyOperand = Convert.ToDouble(WyświetlanaLiczba);
            flagaDziałania = true;
        }

        internal void WprowadźDziałanieJednoargumentowe(string działanie)
        {
            prawyOperand = Convert.ToDouble(WyświetlanaLiczba);
            lewyOperand = null;

            switch (działanie)
            {
                case "√x":
                    WyświetlanaLiczba = $"{Math.Sqrt((double)prawyOperand)}";
                    break;
                case "1/x":
                    WyświetlanaLiczba = $"{1 / prawyOperand}";
                    break;
                case "log":
                    WyświetlanaLiczba = $"{Math.Log10((double)prawyOperand)}";
                    break;
                case "ln":
                    WyświetlanaLiczba = $"{Math.Log((double)prawyOperand)}";
                    break;
                case "lb":
                    WyświetlanaLiczba = $"{Math.Log((double)prawyOperand, 2)}";
                    break;
                case "floor":
                    WyświetlanaLiczba = $"{Math.Floor((double)prawyOperand)}";
                    break;
                case "ceil":
                    WyświetlanaLiczba = $"{Math.Ceiling((double)prawyOperand)}";
                    break;
                case "n!":
                    WyświetlanaLiczba = $"{Silnia((double)prawyOperand)}";
                    break;
            }

            operacja = działanie;
            PropertyChanged?.Invoke(this, new("WyświetlaneDziałanie"));
            lewyOperand = Convert.ToDouble(WyświetlanaLiczba);
            prawyOperand = null;
            flagaDziałania = true;
        }

        internal double Silnia(double a)
        {
            if (a < 0) throw new ArgumentOutOfRangeException("a", "Wartość musi być nieujemna.");
            if (a != Math.Floor(a)) throw new ArgumentException("Wartość musi być liczbą całkowitą.");
            if (a == 0) return 1;
            double result = 1;
            for (int i = 1; i <= a; i++) result *= i;
            return result;
        }

        internal void ZacznijUłamek()
        {
            if (flagaDziałania)
                KasujWszystko();
            if (WyświetlanaLiczba.Contains(','))
                return;
            else
                WyświetlanaLiczba += ",";
        }

        internal void ZmieńZnak()
        {
            if (flagaDziałania)
                KasujWszystko();
            if (WyświetlanaLiczba == "0")
                return;
            else if (WyświetlanaLiczba[0] == '-')
                WyświetlanaLiczba = WyświetlanaLiczba.Substring(1);
            else
                WyświetlanaLiczba = "-" + WyświetlanaLiczba;
        }
    }
}
