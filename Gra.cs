using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tetriswinforms;

namespace Tetris
{
    class Gra
    {
        int cols = 10, rows = 15;
        public Plansza pl;
        public Bloczek b;
        Random r = new Random();
        List<Bloczek> wszystkieBloczki;
        private int punkty = 0;
        IEnumerable<Bloczek> aux;
        public bool koniec = false;

        Graphics e;

        public string Punkty()
        {
            return punkty.ToString();
        }

        public Gra(int c, int r,Graphics e)
        {
            cols = c;
            rows = r;
            pl = new Plansza(cols, rows);
            aux = typeof(Bloczek).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Bloczek))).Select(t => (Bloczek)Activator.CreateInstance(t));
            NowyBloczek();
            this.e = e;
        }
        private void KoniecGry()
        {
            koniec = true;
            MessageBox.Show("Koniec gry! Twój wynik to "+punkty+" pkt","Koniec gry",MessageBoxButtons.OK);
        }
        private bool SprawdźCzyKoniec()
        {
            if (b.PosY == 0) return true;
            else return false;
        }
        public void NowyBloczek()
        {
            wszystkieBloczki = aux.Cast<Bloczek>().ToList();
            b = wszystkieBloczki[r.Next(wszystkieBloczki.Count)];
            b.PozycjaStartowa(r.Next(cols - b.Sz));
        }

        public void Ruch()
        {
            pl.PłytkieCzyszczenie();
            if (pl.KolizjaDół(b) == false)
            {
                b.MoveDown();
                pl.DodajBloczek(b);
            }
            else
            {
                if (SprawdźCzyKoniec())
                {
                    KoniecGry();
                    return;
                }
                b.ZamróźBloczek();
                pl.DodajBloczek(b);
                NowyBloczek();
                int ilośćLinii = pl.Linia();
                switch (ilośćLinii)
                {
                    case 1:
                        punkty += 5;
                        break;
                    case 2:
                        punkty += 15;
                        break;
                    case 3:
                        punkty += 45;
                        break;
                    case 4:
                        punkty += 75;
                        break;
                }
            }
        }
        
    }
}
