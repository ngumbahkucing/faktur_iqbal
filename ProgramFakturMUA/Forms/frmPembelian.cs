
using Simplexcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramFakturMUA
{
    public partial class frmPembelian : Form
    {
        string selected_id_supplier = ""; 
        string stok_masuk_id = "";
        string selected_id_barang = "";
        Db db = new Db();
        Functions fungsi = new Functions();
        Barang barang = new Barang();
        Pabrik pabrik = new Pabrik();
        Satuan satuan = new Satuan();
        Setting setting = new Setting();
        Pembelian pembelian = new Pembelian();
        Stok_masuk stok_masuk = new Stok_masuk();
        MitraBisnis mitrabisnis = new MitraBisnis();
        double subtotal = 0; 
        double ppn = 0; 
        double Grandtotal = 0;
        double brutto = 0;
        double diskon = 0;
        string ppn_persen = "";
        frmMain frmMain;
        string id_edit = "";
        int edit_detail = 0;
         
        
        public frmPembelian(frmMain frm)
        {
            InitializeComponent();
            frmMain = frm;
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmCariSupplier frm = new frmCariSupplier(this);
            frm.Show();
        }

        private void frmPembelian_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            cboDiskon.SelectedIndex = 0;
            cboPPN.SelectedIndex = 0;
            cboDiskonTambahan.SelectedIndex = 0;
            ppn_persen = setting.getSetting("ppn");

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
            dataGridView1.Columns.Add("lot", "Lot");
            dataGridView1.Columns.Add("ed", "ED");

            showDataPembelian();


        }


        public void setIDSupplier(string supplier_id, string nama_supplier)
        {
            selected_id_supplier = supplier_id;
            txtSupplier.Text = nama_supplier;
        }

        public void setIDBarang(string stok_masuk_idx, string nama_barang)
        {
            selected_id_barang = stok_masuk_idx;
            stok_masuk_id = stok_masuk_idx;
            txtBarang.Text = nama_barang;
        }

        private void checkED_CheckedChanged(object sender, EventArgs e)
        {
            if (checkED.Checked)
            {
                tanggal_ed.Visible = true;
            }
            else
            {
                tanggal_ed.Visible = false;
            }
        }

        private void btnCariBarang_Click(object sender, EventArgs e)
        {
            frmCariBarang frm = new frmCariBarang(this);
            frm.Show();
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
                //fungsi.showError(selected_id_barang);
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
                double grandtotal = total - diskon_uang;
                string ed = "";
                if (checkED.Checked)
                {
                    ed = tanggal_ed.Value.ToString("yyyy/MM/dd");
                }

                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = stok_masuk_id;
                dataGridView1.Rows[index].Cells[1].Value = txtBarang.Text;
                dataGridView1.Rows[index].Cells[2].Value = nama_satuan;
                dataGridView1.Rows[index].Cells[3].Value = nama_pabrik;
                dataGridView1.Rows[index].Cells[4].Value = txtQty.Text;
                dataGridView1.Rows[index].Cells[5].Value = txtHarga.Text;
                dataGridView1.Rows[index].Cells[6].Value = strTotal;
                dataGridView1.Rows[index].Cells[7].Value = diskon_persen.ToString();
                dataGridView1.Rows[index].Cells[8].Value = diskon_uang.ToString();
                dataGridView1.Rows[index].Cells[9].Value = grandtotal;
                dataGridView1.Rows[index].Cells[10].Value = txtLot.Text;
                dataGridView1.Rows[index].Cells[11].Value = ed;

                kosongkanFormDataBarang();
                hitungGrandtotal();



            }
        }

        private void kosongkanFormDataBarang()
        {
            selected_id_barang = "";
            txtBarang.Text = "";
            txtQty.Text = "";
            txtHarga.Text = "";
            txtDiskon.Text = "";
            txtLot.Text = "";
            cboDiskon.SelectedIndex = 0;
            checkED.Checked = false;
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
            txtNomorFaktur.Text = "";
            txtFakturPajak.Text = "";
            cboPPN.SelectedIndex = 0;
            subtotal = 0;
            ppn = 0;
            Grandtotal = 0;
            brutto = 0;
            diskon = 0;
            dataGridView1.Rows.Clear();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
             
            ppn = subtotal * (Double.Parse(ppn_persen) / 100);
            lblPPN.Text = string.Format("{0:N2}", ppn);
            Grandtotal = subtotal + ppn;
            lblGrandtotal.Text = string.Format("{0:N2}", Grandtotal);

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
                //selected_id_barang = stok_masuk.getIDBarangFromStokMasukID(stok_masuk_id);
                selected_id_barang = stok_masuk_id;
                txtBarang.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtQty.Text = dataGridView1.SelectedRows[0].Cells["qty"].Value.ToString();
                txtHarga.Text = dataGridView1.SelectedRows[0].Cells["harga"].Value.ToString();
                txtDiskon.Text = dataGridView1.SelectedRows[0].Cells["diskon_persen"].Value.ToString();
                txtLot.Text = dataGridView1.SelectedRows[0].Cells["lot"].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells["ed"].Value.ToString() != "")
                {
                    checkED.Checked = true;
                    tanggal_ed.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["ed"].Value.ToString());
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

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (selected_id_supplier != "" && dataGridView1.Rows.Count > 0)
            {
                if (btnSimpan.Text == "Simpan")
                {
                    hitungGrandtotal();
                    persiapkanData();

                    string sql = "insert into pembelian (tanggal, no_faktur, supplier_id, jatuh_tempo, brutto, diskon, "+
                    "jenis_diskon2, diskon_persen2, diskon_uang2, netto, ppn_persen, ppn, tagihan, faktur_pajak, "+
                    "is_active, user, ongkir, meterai) values (@tanggal, @no_faktur, @supplier_id, @jatuh_tempo, @brutto, @diskon, " +
                    "@jenis_diskon2, @diskon_persen2, @diskon_uang2, @netto, @ppn_persen, @ppn, @tagihan, @faktur_pajak, " +
                    "@is_active, @user, @ongkir, @meterai)";
                    db.query(sql);

                    simpanDetailPembelian();

                    kosongkanFormDataBarang();
                    kosongkanFormPenjualan();
                    hitungGrandtotal();
                    showDataPembelian();

                    fungsi.showSuccess("Data berhasil disimpan");

                }

                else
                {
                    hitungGrandtotal();
                    btnSimpan.Text = "Simpan";
                    // update penjualan
                    persiapkanData();
                    db.bind("beli_id", id_edit);
                    string sql = "update pembelian " +
                    "set tanggal = @tanggal, no_faktur = @no_faktur, supplier_id= @supplier_id, jatuh_tempo= @jatuh_tempo, brutto=@brutto, diskon=@diskon, " +
                    "jenis_diskon2=@jenis_diskon2, diskon_persen2=@diskon_persen2,diskon_uang2= @diskon_uang2, netto=@netto, ppn_persen=@ppn_persen, ppn=@ppn, tagihan=@tagihan, faktur_pajak=@faktur_pajak, " +
                    "is_active=@is_active, user=@user, meterai = @meterai, ongkir = @ongkir " +
                    "where beli_id = @beli_id";
                    db.query(sql);

                    //fungsi.showError(cboPembayaran.Text);

                    if (edit_detail == 1)
                    {
                        //pembelian.hapusPembelianDetail(id_edit);


                        editDetailPembelian();
                    }

                    kosongkanFormDataBarang();
                    kosongkanFormPenjualan();
                    hitungGrandtotal();
                    showDataPembelian();

                    id_edit = "";

                    fungsi.showSuccess("Data berhasil diedit");
                }
            }
            else
            {
                fungsi.showError("Data Pembelian dan Barang harus diisi.");
            }
        }

        private void persiapkanData()
        {
            db.bind("tanggal", tanggal.Value.ToString("yyyy/MM/dd"));
            db.bind("jatuh_tempo", jatuh_tempo.Value.ToString("yyyy/MM/dd"));
            db.bind("supplier_id", selected_id_supplier);
            db.bind("no_faktur", txtNomorFaktur.Text);
            db.bind("faktur_pajak", txtFakturPajak.Text);
            db.bind("is_active", "1");
            db.bind("brutto", brutto.ToString());
            db.bind("ppn", ppn.ToString());
            db.bind("netto", subtotal.ToString());
            db.bind("diskon", diskon.ToString());
            db.bind("jenis_diskon2", cboDiskonTambahan.SelectedIndex.ToString());
            if (id_edit == "")
            {
                db.bind("diskon_persen2", "0");
                db.bind("diskon_uang2", "0");
            }

            if (cboDiskonTambahan.SelectedIndex == 0 && txtDiskonTambahan.Text != "")
            {
                double diskon2 = subtotal * (Double.Parse(txtDiskonTambahan.Text) / 100);
                 
                db.bind("diskon_persen2", txtDiskonTambahan.Text);
                db.bind("diskon_uang2", diskon2.ToString());

            }

            if (cboDiskonTambahan.SelectedIndex == 1 && txtDiskonTambahan.Text != "")
            {
                double diskon2 = Double.Parse(txtDiskonTambahan.Text);
                double diskonpersen2 = (diskon2 / subtotal) * 100;
                 
                db.bind("diskon_persen2", diskonpersen2.ToString());
                db.bind("diskon_uang2", diskon2.ToString());

            }

            db.bind("ppn_persen", ppn_persen);
            db.bind("tagihan", Grandtotal.ToString());
            db.bind("user", frmMain.getUsername());
            db.bind("ongkir", txtOngkir.Text);
            db.bind("meterai", txtMeterai.Text);
        }

        private void simpanDetailPembelian()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string beli_id = "";
                if (id_edit != "")
                {
                    // edit
                    beli_id = id_edit;
                }
                else
                {

                    // baru
                    beli_id = pembelian.getLatestIDPembelian();
                }
                //string id_beli = pembelian.getLatestIDPembelian();
                string sql = "";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sql = "insert into pembelian_detail (beli_id, barang_id, qty, harga_beli, diskon_persen, diskon_uang, "+
                    "total, is_active, lot, ed) values (@beli_id, @barang_id, @qty, @harga_beli, @diskon_persen, @diskon_uang, " +
                    "@total, @is_active, @lot, @ed)";

                    db.bind("beli_id", beli_id);
                    db.bind("barang_id", dataGridView1.Rows[i].Cells["id"].Value.ToString());
                    db.bind("qty", dataGridView1.Rows[i].Cells["qty"].Value.ToString());
                    db.bind("harga_beli", dataGridView1.Rows[i].Cells["harga"].Value.ToString());
                    db.bind("diskon_persen", dataGridView1.Rows[i].Cells["diskon_persen"].Value.ToString());
                    db.bind("diskon_uang", dataGridView1.Rows[i].Cells["diskon_uang"].Value.ToString());
                    db.bind("total", dataGridView1.Rows[i].Cells["subtotal"].Value.ToString());
                    db.bind("is_active", "1");
                    db.bind("lot", dataGridView1.Rows[i].Cells["lot"].Value.ToString());
                    db.bind("ed", dataGridView1.Rows[i].Cells["ed"].Value.ToString());

                    db.query(sql);

                    // stok masuk
                    string detail_id = pembelian.getLatestDetailID();
                    stok_masuk.insert(tanggal.Value.ToString("yyyy/MM/dd"), 
                        dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        detail_id, 
                        dataGridView1.Rows[i].Cells["qty"].Value.ToString());

                }
            }
        }

        private void editDetailPembelian()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string beli_id = "";
                int ada = 0;
                beli_id = id_edit;
                DataTable data;

                // hapus barang yang tidak ada di gridview
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    db.bind("beli_id", beli_id);
                    db.bind("barang_id", dataGridView1.Rows[i].Cells["id"].Value.ToString());
                    string stok_id = db.single("select stok_id from pembelian_detail where beli_id = @beli_id and barang_id = @barang_id ");
                    if (string.IsNullOrEmpty(stok_id))
                    {
                        // tidak ada barang
                        string sql = "insert into pembelian_detail (beli_id, barang_id, qty, harga_beli, diskon_persen, diskon_uang, " +
                        "total, is_active, lot, ed) values (@beli_id, @barang_id, @qty, @harga_beli, @diskon_persen, @diskon_uang, " +
                        "@total, @is_active, @lot, @ed)";

                        db.bind("beli_id", beli_id);
                        db.bind("barang_id", dataGridView1.Rows[i].Cells["id"].Value.ToString());
                        db.bind("qty", dataGridView1.Rows[i].Cells["qty"].Value.ToString());
                        db.bind("harga_beli", dataGridView1.Rows[i].Cells["harga"].Value.ToString());
                        db.bind("diskon_persen", dataGridView1.Rows[i].Cells["diskon_persen"].Value.ToString());
                        db.bind("diskon_uang", dataGridView1.Rows[i].Cells["diskon_uang"].Value.ToString());
                        db.bind("total", dataGridView1.Rows[i].Cells["subtotal"].Value.ToString());
                        db.bind("is_active", "1");
                        db.bind("lot", dataGridView1.Rows[i].Cells["lot"].Value.ToString());
                        db.bind("ed", dataGridView1.Rows[i].Cells["ed"].Value.ToString());

                        db.query(sql);

                        // stok masuk
                        string detail_id = pembelian.getLatestDetailID();
                        stok_masuk.insert(tanggal.Value.ToString("yyyy/MM/dd"),
                            dataGridView1.Rows[i].Cells[0].Value.ToString(),
                            detail_id,
                            dataGridView1.Rows[i].Cells["qty"].Value.ToString());


                    }
                    else
                    {
                        // ada barang
                        db.bind("beli_id", beli_id);
                        db.bind("barang_id", dataGridView1.Rows[i].Cells["id"].Value.ToString());
                        string qty = db.single("select qty from pembelian_detail where beli_id = @beli_id and barang_id = @barang_id ");
                        // kurangi stok
                        stok_masuk.kurangiStok(stok_id, dataGridView1.Rows[i].Cells["id"].Value.ToString(), qty);
                    
                        // edit
                        string sql = "update pembelian_detail set qty = @qty, harga_beli=@harga_beli, diskon_persen=@diskon_persen, diskon_uang=@diskon_uang, " +
                        "total=@total, lot=@lot, ed=@ed where stok_id = @stok_id";

                        db.bind("stok_id", stok_id);
                        db.bind("qty", dataGridView1.Rows[i].Cells["qty"].Value.ToString());
                        db.bind("harga_beli", dataGridView1.Rows[i].Cells["harga"].Value.ToString());
                        db.bind("diskon_persen", dataGridView1.Rows[i].Cells["diskon_persen"].Value.ToString());
                        db.bind("diskon_uang", dataGridView1.Rows[i].Cells["diskon_uang"].Value.ToString());
                        db.bind("total", dataGridView1.Rows[i].Cells["subtotal"].Value.ToString());
                        db.bind("lot", dataGridView1.Rows[i].Cells["lot"].Value.ToString());
                        db.bind("ed", dataGridView1.Rows[i].Cells["ed"].Value.ToString());

                        db.query(sql);

                        stok_masuk.updateStok(stok_id, dataGridView1.Rows[i].Cells["id"].Value.ToString(), qty);
                    

                    }
                    
                }


                // cek detail barang yang tidak ada di gridview
                db.bind("id", beli_id);
                data = db.query("select * from pembelian_detail where beli_id = @id");
                foreach (DataRow row in data.Rows)
                {
                    string barang_id = row["barang_id"].ToString();
                    //string id = row["id"].ToString();
                    string stok_id = row["stok_id"].ToString();
                    db.bind("tabel_id", stok_id);
                    string stok_masuk_id = db.single("select stok_masuk_id from stok_masuk where tabel_id = @tabel_id");
                    string qty = row["qty"].ToString();


                      ada = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (barang_id == dataGridView1.Rows[i].Cells["id"].Value.ToString())
                        {
                            ada = 1;
                        }

                    }

                    if (ada == 0)
                    {
                       // hapus
                        pembelian.hapusPembelianDetailByStokID(stok_id);
                        //fungsi.showError("terhapus");
                        // kurangi stok
                        stok_masuk.kurangiStok(stok_id, barang_id, qty);
                    
                    }


                }


            }
        }

        private void showDataPembelian()
        {
            string sql = "select beli_id, date_format(tanggal, '%d/%m/%Y') as tanggal, no_faktur, supplier.nama_supplier, round(tagihan,0) as tagihan, "+
                "case when lunas = 0 then 'Belum Lunas' else 'Lunas' end as status "+
                "from pembelian "+
                "left join supplier on supplier.supplier_id = pembelian.supplier_id "+
                "where nama_supplier like @nama or no_faktur like @nomor "+
                "order by beli_id desc limit 200";

            db.bind("nama", "%" + txtCari.Text + "%");
            db.bind("nomor", "%" + txtCari.Text + "%");
            dataGridView2.DataSource = db.query(sql);
            dataGridView2.Columns["tagihan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView2.Columns["beli_id"].HeaderText = "ID";
            dataGridView2.Columns["tanggal"].HeaderText = "Tanggal";
            dataGridView2.Columns["no_faktur"].HeaderText = "No Faktur";
            dataGridView2.Columns["nama_supplier"].HeaderText = "Nama Supplier";
            dataGridView2.Columns["tagihan"].HeaderText = "Tagihan";
            dataGridView2.Columns["status"].HeaderText = "Status";

            


            dataGridView2.Columns["tagihan"].DefaultCellStyle.Format = "N2";
             

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showDataPembelian();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Anda yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                hapusDataPembelian();
                showDataPembelian();
            }
        }

        private void hapusDataPembelian()
        {
            // cek data sudah dipakai
            string beli_id = dataGridView2.SelectedRows[0].Cells["beli_id"].Value.ToString();
            db.bind("id", beli_id);
            DataTable data = db.query("select * from pembelian_detail where beli_id = @id");
            string terpakai = "";
            foreach (DataRow row in data.Rows)
            {
                string barang_id = row["barang_id"].ToString();
                string detail_id = row["stok_id"].ToString();
                db.bind("tabel_id", detail_id);
                string cek = db.single("select count(*) from penjualan_detail where stok_masuk_id in "+
                    "(select stok_masuk_id from stok_masuk where tabel_id = @tabel_id)");
                if (double.Parse(cek) > 0)
                {
                    terpakai = "1";
                }
            }
            if (terpakai == "1")
            {
                fungsi.showError("Data sudah dipakai. Tidak dapat dihapus.");
            }
            else
            {
                pembelian.hapusPembelian(beli_id);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                btnSimpan.Text = "Edit";
                kosongkanFormDataBarang();
                kosongkanFormPenjualan();
                id_edit = dataGridView2.SelectedRows[0].Cells["beli_id"].Value.ToString();
                selected_id_supplier = id_edit;

                string[] tanggalx = pembelian.getPembelian(id_edit, "tanggal").Split(' ');
                tanggal.Value = DateTime.ParseExact(tanggalx[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string[] jatuh_tempox = pembelian.getPembelian(id_edit, "jatuh_tempo").Split(' ');
                jatuh_tempo.Value = DateTime.ParseExact(jatuh_tempox[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                string customer_id = pembelian.getPembelian(id_edit, "supplier_id");
                selected_id_supplier = customer_id;
                txtSupplier.Text = mitrabisnis.getMitraBisnis(customer_id, "nama_supplier");


                string ppn_persen = pembelian.getPembelian(id_edit, "ppn_persen");
                if (double.Parse(ppn_persen) > 0)
                {
                    cboPPN.SelectedIndex = 0;
                     
                }
                else
                {
                    cboPPN.SelectedIndex = 1;
                     
                }
                string no_faktur = pembelian.getPembelian(id_edit, "no_faktur");
                txtNomorFaktur.Text = no_faktur;
                string no_faktur_pajak = pembelian.getPembelian(id_edit, "faktur_pajak");
                txtFakturPajak.Text = no_faktur_pajak;

                txtOngkir.Text = pembelian.getPembelian(id_edit, "ongkir");
                txtMeterai.Text = pembelian.getPembelian(id_edit, "meterai");

                txtDiskonTambahan.Text = pembelian.getPembelian(id_edit, "diskon_persen2");
                cboDiskonTambahan.SelectedIndex = int.Parse(pembelian.getPembelian(id_edit, "jenis_diskon2"));
                

                // load detail barang
                DataTable dt = pembelian.getDetailBarang(id_edit);
                foreach (DataRow row in dt.Rows)
                {
                    selected_id_barang = row["barang_id"].ToString();
                    stok_masuk_id = selected_id_barang;
                    txtBarang.Text = barang.getNamaBarangFromIDBarang(selected_id_barang);
                    txtQty.Text = row["qty"].ToString();
                    txtHarga.Text = row["harga"].ToString();
                    txtDiskon.Text = row["diskon_persen"].ToString();
                    cboDiskon.SelectedIndex = 0;
                    txtLot.Text = row["lot"].ToString();
                    
                    checkED.Checked = true;
                    string[] tgl = row["ed"].ToString().Split(' ');
                    //fungsi.showError(tgl[0]);

                    if (tgl[0] != "01/01/0001")
                    {
                        tanggal_ed.Value = DateTime.ParseExact(tgl[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    

                    tambahkanBarang();


                }
            }

        }

        private void cboPPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPPN.SelectedIndex == 0)
            {
                ppn_persen = setting.getSetting("ppn");
            }
            else
            {
                ppn_persen = "0";
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                var sheet = new Worksheet("DATA PEMBELIAN");
                sheet.Cells["A1"] = "DATA PEMBELIAN";
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
                string path = Directory.GetCurrentDirectory() + "\\Data_Pembelian.xlsx";
                workbook.Save(path);
                Process.Start(path);

            }
        }

        
    }
}
