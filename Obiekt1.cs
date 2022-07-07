using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Obiekt1 : Bloczek  // 0 0 0 0
    {                               // 1 1 1 1
                                    // 0 0 0 0  
                                    // 0 0 0 0                                   
        public Obiekt1() : base()
        {
            kształtBloczka = new int[rozmiar, rozmiar];
            for (int i = 0; i < rozmiar; i++)
                kształtBloczka[i, 1] = 1;
        }
    }
}
