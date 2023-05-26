using Simplexcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramFakturMUA
{
    public partial class frmPenjualan : Form
    {
        Db db = new Db();
        Functions fungsi = new Functions();
        Barang barang = new Barang();
        Pabrik pabrik = new Pabrik();
        Satuan satuan = new Satuan();
        Setting setting = new Setting();
        Pembelian pembelian = new Pembelian();
        Penjualan penjualan = new Penjualan();
        Stok_masuk stok_masuk = new Stok_masuk();
        MitraBisnis mitrabisnis = new MitraBisnis();
        Kota kota = new Kota();
        frmMain frmMain;
        double subtotal = 0;
        double ppn = 0;
        double Grandtotal = 0;
        double brutto = 0;
        double diskon = 0;
        string ppn_persen = "";
        string selected_id_supplier = "";
        string selected_id_barang = "";
        string stok_masuk_id = "";
        string id_edit = "";
        int edit_detail = 0;
         
        


        public frmPenjualan(frmMain frm)
        {
            InitializeComponent();
            frmMain = frm;
        }

        private void frmPenjualan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            ppn_persen = setting.getSetting("ppn");
            txtPPN.Text = "0";
                

            cboPPN.SelectedIndex = 0;
            cboFakturPajak.SelectedIndex = 0;
            cboPembayaran.SelectedIndex = 0;
            cboPengiriman.SelectedIndex = 0;
            cboSales.DisplayMember = "nama";
            cboSales.ValueMember = "penjaja_id";
            cboSales.DataSource = db.query("select penjaja_id, nama from penjaja order by nama");
            cboSales.SelectedIndex = 0;
            cboBulanBuku.SelectedIndex = 0;
            generateNomorFaktur();

            string tanggal = DateTime.Now.ToString("MM");
            int tgl = Int32.Parse(tanggal);
            cboBulanBuku.SelectedIndex = tgl - 1;

            radioButton1.Checked = true;
            cboDiskon.SelectedIndex = 0;
            cboCN1.SelectedIndex = 1;
            cboCN2.SelectedIndex = 1;

            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("nama_barang", "Nama Barang");
            dataGridView1.Columns.Add("nama_satuan", "Satuan");
            dataGridView1.Columns.Add("nama_pabrik", "Pabrik");
            dataGridView1.Columns.Add("qty", "Qty");
            dataGridView1.Columns.Add("harga", "Harga");
            dataGridView1.Columns.Add("total", "Total");
            dataGridView1.Columns.Add("diskon_persen", "Disc-%");
            dataGridView1.Columns.Add("diskon_uang", "Disc-Rp");
            dataGridView1.Columns.Add("subtotal", "Subtotal");
            dataGridView1.Columns.Add("cn1_persen", "CN1-%");
            dataGridView1.Columns.Add("cn1_uang", "CN1-Rp");
            dataGridView1.Columns.Add("cn2_persen", "CN2-%");
            dataGridView1.Columns.Add("cn2_uang", "CN2-Rp");
            dataGridView1.Columns.Add("margin", "Margin");
            dataGridView1.Columns.Add("hpp", "HPP");

            dataGridView1.Columns["nama_barang"].Width = 150;
             


            showDataPenjualan();

             
        }

        public void setIDSupplier(string supplier_id, string nama_supplier)
        {
            selected_id_supplier = supplier_id;
            txtSupplier.Text = nama_supplier;

            db.bind("id", selected_id_supplier);
            string sales = db.single("select marketing from supplier where supplier_id = @id");
            cboSales.Text = sales;
        }

        public void setIDBarang(string stok_masuk_idx, string nama_barang)
        {
            selected_id_barang = barang.getIDBarangFromStokMasukID(stok_masuk_idx);
            stok_masuk_id = stok_masuk_idx;
            txtBarang.Text = nama_barang;
            txtHPP.Text = pembelian.getHPP(stok_masuk_id);
        }

        private string generateNomorFaktur()
        {
            string tanggal = DateTime.Now.ToString("yyyyMMdd");
            string cek = db.single("select no_faktur from penjualan where no_faktur like '"+tanggal+"%' order by jual_id desc limit 1");
            if (cek == "")
            {
                cek = tanggal + "0001";
            }
            else
            {
                double cek2 = Double.Parse(cek) + 1;
                cek = cek2.ToString();
            }
            txtFakturPajak.Text = "";
            return cek;
        }

        private string generateNomorFakturPajak()
        {
            string faktur_pajak_berjalan = setting.getSetting("faktur_pajak_berjalan");
            string format_faktur_pajak = setting.getSetting("format_faktur_pajak");
            txtFakturPajak.Text = faktur_pajak_berjalan;
            return cboFakturPajak.Text + format_faktur_pajak + faktur_pajak_berjalan;

        }

        private void showDataPenjualan()
        {
            string sql = "select jual_id, date_format(tanggal, '%d/%m/%Y') as tanggal, no_faktur, supplier.nama_supplier, round(grandtotal,2) as tagihan, " +
                "round((select sum((cn1_uang+cn2_uang) * qty) from penjualan_detail where penjualan_detail.jual_id = penjualan.jual_id),2) as cn, " +
                "case when lunas = 0 then 'Belum Lunas' else 'Lunas' end as status, " +
                "case when format_faktur = 1 then 'Standar' when format_faktur = 2 then 'PPN Include' else 'Disc Include' end as jenis, "+
                "print "+
                "from penjualan " +
                "left join supplier on supplier.supplier_id = penjualan.supplier_id " +
                "where nama_supplier like @nama or no_faktur like @nomor " +
                "order by jual_id desc limit 200";

            db.bind("nama", "%" + txtCari.Text + "%");
            db.bind("nomor", "%" + txtCari.Text + "%");

            dataGridView2.DataSource = db.query(sql);
            dataGridView2.Columns["tagihan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns["cn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns["no_faktur"].Width = 150;
            dataGridView2.Columns["nama_supplier"].Width = 200;
            dataGridView2.Columns["tagihan"].Width = 100;
            dataGridView2.Columns["jual_id"].Width = 50;


            dataGridView2.Columns["tagihan"].DefaultCellStyle.Format = "N2";
            dataGridView2.Columns["cn"].DefaultCellStyle.Format = "N2";
            

            dataGridView2.Columns["jual_id"].HeaderText = "ID";
            dataGridView2.Columns["tanggal"].HeaderText = "Tanggal";
            dataGridView2.Columns["no_faktur"].HeaderText = "No.Faktur";
            dataGridView2.Columns["nama_supplier"].HeaderText = "Nama Customer";
            dataGridView2.Columns["tagihan"].HeaderText = "Grandtotal";
            dataGridView2.Columns["cn"].HeaderText = "CN";
            dataGridView2.Columns["status"].HeaderText = "Status";
            dataGridView2.Columns["jenis"].HeaderText = "Jenis";
            dataGridView2.Columns["print"].HeaderText = "Print";



        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmCariSupplier frm = new frmCariSupplier(this);
            frm.Show();
        }

        private void cboPPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPPN.SelectedIndex == 1)
            {
                txtNomorFaktur.Text = generateNomorFaktur();
                txtPPN.Text = "0";

            }
            else
            {
                txtNomorFaktur.Text = generateNomorFakturPajak();
                txtPPN.Text = ppn_persen;
            }
        }

        private void cboPembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPembayaran.Text == "14")
            {
                jatuh_tempo.Value = DateTime.Now.AddDays(14);
            }
            else if (cboPembayaran.Text == "30")
            {
                jatuh_tempo.Value = DateTime.Now.AddDays(30);
            }
            else if (cboPembayaran.Text == "35")
            {
                jatuh_tempo.Value = DateTime.Now.AddDays(35);
            }
            else if (cboPembayaran.Text == "40")
            {
                jatuh_tempo.Value = DateTime.Now.AddDays(40);
            }
            else if (cboPembayaran.Text == "45")
            {
                jatuh_tempo.Value = DateTime.Now.AddDays(45);
            }
            else if (cboPembayaran.Text == "60")
            {
                jatuh_tempo.Value = DateTime.Now.AddDays(60);
            }
            else
            {
                jatuh_tempo.Value = DateTime.Now;
            }
        }

        private void btnCariBarang_Click(object sender, EventArgs e)
        {
            frmCariBarang form = new frmCariBarang(this);
            form.Show();
        }

        private void btnTambahkan_Click(object sender, EventArgs e)
        {
            if (btnSimpan.Text == "Edit")
            {
                edit_detail = 1;
            }
            else
            {
                edit_detail = 0;
            }
            tambahkanBarang();
        }

        private void tambahkanBarang()
        {
            if (txtBarang.Text != "" && txtQty.Text != "" && txtHarga.Text != "")
            {
                string pabrik_id = barang.getIDPabrikFromBarangID(selected_id_barang);
                string nama_pabrik = pabrik.getNamaPabrikByID(pabrik_id);
                string satuan_id = barang.getIDSatuanFromBarangID(selected_id_barang);
                string nama_satuan = satuan.getNamaSatuanByID(satuan_id);
                double total = Double.Parse(txtQty.Text) * Double.Parse(txtHarga.Text);
                string strTotal = total.ToString();
                double diskon_persen = 0;
                double diskon_uang = 0;
                
                if (cboDiskon.Text == "%" && txtDiskon.Text != "")
                {
                    diskon_persen = Double.Parse(txtDiskon.Text);
                    diskon_uang = total * (diskon_persen / 100);

                }

                if (cboDiskon.Text != "%" && txtDiskon.Text != "")
                {
                    diskon_uang = Double.Parse(txtDiskon.Text);
                    diskon_persen = (diskon_uang / total) * 100;
                }

                double diskon_satuan = diskon_uang / Double.Parse(txtQty.Text);
                
                double grandtotal = total - diskon_uang;

                double cn1_persen = 0; double cn1_uang = 0;
                if (cboCN1.Text == "%" && txtCN1.Text != "")
                {
                    cn1_persen = Double.Parse(txtCN1.Text);
                    cn1_uang = (Double.Parse(txtHarga.Text) -  diskon_satuan) * (cn1_persen / 100);

                }

                if (cboCN1.Text != "%" && txtCN1.Text != "")
                {
                    cn1_uang = Double.Parse(txtCN1.Text) ;
                    cn1_persen = 100 * (cn1_uang / (Double.Parse(txtHarga.Text) - diskon_satuan));

                }

                double cn2_persen = 0; double cn2_uang = 0;
                if (cboCN2.Text == "%" && txtCN2.Text != "")
                {
                    cn2_persen = Double.Parse(txtCN2.Text);
                    cn2_uang = Double.Parse(txtHarga.Text) * (cn2_persen / 100);

                }

                if (cboCN2.Text != "%" && txtCN2.Text != "")
                {
                    cn2_uang = Double.Parse(txtCN2.Text);
                    cn2_persen = 100 * (cn2_uang / (Double.Parse(txtHarga.Text) - diskon_satuan));

                }

                
                string hpp = txtHPP.Text;
                if (hpp == "") hpp = "0";
                 
                double margin = hitungMargin(txtHarga.Text, hpp, diskon_satuan.ToString(), cn1_uang.ToString(), cn2_uang.ToString());
                //double margin = ((double.Parse(txtHarga.Text) - double.Parse(hpp) - diskon_uang) / double.Parse(hpp)) * 100;
                

                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = stok_masuk_id;
                dataGridView1.Rows[index].Cells[1].Value = txtBarang.Text;
                dataGridView1.Rows[index].Cells[2].Value = nama_satuan;
                dataGridView1.Rows[index].Cells[3].Value = nama_pabrik;
                dataGridView1.Rows[index].Cells[4].Value = txtQty.Text;
                dataGridView1.Rows[index].Cells[5].Value = txtHarga.Text.Replace(",","");
                dataGridView1.Rows[index].Cells[6].Value = strTotal;
                dataGridView1.Rows[index].Cells[7].Value = diskon_persen.ToString();
                dataGridView1.Rows[index].Cells[8].Value = diskon_uang.ToString();
                dataGridView1.Rows[index].Cells[9].Value = grandtotal;
                dataGridView1.Rows[index].Cells[10].Value = cn1_persen.ToString();
                dataGridView1.Rows[index].Cells[11].Value = cn1_uang.ToString();
                dataGridView1.Rows[index].Cells[12].Value = cn2_persen.ToString();
                dataGridView1.Rows[index].Cells[13].Value = cn2_uang.ToString();
                dataGridView1.Rows[index].Cells[14].Value = Math.Round(margin, 2, MidpointRounding.AwayFromZero);
                dataGridView1.Rows[index].Cells[15].Value = Math.Round(double.Parse(hpp), 2, MidpointRounding.AwayFromZero);  

                kosongkanFormDataBarang();
                hitungGrandtotal();

                //fungsi.showError(hpp);

            }


        }

        private double hitungMargin(string harga, string hpp, string diskon, string cn1, string cn2)
        {
            double margin = ((double.Parse(txtHarga.Text) - double.Parse(hpp) - double.Parse(diskon) - double.Parse(cn1) - double.Parse(cn2)) / double.Parse(hpp)) * 100;
            return margin;
        }

        private void kosongkanFormDataBarang()
        {
            selected_id_barang = "";
            txtBarang.Text = "";
            txtQty.Text = "";
            txtHarga.Text = "";
            txtDiskon.Text = "";
            txtCN1.Text = "";
            txtCN2.Text = "";
            txtHPP.Text = "";
            cboDiskon.SelectedIndex = 0;
            cboCN1.SelectedIndex = 0;
            cboCN2.SelectedIndex = 0;
            
            lblGrandtotal.Text = "0";
            lblPPN.Text = "0";
            lblGrandtotal.Text = "0";

        }

        private void kosongkanFormPenjualan()
        {
            tanggal.Value = DateTime.Today;
            jatuh_tempo.Value = DateTime.Today;
            txtSupplier.Text = "";
            selected_id_supplier = "";
            selected_id_barang = "";
            stok_masuk_id = "";
            txtNomorFaktur.Text = "";
            txtFakturPajak.Text = "";
            cboPPN.SelectedIndex = 0;
            txtPPN.Text = ppn_persen;
            txtOngkir.Text = "0";
            txtMeterai.Text = "0";
            txtKTP.Text = "";
            subtotal = 0;
            ppn = 0;
            Grandtotal = 0;
            brutto = 0;
            diskon = 0;
            dataGridView1.Rows.Clear();
        }

        private void hitungGrandtotal()
        {
            subtotal = 0;
            diskon = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                subtotal += Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                diskon += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
            }
            brutto = subtotal + diskon;
            lblSubtotal.Text = string.Format("{0:N2}", subtotal);

            string ppn_persenx = txtPPN.Text;
            ppn = subtotal * (Double.Parse(ppn_persenx) / 100);
            lblPPN.Text = string.Format("{0:N2}", ppn);
            Grandtotal = subtotal + ppn;
            lblGrandtotal.Text = string.Format("{0:N2}", Grandtotal);

        }

        private void btnHapusBarang_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (btnSimpan.Text == "Edit")
                {
                    edit_detail = 1;
                }
                else
                {
                    edit_detail = 0;
                }
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                hitungGrandtotal();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            kosongkanFormDataBarang();
            kosongkanFormPenjualan();
            hitungGrandtotal();
            btnSimpan.Text = "Simpan";
        }

        private void btnEditBarang_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (btnSimpan.Text == "Edit")
                {
                    edit_detail = 1;
                }
                else
                {
                    edit_detail = 0;
                }
                stok_masuk_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                selected_id_barang = stok_masuk.getIDBarangFromStokMasukID(stok_masuk_id);
                txtBarang.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtQty.Text = dataGridView1.SelectedRows[0].Cells["qty"].Value.ToString();
                txtHarga.Text = dataGridView1.SelectedRows[0].Cells["harga"].Value.ToString();
                txtDiskon.Text = dataGridView1.SelectedRows[0].Cells["diskon_persen"].Value.ToString();
                txtCN1.Text = dataGridView1.SelectedRows[0].Cells["cn1_persen"].Value.ToString();
                txtCN2.Text = dataGridView1.SelectedRows[0].Cells["cn2_persen"].Value.ToString();
                txtHPP.Text = dataGridView1.SelectedRows[0].Cells["hpp"].Value.ToString().Replace(",","");
                 
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                hitungGrandtotal();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (selected_id_supplier != "" && dataGridView1.Rows.Count > 0)
            {
                if (btnSimpan.Text == "Simpan")
                {
                    hitungGrandtotal();
                    persiapkanData();


                    string sql = "insert into penjualan (tanggal, no_faktur, supplier_id, jatuh_tempo, faktur_pajak, jenis_bayar, penjaja, " +
                    "netto, diskon_persen, diskon_uang, is_pph, is_ppn, pph, ppn, grandtotal, " +
                    "format_faktur, is_active, user, bulan_buku, meterai, ongkir, pengiriman, ppn_persen) values (@tanggal, @no_faktur, @supplier_id, @jatuh_tempo, @faktur_pajak, @jenis_bayar, @penjaja, " +
                    "@netto, @diskon_persen, @diskon_uang, @is_pph, @is_ppn, @pph, @ppn, @grandtotal, " +
                    "@format_faktur, @is_active, @user, @bulan_buku, @meterai, @ongkir, @pengiriman, @ppn_persen)";
                    db.query(sql);

                    simpanDetailPenjualan();
                    if (cboPPN.SelectedIndex == 0)
                    {
                        fungsi.setFakturPajak();

                    }

                    // ktp
                    if (txtKTP.Text != "")
                    {
                        mitrabisnis.updateKTP(txtKTP.Text, selected_id_supplier);
                    }
                    

                    kosongkanFormDataBarang();
                    kosongkanFormPenjualan();
                    hitungGrandtotal();
                    showDataPenjualan();

                    fungsi.showSuccess("Data berhasil disimpan");

                }
                else
                {
                    hitungGrandtotal();
                    btnSimpan.Text = "Simpan";
                    // update penjualan
                    persiapkanData();
                    db.bind("jual_id", id_edit);
                     
                    string sql = "update penjualan "+
                    "set tanggal = @tanggal, supplier_id = @supplier_id, jatuh_tempo = @jatuh_tempo, "+
                    "jenis_bayar = @jenis_bayar, penjaja = @penjaja, " +
                    "netto = @netto, diskon_persen = @diskon_persen, diskon_uang = @diskon_uang, "+
                    "is_pph = @is_pph, is_ppn = @is_ppn, pph = @pph, ppn = @ppn, grandtotal = @grandtotal, " +
                    "format_faktur = @format_faktur, bulan_buku = @bulan_buku, meterai = @meterai, ongkir = @ongkir, pengiriman = @pengiriman "+
                    "where jual_id = @jual_id";
                    db.query(sql);

                    //fungsi.showError(cboPembayaran.Text);

                    if (edit_detail == 1)
                    {
                        penjualan.hapusPenjualanDetail(id_edit);
                         
                        
                        simpanDetailPenjualan();
                    }

                    kosongkanFormDataBarang();
                    kosongkanFormPenjualan();
                    hitungGrandtotal();
                    showDataPenjualan();

                    id_edit = "";

                    fungsi.showSuccess("Data berhasil diedit");
                }
            }
            else
            {
                fungsi.showError("Data Penjualan dan Barang harus diisi.");
            }
        }

        private void persiapkanData()
        {
            string no_faktur = ""; string faktur_pajak = "";
            if (cboPPN.SelectedIndex == 0)
            {
                faktur_pajak = setting.getSetting("faktur_pajak_berjalan");
                no_faktur = generateNomorFakturPajak();
            }
            else
            {
                //faktur_pajak = generateNomorFakturPajak();
                no_faktur = generateNomorFaktur();
            }
            db.bind("tanggal", tanggal.Value.ToString("yyyy/MM/dd"));
            db.bind("jatuh_tempo", jatuh_tempo.Value.ToString("yyyy/MM/dd"));
            db.bind("supplier_id", selected_id_supplier);
            
            db.bind("no_faktur", no_faktur);
            db.bind("faktur_pajak", faktur_pajak);
            db.bind("is_active", "1");
            db.bind("brutto", brutto.ToString());
            db.bind("ppn", ppn.ToString());
            db.bind("netto", subtotal.ToString());
            db.bind("diskon", diskon.ToString());
            

            if (cboDiskon.SelectedIndex == 0 && txtDiskon.Text != "")
            {

                double diskon_uang = subtotal * (Double.Parse(txtDiskon.Text) / 100);
                db.bind("diskon_persen", txtDiskon.Text);
                db.bind("diskon_uang", diskon_uang.ToString());

            }
            else if (cboDiskon.SelectedIndex == 1 && txtDiskon.Text != "")
            {
                double diskon_persen = (Double.Parse(txtDiskon.Text) / subtotal) * 100;
                db.bind("diskon_persen", diskon_persen.ToString());
                db.bind("diskon_uang", txtDiskon.Text);
            }
            else
            {
                db.bind("diskon_persen", "0");
                db.bind("diskon_uang", "0");
            }


            if (cboCN1.SelectedIndex == 0 && txtCN1.Text != "")
            {

                double cn1_uang = subtotal * (Double.Parse(txtCN1.Text) / 100);
                db.bind("cn1_persen", txtCN1.Text);
                db.bind("cn1_uang", cn1_uang.ToString());

            }
            else if (cboCN1.SelectedIndex == 1 && txtCN1.Text != "")
            {
                double cn1_persen = (Double.Parse(txtCN1.Text) / subtotal) * 100;
                db.bind("cn1_persen", cn1_persen.ToString());
                db.bind("cn1_uang", txtCN1.Text);
            }
            else
            {
                db.bind("cn1_persen", "0");
                db.bind("cn1_uang", "0");
            }

            if (cboCN2.SelectedIndex == 0 && txtCN2.Text != "")
            {

                double cn2_uang = subtotal * (Double.Parse(txtCN2.Text) / 100);
                db.bind("cn2_persen", txtCN2.Text);
                db.bind("cn2_uang", cn2_uang.ToString());

            }
            else if (cboCN2.SelectedIndex == 1 && txtCN2.Text != "")
            {
                double cn2_persen = (Double.Parse(txtCN2.Text) / subtotal) * 100;
                db.bind("cn2_persen", cn2_persen.ToString());
                db.bind("cn2_uang", txtCN2.Text);
            }
            else
            {
                db.bind("cn2_persen", "0");
                db.bind("cn2_uang", "0");
            }

            
            db.bind("grandtotal", Grandtotal.ToString());
            db.bind("user", frmMain.getUsername());
            db.bind("jenis_bayar", cboPembayaran.Text);
            db.bind("penjaja", cboSales.Text);
            db.bind("is_pph", "1");
            string is_ppn = "0";
            if (cboPPN.SelectedIndex == 0)
            {
                is_ppn = "1";

            }
            db.bind("is_ppn", is_ppn);
            db.bind("pph", "0");
            string format_faktur = "1";
            if (radioButton2.Checked) format_faktur = "2";
            if (radioButton3.Checked) format_faktur = "3";

            db.bind("format_faktur", format_faktur);
            db.bind("bulan_buku", cboBulanBuku.Text);
            db.bind("meterai", txtMeterai.Text);
            db.bind("ongkir", txtOngkir.Text);
            db.bind("pengiriman", cboPengiriman.Text);
            db.bind("ppn_persen", txtPPN.Text);
        }

        private void simpanDetailPenjualan()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string jual_id = "";
                if (id_edit != "")
                {
                    // edit
                    jual_id = id_edit;
                }
                else
                {
                    
                     // baru
                     jual_id = penjualan.getLatestIDPenjualan();
                }
                

                
                string sql = "";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sql = "insert into penjualan_detail (jual_id, barang_id, qty, harga, diskon_persen, diskon_uang, " +
                    "cn1_persen, cn1_uang, cn2_persen, cn2_uang, total_harga, pph, margin, hpp, penjualan_bersih, untung, "+
                    "laba_bersih, persen_laba_bersih, stok_masuk_id) values (@jual_id, @barang_id, @qty, @harga, @diskon_persen, @diskon_uang, " +
                    "@cn1_persen, @cn1_uang, @cn2_persen, @cn2_uang, @total_harga, @pph, @margin, @hpp, @penjualan_bersih, @untung, " +
                    "@laba_bersih, @persen_laba_bersih, @stok_masuk_id)";

                    string qty = dataGridView1.Rows[i].Cells["qty"].Value.ToString();
                    string harga = dataGridView1.Rows[i].Cells["harga"].Value.ToString();
                    string diskon_uang = dataGridView1.Rows[i].Cells["diskon_uang"].Value.ToString();
                    string cn1_uang = dataGridView1.Rows[i].Cells["cn1_uang"].Value.ToString();
                    string cn2_uang = dataGridView1.Rows[i].Cells["cn2_uang"].Value.ToString();
                    string total_harga = dataGridView1.Rows[i].Cells["subtotal"].Value.ToString();
                    db.bind("jual_id", jual_id);
                    db.bind("barang_id", stok_masuk.getIDBarangFromStokMasukID(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                    db.bind("qty", qty);
                    db.bind("harga", harga);
                    db.bind("diskon_persen", dataGridView1.Rows[i].Cells["diskon_persen"].Value.ToString());
                    db.bind("diskon_uang", diskon_uang);
                    db.bind("cn1_persen", dataGridView1.Rows[i].Cells["cn1_persen"].Value.ToString());
                    db.bind("cn1_uang", cn1_uang);
                    db.bind("cn2_persen", dataGridView1.Rows[i].Cells["cn2_persen"].Value.ToString());
                    db.bind("cn2_uang", cn2_uang);
                    db.bind("total_harga", total_harga);
                    db.bind("pph", "1");


                    string hpp = dataGridView1.Rows[i].Cells["hpp"].Value.ToString();
                    double penjualan_bersih = double.Parse(total_harga) - double.Parse(cn1_uang) - double.Parse(cn2_uang);
                    db.bind("hpp", hpp);
                  
                    db.bind("penjualan_bersih", penjualan_bersih.ToString());
                    db.bind("untung", "0");
                    db.bind("laba_bersih", "0");
                    db.bind("persen_laba_bersih", "0");
                    string stok_masuk_id = dataGridView1.Rows[i].Cells["id"].Value.ToString();
                    db.bind("stok_masuk_id", stok_masuk_id);
                    db.bind("margin", dataGridView1.Rows[i].Cells["margin"].Value.ToString());
                    

                    db.query(sql);

                    // stok keluar
                    //string detail_id = pembelian.getLatestDetailID();
                    stok_masuk.kurangiStok(stok_masuk_id, qty);

                }
            }
        }

         

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Anda yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                hapusDataPenjualan();
                showDataPenjualan();
            }
        }

        private void hapusDataPenjualan()
        {
            penjualan.hapusPenjualan(dataGridView2.SelectedRows[0].Cells["jual_id"].Value.ToString());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Anda yakin ingin mencetak faktur?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string jual_id = dataGridView2.SelectedRows[0].Cells["jual_id"].Value.ToString();
                    penjualan.setPrint(jual_id);

                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);


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
            Font fontConsolas = new Font("Lucida Console", 10.0f);
            Font fontConsolasB = new Font("Lucida Console", 10.0f, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);

            // ambil detail perusahaan
            string nama_perusahaan = setting.getSetting("nama_perusahaan");
            string alamat = setting.getSetting("alamat");
            string kota_perusahaan = setting.getSetting("kota");
            string telepon = setting.getSetting("telepon");
            string fax = setting.getSetting("fax");
            string npwp = setting.getSetting("npwp");

            // ambil data faktur
            string jual_id = dataGridView2.SelectedRows[0].Cells["jual_id"].Value.ToString();
            string no_faktur = penjualan.getPenjualan(jual_id, "no_faktur");
            string tanggal = penjualan.getPenjualan(jual_id, "tanggal");
            string penjaja = penjualan.getPenjualan(jual_id, "penjaja");
            string jatuh_tempo = penjualan.getPenjualan(jual_id, "jatuh_tempo");
            string pengiriman = penjualan.getPenjualan(jual_id, "pengiriman");
            string ppn = penjualan.getPenjualan(jual_id, "ppn_persen");

            // ambil data customer
            string customer_id = penjualan.getPenjualan(jual_id, "supplier_id");
            string nama_customer = mitrabisnis.getMitraBisnis(customer_id, "nama_supplier");
            string alamat_customer = mitrabisnis.getMitraBisnis(customer_id, "alamat");
            string kota_customer = kota.getNamaKota(mitrabisnis.getMitraBisnis(customer_id, "kota_id"));
            string npwp_customer = mitrabisnis.getMitraBisnis(customer_id, "npwp");
            string telepon_customer = mitrabisnis.getMitraBisnis(customer_id, "telepon");
            string is_ppn = penjualan.getPenjualan(jual_id, "is_ppn");

            string jenis_faktur = penjualan.getPenjualan(jual_id, "format_faktur");
            
             
            // cetak perusahaan
            //if (is_ppn == "1")
            //{
                e.Graphics.DrawString(nama_perusahaan, fontTimes12, brush, xPos, yPos, new StringFormat());
                yPos += fontTimes12.Height;
                e.Graphics.DrawString("ALAT KESEHATAN DAN LABORATORIUM", fontTimes10R, brush, xPos, yPos, new StringFormat());
                yPos += fontTimes10R.Height;
                e.Graphics.DrawString(alamat + " " + kota_perusahaan, fontTimes10R, brush, xPos, yPos, new StringFormat());
                yPos += fontTimes10R.Height;
                e.Graphics.DrawString("Telepon: " + telepon, fontTimes10R, brush, xPos, yPos, new StringFormat());
                yPos += fontTimes10R.Height;
                e.Graphics.DrawString("NPWP: " + npwp, fontTimes10R, brush, xPos, yPos, new StringFormat());
                yPos += fontTimes10R.Height;
            //}
            ////else
            //{
            //    e.Graphics.DrawString("ALAT KESEHATAN DAN LABORATORIUM", fontTimes10R, brush, xPos, yPos, new StringFormat());
            //    
            //}


            // cetak nomor faktur
            yPos = 0;
            xPos = 320;
            if (is_ppn == "1")
            {
                e.Graphics.DrawString("FAKTUR PENJUALAN", fontTimes12, brush, xPos, yPos, new StringFormat());
            }
            else
            {
                e.Graphics.DrawString("INVOICE PENJUALAN", fontTimes12, brush, xPos, yPos, new StringFormat());
            }
            yPos += fontTimes12.Height;
            xPos = 300;
            e.Graphics.DrawString("No.Faktur", fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            e.Graphics.DrawString("Tanggal", fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            e.Graphics.DrawString("Sales", fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            e.Graphics.DrawString("Jatuh Tempo", fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            //e.Graphics.DrawString("Pengiriman", fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos -= fontTimes10R.Height * 4;
            xPos = 380;
            e.Graphics.DrawString(": " + no_faktur, fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            e.Graphics.DrawString(": " + fungsi.tanggal_indo(tanggal), fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            e.Graphics.DrawString(": " + penjaja, fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            e.Graphics.DrawString(": " + fungsi.tanggal_indo(jatuh_tempo), fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            //e.Graphics.DrawString(": " + pengiriman, fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;

            yPos = 0;
            xPos = 540;
            e.Graphics.DrawString("KEPADA YTH.", fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            e.Graphics.DrawString(nama_customer, fontTimes12, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes12.Height;
            e.Graphics.DrawString(alamat_customer, fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            e.Graphics.DrawString(kota_customer, fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += fontTimes10R.Height;
            if (!string.IsNullOrEmpty(npwp_customer))
            {
                e.Graphics.DrawString("NPWP: " + npwp_customer, fontTimes10R, brush, xPos, yPos, new StringFormat());
                yPos += fontTimes10R.Height;

            }
            else
            {

                string ktp = mitrabisnis.getMitraBisnis(customer_id, "ktp");
                e.Graphics.DrawString("KTP: " + ktp, fontTimes10R, brush, xPos, yPos, new StringFormat());
                yPos += fontTimes10R.Height;
            }
            yPos = (fontTimes10R.Height * 6);
            xPos = 0;
            Pen blackPen = new Pen(System.Drawing.Color.Black, 1);
            PointF point1 = new PointF(0, yPos);
            PointF point2 = new PointF(800, yPos);
            e.Graphics.DrawLine(blackPen, point1, point2);

            yPos += 3;
            Single xNo = xPos;
            Single xNamaBarang = xNo + 30;
            Single xJumlah = xNamaBarang + 420;
            Single xHargaSatuan = xJumlah + 80;
            Single xDiskon = xHargaSatuan + 100;
            Single xTotal = xDiskon + 40;
            
            xPos = xNo;
            e.Graphics.DrawString("No.", fontTimes10R, brush, xPos, yPos, new StringFormat());
            xPos = xNamaBarang;
            e.Graphics.DrawString("Nama Barang", fontTimes10R, brush, xPos, yPos, new StringFormat());
            xPos = xJumlah;
            e.Graphics.DrawString("Jumlah", fontTimes10R, brush, xPos, yPos, new StringFormat());
            xPos = xHargaSatuan;
            e.Graphics.DrawString("Harga Satuan", fontTimes10R, brush, xPos, yPos, new StringFormat());
            xPos = xDiskon;
            e.Graphics.DrawString("Diskon", fontTimes10R, brush, xPos, yPos, new StringFormat());
            xPos = xTotal+30;
            e.Graphics.DrawString("Total", fontTimes10R, brush, xPos, yPos, new StringFormat());
            yPos += 3 + fontTimes10R.Height;


            point1 = new PointF(0, yPos);
            point2 = new PointF(800, yPos);
            e.Graphics.DrawLine(blackPen, point1, point2);
            string baris = setting.getSetting("row_per_page");
            Single yBaris2 = yPos + (int.Parse(baris) * fontConsolas.Height);

            yPos += 3;

            // ambil detail barang
            DataTable dt = penjualan.getDetailBarang(jual_id);
            double dpp = 0; int no_urut =0;
            foreach (DataRow row in dt.Rows)
            {
                no_urut++;
                string qty = row["qty"].ToString();
                string nama_satuan = row["nama_satuan"].ToString();
                string nama_barang = row["nama_barang"].ToString();
                string harga = row["harga"].ToString();
                string diskon = row["diskon_persen"].ToString();
                string total = row["total_harga"].ToString();
                string lot = row["lot"].ToString();
                string ed = row["ed"].ToString();
                string barang_id = row["barang_id"].ToString();

                string pabrik_id = barang.getIDPabrikFromIDBarang(barang_id);
                string nama_pabrik = pabrik.getNamaPabrikByID(pabrik_id);

                double hargax = 0; double totalx = 0;
                if (jenis_faktur == "1")
                {
                    hargax = Double.Parse(harga);
                    totalx = Double.Parse(total);
                    dpp += totalx;
                }
                else
                {
                    hargax = (Double.Parse(harga) * (1 + (double.Parse(ppn) / 100)));
                    totalx = (hargax - (hargax * (double.Parse(diskon)/100))) * double.Parse(qty);
                    dpp += totalx;
                }
                

                 
                xPos = xNo;
                e.Graphics.DrawString(no_urut.ToString()+ ".", fontConsolas, brush, xPos, yPos, new StringFormat());

                int tambah_baris = 0;
                xPos = xNamaBarang;
                string nama_barangx = "";
                nama_barang = nama_barang + " " + nama_pabrik;
                if (nama_barang.Length > 45)
                {
                    nama_barangx = nama_barang.Substring(0, 45);
                    string nama_barang2 = nama_barang.Substring(45, nama_barang.Length - 45);
                    e.Graphics.DrawString(nama_barangx, fontConsolas, brush, xPos, yPos, new StringFormat());
                    yPos += fontConsolas.Height;
                    if (nama_barang2.Length > 45)
                    {
                        string nama_barang3 = nama_barang2.Substring(0, 45);
                        string nama_barang4 = nama_barang2.Substring(45, nama_barang2.Length - 45);
                        e.Graphics.DrawString(nama_barang3.Trim(), fontConsolas, brush, xPos, yPos, new StringFormat());
                        yPos += fontConsolas.Height;
                        e.Graphics.DrawString(nama_barang4.Trim(), fontConsolas, brush, xPos, yPos, new StringFormat());
                        yPos -= fontConsolas.Height * 2;
                        tambah_baris = 3;

                    }
                    else
                    {
                        e.Graphics.DrawString(nama_barang2.Trim(), fontConsolas, brush, xPos, yPos, new StringFormat());
                        yPos -= fontConsolas.Height;
                        tambah_baris = 2;
                    }
                }
                else
                {
                    nama_barangx = nama_barang;
                    e.Graphics.DrawString(nama_barangx, fontConsolas, brush, xPos, yPos, new StringFormat());
                    tambah_baris = 1;
                }
                xPos = xHargaSatuan - 20;
                e.Graphics.DrawString(string.Format("{0:N2}", hargax).PadLeft(13), fontConsolas, brush, xPos, yPos, new StringFormat());
                xPos = xJumlah;
                e.Graphics.DrawString(qty + " " + nama_satuan, fontConsolas, brush, xPos, yPos, new StringFormat());
                xPos = xDiskon;
                if (diskon != "0")
                {
                    e.Graphics.DrawString(diskon + "%", fontConsolas, brush, xPos, yPos, new StringFormat());
                }
                xPos = xTotal;
                e.Graphics.DrawString(string.Format("{0:N2}", totalx).PadLeft(13), fontConsolas, brush, xPos, yPos, new StringFormat());
                //e.Graphics.DrawString(qty + " " + nama_satuan, fontConsolas, brush, xPos, yPos, new StringFormat());
                yPos += ( fontConsolas.Height * tambah_baris ) + 3; 
            }

            string ppn_uang = penjualan.getPenjualan(jual_id, "ppn");
            string grandtotal = penjualan.getPenjualan(jual_id, "grandtotal");
            string meterai = penjualan.getPenjualan(jual_id, "meterai");
            string ongkir = penjualan.getPenjualan(jual_id, "ongkir");
            
            double ppnx = Double.Parse(ppn_uang);
            double meteraix = Double.Parse(meterai);
            double ongkirx = Double.Parse(ongkir);
             
            decimal grandtotalx = Math.Round(decimal.Parse(grandtotal) + decimal.Parse(ongkir), 2, MidpointRounding.AwayFromZero);


            yPos = yBaris2;
            point1 = new PointF(0, yPos);
            point2 = new PointF(800, yPos);
            e.Graphics.DrawLine(blackPen, point1, point2);
            //yPos += fontConsolas.Height;
            xPos = 0;
            
            string terbilang = "Terbilang: " + fungsi.Terbilang(grandtotalx) + " rupiah";
            yPos += 5;
            if (terbilang.Length > 50)
            {
                string terbilang1 = terbilang.Substring(0,50); 
                string terbilang2 = terbilang.Substring(50,terbilang.Length-50);
                e.Graphics.DrawString(terbilang1 + "-", fontConsolas, brush, xPos, yPos, new StringFormat());
                yPos += fontConsolas.Height;

                if (terbilang2.Length > 50)
                {
                    string terbilang3 = terbilang2.Substring(0, 50);
                    string terbilang4 = terbilang2.Substring(50, terbilang2.Length - 50);
                
                    e.Graphics.DrawString(terbilang3.Trim()+ "-", fontConsolas, brush, xPos, yPos, new StringFormat());
                    yPos += fontConsolas.Height;
                    e.Graphics.DrawString(terbilang4.Trim(), fontConsolas, brush, xPos, yPos, new StringFormat());
                
                }
                else
                {
                    e.Graphics.DrawString(terbilang2.Trim(), fontConsolas, brush, xPos, yPos, new StringFormat());
                
                }

                
            }
            else
            {
                e.Graphics.DrawString(terbilang, fontConsolas, brush, xPos, yPos, new StringFormat());
            }
            xPos = xJumlah + 20;
            yPos = yBaris2 + 5;
            e.Graphics.DrawString("Hormat Kami,", fontConsolas, brush, xPos, yPos, new StringFormat());
            xPos += 110;
            if (jenis_faktur == "1")
            {
                e.Graphics.DrawString("DPP", fontConsolas, brush, xPos, yPos, new StringFormat());
            }
            else
            {
                e.Graphics.DrawString("Jumlah", fontConsolas, brush, xPos, yPos, new StringFormat());
 
            }
            yPos += fontConsolas.Height;
            e.Graphics.DrawString("PPN", fontConsolas, brush, xPos, yPos, new StringFormat());
            yPos += fontConsolas.Height;
            e.Graphics.DrawString("Meterai", fontConsolas, brush, xPos, yPos, new StringFormat());
            yPos += fontConsolas.Height;
            e.Graphics.DrawString("Ongkir", fontConsolas, brush, xPos, yPos, new StringFormat());
            yPos += fontConsolas.Height;
            e.Graphics.DrawString("Tagihan", fontConsolasB, brush, xPos, yPos, new StringFormat());
            yPos = yBaris2+5;
            xPos += 90;
            e.Graphics.DrawString(string.Format("{0:N2}", dpp).PadLeft(13), fontConsolas, brush, xPos, yPos, new StringFormat());
            yPos += fontConsolas.Height;
            if (jenis_faktur == "1")
            {
                e.Graphics.DrawString(string.Format("{0:N2}", ppnx).PadLeft(13), fontConsolas, brush, xPos, yPos, new StringFormat());
            }
            else
            {
                e.Graphics.DrawString("Include".PadLeft(13), fontConsolas, brush, xPos, yPos, new StringFormat());
 
            }
            yPos += fontConsolas.Height;
            e.Graphics.DrawString(string.Format("{0:N2}", meteraix).PadLeft(13), fontConsolas, brush, xPos, yPos, new StringFormat());
            yPos += fontConsolas.Height;
            e.Graphics.DrawString(string.Format("{0:N2}", ongkirx).PadLeft(13), fontConsolas, brush, xPos, yPos, new StringFormat());
            yPos += fontConsolas.Height;
            e.Graphics.DrawString(string.Format("{0:N2}", grandtotalx).PadLeft(13), fontConsolasB, brush, xPos, yPos, new StringFormat());


            yPos = yBaris2 + (fontConsolas.Height * 6);
            xPos = 0;
            e.Graphics.DrawString("Penerima", fontConsolas, brush, xPos, yPos, new StringFormat());
            xPos += 250;
            e.Graphics.DrawString("Gudang", fontConsolas, brush, xPos, yPos, new StringFormat());
            xPos += 150;
            //e.Graphics.DrawString("Ekspedisi", fontConsolas, brush, xPos, yPos, new StringFormat());
            
            xPos = xJumlah + 20;
            string direktur = setting.getSetting("direktur");
            e.Graphics.DrawString(direktur, fontConsolas, brush, xPos, yPos, new StringFormat());
            
                



            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtHarga.Text != "")
            {
                double harga = double.Parse(txtHarga.Text);
                
                double ppn = 1 + (double.Parse(ppn_persen) / 100);
                double harga2 = harga / ppn;
                txtHarga.Text = string.Format("{0:N2}",harga2);
            }

        }

        private void txtPPN_Leave(object sender, EventArgs e)
        {
            if (txtPPN.Text == "")
            {
                txtPPN.Text = "11";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                btnSimpan.Text = "Edit";
                kosongkanFormDataBarang();
                kosongkanFormPenjualan();
                id_edit = dataGridView2.SelectedRows[0].Cells["jual_id"].Value.ToString();
                
                string[] tanggalx = penjualan.getPenjualan(id_edit, "tanggal").Split(' ');
                tanggal.Value = DateTime.ParseExact(tanggalx[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string[] jatuh_tempox = penjualan.getPenjualan(id_edit, "jatuh_tempo").Split(' ');
                jatuh_tempo.Value = DateTime.ParseExact(jatuh_tempox[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                
                string customer_id = penjualan.getPenjualan(id_edit, "supplier_id");
                selected_id_supplier = customer_id;
                txtSupplier.Text = mitrabisnis.getMitraBisnis(customer_id, "nama_supplier");
                string pembayaran = penjualan.getPenjualan(id_edit, "jenis_bayar");
                cboPembayaran.Text = pembayaran;
                string pengiriman = penjualan.getPenjualan(id_edit, "pengiriman");
                cboPengiriman.Text = pengiriman;
                string is_ppn = penjualan.getPenjualan(id_edit, "is_ppn");
                if (is_ppn == "1")
                {
                    cboPPN.SelectedIndex = 0;
                    txtPPN.Text = penjualan.getPenjualan(id_edit, "ppn_persen"); ;
                }
                else
                {
                    cboPPN.SelectedIndex = 1;
                    txtPPN.Text = "0";
                }
                string no_faktur = penjualan.getPenjualan(id_edit, "no_faktur");
                txtNomorFaktur.Text = no_faktur;
                string no_faktur_pajak = penjualan.getPenjualan(id_edit, "faktur_pajak");
                txtFakturPajak.Text = no_faktur_pajak;
                string sales = penjualan.getPenjualan(id_edit, "penjaja");
                cboSales.Text = sales;
                string bulan_buku = penjualan.getPenjualan(id_edit, "bulan_buku");
                cboBulanBuku.Text = bulan_buku;

                txtKTP.Text = mitrabisnis.getMitraBisnis(customer_id, "ktp");
                txtOngkir.Text = penjualan.getPenjualan(id_edit, "ongkir");
                txtMeterai.Text = penjualan.getPenjualan(id_edit, "meterai");
                string format_faktur = penjualan.getPenjualan(id_edit, "format_faktur");
                if (format_faktur == "1")
                {
                    radioButton1.Checked = true;
                }
                else if (format_faktur == "2")
                {
                    radioButton2.Checked = true;
                }

                // load detail barang
                DataTable dt = penjualan.getDetailBarang(id_edit);
                foreach (DataRow row in dt.Rows)
                {
                    selected_id_barang = row["barang_id"].ToString();
                    stok_masuk_id = row["stok_masuk_id"].ToString();
                    txtBarang.Text = barang.getNamaBarangFromIDBarang( selected_id_barang);
                    txtQty.Text = row["qty"].ToString();
                    txtHarga.Text = row["harga"].ToString();
                    txtDiskon.Text = row["diskon_persen"].ToString();
                    cboDiskon.SelectedIndex = 0;
                    txtCN1.Text = row["cn1_persen"].ToString();
                    txtCN2.Text = row["cn2_persen"].ToString();
                    cboCN1.SelectedIndex = 0;
                    cboCN2.SelectedIndex = 0;
                    txtHPP.Text = row["hpp"].ToString();

                    tambahkanBarang();
                        
                    
                }

                

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cariFaktur();
        }

        private void cariFaktur()
        {
            showDataPenjualan();
        }

        private void txtCari_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCari_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cariFaktur();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                var sheet = new Worksheet("DATA PENJUALAN");
                sheet.Cells["A1"] = "DATA PENJUALAN";
                sheet.Cells["A1"].Bold = true;

                int baris = 2;
                int counter = 1;
                int kolom = 0;
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {

                    DataGridViewColumnHeaderCell headerCell = column.HeaderCell;
                    string headerCaptionText = column.HeaderText;
                    string columnName = column.Name;

                    sheet.Cells[baris, kolom] = columnName;
                    kolom++;
                }

                baris = 3;
                counter = 1;
                foreach (DataGridViewRow row in dataGridView2.Rows)
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
                string path = Directory.GetCurrentDirectory() + "\\Data_Penjualan.xlsx";
                workbook.Save(path);
                Process.Start(path);

            }
        }

        private void cboFakturPajak_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
