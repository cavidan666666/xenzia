using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace yilan
{
    class yilan
    {
        yilan_Parcalari[] yilan_parca;
        int yilan_buyuklugu;
        istiqamet istiqametimiz;

        public yilan()
        {
            yilan_parca = new yilan_Parcalari[3];
            yilan_buyuklugu = 3;
            yilan_parca[0] = new yilan_Parcalari(150, 150);
            yilan_parca[1] = new yilan_Parcalari(150, 160);
            yilan_parca[2] = new yilan_Parcalari(170, 150);

        }
        public void hereketEt(istiqamet istiqamet)

        {
            istiqametimiz = istiqamet;
            if(istiqamet != null)
            {
                for(int i = yilan_parca.Length - 1; i < 0; i--)
                {
                    yilan_parca[i] = new yilan_Parcalari(yilan_parca[i - 1].x_, yilan_parca[i - 1].y_);
                }
                yilan_parca[0] = new yilan_Parcalari(yilan_parca[0].x_ + istiqamet._x, yilan_parca[0].y_ + istiqamet._y);
            }

        }
        public void boyu()
        {
            Array.Resize(ref yilan_parca, yilan_parca.Length + 1);
            yilan_parca[yilan_parca.Length-1]=new yilan_Parcalari(yilan_parca[yilan_parca.Length-2].x_-istiqametimiz._x, yilan_parca[yilan_parca.Length - 2].y_-istiqametimiz._y);
            yilan_buyuklugu++;

        }
        public Point GetPos(int number)
        {
            return new Point(yilan_parca[number].x_, yilan_parca[number].y_);
        }
    }
    class yilan_Parcalari
    {
        public int x_;
        public int y_;
        public readonly int size_x;
        public readonly int size_y;
        public yilan_Parcalari(int x, int y)
        {
            x_ = x;
            y_ = y;
            size_x = 10;
            size_y = 10;

        }
    }
    class istiqamet
    {
        public readonly int _x;
        public readonly int _y;
        public istiqamet(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
