using ProgramFakturMUA;
using Simplexcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProgramFakturMUA
{
    public partial class frmMain : Form
    {
        Db db = new Db();
        Setting setting = new Setting();
        Pembelian pembelian = new Pembelian();
        Penjualan penjualan = new Penjualan();
        Functions fungsi = new Functions();
        string username = "admin";

        public frmMain()
        {
            InitializeComponent();
        }

        public void refreshDGV()
        {
            showTable();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = this.Text +" - "+ setting.getSetting("nama_perusahaan");

            this.Location = new Point(0, 0);
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            int koordinatY = btnCari.Location.Y;
            int koordinatX = Screen.PrimaryScreen.Bounds.Width - 150;
            btnExcel.Location = new Point(koordinatX, koordinatY);
            btnCari.Location = new Point(koordinatX - btnCari.Width, koordinatY);
            txtPabrik.Location = new Point(koordinatX - 75 - btnCari.Width, koordinatY+5);
            lblPabrik.Location = new Point(koordinatX - 115 - btnCari.Width, koordinatY + 5);
            txtBarang.Location = new Point(koordinatX - 230 - btnCari.Width, koordinatY + 5);
            lblBarang.Location = new Point(koordinatX - 305 - btnCari.Width, koordinatY + 5);
            dataGridView1.Width = this.Width - 40;
            dataGridView1.Height = this.Height- 150;
            btnEdit.Location = new Point(koordinatX, this.Height - 80);
            //showTable();



        }

        private void showTable()
        {
            string sql = "select stok_masuk_id, barang.nama_barang, satuan.nama_satuan, pabrik.nama_pabrik, "+
                "sisa as qty, round(pembelian_detail.harga_beli - (diskon_uang/pembelian_detail.qty),0) as harga_beli,  " +
                "round((sisa * (pembelian_detail.harga_beli - (diskon_uang/pembelian_detail.qty))),0) as total_harga " +
                "FROM stok_masuk " +
                "left join barang on barang.barang_id = stok_masuk.barang_id " +
                "left join satuan on satuan.satuan_id = barang.satuan_id " +
                "left join pabrik on pabrik.pabrik_id = barang.pabrik_id " +
                "left join pembelian_detail on pembelian_detail.stok_id = stok_masuk.tabel_id " +
                "where barang.nama_barang like @barang and pabrik.nama_pabrik like @pabrik " +
                "and sisa > 0  ";
            db.bind("barang", "%" + txtBarang.Text + "%");
            db.bind("pabrik", "%" + txtPabrik.Text + "%");
            
            dataGridView1.DataSource = db.query(sql);

            dataGridView1.Columns["stok_masuk_id"].HeaderText = "ID";
            dataGridView1.Columns["nama_barang"].HeaderText = "Nama Barang";
            dataGridView1.Columns["nama_satuan"].HeaderText = "Satuan";
            dataGridView1.Columns["nama_pabrik"].HeaderText = "Pabrik";
            dataGridView1.Columns["qty"].HeaderText = "Qty";
            dataGridView1.Columns["harga_beli"].HeaderText = "Harga Beli";

            dataGridView1.Columns["harga_beli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["total_harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["harga_beli"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["total_harga"].DefaultCellStyle.Format = "N0";
        }

        private void masterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var sheet = new Worksheet("STOK BARANG");
                sheet.Cells["A1"] = "STOK BARANG";
                sheet.Cells["A1"].Bold = true;

                int baris = 2;
                int counter = 1;
                int kolom = 0;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {

                    DataGridViewColumnHeaderCell headerCell = column.HeaderCell;
                    string headerCaptionText = column.HeaderText;
                    string columnName = column.Name;

                    sheet.Cells[baris, kolom] = columnName;
                    kolom++;
                }

                baris = 3;
                counter = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    kolom = 0;
                    //sheet.Cells[baris, kolom] = counter;
                    counter++;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.GetType().ToString() == "System.String")
                        {
                            Cell value = cell.Value.ToString();
                            sheet.Cells[baris, kolom] = value;
                        }
                        else
                        {
                            if (cell.Value.GetType().ToString() != "System.DBNull"
                                && cell.Value.GetType().ToString() != "System.SByte"
                                && cell.Value.GetType().ToString() != "System.DateTime")
                            {
                                sheet.Cells[baris, kolom] = double.Parse(cell.Value.ToString());
                            }
                            else
                            {
                                sheet.Cells[baris, kolom] = cell.Value.ToString();
                            }
                        }

                        kolom++;

                    }
                    baris++;
                }

                var workbook = new Workbook();
                workbook.Add(sheet);
                string path = Directory.GetCurrentDirectory() + "\\Stok_Barang.xlsx";
                workbook.Save(path);
                Process.Start(path);

            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void dataPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPembelian beli = new frmPembelian(this);
            beli.Show();
        }

        public string getUsername()
        {
            return username;
        }

        private void dataPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPenjualan form = new frmPenjualan(this);
            form.Show();
        }

        private void settingAplikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetting form = new frmSetting();
            form.Show();
        }

        private void dataBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarang form = new frmBarang();
            form.Show();
        }

        private void dataMitraBisnisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMitrabisnis form = new frmMitrabisnis();
            form.Show();
        }

        private void laporanPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaporanPenjualan form = new frmLaporanPenjualan();
            form.Show();
        }

        private void fixHPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string hppx = ""; double margin = 0;
            DataTable dt = db.query("select * from penjualan_detail where jual_id in (select jual_id from penjualan where year(tanggal) = 2022 and month(tanggal) = 4)");
            foreach (DataRow row in dt.Rows)
            {
                string stok_masuk_id = row["stok_masuk_id"].ToString();
                string id = row["id"].ToString();
                string harga = row["harga"].ToString();

                if (stok_masuk_id == "0")
                {
                    hppx = "0";
                }
                else
                {
                    hppx = pembelian.getHPP(stok_masuk_id);
                    if (hppx == "") hppx = "0";
                }

                margin = (double.Parse(harga) - double.Parse(hppx)) / double.Parse(hppx) * 100;
                //fungsi.showError("harga: "+ harga + " hpp: " + hppx+ " margin : " + margin.ToString());

                penjualan.update(id, "hpp", hppx);
                penjualan.update(id, "margin", margin.ToString() );

            }

            fungsi.showSuccess("Fix HPP Selesai");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                frmEditStok frm = new frmEditStok(this);
                frm.stok_masuk_id = dataGridView1.SelectedRows[0].Cells["stok_masuk_id"].Value.ToString();
                frm.Show();

            }
        }

        private void laporanPembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaporanPembelian form = new frmLaporanPembelian();
            form.Show();

        }

        private void laporanDaftarPiutangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaporanDaftarPiutang form = new frmLaporanDaftarPiutang();
            form.Show();
        }

        private void laporanOmzetMarketingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaporanOmzetMarketing form = new frmLaporanOmzetMarketing();
            form.Show();
        }

        private void laporanDaftarUtangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaporanDaftarUtang frm = new frmLaporanDaftarUtang();
            frm.Show();
        }
    }
}
