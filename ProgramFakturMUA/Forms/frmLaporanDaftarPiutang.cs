using Simplexcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace ProgramFakturMUA
{
    public partial class frmLaporanDaftarPiutang : Form
    {
        Db db = new Db();
        Setting setting = new Setting();
        Penjualan penjualan = new Penjualan();
        MitraBisnis mitrabisnis = new MitraBisnis();
        
        Functions fungsi = new Functions();

        public frmLaporanDaftarPiutang()
        {
            InitializeComponent();
        }

        private void frmLaporanDaftarPiutang_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            cboStatus.SelectedIndex = 2;
            showData();
        }

        private void showData()
        {
            string filter_lunas = "and lunas = @lunas ";
            if (cboStatus.SelectedIndex == 2)
            {
                filter_lunas = "";
            }
            string sql = "select  penjualan.jual_id, date_format(penjualan.tanggal, '%d/%m/%Y') as tanggal, penjualan.no_faktur, penjualan.jatuh_tempo, supplier.nama_supplier as customer, penjualan.faktur_pajak, " +
            "round(grandtotal,0) as nilai_faktur, round(penjualan.netto,0) as  dpp, case when is_pph = 1 then  round((netto * 0.015),0) else 0 end as pph, round((penjualan.netto * (penjualan.ppn_persen/100)),0) as ppn, round((select sum(cn1_uang*qty) from penjualan_detail where penjualan_detail.jual_id = penjualan.jual_id),0) as promosi1, " +
            "round((select sum(cn2_uang*qty) from penjualan_detail where penjualan_detail.jual_id = penjualan.jual_id),0) as promosi2, round((select sum((cn1_uang+cn2_uang) * qty) from penjualan_detail where penjualan_detail.jual_id = penjualan.jual_id),0) as total_promosi,   "+
            "round(grandtotal-ppn-pph-(select sum((cn1_uang+cn2_uang)*qty) from penjualan_detail where penjualan_detail.jual_id = penjualan.jual_id)) as netto, "+
            "round((select sum(jumlah) from penjualan_bayar where penjualan_bayar.jual_id = penjualan.jual_id),0)   as pembayaran,  " +
            "case when penjualan.lunas = 1 then 'Lunas' else 'Belum Lunas' end as status, case when date_format(penjualan.tanggal_lunas, '%d/%m/%Y') = '01/01/1970' then '' else date_format(penjualan.tanggal_lunas, '%d/%m/%Y') end  as tanggal_lunas , ongkir,   " +
            "penjaja, bulan_buku, date_format(penjualan.tanggal, '%m') as bulan_faktur  " +

            "from penjualan " +
            "left join supplier on supplier.supplier_id = penjualan.supplier_id " +


            "where   no_faktur like @no_faktur and nama_supplier like @customer " +
            "and penjaja like @penjaja  and penjualan.tanggal  between @tanggal1 and @tanggal2 " +
            filter_lunas +
            "order by penjualan.tanggal desc";

            //fungsi.debug(sql);

            //fungsi.showError(dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + dateTimePicker2.Value.ToString("yyyy/MM/dd"));

            //fungsi.showError(sql);


            db.bind("no_faktur", "%" + txtNoFaktur.Text + "%");
            db.bind("customer", "%" + txtCustomer.Text + "%");
            db.bind("penjaja", "%" + txtSales.Text + "%");
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

            dataGridView1.Columns["nilai_faktur"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["pph"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ppn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["promosi1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["promosi2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["pembayaran"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["dpp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["total_promosi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ongkir"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["netto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["nilai_faktur"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["pph"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["ppn"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["promosi1"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["promosi2"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["pembayaran"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["dpp"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["total_promosi"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["ongkir"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["netto"].DefaultCellStyle.Format = "N2";



            if (dataGridView1.Rows.Count > 0)
            {
                double total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells["nilai_faktur"].Value);
                }
                lblTotal.Text = string.Format("{0:N2}", total);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData();
        }

        public void refreshData()
        {
            showData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var sheet = new Worksheet("LAPORAN DAFTAR PIUTANG");
                sheet.Cells["A1"] = "LAPORAN DAFTAR PIUTANG";
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
                string path = Directory.GetCurrentDirectory() + "\\Laporan_Daftar_Piutang.xlsx";
                workbook.Save(path);
                Process.Start(path);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                frmPelunasan frm = new frmPelunasan(this, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                frm.ShowDialog();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Anda yakin ingin mencetak inkaso?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    

                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                    pd.DefaultPageSettings.Landscape = true;

                    PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
                    PrintDialog printdlg = new PrintDialog();
                    printdlg.Document = pd;
                    if (printdlg.ShowDialog() == DialogResult.OK)
                    {
                        printPrvDlg.Document = pd;
                        ((Form)printPrvDlg).WindowState = FormWindowState.Maximized;

                        printPrvDlg.ShowDialog();
                    }
                }



            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Single yPos = 0;
            Single xPos = 0;

            Font fontTimes10R = new Font("Times New Roman", 10.0f);
            Font fontTimes10 = new Font("Times New Roman", 10.0f, FontStyle.Bold);
            Font fontTimes12 = new Font("Times New Roman", 12.0f, FontStyle.Bold);
            Font fontTimes12R = new Font("Times New Roman", 12.0f);
            Font fontConsolas = new Font("Lucida Console", 9.0f);
            Font fontConsolasB = new Font("Lucida Console", 9.0f, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);

            // ambil detail perusahaan
            string nama_perusahaan = setting.getSetting("nama_perusahaan");
            string alamat = setting.getSetting("alamat");
            //string kota_perusahaan = setting.getSetting("kota");
            //string telepon = setting.getSetting("telepon");
            //string fax = setting.getSetting("fax");
            //string npwp = setting.getSetting("npwp");

            // cetak perusahaan

            e.Graphics.DrawString("DAFTAR INKASO", fontTimes12, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes12.Height;
            e.Graphics.DrawString(nama_perusahaan, fontTimes12, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes12.Height *2;

            Pen blackPen = new Pen(System.Drawing.Color.Black, 1);
            PointF point1 = new PointF(0, yPos);
            PointF point2 = new PointF(1800, yPos);
            e.Graphics.DrawLine(blackPen, point1, point2);
            yPos += 10;

            Single xNo = 0;
            Single xTanggal = xNo + 30;
            Single xJatuhTempo = xTanggal + 90;
            Single xCustomer = xJatuhTempo + 80;
            Single xNilaiFaktur = xCustomer + 300;
            Single xPembayaran = xNilaiFaktur + 100;
            Single xKurangBayar = xPembayaran + 100;
            Single xCN = xKurangBayar + 100;
            Single xSales = xCN + 110;
            Single xTanggalLunas = xSales + 80;

            xPos = xNo;
            e.Graphics.DrawString("No.", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xTanggal;
            e.Graphics.DrawString("Tanggal", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xJatuhTempo;
            e.Graphics.DrawString("Jth Tmp", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xCustomer;
            e.Graphics.DrawString("Nama Customer", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xNilaiFaktur;
            e.Graphics.DrawString("Nilai Faktur", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xPembayaran;
            e.Graphics.DrawString("Pembayaran", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xKurangBayar;
            e.Graphics.DrawString("Kurang Bayar", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xCN+20;
            e.Graphics.DrawString("CN", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xSales;
            e.Graphics.DrawString("Sales", fontConsolas, brush, xPos, yPos, new StringFormat());

            xPos = xTanggalLunas;
            e.Graphics.DrawString("Tanggal Lunas", fontConsolas, brush, xPos, yPos, new StringFormat());
            yPos += fontConsolas.Height;
            yPos += 5;
            blackPen = new Pen(System.Drawing.Color.Black, 1);
            point1 = new PointF(0, yPos);
            point2 = new PointF(1800, yPos);
            e.Graphics.DrawLine(blackPen, point1, point2);
            yPos += 10;
            
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            int no = 0;
            double total_faktur = 0;
            double total_pembayaran = 0;
            double total_kurang_bayar = 0;

            for (int i = 0; i < selectedRowCount; i++)
            {
                no++;
                //// ambil data faktur
                string jual_id = dataGridView1.SelectedRows[i].Cells["jual_id"].Value.ToString();
                string no_faktur = penjualan.getPenjualan(jual_id, "no_faktur");
                string tanggal = penjualan.getPenjualan(jual_id, "tanggal");
                string xtanggal = fungsi.tanggal_indo(tanggal);

                string penjaja = penjualan.getPenjualan(jual_id, "penjaja");
                string jatuh_tempo = penjualan.getPenjualan(jual_id, "jatuh_tempo");
                string xjatuh_tempo = fungsi.tanggal_indo(jatuh_tempo);
                string id_customer = penjualan.getPenjualan(jual_id, "supplier_id");
                string nama_customer = mitrabisnis.getMitraBisnis(id_customer, "nama_supplier");
                string nilai_faktur = penjualan.getPenjualan(jual_id, "grandtotal");
                double xnilai_faktur = Math.Round(double.Parse(nilai_faktur), 0, MidpointRounding.AwayFromZero);
                string pembayaran = penjualan.getTotalPembayaran(jual_id);
                double kurang_bayar = xnilai_faktur; double xpembayaran = 0;
                if (!string.IsNullOrEmpty(pembayaran))
                {
                    xpembayaran = Math.Round(double.Parse(pembayaran), 0, MidpointRounding.AwayFromZero);
                    kurang_bayar = double.Parse(nilai_faktur) - double.Parse(pembayaran);
                
                }
                
                string tanggal_lunas = penjualan.getPenjualan(jual_id, "tanggal_lunas");
                string xtanggal_lunas = fungsi.tanggal_indo(tanggal_lunas);
                if (xtanggal_lunas == "01/01/0001") xtanggal_lunas = "-";
                string cn = penjualan.getCN(jual_id);
                double xcn = Math.Round(double.Parse(cn),0,MidpointRounding.AwayFromZero);

                total_faktur += xnilai_faktur;
                total_pembayaran += xpembayaran;
                total_kurang_bayar  += kurang_bayar;

                xPos = xNo;
                e.Graphics.DrawString(no + ".", fontConsolas, brush, xPos, yPos, new StringFormat());
                
                xPos = xTanggal;
                e.Graphics.DrawString(xtanggal, fontConsolas, brush, xPos, yPos, new StringFormat());

                xPos = xJatuhTempo;
                e.Graphics.DrawString(xjatuh_tempo, fontConsolas, brush, xPos, yPos, new StringFormat());

                xPos = xCustomer;
                string xnama_customer = nama_customer;
                if (nama_customer.Length > 35)
                {
                    xnama_customer = nama_customer.Substring(0, 35);
                }
                e.Graphics.DrawString(xnama_customer, fontConsolas, brush, xPos, yPos, new StringFormat());

                xPos = xNilaiFaktur;
                e.Graphics.DrawString(string.Format("{0:N0}", xnilai_faktur).PadLeft(12), fontConsolas, brush, xPos, yPos, new StringFormat());

                xPos = xPembayaran;
                e.Graphics.DrawString(string.Format("{0:N0}", xpembayaran).PadLeft(12), fontConsolas, brush, xPos, yPos, new StringFormat());

                xPos = xKurangBayar;
                e.Graphics.DrawString(string.Format("{0:N0}", kurang_bayar).PadLeft(12), fontConsolas, brush, xPos, yPos, new StringFormat());

                xPos = xCN;
                e.Graphics.DrawString(string.Format("{0:N0}", xcn).PadLeft(12), fontConsolas, brush, xPos, yPos, new StringFormat());

                xPos = xSales;
                e.Graphics.DrawString(penjaja, fontConsolas, brush, xPos, yPos, new StringFormat());

                xPos = xTanggalLunas;
                e.Graphics.DrawString(xtanggal_lunas, fontConsolas, brush, xPos, yPos, new StringFormat());
                yPos += fontConsolas.Height;
                
                  
            }

            yPos += 5;
            blackPen = new Pen(System.Drawing.Color.Black, 1);
            point1 = new PointF(0, yPos);
            point2 = new PointF(1800, yPos);
            e.Graphics.DrawLine(blackPen, point1, point2);
            yPos += fontConsolas.Height;

            xPos = xCustomer+250;
            e.Graphics.DrawString("TOTAL", fontConsolas, brush, xPos, yPos, new StringFormat());
            xPos = xNilaiFaktur;
            e.Graphics.DrawString(string.Format("{0:N0}", total_faktur).PadLeft(12), fontConsolas, brush, xPos, yPos, new StringFormat());
            xPos = xPembayaran;
            e.Graphics.DrawString(string.Format("{0:N0}", total_pembayaran).PadLeft(12), fontConsolas, brush, xPos, yPos, new StringFormat());
            xPos = xKurangBayar;
            e.Graphics.DrawString(string.Format("{0:N0}", total_kurang_bayar).PadLeft(12), fontConsolas, brush, xPos, yPos, new StringFormat());
            

           

            

        }
    }
}
