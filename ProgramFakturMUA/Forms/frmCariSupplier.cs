using ProgramFakturMUA;
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
    public partial class frmCariSupplier : Form
    {
        frmPembelian frmPembelian;
        frmPenjualan frmPenjualan;
        Db db = new Db();
        Functions fungsi = new Functions();
        int is_beli = 0;
        int is_jual = 0;

        public frmCariSupplier(frmPembelian frm)
        {
            InitializeComponent();
            frmPembelian = frm;
            is_beli = 1;
        }

        public frmCariSupplier(frmPenjualan frm)
        {
            InitializeComponent();
            frmPenjualan = frm;
            is_jual = 1;
        }

        private void frmCariSupplier_Load(object sender, EventArgs e)
        {
            //showData();
        }

        private void showData()
        {
            string sql = "select supplier_id, nama_supplier, alamat from supplier where nama_supplier like @nama ";
            db.bind("nama", "%" + txtNama.Text + "%");

            dataGridView1.DataSource = db.query(sql);
            dataGridView1.Columns["supplier_id"].HeaderText = "ID";
            dataGridView1.Columns["nama_supplier"].HeaderText = "Nama Supplier";
            dataGridView1.Columns["alamat"].HeaderText = "Alamat";
            
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            pilihData();
        }

        private void pilihData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (is_beli == 1)
                {
                    frmPembelian.setIDSupplier(dataGridView1.SelectedRows[0].Cells["supplier_id"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["nama_supplier"].Value.ToString());
                }
                else
                {
                    frmPenjualan.setIDSupplier(dataGridView1.SelectedRows[0].Cells["supplier_id"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["nama_supplier"].Value.ToString());

                }
                this.Close();
            }
            else
            {
                fungsi.showError("Data belum dipilih");

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pilihData();
        }
    }
}
