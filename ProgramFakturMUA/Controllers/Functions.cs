using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramFakturMUA
{
    class Functions
    {
        Db db = new Db();

        public void showError(string txt)
        {
            MessageBox.Show(txt, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void showSuccess(string txt)
        {
            MessageBox.Show(txt, "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string tanggal_indo(string tgl)
        {
            string[] tanggal = tgl.Split(' ');
            //string[] tanggalx = tanggal[0].Split('-');
            //string tanggal2 = tanggalx[2] + "/" + tanggalx[1] + "/" + tanggalx[0];
            return tanggal[0];
        }

        public DataTable getKota()
        {
            string sql = "select kota_id, nama_kota from kota order by nama_kota";
            return db.query(sql);
        }

   

        public void setFakturPajak()
        {
            db.nQuery("update settings set isi = isi + 1 where nama = 'faktur_pajak_berjalan'");
        }

        public string Terbilang(decimal xx)
        {
            int x; int koma;
            string[] angka;
            string strXX = xx.ToString();
            if (strXX.Contains('.'))
            {
                angka = strXX.Split('.');
                x = int.Parse(angka[0]);
                koma = int.Parse(angka[1]);
            }
            else
            {
                x = int.Parse(strXX);
                koma = 0;
            }

            //showError("x:" + x.ToString() + " koma: " + koma.ToString());

            

            string[] bilangan = { "", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas" };
            string temp = "";

            if (x < 12)
            {
                temp = " " + bilangan[x];
            }
            else if (x < 20)
            {
                temp = Terbilang(x - 10).ToString() + " belas";
            }
            else if (x < 100)
            {
                temp = Terbilang(x / 10) + " puluh" + Terbilang(x % 10);
            }
            else if (x < 200)
            {
                temp = " seratus" + Terbilang(x - 100);
            }
            else if (x < 1000)
            {
                temp = Terbilang(x / 100) + " ratus" + Terbilang(x % 100);
            }
            else if (x < 2000)
            {
                temp = " seribu" + Terbilang(x - 1000);
            }
            else if (x < 1000000)
            {
                temp = Terbilang(x / 1000) + " ribu" + Terbilang(x % 1000);
            }
            else if (x < 1000000000)
            {
                temp = Terbilang(x / 1000000) + " juta" + Terbilang(x % 1000000);
            }

            if (koma > 0)
            {
                string sen = " koma" + Terbilang(koma);
                temp = temp + sen;
            }
            return temp;
        }

        public string tanggal(string tgl)
        {
            string[] tanggal_split = tgl.Split(' ');
            string[] xtanggal_split = tanggal_split[0].Split('/');
            string xtanggal = xtanggal_split[2] + "/" + xtanggal_split[1] + "/" + xtanggal_split[0] ;

            return xtanggal;
        }



    }
}
