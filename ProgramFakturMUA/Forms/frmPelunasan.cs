using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramFakturMUA
{
    public partial class frmPelunasan : Form
    {
        frmLaporanDaftarPiutang frmLaporanDaftarPiutang;
        string id_jual;
        Penjualan penjualan = new Penjualan();
        Db db = new Db();
        Functions fungsi = new Functions();
        MitraBisnis mitrabisnis = new MitraBisnis();
        double grandtotalx;

        public frmPelunasan(frmLaporanDaftarPiutang frm, string id)
        {
            InitializeComponent();
            id_jual = id;
            frmLaporanDaftarPiutang = frm;
        }

        private void frmPelunasan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            string lunas = penjualan.getPenjualan(id_jual, "lunas");
            string tanggal_lunas = penjualan.getPenjualan(id_jual, "tanggal_lunas");
            string no_faktur = penjualan.getPenjualan(id_jual, "no_faktur");
            string supplier_id = penjualan.getPenjualan(id_jual, "supplier_id");
            string nama_supplier = mitrabisnis.getMitraBisnis(supplier_id, "nama_supplier");
            string grandtotal = penjualan.getPenjualan(id_jual, "grandtotal");
            grandtotalx = double.Parse(grandtotal);
            //fungsi.showSuccess(tanggal_lunas);
            if (tanggal_lunas != "01/01/0001 00:00:00")
            {
                string[] tanggalx = tanggal_lunas.Split(' ');

                dateTimePicker1.Value = DateTime.ParseExact(tanggalx[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            int status_lunas = int.Parse(lunas);
            cboStatus.SelectedIndex = status_lunas;

            txtNoFaktur.Text = no_faktur;
            txtNamaCustomer.Text = nama_supplier;
            txtNilaiFaktur.Text = string.Format("{0:N0}", double.Parse(grandtotal));

            showData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lunas = cboStatus.SelectedIndex;
            penjualan.updatePenjualan(id_jual, "lunas", lunas.ToString());
            penjualan.updatePenjualan(id_jual, "tanggal_lunas", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            fungsi.showSuccess("Status pelunasan berhasil disimpan");
            frmLaporanDaftarPiutang.refreshData();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtJumlahBayar.Text != "" && double.Parse(txtJumlahBayar.Text) > 0)
            {
                penjualan.insertPembayaran(id_jual, dateTimePicker1.Value.ToString("yyyy/MM/dd"), txtJumlahBayar.Text);
                showData();
                txtJumlahBayar.Text = "";
            }
        }
        private void showData()
        {
            string sql = "select id, date_format(tanggal, '%d/%m/%Y') as tanggal, format(jumlah,2) as jumlah  " +
            "from penjualan_bayar " +

            "where jual_id = @jual_id " +
            "order by tanggal desc";

            //frmDebug debug = new frmDebug();
            //debug.str = sql;
            //debug.Show();

            //fungsi.showError(dateTimePicker1.Value.ToString("yyyy/MM/dd") + " " + dateTimePicker2.Value.ToString("yyyy/MM/dd"));

            //fungsi.showError(sql);

            db.bind("jual_id", id_jual);


            dataGridView1.DataSource = db.query(sql);

            dataGridView1.Columns["jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["jumlah"].DefaultCellStyle.Format = "N2";

            if (dataGridView1.Rows.Count > 0)
            {
                double total = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells["jumlah"].Value);
                }
                txtTotal.Text = string.Format("{0:N2}", total);
                double kekurangan = total - grandtotalx;
                txtKekurangan.Text = string.Format("{0:N2}", kekurangan);
            }
            frmLaporanDaftarPiutang.refreshData();


        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Anda yakin ingin menghapus data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    penjualan.hapusPembayaran(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    showData();
                }
            }
        }
    }
}
