using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomRegresyonAnalizi
{
    internal class Program
    {
        static float yussu(float x, float[] a)
        {
            float top = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                top += a[i] * (float)Math.Pow(x, i);
            }
            return top;
        }
        static float E(float[] y, float[] x, float[] a)
        {
            float top = 0;
            for (int i = 0; i < x.Length; i++)
            {
                top += (float)Math.Pow(y[i] - yussu(x[i], a), 2);
            }
            return top;
        }
        static float Toplam(float[] x, int kuvvet)
        {
            float top = 0;
            for (int i = 0; i < x.Length; i++)
            {
                top += (float)Math.Pow(x[i], kuvvet);
            }
            return top;
        }
        static float SagTaraf(float[] x, float[] y, int kuvvet)
        {
            float top = 0;
            for (int i = 0; i < x.Length; i++)
                top += y[i] * (float)Math.Pow(x[i], kuvvet);
            return top;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Kaç veri gireceksin?");
            int verisayisi = Convert.ToInt32(Console.ReadLine());
            float[] x = new float[verisayisi];
            float[] y = new float[verisayisi];
            Console.WriteLine("Lütfen x'leri gir:");
            for (int i = 0; i < x.Length; i++)
                x[i] = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Lütfen y'leri gir:");
            for (int i = 0; i < y.Length; i++)
                y[i] = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Kaçıncı derecedene uydurmak istiyorsun?");
            int mertebe = Convert.ToInt32(Console.ReadLine());
            int n = mertebe + 1;
            //float[] x = {3,7,8,33,11,19,44};
            //float[] y = { 48,184,233,3408,416,1168,5993};
            float[,] dizi = new float[n, n + 1];
            for (int i = 0; i < dizi.GetLength(0); i++)
            {
                for (int j = 0; j < dizi.GetLength(1); j++)
                {
                    if (j < dizi.GetLength(1) - 1)
                        dizi[i, j] = Toplam(x, i + j);
                    else
                        dizi[i, j] = SagTaraf(x, y, i);
                }
            }
            float[] a = new float[n];
            for (int i = 0; i < a.Length; i++)
                a[i] = 0;
            float pay;
            for (int sayac = 0; sayac < 100; sayac++)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    pay = dizi[i, dizi.GetLength(1) - 1];
                    for (int j = 0; j < dizi.GetLength(1) - 1; j++)
                    {
                        if (i == j) continue;
                        pay -= dizi[i, j] * a[j];
                    }
                    a[i] = pay / dizi[i, i];
                }
            }
            Console.WriteLine("En iyi polinom yaklaşımı:");
            for (int i = n - 1; i >= 0; i--)
                Console.Write(Math.Round(a[i], 3) + "x^" + i + "\t");
            Console.WriteLine();
            Console.WriteLine("Hata:" + Math.Round(E(y, x, a), 4));
            Console.WriteLine("Kaçıncı derecedene uydurmak istiyorsun?");
            int mertebe2 = Convert.ToInt32(Console.ReadLine());
            int n2 = mertebe2 + 1;
            float[] x2 = x;
            float[] y2 = y;
            float[,] dizi2 = new float[n2, n2 + 1];
            for (int i = 0; i < dizi2.GetLength(0); i++)
            {
                for (int j = 0; j < dizi2.GetLength(1); j++)
                {
                    if (j < dizi2.GetLength(1) - 1)
                        dizi2[i, j] = Toplam(x, i + j);
                    else
                        dizi2[i, j] = SagTaraf(x, y, i);
                }
            }
            float[] a2 = new float[n2];
            for (int i = 0; i < a2.Length; i++)
                a2[i] = 0;
            float pay2;
            for (int sayac = 0; sayac < 100; sayac++)
            {
                for (int i = 0; i < a2.Length; i++)
                {
                    pay2 = dizi2[i, dizi2.GetLength(1) - 1];
                    for (int j = 0; j < dizi2.GetLength(1) - 1; j++)
                    {
                        if (i == j) continue;
                        pay2 -= dizi2[i, j] * a2[j];
                    }
                    a2[i] = pay2 / dizi2[i, i];
                }
            }
            Console.WriteLine("En iyi polinom yaklaşımı:");
            for (int i = n2 - 1; i >= 0; i--)
                Console.Write(Math.Round(a2[i], 3) + "x^" + i + "\t");
            Console.WriteLine();
            Console.WriteLine("Hata:" + Math.Round(E(y2, x2, a2), 4));
            if (Math.Round(E(y2, x2, a2), 4) >= Math.Round(E(y, x, a), 4))
                Console.WriteLine("İlk tahminin daha iyi");
            else
                Console.WriteLine("İkinci tahminin daha iyi");
        }
    }
}
