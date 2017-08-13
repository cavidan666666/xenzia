using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yilan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        yilan yilanimiz = new yilan();
        istiqamet istiqametimiz;
        PictureBox[] pb_yilanparcalari;
        bool yem_varmi = false;
        Random rastGele = new Random();
        PictureBox pb_yem;
        private void Form1_Load(object sender, EventArgs e)
        {
            pb_yilanparcalari = new PictureBox[0];
            for(int i = 0; i < 3; i++)
            {
                Array.Resize(ref pb_yilanparcalari, pb_yilanparcalari.Length + 1);
                pb_yilanparcalari[i] = Pb_ekle();
            }
            timer1.Start();
        }
        
        private PictureBox Pb_ekle()
        {
            
            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 10);
            pb.BackColor = Color.White;
            pb.Location = yilanimiz.GetPos(pb_yilanparcalari.Length - 1);
            panel1.Controls.Add(pb);
            return pb;
        }

        private void Pb_guncelle()
        {
            for(int i = 0; i < pb_yilanparcalari.Length; i++)
            {
                pb_yilanparcalari[i].Location = yilanimiz.GetPos(i);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up || e.KeyCode == Keys.W)
            {
                istiqametimiz = new istiqamet(0, -10);

            }else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                istiqametimiz = new istiqamet(0, 10);

            }else if(e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                istiqametimiz = new istiqamet(-10, 0);

            }else if(e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                istiqametimiz = new istiqamet(10, -0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            yilanimiz.hereketEt(istiqametimiz);
            Pb_guncelle();
            Yem_Olustur();
            yemi_yedikmi();
        }
        public void Yem_Olustur()
        {
            if (!yem_varmi) { 
            PictureBox pb = new PictureBox();
            pb.BackColor = Color.Red;
            pb.Size = new Size(10, 10);
            pb.Location = new Point(rastGele.Next(panel1.Width / 10) * 10, rastGele.Next(panel1.Height / 10) * 10);
            pb_yem = pb;
            yem_varmi = true;
            panel1.Controls.Add(pb);
        }
        }
        public void yemi_yedikmi()
        {
            if (yilanimiz.GetPos(0) == pb_yem.Location)
            {
                yilanimiz.boyu();
                Array.Resize(ref pb_yilanparcalari, pb_yilanparcalari.Length + 1);
                pb_yilanparcalari[pb_yilanparcalari.Length - 1] = Pb_ekle();
                yem_varmi = false;
                panel1.Controls.Remove(pb_yem);

            }
        }
    }
}
