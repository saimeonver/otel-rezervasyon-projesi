using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otel
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 100; i <= 123; i++)
            {
                PictureBox P = new PictureBox();

                P.Text = i.ToString();
                P.Height = 60;
                P.Width = 80;
                P.BackColor = Color.Green;
                P.ForeColor = Color.Green;
                P.Image = Image.FromFile("../../NewFolder1/yk0out20170403011407.png");
                flowLayoutPanel1.Controls.Add(P);
                P.Click += new EventHandler(btn_click);
                P.MouseDoubleClick += new MouseEventHandler (Btn_DoubleClick);
            }

            for (int i = 124; i <= 153; i++)
            {
                PictureBox P = new PictureBox();

                P.Text = i.ToString();
                P.Height = 60;
                P.Width = 80;
                P.BackColor = Color.Lime;
                P.ForeColor = Color.Lime;
                P.Image = Image.FromFile("../../NewFolder1/images.png");
                flowLayoutPanel1.Controls.Add(P);
                P.Click += new EventHandler(btn_click);
                P.MouseDoubleClick += new MouseEventHandler(Btn_DoubleClick);
            }

        }

        private void Btn_DoubleClick(object sender, EventArgs e)
        {
            PictureBox Pi = sender as PictureBox;
            Müşteri_Kayıt mKayit = new Müşteri_Kayıt();
            mKayit.textBox8.Text = label1.Text;
         
            mKayit.Show();
            this.Hide();
        }

        private void btn_click(object sender, EventArgs e)
        {
            PictureBox Pi = sender as PictureBox;
            foreach (PictureBox item in flowLayoutPanel1.Controls)
            {
                if (item is PictureBox)
                {
                    if (Convert.ToInt32(item.Text) < 124)
                    {
                        item.BackColor = Color.Green;

                    }
                    else
                    {
                        item.BackColor = Color.Lime;

                    }
                }
            }
            Pi.BackColor = Color.IndianRed;
            label1.Text = Pi.Text;
        }
    }
}
