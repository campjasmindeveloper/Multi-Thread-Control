using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace YazLab12
{

    class asansor
    {
        public int floor,bulunanSayisi;
        public int[] bulunanlar = {0, 0, 0, 0, 0};////asansörde bulunup da 0,1,2,3 kata gitmek isteyenler sayisi
        public static int[] katBulunanlar = { 0, 0, 0, 0, 0 };//avm de katlardan bulunanların sayısı sadece asansör classı içndedir
        public bool yon, aktiflik;// yön bilgisi true ise yukarı false ise asağı
        Random rast = new Random();
        public asansor()
        {
            aktiflik = false;
            yon = true;
            floor = 0;
            Thread tr = new Thread(ThreadRun);
            tr.Start(); //oluşan thread başlatılır.
        }

        public void ThreadRun()
        {
            while (true)
            {
                bulunanSayisi = bulunanlar[0] + bulunanlar[1] + bulunanlar[2] + bulunanlar[3]+ bulunanlar[4]  ;//bulunan sayısı güncellem
                if (bulunanSayisi < 0)
                {
                    Console.WriteLine("1.çıktı "+ bulunanlar[0] +" " +bulunanlar[1] +" "+ bulunanlar[2] +" "+ bulunanlar[3] + " " + bulunanlar[4]);
                }
                if (aktiflik) //aktif ise InsanAl InsanIndir,dolaşma fonksiyonlarını çalıştır.
                {
                    InsanIndir();
                    if (bulunanSayisi < 0)
                    {
                        Console.WriteLine("2.çıktı " + bulunanlar[0] + " " + bulunanlar[1] + " " + bulunanlar[2] + " " + bulunanlar[3] + " " + bulunanlar[4]);
                    }
                    InsanAl();
                    if (bulunanSayisi < 0)
                    {
                        Console.WriteLine("3.çıktı " + bulunanlar[0] + " " + bulunanlar[1] + " " + bulunanlar[2] + " " + bulunanlar[3] + " " + bulunanlar[4]);
                    }
                    dolasma();
                }
                else
                {
                    if(bulunanSayisi>0)
                    {
                        InsanIndir();
                        dolasma();
                    }
                }
              
                Thread.Sleep(200); // 200 ms bekleme süresi
            }

        }
        public void InsanIndir()
        {
            if (bulunanlar[floor] > 0)
            {
                katBulunanlar[floor] += bulunanlar[floor];
                bulunanlar[floor] = 0;
            }
        }
            public void dolasma() //katlar arası dolaşma işlemi yapar
        {
            if (yon)
            {
                if (floor == 4)
                {
                    floor--;
                    yon = false;
                }
                else
                {
                    floor++;
                }
            }
            else
            {
                if (floor == 0)
                {
                    floor++;
                    yon = true;
                }
                else
                {
                    floor--;
                }
            }
        }
        public void InsanAl()
        {
            while(bulunanSayisi < 10)
            {
                bulunanSayisi = bulunanlar[0] + bulunanlar[1] + bulunanlar[2] + bulunanlar[3] + bulunanlar[4];

                if (floor == 0) {
                    int kat = rast.Next(1, 5);// 1. ve 4. kat arasından rastgele bir kat seçiyor.
                    if (girisThread.queue[kat-1] >0) { 
                    bulunanlar[kat]++;
                    girisThread.queue[kat-1]--;
                    }

                }
                else
                {
                    int alinabilecek = 10 - bulunanSayisi;
                    if(alinabilecek<= cikisThread.queue[floor - 1]) { 
                        bulunanlar[0] += alinabilecek;
                        cikisThread.queue[floor - 1] -= alinabilecek;
                    }
                    else
                    {
                        break;
                    }
                
                }
                
            }
        }
    }
}
