using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tetriswinforms;

namespace Tetris
{
    public class Plansza
    {
        private int[,] plansza = null;

        SolidBrush r = new SolidBrush(Color.Red);
        SolidBrush b = new SolidBrush(Color.Blue);

        public Plansza(int x, int y)
        {
            plansza = new int[x, y];
            for (int i = 0; i < plansza.GetLength(0); i++)
                for (int j = 0; j < plansza.GetLength(1); j++)
                    plansza[i, j] = 0;
            for (int i = 0; i < plansza.GetLength(0); i++)
                plansza[i, 0] = 0;
        }
        public void Spadek(int wiersz)
        {
            for (int j = wiersz; j > 0; j--)
                for (int i = 0; i < plansza.GetLength(0); i++)
                    plansza[i, j] = plansza[i, j - 1];
        }

        public int Linia()
        {
            int counter = 0;
            int ilośćLinii = 0;
            for (int j = 0; j < plansza.GetLength(1); j++)
            {
                for (int i = 0; i < plansza.GetLength(0); i++)
                    if (plansza[i, j] == 2)
                        counter++;
                if (counter == plansza.GetLength(0))
                {
                    Spadek(j);
                    ilośćLinii++;
                }
                counter = 0;
            }
            return ilośćLinii;
        }
        public bool Kolizja(Bloczek b)
        {
            for (int i = 0; i < b.Sz; i++)
                for (int j = 0; j < b.Dł; j++)
                {
                    if (b[i, j] == 1)
                        if (j + b.PosY >= plansza.GetLength(1) || i + b.PosX >= plansza.GetLength(0) || i + b.PosX < 0 || j + b.PosY < 0)
                            return true;
                        else
                            if (plansza[i + b.PosX, j + b.PosY] == 2)
                            return true;
                }
            return false;
        }
        public bool KolizjaDół(Bloczek b)
        {
            for (int i = 0; i < b.Sz; i++)
                for (int j = 0; j < b.Dł; j++)
                {
                    if (b[i, j] == 1)
                        if (j + b.PosY + 1 >= plansza.GetLength(1))
                            return true;
                        else
                            if (plansza[i + b.PosX, j + b.PosY + 1] == 2)
                            return true;
                }
            return false;
        }
        public bool KolizjaPrawo(Bloczek b)
        {
            for (int i = 0; i < b.Sz; i++)
                for (int j = 0; j < b.Dł; j++)
                {
                    if (b[i, j] == 1)
                        if (i + b.PosX + 1 >= plansza.GetLength(0))
                            return true;
                        else if (plansza[i + b.PosX + 1, j + b.PosY] == 2)
                            return true;
                }
            return false;
        }
        public bool KolizjaLewo(Bloczek b)
        {
            for (int i = 0; i < b.Sz; i++)
                for (int j = 0; j < b.Dł; j++)
                {
                    if (b[i, j] == 1)
                        if (i + b.PosX - 1 < 0)
                            return true;
                        else if (plansza[i + b.PosX - 1, j + b.PosY] == 2)
                            return true;
                }
            return false;
        }

        public bool KolizjaObrót(Bloczek b, bool kierunek)
        {
            Bloczek kopia = new Bloczek(b);
            kopia.Obrót(true);
            if (Kolizja(kopia))
                return true;
            else
                return false;
        }
        public void PłytkieCzyszczenie()
        {
            for (int j = 0; j < plansza.GetLength(1); j++)
                for (int i = 0; i < plansza.GetLength(0); i++)
                    if (plansza[i, j] == 1)
                        plansza[i, j] = 0;
        }
        public void GłębokieCzyszczenie()
        {
            for (int j = 0; j < plansza.GetLength(1); j++)
                for (int i = 0; i < plansza.GetLength(0); i++)
                    plansza[i, j] = 0;
        }

        public void DodajBloczek(Bloczek b)
        {
            int iteratorDl = 0, iteratorSz = 0;
            for (int i = b.PosX; i < b.PosX + b.Sz; i++)
            {
                if (i >= 0)
                {
                    for (int j = b.PosY; j < b.PosY + b.Dł; j++)
                    {
                        if (j < plansza.GetLength(1) && i < plansza.GetLength(0) && plansza[i, j] == 0)
                            plansza[i, j] = b[iteratorSz, iteratorDl];
                        iteratorDl++;
                    }
                    iteratorDl = 0;
                }
                iteratorSz++;
            }
        }
        public void Druk(Graphics e)
        {
            for (int j = 0; j < plansza.GetLength(1); j++)
            {
                for (int i = 0; i < plansza.GetLength(0); i++)
                {
                    if (plansza[i, j] == 1)
                        e.FillRectangle(r, i*25, j*25, 25, 25);
                    if (plansza[i, j] == 2)
                        e.FillRectangle(b, i * 25, j * 25, 25, 25);
                }
            }
        }
    }
}
