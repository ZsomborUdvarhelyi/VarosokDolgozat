using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarosokDolgozat
{
    internal class Varos
    {
        public string VarosNev {  get; set; }
        public string OrszagNev {  get; set; }
        public float Nepesseg {  get; set; }

        public override string ToString() =>
            $"\tA város neve: {VarosNev}" +
            $"\n\tOrszág: {OrszagNev}" +
            $"\n\tNépesség: {Math.Round(Nepesseg, 2)} millió fő.";

        public Varos(string s)
        {
            var v = s.Split(';');
            VarosNev = v[0];
            OrszagNev = v[1];
            Nepesseg = float.Parse(v[2]);
        }
    }
}
