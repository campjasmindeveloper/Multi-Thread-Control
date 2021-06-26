using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
 
namespace YazLab12
{
    public partial class Form1 : Form
    {
        int a = 0;
        girisThread giris;  
        cikisThread cikis; 
        asansor Asansor,Asansor2,Asansor3,Asansor4,Asansor5;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            giris = new girisThread();
            cikis = new cikisThread();
            Asansor = new asansor();
            Asansor2 = new asansor();
            Asansor3 = new asansor();
            Asansor4 = new asansor();
            Asansor5 = new asansor();
            Asansor.aktiflik = true;
            Thread kontrol = new Thread(asansorKontrol); //kontrol threadi oluşturduk
            kontrol.Start();

        }


        public void asansorKontrol()
        {
            while (true) { 
            int kuyrukSayisi = 0;  //kuyruklarda bekleyen kişi sayısı yazdırdık.
            for(int i = 0; i < 4; i++) {
               kuyrukSayisi+= girisThread.queue[i];
               kuyrukSayisi += cikisThread.queue[i];

            }

            if (Asansor5.aktiflik)
            {
                if (kuyrukSayisi < 50)
                {
                    Asansor5.aktiflik = false;
                }
            }else if (Asansor4.aktiflik)
            {
                if (kuyrukSayisi < 40)
                {
                    Asansor4.aktiflik = false;  
                }else if (kuyrukSayisi > 80)
                {
                    Asansor5.aktiflik = true;
                }
                

            }else if (Asansor3.aktiflik)
            {
                if (kuyrukSayisi < 30)
                {
                    Asansor3.aktiflik = false;
                }
                else if (kuyrukSayisi > 60)
                {
                    Asansor4.aktiflik = true;
                }
            }
            else if (Asansor2.aktiflik)
            {
                if (kuyrukSayisi < 20)
                {
                    Asansor2.aktiflik = false;
                }
                else if (kuyrukSayisi > 40)
                {
                    Asansor3.aktiflik = true;
                }
            }
            else if (Asansor.aktiflik)
            {
           
                if (kuyrukSayisi > 20)
                {
                    Asansor2.aktiflik = true;
                }
            }

            }

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            KuyrukGuncelle();
            AsansorGuncelle();

        }
        void AsansorGuncelle()
        {
            asansor_adi1.Text = "Asansör:1";
            asansor_aktif1.Text = "Aktif" + Asansor.aktiflik;
            asansor_icerdekiler1.Text = "İçerdekiler: [" + Asansor.bulunanlar[0] + "][" + Asansor.bulunanlar[1] + "][" + Asansor.bulunanlar[2] + "][" + Asansor.bulunanlar[3] + "][" + Asansor.bulunanlar[4] + "]";
            asansor_icerdekiSayisi1.Text = "İçerdeki Sayısı:" + Asansor.bulunanSayisi;
            asansor_kat1.Text = "Kat:" + Asansor.floor;
            if (Asansor.yon)
                asansor_yon1.Text = "Yön:Yukarı";
            else
                asansor_yon1.Text = "Yön:Aşağı";
            // asansör 1 sonu
            asansor_adi2.Text = "Asansör:2";
            asansor_aktif2.Text = "Aktif" + Asansor2.aktiflik;
            asansor_icerdekiler2.Text = "İçerdekiler: [" + Asansor2.bulunanlar[0] + "][" + Asansor2.bulunanlar[1] + "][" + Asansor2.bulunanlar[2] + "][" + Asansor2.bulunanlar[3] + "][" + Asansor2.bulunanlar[4] + "]";
            asansor_icerdekiSayisi2.Text = "İçerdeki Sayısı:" + Asansor2.bulunanSayisi;
            asansor_kat2.Text = "Kat:" + Asansor2.floor;
            if (Asansor2.yon)
                asansor_yon2.Text = "Yön:Yukarı";
            else
                asansor_yon2.Text = "Yön:Aşağı";
            // asansör 2 sonu

            asansor_adi3.Text = "Asansör:3";
            asansor_aktif3.Text = "Aktif" + Asansor3.aktiflik;
            asansor_icerdekiler3.Text = "İçerdekiler: [" + Asansor3.bulunanlar[0] + "][" + Asansor3.bulunanlar[1] + "][" + Asansor3.bulunanlar[2] + "][" + Asansor3.bulunanlar[3] + "][" + Asansor3.bulunanlar[4] + "]";
            asansor_icerdekiSayisi3.Text = "İçerdeki Sayısı:" + Asansor3.bulunanSayisi;
            asansor_kat3.Text = "Kat:" + Asansor3.floor;
            if (Asansor3.yon)
                asansor_yon3.Text = "Yön:Yukarı";
            else
                asansor_yon3.Text = "Yön:Aşağı";
            // asansör 3 sonu

            asansor_adi4.Text = "Asansör:4";
            asansor_aktif4.Text = "Aktif" + Asansor4.aktiflik;
            asansor_icerdekiler4.Text = "İçerdekiler: [" + Asansor4.bulunanlar[0] + "][" + Asansor4.bulunanlar[1] + "][" + Asansor4.bulunanlar[2] + "][" + Asansor4.bulunanlar[3] + "][" + Asansor4.bulunanlar[4] + "]";
            asansor_icerdekiSayisi4.Text = "İçerdeki Sayısı:" + Asansor4.bulunanSayisi;
            asansor_kat4.Text = "Kat:" + Asansor4.floor;
            if (Asansor4.yon)
                asansor_yon4.Text = "Yön:Yukarı";
            else
                asansor_yon4.Text = "Yön:Aşağı";
            // asansör 4 sonu

            asansor_adi5.Text = "Asansör:5";
            asansor_aktif5.Text = "Aktif" + Asansor5.aktiflik;
            asansor_icerdekiler5.Text = "İçerdekiler: [" + Asansor5.bulunanlar[0] + "][" + Asansor5.bulunanlar[1] + "][" + Asansor5.bulunanlar[2] + "][" + Asansor5.bulunanlar[3] + "][" + Asansor5.bulunanlar[4] + "]";
            asansor_icerdekiSayisi5.Text = "İçerdeki Sayısı:" + Asansor5.bulunanSayisi;
            asansor_kat5.Text = "Kat:" + Asansor5.floor;
            if (Asansor5.yon)
                asansor_yon5.Text = "Yön:Yukarı";
            else
                asansor_yon5.Text = "Yön:Aşağı";
            // asansör 5 sonu
        }
        void KuyrukGuncelle()
        {
            int girisSayisi = girisThread.queue[0] + girisThread.queue[1] + girisThread.queue[2] + girisThread.queue[3];
            kat0KuyrukSayısı.Text = "0.kat :All: Kuyruk:" + girisSayisi;
            kat1KuyrukSayisi.Text = "1.kat :All:" + asansor.katBulunanlar[1] + "    Kuyruk:" + cikisThread.queue[0];
            kat2KuyrukSayisi.Text = "2.kat :All:" + asansor.katBulunanlar[2] + "    Kuyruk:" + cikisThread.queue[1];
            kat3KuyrukSayisi.Text = "3.kat :All:" + asansor.katBulunanlar[3] + "    Kuyruk:" + cikisThread.queue[2];
            kat4KuyrukSayisi.Text = "4.kat :All:" + asansor.katBulunanlar[4] + "    Kuyruk:" + cikisThread.queue[3];
            ZeminKatKuyruk.Text = "0.kat : " +
                 "[" + girisThread.queue[0] + ",1]," +
                 "[" + girisThread.queue[1] + ",2]," +
                 "[" + girisThread.queue[2] + ",3]," +
                 "[" + girisThread.queue[3] + ",4]";
            BirinciKatKuyruk.Text = "1.kat :"
            + "[" + cikisThread.queue[0] + ",0]";
            IkinciKatKuyruk.Text = "2.kat :"
            + "[" + cikisThread.queue[1] + ",0]";
            UcuncuKatKuyruk.Text = "3.kat :"
            + "[" + cikisThread.queue[2] + ",0]";
            DorduncuKatKuyruk.Text = "4.kat :"
            + "[" + cikisThread.queue[3] + ",0]";
            cikisSayisi.Text = "Çıkış Sayısı :" + asansor.katBulunanlar[0];
        }
    }
}
