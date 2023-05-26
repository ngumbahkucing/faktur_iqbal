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
    public partial class frmLaporanPembelian : Form
    {
        Db db = new Db();

        public frmLaporanPembelian()
        {
            InitializeComponent();
        }

        private void frmLaporanPembelian_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            showData();
        }

        private void showData()
        {
            string sql = "select date_format(pembelian.tanggal, '%d/%m/%Y') as tanggal, pembelian.no_faktur, supplier.nama_supplier as customer, " +
            "barang.nama_barang, pabrik.nama_pabrik, satuan.nama_satuan, pembelian_detail.qty, pembelian_detail.harga_beli  as harga, (pembelian_detail.qty * pembelian_detail.harga_beli) as total_harga,  " +
            "pembelian_detail.diskon_persen, pembelian_detail.diskon_uang as diskon_uang,     " +
            "(pembelian_detail.harga_beli - (diskon_uang / qty)) as harga_bersih,   ((pembelian_detail.qty * pembelian_detail.harga_beli) - (diskon_uang))   as pembelian_bersih, " +
            "  pembelian_detail.lot, date_format(pembelian_detail.ed, '%d/%m/%Y') as ed  " +
            "from pembelian_detail " +
            "left join pembelian on pembelian.beli_id = pembelian_detail.beli_id " +
            "left join supplier on supplier.supplier_id = pembelian.supplier_id " +
            "left join barang on barang.barang_id = pembelian_detail.barang_id " +
            "left join pabrik on pabrik.pabrik_id = barang.pabrik_id " +
            "left join satuan on satuan.satuan_id = barang.satuan_id " +

            "where nama_barang like @nama_barang and no_faktur like @no_faktur and nama_supplier like @customer " +
            "and   nama_pabrik like @pabrik and pembelian.tanggal  between @tanggal1 and @tanggal2 " +
            "order by pembelian.tanggal desc";

            //frmDebug debug = new frmDebug();
            //debug.str = sql;
            //debug.Show();

            //fungsi.showError(dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + dateTimePicker2.Value.ToString("yyyy/MM/dd"));

            //fungsi.showError(sql);

            db.bind("nama_barang", "%" + txtNamaBarang.Text + "%");
            db.bind("no_faktur", "%" + txtNoFaktur.Text + "%");
            db.bind("customer", "%" + txtCustomer.Text + "%");
            db.bind("tanggal1", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            db.bind("tanggal2", dateTimePicker2.Value.ToString("yyyy/MM/dd"));

            db.bind("pabrik", "%" + txtPabrik.Text + "%");

            dataGridView1.DataSource = db.query(sql);

            dataGridView1.Columns["total_harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["harga_bersih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["diskon_uang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["pembelian_bersih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["total_harga"].DefaultCellStyle.Format = "N2";

            dataGridView1.Columns["harga"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["harga_bersih"].DefaultCellStyle.Format = "N2";


            dataGridView1.Columns["diskon_uang"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["pembelian_bersih"].DefaultCellStyle.Format = "N2";


            if (dataGridView1.Rows.Count > 0)
            {
                double total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells["total_harga"].Value);
                }
                lblTotal.Text = string.Format("{0:N2}", total);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var sheet = new Worksheet("LAPORAN PEMBELIAN");
                sheet.Cells["A1"] = "LAPORAN PEMBELIAN";
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
                string path = Directory.GetCurrentDirectory() + "\\Laporan_Pembelian.xlsx";
                workbook.Save(path);
                Process.Start(path);

            }
        }


    }
}
