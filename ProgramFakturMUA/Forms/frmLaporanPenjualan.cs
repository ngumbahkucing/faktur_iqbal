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
    public partial class frmLaporanPenjualan : Form
    {
        Db db = new Db();
        Functions fungsi = new Functions();

        public frmLaporanPenjualan()
        {
            InitializeComponent();
        }

        private void frmLaporanPenjualan_Load(object sender, EventArgs e)
        {

            this.Location = new Point(0, 0);

            showData();
        }

        private void showData()
        {
            string sql = "select date_format(penjualan.tanggal, '%d/%m/%Y') as tanggal, penjualan.no_faktur, supplier.nama_supplier as customer, " +
            "barang.nama_barang, pabrik.nama_pabrik, satuan.nama_satuan, penjualan_detail.qty, round(penjualan_detail.harga,0) as harga, round(( penjualan_detail.harga  * (1+ (penjualan.ppn_persen/100) )),0) as harga_faktur, " +
            "round(hpp,0) as hpp, round(total_harga,0) as dpp, round((total_harga  *  (penjualan.ppn_persen/100)),0) as ppn, round((round(total_harga,0) * (1 + (penjualan.ppn_persen/100))),0) as penjualan, round((hpp * penjualan_detail.qty),0) as hpp_penjualan, round((total_harga - ((cn1_uang + cn2_uang)*penjualan_detail.qty)),0) as penjualan_bersih, " +
            "penjualan_detail.diskon_persen, round(penjualan_detail.diskon_uang,0) as diskon_uang, cn1_persen, round(cn1_uang,0) as cn1_uang, cn2_persen, round(cn2_uang,0) as cn2_uang, " +
            "round(((cn1_uang + cn2_uang)*penjualan_detail.qty),0) as total_cn,  " +
            "penjualan.penjaja, pembelian_detail.lot, date_format(pembelian_detail.ed, '%d/%m/%Y') as ed, penjualan_detail.margin " +
            "from penjualan_detail " +
            "left join penjualan on penjualan.jual_id = penjualan_detail.jual_id " +
            "left join supplier on supplier.supplier_id = penjualan.supplier_id " +
            "left join barang on barang.barang_id = penjualan_detail.barang_id " +
            "left join pabrik on pabrik.pabrik_id = barang.pabrik_id " +
            "left join satuan on satuan.satuan_id = barang.satuan_id " +
            "left join stok_masuk on stok_masuk.stok_masuk_id = penjualan_detail.stok_masuk_id " +
            "left join pembelian_detail on pembelian_detail.stok_id = stok_masuk.tabel_id " +
            "where nama_barang like @nama_barang and no_faktur like @no_faktur and nama_supplier like @customer "+
            "and penjaja like @penjaja and nama_pabrik like @pabrik and penjualan.tanggal  between @tanggal1 and @tanggal2 "+
            "order by penjualan.tanggal desc";
            
            //frmDebug debug = new frmDebug();
            //debug.str = sql;
            //debug.Show();

            //fungsi.showError(dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + dateTimePicker2.Value.ToString("yyyy/MM/dd"));

            //fungsi.showError(sql);

            db.bind("nama_barang", "%"+txtNamaBarang.Text+"%");
            db.bind("no_faktur", "%" + txtNoFaktur.Text + "%");
            db.bind("customer", "%" + txtCustomer.Text + "%");
            db.bind("tanggal1", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            db.bind("tanggal2", dateTimePicker2.Value.ToString("yyyy/MM/dd"));
            db.bind("penjaja", "%" + txtSales.Text + "%");
            db.bind("pabrik", "%" + txtPabrik.Text+"%");

            dataGridView1.DataSource = db.query(sql);

            dataGridView1.Columns["dpp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ppn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["penjualan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["hpp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["harga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["harga_faktur"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["hpp_penjualan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["diskon_uang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["cn1_uang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["cn2_uang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["penjualan_bersih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["total_cn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["dpp"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["ppn"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["penjualan"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["hpp"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["harga"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["harga_faktur"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["hpp_penjualan"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["cn1_uang"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["cn2_uang"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["diskon_uang"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["penjualan_bersih"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["total_cn"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["margin"].DefaultCellStyle.Format = "N2";
            
            if (dataGridView1.Rows.Count > 0)
            {
                double total = 0;
                double total_bersih = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells["penjualan"].Value);
                    total_bersih += Convert.ToDouble(dataGridView1.Rows[i].Cells["penjualan_bersih"].Value);
                }
                lblTotal.Text = string.Format("{0:N2}", total);
                lblTotalPenjualanBersih.Text = string.Format("{0:N2}", total_bersih);
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
                var sheet = new Worksheet("LAPORAN PENJUALAN");
                sheet.Cells["A1"] = "LAPORAN PENJUALAN";
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
                string path = Directory.GetCurrentDirectory() + "\\Laporan_Penjualan.xlsx";
                workbook.Save(path);
                Process.Start(path);

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
