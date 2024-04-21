using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBoxUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
             
            int islemSonuc = yeniMusteriEKle(new Musteri()
            {
                id = Guid.NewGuid(),
                isim = txtIsim.Text,
                soyisim = txtSoyisim.Text,
                mail = txtMail.Text,
                telNumarasi = txtTelefon.Text,
            }); 

            if (islemSonuc > 0)
            {
                DialogResult res = MessageBox.Show("Yeni müşteri eklemek ister misiniz ? ", "Müşteri ekleme işlemi başarılı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    bildirimCubugu = new NotifyIcon();
                    bildirimCubugu.BalloonTipText = "Toplam müşteri kayıt adedi :" + sanalDatabase.musteriler.Count.ToString();
                    bildirimCubugu.BalloonTipTitle = "Müşteri sayısı";
                    bildirimCubugu.Visible = true;
                    bildirimCubugu.Icon = SystemIcons.Information;
                    bildirimCubugu.ShowBalloonTip(3000); // Ekranda kalma süresi.
                }
                else if (res == DialogResult.No)
                {

                }

                EkranTemizle();
                ListeyiEkle();
            }
            else
            {
                MessageBox.Show("Hata : Kayıt başarısız ! ");
            }
           
        }

        private void ListeyiEkle()
        {
            lstMusteriler.DataSource = sanalDatabase.musteriler.ToArray();
        }
        private void EkranTemizle()
        {
            txtIsim.Text = string.Empty;
            txtSoyisim.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtTelefon.Text = string.Empty;
        }
        private int yeniMusteriEKle(Musteri Data)
        {
            sanalDatabase.musteriler.Add(Data);
            return 1;
        }
    }
}
