namespace ProgramFakturMUA
{
    partial class frmPenjualan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPenjualan));
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGrandtotal = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblPPN = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.diskon_persen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diskon_uang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnEditBarang = new System.Windows.Forms.Button();
            this.btnHapusBarang = new System.Windows.Forms.Button();
            this.harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTambahkan = new System.Windows.Forms.Button();
            this.nama_satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_pabrik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboDiskon = new System.Windows.Forms.ComboBox();
            this.txtDiskon = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCariBarang = new System.Windows.Forms.Button();
            this.txtBarang = new System.Windows.Forms.TextBox();
            this.nama_barang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPPN = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFakturPajak = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomorFaktur = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.jatuh_tempo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tanggal = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHPP = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCN2 = new System.Windows.Forms.TextBox();
            this.txtCN1 = new System.Windows.Forms.TextBox();
            this.cboCN2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCN1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFakturPajak = new System.Windows.Forms.ComboBox();
            this.cboPembayaran = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboPengiriman = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboSales = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboBulanBuku = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtKTP = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtOngkir = new System.Windows.Forms.TextBox();
            this.txtMeterai = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.txtPPN = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // qty
            // 
            this.qty.FillWeight = 81.34165F;
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 83;
            // 
            // total
            // 
            this.total.FillWeight = 133.7373F;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 137;
            // 
            // lblGrandtotal
            // 
            this.lblGrandtotal.AutoSize = true;
            this.lblGrandtotal.Location = new System.Drawing.Point(361, 337);
            this.lblGrandtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrandtotal.Name = "lblGrandtotal";
            this.lblGrandtotal.Size = new System.Drawing.Size(13, 13);
            this.lblGrandtotal.TabIndex = 51;
            this.lblGrandtotal.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(298, 337);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 54;
            this.label18.Text = "Grandtotal :";
            // 
            // lblPPN
            // 
            this.lblPPN.AutoSize = true;
            this.lblPPN.Location = new System.Drawing.Point(186, 337);
            this.lblPPN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPPN.Name = "lblPPN";
            this.lblPPN.Size = new System.Drawing.Size(13, 13);
            this.lblPPN.TabIndex = 53;
            this.lblPPN.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(152, 337);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "PPN :";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(60, 337);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(13, 13);
            this.lblSubtotal.TabIndex = 51;
            this.lblSubtotal.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 337);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Subtotal :";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimpan.Location = new System.Drawing.Point(513, 310);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(104, 32);
            this.btnSimpan.TabIndex = 49;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Image = ((System.Drawing.Image)(resources.GetObject("btnBatal.Image")));
            this.btnBatal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBatal.Location = new System.Drawing.Point(621, 310);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(92, 32);
            this.btnBatal.TabIndex = 48;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // diskon_persen
            // 
            this.diskon_persen.FillWeight = 75.19869F;
            this.diskon_persen.HeaderText = "Disc-%";
            this.diskon_persen.Name = "diskon_persen";
            this.diskon_persen.ReadOnly = true;
            this.diskon_persen.Width = 77;
            // 
            // diskon_uang
            // 
            this.diskon_uang.FillWeight = 69.40076F;
            this.diskon_uang.HeaderText = "Disc-Rp";
            this.diskon_uang.Name = "diskon_uang";
            this.diskon_uang.ReadOnly = true;
            this.diskon_uang.Width = 72;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnHapus);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtCari);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(15, 499);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(981, 324);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RIWAYAT DATA PENJUALAN";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(548, 15);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(120, 28);
            this.btnExcel.TabIndex = 47;
            this.btnExcel.Text = "Export Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(672, 14);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 32);
            this.btnPrint.TabIndex = 46;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(772, 14);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 32);
            this.btnEdit.TabIndex = 45;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Image = ((System.Drawing.Image)(resources.GetObject("btnHapus.Image")));
            this.btnHapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHapus.Location = new System.Drawing.Point(872, 14);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(95, 32);
            this.btnHapus.TabIndex = 44;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(229, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 21);
            this.button1.TabIndex = 35;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(124, 27);
            this.txtCari.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(103, 20);
            this.txtCari.TabIndex = 34;
            this.txtCari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCari_KeyPress);
            this.txtCari.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCari_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 29);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "No. Faktur / Supplier";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 50);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(955, 262);
            this.dataGridView2.TabIndex = 4;
            // 
            // btnEditBarang
            // 
            this.btnEditBarang.Image = ((System.Drawing.Image)(resources.GetObject("btnEditBarang.Image")));
            this.btnEditBarang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditBarang.Location = new System.Drawing.Point(717, 310);
            this.btnEditBarang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditBarang.Name = "btnEditBarang";
            this.btnEditBarang.Size = new System.Drawing.Size(116, 32);
            this.btnEditBarang.TabIndex = 47;
            this.btnEditBarang.Text = "Edit Barang";
            this.btnEditBarang.UseVisualStyleBackColor = true;
            this.btnEditBarang.Click += new System.EventHandler(this.btnEditBarang_Click);
            // 
            // btnHapusBarang
            // 
            this.btnHapusBarang.Image = ((System.Drawing.Image)(resources.GetObject("btnHapusBarang.Image")));
            this.btnHapusBarang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHapusBarang.Location = new System.Drawing.Point(837, 310);
            this.btnHapusBarang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHapusBarang.Name = "btnHapusBarang";
            this.btnHapusBarang.Size = new System.Drawing.Size(130, 32);
            this.btnHapusBarang.TabIndex = 43;
            this.btnHapusBarang.Text = "Hapus Barang";
            this.btnHapusBarang.UseVisualStyleBackColor = true;
            this.btnHapusBarang.Click += new System.EventHandler(this.btnHapusBarang_Click);
            // 
            // harga
            // 
            this.harga.FillWeight = 121.8274F;
            this.harga.HeaderText = "Harga";
            this.harga.Name = "harga";
            this.harga.ReadOnly = true;
            this.harga.Width = 125;
            // 
            // btnTambahkan
            // 
            this.btnTambahkan.Image = ((System.Drawing.Image)(resources.GetObject("btnTambahkan.Image")));
            this.btnTambahkan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTambahkan.Location = new System.Drawing.Point(611, 26);
            this.btnTambahkan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTambahkan.Name = "btnTambahkan";
            this.btnTambahkan.Size = new System.Drawing.Size(108, 46);
            this.btnTambahkan.TabIndex = 42;
            this.btnTambahkan.Text = "Tambahkan";
            this.btnTambahkan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTambahkan.UseVisualStyleBackColor = true;
            this.btnTambahkan.Click += new System.EventHandler(this.btnTambahkan_Click);
            // 
            // nama_satuan
            // 
            this.nama_satuan.FillWeight = 85.9266F;
            this.nama_satuan.HeaderText = "Satuan";
            this.nama_satuan.Name = "nama_satuan";
            this.nama_satuan.ReadOnly = true;
            this.nama_satuan.Width = 88;
            // 
            // nama_pabrik
            // 
            this.nama_pabrik.FillWeight = 80.70232F;
            this.nama_pabrik.HeaderText = "Pabrik";
            this.nama_pabrik.Name = "nama_pabrik";
            this.nama_pabrik.ReadOnly = true;
            this.nama_pabrik.Width = 83;
            // 
            // id
            // 
            this.id.FillWeight = 53.66575F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 55;
            // 
            // cboDiskon
            // 
            this.cboDiskon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiskon.FormattingEnabled = true;
            this.cboDiskon.Items.AddRange(new object[] {
            "%",
            "Rp"});
            this.cboDiskon.Location = new System.Drawing.Point(424, 30);
            this.cboDiskon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboDiskon.Name = "cboDiskon";
            this.cboDiskon.Size = new System.Drawing.Size(49, 21);
            this.cboDiskon.TabIndex = 28;
            // 
            // txtDiskon
            // 
            this.txtDiskon.Location = new System.Drawing.Point(424, 54);
            this.txtDiskon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiskon.Name = "txtDiskon";
            this.txtDiskon.Size = new System.Drawing.Size(49, 20);
            this.txtDiskon.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(382, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Diskon";
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(318, 53);
            this.txtHarga.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(59, 20);
            this.txtHarga.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 55);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Harga Jual";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(318, 30);
            this.txtQty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(59, 20);
            this.txtQty.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Qty";
            // 
            // btnCariBarang
            // 
            this.btnCariBarang.Image = ((System.Drawing.Image)(resources.GetObject("btnCariBarang.Image")));
            this.btnCariBarang.Location = new System.Drawing.Point(244, 27);
            this.btnCariBarang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCariBarang.Name = "btnCariBarang";
            this.btnCariBarang.Size = new System.Drawing.Size(26, 21);
            this.btnCariBarang.TabIndex = 30;
            this.btnCariBarang.UseVisualStyleBackColor = true;
            this.btnCariBarang.Click += new System.EventHandler(this.btnCariBarang_Click);
            // 
            // txtBarang
            // 
            this.txtBarang.Location = new System.Drawing.Point(92, 28);
            this.txtBarang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBarang.Name = "txtBarang";
            this.txtBarang.ReadOnly = true;
            this.txtBarang.Size = new System.Drawing.Size(151, 20);
            this.txtBarang.TabIndex = 29;
            // 
            // nama_barang
            // 
            this.nama_barang.FillWeight = 183.6202F;
            this.nama_barang.HeaderText = "Nama Barang";
            this.nama_barang.MinimumWidth = 20;
            this.nama_barang.Name = "nama_barang";
            this.nama_barang.ReadOnly = true;
            this.nama_barang.Width = 188;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Nama Barang";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(74, 58);
            this.txtSupplier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(151, 20);
            this.txtSupplier.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Customer";
            // 
            // cboPPN
            // 
            this.cboPPN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPPN.FormattingEnabled = true;
            this.cboPPN.Items.AddRange(new object[] {
            "Ada",
            "Standar"});
            this.cboPPN.Location = new System.Drawing.Point(555, 10);
            this.cboPPN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboPPN.Name = "cboPPN";
            this.cboPPN.Size = new System.Drawing.Size(78, 21);
            this.cboPPN.TabIndex = 38;
            this.cboPPN.SelectedIndexChanged += new System.EventHandler(this.cboPPN_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "PPN";
            // 
            // txtFakturPajak
            // 
            this.txtFakturPajak.Location = new System.Drawing.Point(417, 34);
            this.txtFakturPajak.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFakturPajak.Name = "txtFakturPajak";
            this.txtFakturPajak.ReadOnly = true;
            this.txtFakturPajak.Size = new System.Drawing.Size(95, 20);
            this.txtFakturPajak.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "No. Faktur Pajak";
            // 
            // txtNomorFaktur
            // 
            this.txtNomorFaktur.Location = new System.Drawing.Point(74, 35);
            this.txtNomorFaktur.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNomorFaktur.Name = "txtNomorFaktur";
            this.txtNomorFaktur.ReadOnly = true;
            this.txtNomorFaktur.Size = new System.Drawing.Size(151, 20);
            this.txtNomorFaktur.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "No. Faktur";
            // 
            // jatuh_tempo
            // 
            this.jatuh_tempo.Location = new System.Drawing.Point(361, 11);
            this.jatuh_tempo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.jatuh_tempo.Name = "jatuh_tempo";
            this.jatuh_tempo.Size = new System.Drawing.Size(151, 20);
            this.jatuh_tempo.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Jatuh Tempo";
            // 
            // tanggal
            // 
            this.tanggal.Location = new System.Drawing.Point(74, 12);
            this.tanggal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tanggal.Name = "tanggal";
            this.tanggal.Size = new System.Drawing.Size(151, 20);
            this.tanggal.TabIndex = 30;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(955, 228);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnSupplier
            // 
            this.btnSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnSupplier.Image")));
            this.btnSupplier.Location = new System.Drawing.Point(226, 56);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(26, 21);
            this.btnSupplier.TabIndex = 42;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHPP);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtCN2);
            this.groupBox1.Controls.Add(this.txtCN1);
            this.groupBox1.Controls.Add(this.cboCN2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cboCN1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblGrandtotal);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lblPPN);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblSubtotal);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.btnSimpan);
            this.groupBox1.Controls.Add(this.btnBatal);
            this.groupBox1.Controls.Add(this.btnEditBarang);
            this.groupBox1.Controls.Add(this.btnHapusBarang);
            this.groupBox1.Controls.Add(this.btnTambahkan);
            this.groupBox1.Controls.Add(this.cboDiskon);
            this.groupBox1.Controls.Add(this.txtDiskon);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtHarga);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnCariBarang);
            this.groupBox1.Controls.Add(this.txtBarang);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(15, 132);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(981, 362);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DAFTAR BARANG";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtHPP
            // 
            this.txtHPP.Location = new System.Drawing.Point(196, 53);
            this.txtHPP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHPP.Name = "txtHPP";
            this.txtHPP.Size = new System.Drawing.Size(59, 20);
            this.txtHPP.TabIndex = 63;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(164, 55);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 13);
            this.label26.TabIndex = 62;
            this.label26.Text = "HPP";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(384, 50);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 21);
            this.button2.TabIndex = 61;
            this.button2.Text = "/";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCN2
            // 
            this.txtCN2.Location = new System.Drawing.Point(555, 54);
            this.txtCN2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCN2.Name = "txtCN2";
            this.txtCN2.Size = new System.Drawing.Size(49, 20);
            this.txtCN2.TabIndex = 60;
            // 
            // txtCN1
            // 
            this.txtCN1.Location = new System.Drawing.Point(555, 31);
            this.txtCN1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCN1.Name = "txtCN1";
            this.txtCN1.Size = new System.Drawing.Size(49, 20);
            this.txtCN1.TabIndex = 59;
            // 
            // cboCN2
            // 
            this.cboCN2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCN2.FormattingEnabled = true;
            this.cboCN2.Items.AddRange(new object[] {
            "%",
            "Rp"});
            this.cboCN2.Location = new System.Drawing.Point(502, 53);
            this.cboCN2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboCN2.Name = "cboCN2";
            this.cboCN2.Size = new System.Drawing.Size(49, 21);
            this.cboCN2.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(477, 56);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "CN2";
            // 
            // cboCN1
            // 
            this.cboCN1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCN1.FormattingEnabled = true;
            this.cboCN1.Items.AddRange(new object[] {
            "%",
            "Rp"});
            this.cboCN1.Location = new System.Drawing.Point(502, 30);
            this.cboCN1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboCN1.Name = "cboCN1";
            this.cboCN1.Size = new System.Drawing.Size(49, 21);
            this.cboCN1.TabIndex = 56;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(477, 32);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "CN1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tanggal";
            // 
            // cboFakturPajak
            // 
            this.cboFakturPajak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFakturPajak.FormattingEnabled = true;
            this.cboFakturPajak.Items.AddRange(new object[] {
            "010.",
            "020.",
            "030.",
            "070."});
            this.cboFakturPajak.Location = new System.Drawing.Point(361, 35);
            this.cboFakturPajak.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboFakturPajak.Name = "cboFakturPajak";
            this.cboFakturPajak.Size = new System.Drawing.Size(53, 21);
            this.cboFakturPajak.TabIndex = 44;
            this.cboFakturPajak.SelectedIndexChanged += new System.EventHandler(this.cboFakturPajak_SelectedIndexChanged);
            // 
            // cboPembayaran
            // 
            this.cboPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPembayaran.FormattingEnabled = true;
            this.cboPembayaran.Items.AddRange(new object[] {
            "0",
            "14",
            "30",
            "35",
            "40",
            "45",
            "60"});
            this.cboPembayaran.Location = new System.Drawing.Point(361, 58);
            this.cboPembayaran.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboPembayaran.Name = "cboPembayaran";
            this.cboPembayaran.Size = new System.Drawing.Size(53, 21);
            this.cboPembayaran.TabIndex = 46;
            this.cboPembayaran.SelectedIndexChanged += new System.EventHandler(this.cboPembayaran_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(272, 60);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "Pembayaran";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(415, 62);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 13);
            this.label19.TabIndex = 47;
            this.label19.Text = "hari";
            // 
            // cboPengiriman
            // 
            this.cboPengiriman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPengiriman.FormattingEnabled = true;
            this.cboPengiriman.Items.AddRange(new object[] {
            "Diambil",
            "Paket",
            "Sales",
            "Driver",
            "TBT"});
            this.cboPengiriman.Location = new System.Drawing.Point(361, 83);
            this.cboPengiriman.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboPengiriman.Name = "cboPengiriman";
            this.cboPengiriman.Size = new System.Drawing.Size(71, 21);
            this.cboPengiriman.TabIndex = 49;
            this.cboPengiriman.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(272, 84);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "Pengiriman";
            this.label20.Visible = false;
            // 
            // cboSales
            // 
            this.cboSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSales.FormattingEnabled = true;
            this.cboSales.Items.AddRange(new object[] {
            "ADA",
            "STANDAR"});
            this.cboSales.Location = new System.Drawing.Point(555, 58);
            this.cboSales.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboSales.Name = "cboSales";
            this.cboSales.Size = new System.Drawing.Size(78, 21);
            this.cboSales.TabIndex = 51;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(515, 61);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "Sales";
            // 
            // cboBulanBuku
            // 
            this.cboBulanBuku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBulanBuku.FormattingEnabled = true;
            this.cboBulanBuku.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboBulanBuku.Location = new System.Drawing.Point(574, 84);
            this.cboBulanBuku.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboBulanBuku.Name = "cboBulanBuku";
            this.cboBulanBuku.Size = new System.Drawing.Size(59, 21);
            this.cboBulanBuku.TabIndex = 53;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(515, 86);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 13);
            this.label22.TabIndex = 52;
            this.label22.Text = "Bulan Buku";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(636, 12);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 13);
            this.label23.TabIndex = 54;
            this.label23.Text = "KTP";
            // 
            // txtKTP
            // 
            this.txtKTP.Location = new System.Drawing.Point(674, 9);
            this.txtKTP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKTP.Name = "txtKTP";
            this.txtKTP.Size = new System.Drawing.Size(77, 20);
            this.txtKTP.TabIndex = 55;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(636, 37);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 13);
            this.label24.TabIndex = 56;
            this.label24.Text = "Ongkir";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(636, 61);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 13);
            this.label25.TabIndex = 57;
            this.label25.Text = "Meterai";
            // 
            // txtOngkir
            // 
            this.txtOngkir.Location = new System.Drawing.Point(674, 35);
            this.txtOngkir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOngkir.Name = "txtOngkir";
            this.txtOngkir.Size = new System.Drawing.Size(77, 20);
            this.txtOngkir.TabIndex = 58;
            // 
            // txtMeterai
            // 
            this.txtMeterai.Location = new System.Drawing.Point(674, 58);
            this.txtMeterai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMeterai.Name = "txtMeterai";
            this.txtMeterai.Size = new System.Drawing.Size(77, 20);
            this.txtMeterai.TabIndex = 59;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(15, 82);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(185, 45);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "JENIS FAKTUR";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(173, 17);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(100, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "DISC INCLUDE";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(82, 17);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(97, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "PPN INCLUDE";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 17);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "STANDAR";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // txtPPN
            // 
            this.txtPPN.Location = new System.Drawing.Point(591, 32);
            this.txtPPN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPPN.Name = "txtPPN";
            this.txtPPN.Size = new System.Drawing.Size(28, 20);
            this.txtPPN.TabIndex = 61;
            this.txtPPN.Leave += new System.EventHandler(this.txtPPN_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(618, 35);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "%";
            // 
            // frmPenjualan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1009, 640);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPPN);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtMeterai);
            this.Controls.Add(this.txtOngkir);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtKTP);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cboBulanBuku);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.cboSales);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cboPengiriman);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboPembayaran);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboFakturPajak);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboPPN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFakturPajak);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNomorFaktur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jatuh_tempo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tanggal);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmPenjualan";
            this.Text = "Data Penjualan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPenjualan_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Label lblGrandtotal;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblPPN;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.DataGridViewTextBoxColumn diskon_persen;
        private System.Windows.Forms.DataGridViewTextBoxColumn diskon_uang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnEditBarang;
        private System.Windows.Forms.Button btnHapusBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga;
        private System.Windows.Forms.Button btnTambahkan;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_pabrik;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.ComboBox cboDiskon;
        private System.Windows.Forms.TextBox txtDiskon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCariBarang;
        private System.Windows.Forms.TextBox txtBarang;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_barang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPPN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFakturPajak;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomorFaktur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker jatuh_tempo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker tanggal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCN2;
        private System.Windows.Forms.TextBox txtCN1;
        private System.Windows.Forms.ComboBox cboCN2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboCN1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboFakturPajak;
        private System.Windows.Forms.ComboBox cboPembayaran;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboPengiriman;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboSales;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboBulanBuku;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtKTP;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtOngkir;
        private System.Windows.Forms.TextBox txtMeterai;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPPN;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtHPP;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnExcel;
    }
}