using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Bloczek
    {
        private int x = 0, y = 0;
        protected int[,] kształtBloczka = null;
        protected int rozmiar = 4;
        public Bloczek() { }
        public Bloczek(Bloczek b)
        {
            x = b.PosX;
            y = b.PosY;
            kształtBloczka = b.kształtBloczka;
            rozmiar = b.rozmiar;
        }
        public int PosX { get { return x; } }
        public int PosY { get { return y; } }
        public int Dł { get { return kształtBloczka.GetLength(0); } }
        public int Sz { get { return kształtBloczka.GetLength(1); } }
        public int this[int i, int j]
        {
            get { return kształtBloczka[i, j]; }
        }

        public void PozycjaStartowa(int i)
        {
            x = i;
            y = 0;
        }
        public void MoveDown()
        {
            y++;
        }
        public void MoveLeft()
        {
            x--;
        }
        public void MoveRight()
        {
            x++;
        }

        public void ZamróźBloczek()
        {
            for (int j = 0; j < kształtBloczka.GetLength(1); j++)
            {
                for (int i = 0; i < kształtBloczka.GetLength(0); i++)
                    if (kształtBloczka[i, j] == 1)
                        kształtBloczka[i, j] = 2;
            }
        }
        public void Obrót(bool kierunekZegara)
        {
            int n = kształtBloczka.GetLength(0);
            int[,] StanPoObrocie = new int[n, n];
            int iterator = 0;
            if (kierunekZegara)
            {
                iterator = n - 1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        StanPoObrocie[iterator, i] = kształtBloczka[i, j];
                        iterator--;
                    }
                    iterator = n - 1;
                }
            }
            else
            {
                iterator = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    for (int j = 0; j < n; j++)
                    {
                        StanPoObrocie[j, iterator] = kształtBloczka[i, j];
                    }
                    iterator++;
                }
            }
            kształtBloczka = StanPoObrocie;
        }
    }
}
