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
    public partial class frmEditStok : Form
    {
        Db db = new Db();
        Barang barang = new Barang();
        Stok_masuk stok_masuk = new Stok_masuk();
        Satuan satuan = new Satuan();
        Pabrik pabrik = new Pabrik();
        Functions fungsi = new Functions();
        Stok_Penyesuaian sp = new Stok_Penyesuaian();

        public string stok_masuk_id = "";
        frmMain frmMain;

        public frmEditStok(frmMain frm)
        {
            InitializeComponent();
            frmMain = frm;
        }

        private void frmEditStok_Load(object sender, EventArgs e)
        {
            string id_barang = stok_masuk.getIDBarangFromStokMasukID(stok_masuk_id);
            txtNama.Text = barang.getNamaBarangFromIDBarang(id_barang);
            string id_satuan = barang.getIDSatuanFromBarangID(id_barang);
            string id_pabrik = barang.getIDPabrikFromIDBarang(id_barang);
            txtSatuan.Text = satuan.getNamaSatuanByID(id_satuan);
            txtPabrik.Text = pabrik.getNamaPabrikByID(id_pabrik);

            txtStok.Text = stok_masuk.getStok(stok_masuk_id);
            cboDitambah.SelectedIndex = 0;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtQty.Text) > 0)
            {
                if (cboDitambah.SelectedIndex == 0)
                {
                    stok_masuk.tambahkanStok(stok_masuk_id, txtQty.Text);
                }
                else
                {
                    stok_masuk.kurangiStok(stok_masuk_id, txtQty.Text);
                }
                sp.insert(DateTime.Now.ToString("yyyy/MM/dd"),stok_masuk_id, txtQty.Text, cboDitambah.SelectedIndex.ToString());
                frmMain.refreshDGV();
                this.Close();
            }
        }
    }
}
