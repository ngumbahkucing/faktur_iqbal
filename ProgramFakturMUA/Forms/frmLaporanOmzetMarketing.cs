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
    public partial class frmLaporanOmzetMarketing : Form
    {

        Db db = new Db();

        Functions fungsi = new Functions();

        public frmLaporanOmzetMarketing()
        {
            InitializeComponent();
        }

        private void frmLaporanOmzetMarketing_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            showData();
        }

        private void showData()
        {
            string sql = "select  penjaja, sum(grandtotal-ppn-pph-(select sum((cn1_uang+cn2_uang)*qty) from penjualan_detail where penjualan_detail.jual_id = penjualan.jual_id))  as total_penjualan  " +

            "from penjualan " +
            "where penjualan.tanggal between @tanggal1 and @tanggal2 " +
            "group by penjaja " +

            "order by penjualan.tanggal desc";

            //fungsi.debug(sql);

            //fungsi.showError(dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + dateTimePicker2.Value.ToString("yyyy/MM/dd"));

            //fungsi.showError(sql);



            db.bind("tanggal1", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            db.bind("tanggal2", dateTimePicker2.Value.ToString("yyyy/MM/dd"));



            dataGridView1.DataSource = db.query(sql);

            dataGridView1.Columns["total_penjualan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dataGridView1.Columns["total_penjualan"].DefaultCellStyle.Format = "N2";




            if (dataGridView1.Rows.Count > 0)
            {
                double total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells["total_penjualan"].Value);
                }
                lblTotal.Text = string.Format("{0:N2}", total);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var sheet = new Worksheet("LAPORAN OMZET MARKETING");
                sheet.Cells["A1"] = "LAPORAN OMZET MARKETING";
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
                string path = Directory.GetCurrentDirectory() + "\\Laporan_Omzet_Marketing.xlsx";
                workbook.Save(path);
                Process.Start(path);

            }
        }
    }
}
