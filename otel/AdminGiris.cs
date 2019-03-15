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
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            Admin admn = new Admin();
            admn.KullanıcıAdı = textBox1.Text;
            admn.KullanıcıAdı = textBox2.Text;

            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                foreach (var item in panel2.Controls)
                {
                    if (item is TextBox)
                    {
                        ((TextBox)item).Visible = false;
                    }
                    else if (item is Label)
                    {
                        ((Label)item).Visible = false;
                    }
                    else if (item is Button)
                    {
                        ((Button)item).Visible = false;
                    }
                }
                panel2.BackgroundImageLayout = ImageLayout.Stretch;
                panel2.BackgroundImage = Image.FromFile("../../ArkaPlanResimleri/BudapestHotelName.png");
                panel2.Location = new Point(27, 12);
                
                pictureBox1.Image = Image.FromFile("../../ArkaPlanResimleri/BudapestHotelLogo.png");
                panel1.Visible = true;

            }
            else
                MessageBox.Show("YANLIŞ GİRİŞ YAPTINIZ TEKRAR DENEYİN");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MusteriKayit Mk = new MusteriKayit();
            this.Hide();
            Mk.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MusteriKayit m = new MusteriKayit();
            this.Hide();
            m.Show();
            m.tabControl1.SelectTab(1);
        }
    }
}
