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
    public partial class frmBarang : Form
    {
        Satuan satuan = new Satuan();
        Pabrik pabrik = new Pabrik();
        Barang barang = new Barang();
        Functions fungsi = new Functions();
        string id_edit = "";

        public frmBarang()
        {
            InitializeComponent();
        }

        private void frmBarang_Load(object sender, EventArgs e)
        {
            loadSatuan();
            loadPabrik();
            //loadData();

        }

        private void loadSatuan()
        {
            DataTable dt = satuan.getData();
            cboSatuan.DisplayMember = "nama_satuan";
            cboSatuan.ValueMember = "satuan_id";
            cboSatuan.DataSource = dt;
        }

        private void loadPabrik()
        {
            DataTable dt = pabrik.getData();
            cboPabrik.DisplayMember = "nama_pabrik";
            cboPabrik.ValueMember = "pabrik_id";
            cboPabrik.DataSource = dt;
        }

        private void loadData()
        {
            dataGridView1.DataSource = barang.getData(txtNama.Text);
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            if (txtNamaBarang.Text != "")
            {
                if (id_edit == "")
                {
                    barang.insert(txtNamaBarang.Text, txtKodeBarang.Text, ((int)cboSatuan.SelectedValue).ToString(), ((int)cboPabrik.SelectedValue).ToString(), txtHargaJual.Text,
                        txtPricelist.Text);
                }
                else
                {
                    barang.update(txtNamaBarang.Text, txtKodeBarang.Text, ((int)cboSatuan.SelectedValue).ToString(), ((int)cboPabrik.SelectedValue).ToString(), txtHargaJual.Text,
                        txtPricelist.Text, id_edit);
                }

                loadData();
                fungsi.showSuccess("Data berhasil disimpan");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtNamaBarang.Text = dataGridView1.SelectedRows[0].Cells["nama_barang"].Value.ToString();
                txtKodeBarang.Text = dataGridView1.SelectedRows[0].Cells["kode"].Value.ToString();
                txtHargaJual.Text = dataGridView1.SelectedRows[0].Cells["harga_jual"].Value.ToString();
                txtPricelist.Text = dataGridView1.SelectedRows[0].Cells["pricelist"].Value.ToString();
                cboSatuan.Text = dataGridView1.SelectedRows[0].Cells["nama_satuan"].Value.ToString();
                cboPabrik.Text = dataGridView1.SelectedRows[0].Cells["nama_pabrik"].Value.ToString();

                id_edit = dataGridView1.SelectedRows[0].Cells["barang_id"].ToString();
                

            }
        }
    }
}
