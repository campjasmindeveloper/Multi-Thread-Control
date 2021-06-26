using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace YazLab12
{
    class girisThread
    {
        public static int[] queue=new int[4];

        public girisThread()
        {
            
        Thread th = new Thread(ThreadRun);
            queue[0] = 0; //1.kat
            queue[1] = 0;//2.kat
            queue[2] = 0;//.3.kat
            queue[3] = 0;//4.kat
            th.Start();
        }
        //0. katta bekleyen kişilerin hedef katlarını tutarız.
        public  void ThreadRun()
        {
            while (true)
            {
                Random rast = new Random();
                int gelen = rast.Next(1, 11);
                while (gelen != 0) {
                    int kat = rast.Next(0, 4);
                    int kat_gelen = rast.Next(1,gelen+1);
                    queue[kat] += kat_gelen;
                    gelen -=kat_gelen;
                }
                Thread.Sleep(500);
            }
           
        }
    }
}
