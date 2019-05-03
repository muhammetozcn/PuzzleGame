using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Yazlab01
{
    public partial class Baslangic : Form
    {
        public Baslangic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim seçiniz |*.jpeg;*.png;*.jpg";
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FileInfo file = new FileInfo(openFileDialog1.FileName);
            FileStream fileStream = file.OpenRead();
            Image secilenResim = Image.FromStream(fileStream);
            Yapboz oyunuBaslat = new Yapboz(secilenResim);
            this.Visible = false;
            oyunuBaslat.Visible = true;


        }

        private void Baslangic_Load(object sender, EventArgs e)
        {

        }
    }
}