using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokVeEulerHesaplayici
{
    internal class Program
    {
        static double F(double x)
        {
            return x * x * x - 27;
        }

        static void KokBul(double min, double max)
        {
            double mid = 0;
            int sayac = 0;
            if (F(min) * F(max) > 0)
            {
                Console.WriteLine("Aradığınız aralıkta kök yok.");
                return;
            }
            while (Math.Abs(max - min) > 0.000001)
            {
                sayac++;
                mid = (min + max) / 2;
                if (F(mid) == 0) break;
                if (F(min) * F(mid) < 0)
                    max = mid;
                else
                    min = mid;
            }
            Console.WriteLine("Bulunan Kök: " + mid);
            Console.WriteLine("İterasyon Sayısı: " + sayac);
        }

        static void EulerHesapla()
        {
            double toplam = 0, gecicicarpim = 1, eskitoplam = 0;
            int i = 0;
            do
            {
                eskitoplam = toplam;
                gecicicarpim = 1;
                for (int j = 1; j <= i; j++)
                {
                    gecicicarpim *= j;
                }
                toplam += (1 / gecicicarpim);
                i++;
            } while (eskitoplam != toplam);
            Console.WriteLine("Euler Sabiti (e): " + toplam);
        }

        static void Main(string[] args)
        {
            KokBul(-100, 100);
            EulerHesapla();
            Console.ReadKey();
        }
    }
}
