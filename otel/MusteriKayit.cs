using System;
using System.Collections;
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
    public partial class MusteriKayit : Form
    {

        public MusteriKayit()
        {
            InitializeComponent();
        }


        private string[] doluOdalarım = new string[0];

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            Musteri mus = new Musteri();
            mus.TCNo = Convert.ToInt64(textBox1.Text);
            mus.Ad = textBox2.Text;
            mus.Soyad = textBox3.Text;
            mus.DogumTarihi = dateTimePicker1.Value;
            mus.DogumYeri = textBox9.Text;
            mus.AnneAdi = textBox6.Text;
            mus.BabaAdi = textBox7.Text;
            Array.Resize(ref doluOdalarım, doluOdalarım.Length + 1);
            doluOdalarım[doluOdalarım.Length - 1] = textBox8.Text;

            Musteri yeniKayit = new Musteri();
            KayitOlustur(yeniKayit);

            ListViewItem lvi = ListviewİtemOlustur(yeniKayit);
            listView1.Items.Add(lvi);
            Temizle();

            }
            catch (Exception a)
            {

                MessageBox.Show("Bilgileri eksik girdiniz." +a +MessageBoxIcon.Warning);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Temizle()
        {
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
                else if (item is ComboBox)
                {
                    ComboBox com = (ComboBox)item;
                    com.SelectedIndex = 0;
                    com.Text = "";
                }
                else if (item is RadioButton)
                {
                    RadioButton rad = (RadioButton)item;
                    rad.Checked = false;
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)item;
                    dt.Value = DateTime.Now;
                }

            }
            foreach (var item in this.groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
                else if (item is ComboBox)
                {
                    ComboBox com = (ComboBox)item;
                    com.SelectedIndex = 0;
                    com.Text = "";
                }
                else if (item is RadioButton)
                {
                    RadioButton rad = (RadioButton)item;
                    rad.Checked = false;
                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)item;
                    dt.Value = DateTime.Now;
                }
                label20.Text = "";
                label21.Text = "";

            }
        }

        private void MusteriKayit_Load(object sender, EventArgs e)
        {
           // button1.Image = Image.FromFile("../../ArkaPlanResimleri/kaydetbutonu.jpg");
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox2.DataSource = Enum.GetValues(typeof(Enums.Cinsiyet));
            comboBox3.DataSource = Enum.GetValues(typeof(Enums.MedeniHali));
            comboBox4.DataSource = Enum.GetValues(typeof(Enums.KanGrubu));
            label24.Text = DateTime.Now.ToShortDateString();
            for (int i = 0; i < 3; i++)
            {
                foreach (FlowLayoutPanel item in panelOlustur())
                {
                    flowLayoutPanel1.Controls.Add(item);
                    foreach (Label Lab in kutucukOlustur())
                    {
                        Lab.Text = (Convert.ToInt32(Lab.Text) + i * 100).ToString();
                        item.Controls.Add(Lab);
                    }
                }
            }
        }

        private Musteri KayitOlustur(Musteri k)
        {
            k.TCNo = Convert.ToInt64(textBox1.Text);
            k.Ad = textBox2.Text;
            k.Soyad = textBox3.Text;
            k.DogumTarihi = dateTimePicker3.Value;
            k.DogumYeri = textBox9.Text;
            k.AnneAdi = textBox6.Text;
            k.BabaAdi = textBox7.Text;
            k.TelNo = Convert.ToInt64(textBox4.Text);
            k.GsmNo = Convert.ToInt64(textBox5.Text);
            k.Checkİn = dateTimePicker1.Value;
            k.CheckOut = dateTimePicker2.Value;
            k.Ucret = label20.Text.ToString();
            return k;
        }

        private ListViewItem ListviewİtemOlustur(Musteri k)
        {
            string[] bilgiler = { k.Ad, k.Soyad, k.TCNo.ToString(), k.GsmNo.ToString(), k.Checkİn.ToShortDateString(), k.CheckOut.ToShortDateString(), k.Ucret };

            ListViewItem lvi = new ListViewItem(bilgiler);

            return lvi;
        }

        double Ucret;


        private void button3_Click(object sender, EventArgs e)
        {
            TimeSpan fark;
            fark = DateTime.Parse(dateTimePicker2.Text) - DateTime.Parse(dateTimePicker1.Text);
            label21.Text = fark.TotalDays.ToString();


            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                Ucret = fark.TotalDays * 100;
            }
            else if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
                Ucret = fark.TotalDays * 150;
            }
            else
            {
                MessageBox.Show("Tek kişilik veya çift kişilik olduğunu belirtmediniz.");
            }

            label20.Text = Ucret.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        Musteri secili;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                secili = (Musteri)listView1.SelectedItems[0].Tag;
                textBox1.Text = secili.TCNo.ToString();
                textBox2.Text = secili.Ad;
                textBox3.Text = secili.Soyad;
                dateTimePicker3.Value = secili.DogumTarihi;
                textBox9.Text = secili.DogumYeri;
                textBox6.Text = secili.AnneAdi;
                textBox7.Text = secili.BabaAdi;
                textBox4.Text = secili.TelNo.ToString();
                textBox5.Text = secili.GsmNo.ToString();
                dateTimePicker1.Value = secili.Checkİn;
                dateTimePicker2.Value = secili.CheckOut;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("silmek istediğinize emin misiniz?", "uyari", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    listView1.SelectedItems[0].Remove();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Enabled = false;
            }
            else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Enabled = false;
            }
            else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
        }


        ArrayList Panel = new ArrayList();
        ArrayList TumPaneller = new ArrayList();

        private ArrayList panelOlustur()
        {
            Panel.Clear();
            FlowLayoutPanel F = new FlowLayoutPanel();
            F.Size = new Size(860, 70);
            F.BackColor = Color.Transparent;
            Panel.Add(F);
            TumPaneller.Add(F);
            return Panel;
        }

        private ArrayList kutucular = new ArrayList();
        private ArrayList kutucukOlustur()
        {
            kutucular.Clear();
            for (int i = 100; i <= 112; i++)
            {
                Label L = new Label();

                L.BackColor = Color.LightGreen;
                L.Size = new Size(60, 60);
                L.ForeColor = Color.White;
                L.Text = i.ToString();
                L.BorderStyle = BorderStyle.Fixed3D;
                L.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
                L.ImageAlign = ContentAlignment.MiddleCenter;
                L.TextAlign = ContentAlignment.MiddleCenter;

                if (i > 108)
                {
                    L.Image = Image.FromFile("../../YatakResimleri/Cift.png");
                }
                else
                {
                    L.Image = Image.FromFile("../../YatakResimleri/Tek.png");

                }
                L.Click += new EventHandler(P_Click);
                L.MouseDoubleClick += P_MouseDoubleClick;
                kutucular.Add(L);
            }
            return kutucular;
        }



        private void P_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            textBox8.Text = lbl.Text;


            foreach (FlowLayoutPanel Panel in TumPaneller)
            {
                foreach (Label item in Panel.Controls)
                {
                    if (Array.IndexOf(doluOdalarım, item.Text) == -1)
                    {
                        item.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        item.BackColor = Color.IndianRed;
                    }
                }
            }
            lbl.BackColor = Color.LightSkyBlue;
        }

        private void P_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
        }
       
        private void button4_Click_1(object sender, EventArgs e)
        {
           
            Rezervasyon kayit = new Rezervasyon();

            RezervasyonOlustur(kayit); 
            ListViewItem lvi2 = ListViewOlustur2(kayit);
           
            listView2.Items.Add(lvi2);
          

            
        }

        private Rezervasyon RezervasyonOlustur(Rezervasyon r )
        {
            r.Ad = txtRezAd.Text;
            r.Soyad = txtRezSyd.Text;
            r.GsmNo = Convert.ToInt64(mtxtRezTel.Text);
            r.CocukSayisi = Convert.ToInt32(numericUpDown1.Value);
            r.Checkİn = dtRezChkIn.Value;
            r.CheckOut = dtRezChkOut.Value;



            return r;
        }
        private ListViewItem ListViewOlustur2(Rezervasyon r)
        {
            string[] bilgiler2 = { r.Ad,r.Soyad,r.GsmNo.ToString(),r.Checkİn.ToString(),r.CheckOut.ToString(),lblRezUcrt1.Text,label24.Text};

            ListViewItem lvi2 = new ListViewItem(bilgiler2);



            return lvi2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TimeSpan fark1;
            fark1 = DateTime.Parse(dtRezChkOut .Text) - DateTime.Parse(dtRezChkIn .Text);

             Rezervasyon r = new Rezervasyon();
            if (comboBox1.SelectedIndex ==0)
            {
               
                if (radioButton5.Checked)
                { r.ucret1 = fark1.TotalDays * (100 + r.CocukSayisi * 50); }
                else if (radioButton6.Checked)
                    r.ucret1 = fark1.TotalDays * (150 + r.CocukSayisi * 50);
            }
            else if (comboBox1.SelectedIndex ==1)
            {
                if (radioButton6.Checked)
                    r.ucret1 = fark1.TotalDays * (100 + r.CocukSayisi * 50);
                else if (radioButton5.Checked)
                    MessageBox.Show("İki kişilik oda seçiniz");
            }

            lblRezUcrt1.Text = r.ucret1.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (listView2.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("silmek istediğinize emin misiniz?", "uyari", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    listView2.SelectedItems[0].Remove();
                }
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }   
}
