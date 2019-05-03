using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab01
{
    public static class Helper
    {
        public static void dosyaOlustur()
        {
            FileStream fs = File.Create(pathDondur());
            fs.Close();
        }

        public static void dosya(int number)
        {
            if (File.Exists(pathDondur()))
            {
                int x = 15;
                StreamWriter dosyaYaz = File.AppendText(pathDondur());
                // ? dosyaYaz.WriteLine();
                dosyaYaz.WriteLine(number);
                dosyaYaz.Close();

            }
            else
            {
                dosyaOlustur();
                dosya(number);
            }

        }

        public static int enYuksekPuanDondur()
        {
            int enYuksekSkor = -10001;
            try
            {
                StreamReader sr = new StreamReader(pathDondur());

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int dosyadakiSayi = 0;
                    try
                    {
                        dosyadakiSayi = Int32.Parse(line);
                    }
                    catch (Exception e)
                    {

                    }


                    if (dosyadakiSayi > enYuksekSkor)
                    {
                        enYuksekSkor = dosyadakiSayi;
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
            }
            return enYuksekSkor;
        }

        public static string pathDondur()
        {
            return @"C:\Users\mtozc\source\repos\Yazlab01\enyuksekskor.txt";
        }


        public static void resimleriSiraliGoster(GroupBox groupBox1, List<Bitmap> resim16parca)
        {
            // Image ımg = resim16parca[0];
            for (int i = 0; i < 16; i++)
            {
                ((Button)groupBox1.Controls["button" + (i + 2).ToString()]).Image = resim16parca[i];
            }

        }
        public static List<int> RastgeleSayilar()
        {
            Random rastgele = new Random();
            List<int> rastgeleSayilar = new List<int>(16);
            int sayi;
            for (int i = 0; i < 16; i++)
            {
                do
                {
                    sayi = rastgele.Next(0, 16);

                } while (rastgeleSayilar.Contains(sayi));

                rastgeleSayilar.Add(sayi);

            }
            return rastgeleSayilar;
        }
        /***/
        public static List<int> resimleriKaristir(GroupBox groupBox1, List<Bitmap> resim16parca)
        {
            /*Sayilari aldık List<int> attık rastgele sayilar geldi.*/
            List<int> rastgeleSayilar = RastgeleSayilar();
            for (int i = 0; i < 16; i++)
            {
                //Ana dizi değiştirilmeden sadece resim parçalarının indexi değiştirilerek atandı.
                ((Button)groupBox1.Controls["button" + (i + 2).ToString()]).Image = resim16parca[rastgeleSayilar[i]];
            }
            return rastgeleSayilar;
        }

        //Karıştır butonuna tıklandığında 1 parça doğrumu kontrol eder.
        public static int BirParcaDogrumuIndex(List<Bitmap> resim16parca, Bitmap secilenParca)
        {
            int i = -1;
            //  int sayi = resim16parca.IndexOf(secilenParca);
            foreach (var item in resim16parca)
            {
                i++;
                if (secilenParca == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool BirParcaDogrumu(List<Bitmap> resim16parca, Bitmap secilenParca, int butonIndex)
        {
            int index = BirParcaDogrumuIndex(resim16parca, secilenParca);

            if (butonIndex == index)
            {
                return true;
            }


            return false;
        }
        public static int sayiDondur(string str)
        {
            for (int i = 2; i < 18; i++)
            {
                if (str.Contains("button" + i.ToString()))
                {
                    return i;
                }

            }
            return 0;
        }

        public static int butonResimDegistir(GroupBox groupBox1, Button button, PictureBox pictureBox1, int global, List<Bitmap> resim16parca)
        {
            string str = button.Name;
            int donensayi = sayiDondur(str);

            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = button.Image;

                global = donensayi;

            }
            else if (pictureBox1.Image != null)
            {
                // ((Button)groupBox1.Controls["button" + (i + 2).ToString()]).Image = resimParcaListesi[rastgeleSayilar[i]];
                ((Button)groupBox1.Controls["button" + global.ToString()]).Image = button.Image;
                button.Image = pictureBox1.Image;
                pictureBox1.Image = null;
                kontrol(groupBox1, resim16parca);

            }


            return global;
        }


        public static void kontrol(GroupBox groupBox1, List<Bitmap> resim16parca)
        {
            //((Button)groupBox1.Controls["button" + global.ToString()]).Image;
            for (int i = 2; i < 18; i++)
            {
                Image img = ((Button)groupBox1.Controls["button" + i.ToString()]).Image;
                if (img == resim16parca[i - 2])
                {
                    ((Button)groupBox1.Controls["button" + i.ToString()]).Enabled = false;

                }

            }
        }

        public static int puanla(GroupBox groupBox1, int hamleSayisi, int puan, Label puanyaz, Button karistir)
        {

            int dogruElemanSayisi = 0;
            for (int i = 0; i < 16; i++)
            {
                if (!((Button)groupBox1.Controls["button" + (i + 2).ToString()]).Enabled)
                {
                    dogruElemanSayisi++;
                }
            }
            if (karistir.Enabled == false && dogruElemanSayisi == 16)
            {
                MessageBox.Show("Tebrikler oyunu bitirdiniz puanınız:" + puan);
                dosya(puan);
                System.Environment.Exit(1);
            }


            if (puan == 0)
            {
                return 0;
            }


            if (karistir.Enabled)
            {


                if (dogruElemanSayisi == 16)
                {
                    puanyaz.Text = "Puanınınız:" + puan;
                    MessageBox.Show("Tebrikler Oyunu 100 puanla kazandınız...");
                    dosya(puan);
                    System.Environment.Exit(1);

                }
                else
                {
                    puan = (100 - (16 - dogruElemanSayisi) * 1);
                    puanyaz.Text = "Puanınız:" + puan;
                }

            }
            else
            {
                puan = puan - 1;
                puanyaz.Text = "Puanınız:" + puan;
            }
            if (dogruElemanSayisi > 2)
            {
                karistir.Enabled = false;
            }
            if (puan < 0)
            {
                puan = 1;
            }
            return puan;
        }


    }

}