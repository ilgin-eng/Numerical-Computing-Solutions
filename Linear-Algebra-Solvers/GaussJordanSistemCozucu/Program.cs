using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussJordanSistemCozucu
{
    internal class Program
    {
        static void KosegenYap(float[,] matris)
        {
            float temp;
            while (matris[0, 0] == 0 || matris[1, 1] == 0 || matris[2, 2] == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = i + 1; j < 3; j++)
                    {
                        if (matris[0, 0] == 0 || matris[1, 1] == 0 || matris[2, 2] == 0)
                        {
                            for (int a = 0; a < 4; a++)
                            {
                                temp = matris[i, a];
                                matris[i, a] = matris[j, a];
                                matris[j, a] = temp;
                            }
                        }
                    }
                }
            }
        }
        static void BirleBaslat(float[,] matris, int satir)
        {
            float katsayi = (float)1 / matris[satir, satir];
            for (int i = 0; i < 4; i++)
            {
                matris[satir, i] *= katsayi;
            }
        }
        static void Islem(float[,] matris, int satir)
        {
            float katsayi;
            for (int i = satir + 1; i < 3; i++)
            {
                katsayi = -matris[i, satir];
                for (int j = 0; j < 4; j++)
                {
                    matris[i, j] = matris[i, j] + katsayi * matris[satir, j];
                }
            }
        }
        static void Islem2(float[,] matris, int satir)
        {
            float katsayi;
            for (int i = satir - 1; i >= 0; i--)
            {
                katsayi = -matris[i, satir];
                for (int j = 0; j < 4; j++)
                {
                    matris[i, j] = matris[i, j] + katsayi * matris[satir, j];
                }
            }
        }
        static void MatrisYazdir(float[,] matris)
        {
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    Console.Write(matris[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            float[,] matris = new float[3, 4];
            Console.WriteLine("Sırasıyla 1. denklemdeki x,y,z'nin katsayısını ve eşitliğin solundaki sayıyı,\n" +
                "2. denklemdeki x,y,z'nin katsayısını ve eşitliğin solundaki sayıyı,\n" +
                "3. denklemdeki x,y,z'nin katsayısını ve eşitliğin solundaki sayıyı giriniz.");
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                    matris[i, j] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < 3; i++)
            {
                if (matris[i, 0] == 0 && matris[i, 1] == 0 && matris[i, 2] == 0)
                    Environment.Exit(0);
            }
            KosegenYap(matris);
            MatrisYazdir(matris);
            BirleBaslat(matris, 0);
            MatrisYazdir(matris);
            Islem(matris, 0);
            MatrisYazdir(matris);
            BirleBaslat(matris, 1);
            MatrisYazdir(matris);
            Islem(matris, 1);
            MatrisYazdir(matris);
            BirleBaslat(matris, 2);
            MatrisYazdir(matris);
            Islem2(matris, 2);
            MatrisYazdir(matris);
            Islem2(matris, 1);
            MatrisYazdir(matris);
            Islem2(matris, 0);
            MatrisYazdir(matris);
            Console.WriteLine("X = " + matris[0, 3]);
            Console.WriteLine("Y = " + matris[1, 3]);
            Console.WriteLine("Z = " + matris[2, 3]);
        }
    }
}
