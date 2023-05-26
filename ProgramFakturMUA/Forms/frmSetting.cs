using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramFakturMUA
{
    public partial class frmSetting : Form
    {
        Db db = new Db();
        Setting setting = new Setting();
        Functions fungsi = new Functions();

        public frmSetting()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNamaPerusahaan.Text = setting.getSetting("nama_perusahaan");
            txtAlamat.Text = setting.getSetting("alamat");
            txtDirektur.Text = setting.getSetting("direktur");
            txtKota.Text = setting.getSetting("kota");
            txtTelepon.Text = setting.getSetting("telepon");
            txtFax.Text = setting.getSetting("fax");
            txtEmail.Text = setting.getSetting("email");
            txtNPWP.Text = setting.getSetting("npwp");
            txtJumlahBaris.Text = setting.getSetting("row_per_page");
            txtPassword.Text = setting.getSetting("buka_blokir");
            txtPPN.Text = setting.getSetting("ppn");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            setting.setSetting("nama_perusahaan", txtNamaPerusahaan.Text);
            setting.setSetting("alamat", txtAlamat.Text);
            setting.setSetting("direktur", txtDirektur.Text);
            setting.setSetting("kota", txtKota.Text);
            setting.setSetting("telepon", txtTelepon.Text);
            setting.setSetting("fax", txtFax.Text);
            setting.setSetting("email", txtEmail.Text);
            setting.setSetting("npwp", txtNPWP.Text);
            setting.setSetting("row_per_page", txtJumlahBaris.Text);
            setting.setSetting("buka_blokir", txtPassword.Text);
            setting.setSetting("ppn", txtPPN.Text);

            fungsi.showSuccess("Data berhasil disimpan");
        }
    }
}
