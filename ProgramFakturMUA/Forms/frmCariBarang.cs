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
    public partial class frmCariBarang : Form
    {
        frmPembelian frmPembelian;
        frmPenjualan frmPenjualan;
        Db db = new Db();
        Functions fungsi = new Functions();
        int is_beli = 0;
        int is_jual = 0;

        public frmCariBarang(frmPembelian frm)
        {
            InitializeComponent();
            frmPembelian = frm;
            is_beli = 1;
        }

        public frmCariBarang(frmPenjualan frm)
        {
            InitializeComponent();
            frmPenjualan = frm;
            is_jual = 1;
        }

        private void frmCariBarang_Load(object sender, EventArgs e)
        {
            //showData();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void showData()
        {
            string sql = "";
            if (is_jual == 1)
            {
                sql = "select stok_masuk_id, barang.nama_barang, satuan.nama_satuan, pabrik.nama_pabrik, sisa,  lot, ed " +
                   "FROM stok_masuk " +
                   "left join barang on barang.barang_id = stok_masuk.barang_id " +
                   "left join satuan on satuan.satuan_id = barang.satuan_id " +
                   "left join pabrik on pabrik.pabrik_id = barang.pabrik_id " +
                   "left join pembelian_detail on pembelian_detail.stok_id = stok_masuk.tabel_id " +

                   "where barang.nama_barang like @barang  " +
                   "and sisa > 0 ";

            }
            else
            {
                 sql = "select barang_id as stok_masuk_id, barang.nama_barang, satuan.nama_satuan, pabrik.nama_pabrik, '0' as sisa " +
                    "FROM barang " +
                    
                    "left join satuan on satuan.satuan_id = barang.satuan_id " +
                    "left join pabrik on pabrik.pabrik_id = barang.pabrik_id " +
                    "where barang.nama_barang like @barang  " +
                    "  ";
            }

            db.bind("barang", "%" + txtNama.Text + "%");

            dataGridView1.DataSource = db.query(sql);
            dataGridView1.Columns["stok_masuk_id"].HeaderText = "ID";
            dataGridView1.Columns["nama_barang"].HeaderText = "Nama Barang";
            dataGridView1.Columns["nama_satuan"].HeaderText = "Satuan";
            dataGridView1.Columns["nama_pabrik"].HeaderText = "Pabrik";
            dataGridView1.Columns["sisa"].HeaderText = "Qty";
             

            dataGridView1.Columns["stok_masuk_id"].Width = 80;
            dataGridView1.Columns["nama_barang"].Width = 200;


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
                    frmPembelian.setIDBarang(dataGridView1.SelectedRows[0].Cells["stok_masuk_id"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["nama_barang"].Value.ToString());
                }
                else
                {
                    frmPenjualan.setIDBarang(dataGridView1.SelectedRows[0].Cells["stok_masuk_id"].Value.ToString(), dataGridView1.SelectedRows[0].Cells["nama_barang"].Value.ToString());

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
