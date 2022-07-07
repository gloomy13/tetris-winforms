using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Obiekt7 : Bloczek // 1 1 0 
    {                              // 0 1 1 
                                   // 0 0 0 

        public Obiekt7() : base()
        {
            rozmiar = 3;
            kształtBloczka = new int[rozmiar, rozmiar];
            kształtBloczka[0, 0] = 1;
            kształtBloczka[1, 0] = 1;
            kształtBloczka[1, 1] = 1;
            kształtBloczka[2, 1] = 1;
        }
    }
}
