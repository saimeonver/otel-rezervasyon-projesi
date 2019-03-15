using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otel
{
    class Musteri
    {
        public long TCNo
        {
            get { return tcno; }
            set
            {
                if (value.ToString().Length == 11)
                {
                    tcno = value;

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Eksik - Fazla  Numara Girişi Lutfen 11 Haneli Tc numaranizi girin");
                }
            }
        }
        private long tcno;
        private long telno;
        private long gsmno;
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string AnneAdi { get; set; }
        public string BabaAdi { get; set; }
        public long TelNo
        {
            get { return telno; }
            set
            {
                if (value.ToString().Length == 10)
                {
                    telno = value;

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Eksik - Fazla  Numara Girişi ||TELEFON Numaranızın Başına 0 Eklemeyiniz");
                }
            }
        }
        public long GsmNo
        {
            get { return gsmno; }
            set
            {
                if (value.ToString().Length == 10)
                {
                    gsmno = value;

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Eksik - Fazla  Numara Girişi || GSM  Numaranızın Başına 0 Eklemeyiniz");
                }
            }
        }
        public DateTime Checkİn { get; set; }
        public DateTime CheckOut { get; set; }
        public string YatakTipi { get; set; }
        public string Ucret { get; set; }
    }
}
