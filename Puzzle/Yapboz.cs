using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab01
{
    public partial class Yapboz : Form
    {
        public Yapboz()
        {

        }
        public Yapboz(Image secilenResim)
        {
            InitializeComponent();

            Image boluncekResim = secilenResim;
            boluncekResim = (Image)(new Bitmap(boluncekResim, new Size(800, 600)));
            int resimUzunluğu = 150;
            int resimYuksekliği = 122;
            Bitmap[,] resimParcalari = new Bitmap[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    resimParcalari[i, j] = new Bitmap(resimUzunluğu, resimYuksekliği);
                    Graphics g = Graphics.FromImage(resimParcalari[i, j]);
                    g.DrawImage(boluncekResim, new Rectangle(0, 0, resimUzunluğu, resimYuksekliği), new Rectangle(j * resimUzunluğu, i * resimYuksekliği, resimUzunluğu, resimYuksekliği), GraphicsUnit.Pixel);
                    g.Dispose();

                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    resim16Parca.Add(resimParcalari[i, j]);
                }

            }
            Helper.resimleriKaristir(groupBox1, resim16Parca);
        }
        //RESİMİN 16 PARÇASI buradaki generic listte tutulur.
        //BUTON 1 KARIŞTIR BUTONUDUR 2-17. BUTONLAR RESİMLERİN TUTULDUĞU BUTONLARDIR.
        static List<Bitmap> resim16Parca = new List<Bitmap>(16);
        int global = -1;
        int hamlesayisi = 1;
        int puan = 100;



        private void button1_Click(object sender, EventArgs e)
        {
            Helper.resimleriKaristir(groupBox1, resim16Parca);
            Helper.kontrol(groupBox1, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void Yapboz_Load(object sender, EventArgs e)
        {
            int maxScore = Helper.enYuksekPuanDondur();
            label1.Text = "En yüksek skor:" + maxScore.ToString();
        }
        // RESMİN OLDUĞU BUTONLAR
        private void button2_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button2, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button3, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button4, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button5, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button6, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button7, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button8, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button9, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button10, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button11, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button12, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button13, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button14, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button15, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button16, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            global = Helper.butonResimDegistir(groupBox1, button17, pictureBox1, global, resim16Parca);
            puan = Helper.puanla(groupBox1, hamlesayisi, puan, label2, button1);
        }
    }
}