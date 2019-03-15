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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 f = new Form2();
        private void button2_Click(object sender, EventArgs e)
        {
            
            Admin admn = new Admin();
            admn.KullanıcıAdı = textBox1.Text;
            admn.KullanıcıAdı = textBox2.Text;

            if(textBox1.Text=="admin" && textBox2.Text=="admin")
            {
                MessageBox.Show("Başarıyla giriş yapıldı");

                Form2 f = new Form2();
                f.Show();
            }
            else
                MessageBox.Show("YANLIŞ GİRİŞ YAPTINIZ TEKRAR DENEYİN");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
