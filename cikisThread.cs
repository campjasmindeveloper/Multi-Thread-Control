using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace YazLab12
{
    class cikisThread
    {
        public static int[] queue = new int[4];
        Random rast = new Random();
        //zemin kata gitmek isteyen kişilerin katlardaki kişi sayısını tutarız.

        public cikisThread()
        {
            Thread th = new Thread(ThreadRun);
            queue[0] = 0;
            queue[1] = 0;
            queue[2] = 0;
            queue[3] = 0;
            th.Start();
        }
        public void ThreadRun()
        {
            while (true)
            {
                int giden = rast.Next(1, 5);
                bool[] kontrol = {false,false,false,false};//4 kat için kontrol yapısı kurduk
                while (giden != 0)
                {
                    int kat = rast.Next(0, 4);
                    if (!kontrol[kat]) { 
                    int kat_giden = rast.Next(1, giden+1);
                    queue[kat] += kat_giden;
                    giden -= kat_giden;
                        kontrol[kat] = true;
                    }
                }
                
                Thread.Sleep(1000); // 1000 ms bekleme süresi
            }

        }
    }
}
