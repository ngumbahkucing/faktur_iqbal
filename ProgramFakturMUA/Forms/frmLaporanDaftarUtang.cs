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
    public partial class frmLaporanDaftarUtang : Form
    {
        Db db = new Db();
         
        Functions fungsi = new Functions();

        public frmLaporanDaftarUtang()
        {
            InitializeComponent();
        }

        private void frmLaporanDaftarUtang_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            cboStatus.SelectedIndex = 2;
        }

        private void showData()
        {
            string filter_lunas = "and lunas = @lunas ";
            if (cboStatus.SelectedIndex == 2)
            {
                filter_lunas = "";
            }
            string sql = "select  pembelian.beli_id, date_format(pembelian.tanggal, '%d/%m/%Y') as tanggal, pembelian.no_faktur, pembelian.jatuh_tempo, supplier.nama_supplier as supplier,  " +
            "round(brutto,0) as total1, round(diskon,0) as diskon, round(netto,0) as total2,  round(ppn,0) as ppn, round(tagihan,0) as tagihan, " +
            "case when pembelian.lunas = 1 then 'Lunas' else 'Belum Lunas' end as status, date_format(pembelian.tanggal_lunas, '%d/%m/%Y') as tanggal_lunas ,   " +
            "pembelian.faktur_pajak, supplier.npwp  " +

            "from pembelian " +
            "left join supplier on supplier.supplier_id = pembelian.supplier_id " +

            "where   no_faktur like @no_faktur and nama_supplier like @customer " +
            "and   pembelian.tanggal  between @tanggal1 and @tanggal2 " +
            filter_lunas +
            "order by pembelian.tanggal desc";

            //fungsi.debug(sql);

            //fungsi.showError(dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + dateTimePicker2.Value.ToString("yyyy/MM/dd"));

            //fungsi.showError(sql);


            db.bind("no_faktur", "%" + txtNoFaktur.Text + "%");
            db.bind("customer", "%" + txtCustomer.Text + "%");

            db.bind("tanggal1", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            db.bind("tanggal2", dateTimePicker2.Value.ToString("yyyy/MM/dd"));
            string lunas = "";
            if (cboStatus.Text == "Belum Lunas")
            {
                lunas = "0";
            }
            else if (cboStatus.Text == "Lunas")
            {
                lunas = "1";
            }
            db.bind("lunas", lunas);


            dataGridView1.DataSource = db.query(sql);

            dataGridView1.Columns["total1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["total2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ppn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["diskon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["tagihan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["total1"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["total2"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["ppn"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["diskon"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["tagihan"].DefaultCellStyle.Format = "N2";




            if (dataGridView1.Rows.Count > 0)
            {
                double total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells["tagihan"].Value);
                }
                lblTotal.Text = string.Format("{0:N2}", total);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var sheet = new Worksheet("LAPORAN DAFTAR UTANG");
                sheet.Cells["A1"] = "LAPORAN DAFTAR UTANG";
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
                string path = Directory.GetCurrentDirectory() + "\\Laporan_Daftar_Utang.xlsx";
                workbook.Save(path);
                Process.Start(path);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                frmPelunasanPembelian frm = new frmPelunasanPembelian(this, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                frm.ShowDialog();

            }
        }

        public void refreshData()
        {
            showData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData();
        }
    }
}
