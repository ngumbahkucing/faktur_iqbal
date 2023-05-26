namespace ProgramFakturMUA
{
    partial class frmBarang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarang));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.txtNamaBarang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKodeBarang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSatuan = new System.Windows.Forms.ComboBox();
            this.cboPabrik = new System.Windows.Forms.ComboBox();
            this.txtHargaJual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPricelist = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 318);
            this.dataGridView1.TabIndex = 14;
            // 
            // btnCari
            // 
            this.btnCari.Image = ((System.Drawing.Image)(resources.GetObject("btnCari.Image")));
            this.btnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCari.Location = new System.Drawing.Point(279, 10);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(108, 34);
            this.btnCari.TabIndex = 13;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(110, 16);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(163, 22);
            this.txtNama.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nama Barang";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(851, 12);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(169, 35);
            this.btnExcel.TabIndex = 15;
            this.btnExcel.Text = "Export Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.Location = new System.Drawing.Point(110, 387);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.Size = new System.Drawing.Size(163, 22);
            this.txtNamaBarang.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nama Barang";
            // 
            // txtKodeBarang
            // 
            this.txtKodeBarang.Location = new System.Drawing.Point(110, 415);
            this.txtKodeBarang.Name = "txtKodeBarang";
            this.txtKodeBarang.Size = new System.Drawing.Size(163, 22);
            this.txtKodeBarang.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Kode Barang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Satuan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 480);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Pabrik";
            // 
            // cboSatuan
            // 
            this.cboSatuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSatuan.FormattingEnabled = true;
            this.cboSatuan.Items.AddRange(new object[] {
            "Diambil",
            "Paket",
            "Sales",
            "Driver",
            "TBT"});
            this.cboSatuan.Location = new System.Drawing.Point(110, 443);
            this.cboSatuan.Name = "cboSatuan";
            this.cboSatuan.Size = new System.Drawing.Size(163, 24);
            this.cboSatuan.TabIndex = 50;
            // 
            // cboPabrik
            // 
            this.cboPabrik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPabrik.FormattingEnabled = true;
            this.cboPabrik.Items.AddRange(new object[] {
            "Diambil",
            "Paket",
            "Sales",
            "Driver",
            "TBT"});
            this.cboPabrik.Location = new System.Drawing.Point(110, 473);
            this.cboPabrik.Name = "cboPabrik";
            this.cboPabrik.Size = new System.Drawing.Size(163, 24);
            this.cboPabrik.TabIndex = 51;
            // 
            // txtHargaJual
            // 
            this.txtHargaJual.Location = new System.Drawing.Point(395, 387);
            this.txtHargaJual.Name = "txtHargaJual";
            this.txtHargaJual.Size = new System.Drawing.Size(163, 22);
            this.txtHargaJual.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 52;
            this.label6.Text = "Harga Jual";
            // 
            // txtPricelist
            // 
            this.txtPricelist.Location = new System.Drawing.Point(395, 415);
            this.txtPricelist.Name = "txtPricelist";
            this.txtPricelist.Size = new System.Drawing.Size(163, 22);
            this.txtPricelist.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 418);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 54;
            this.label7.Text = "Pricelist";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimpan.Location = new System.Drawing.Point(395, 446);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(138, 39);
            this.btnSimpan.TabIndex = 58;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(893, 379);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(127, 39);
            this.btnEdit.TabIndex = 59;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 517);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtPricelist);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHargaJual);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboPabrik);
            this.Controls.Add(this.cboSatuan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKodeBarang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNamaBarang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.Name = "frmBarang";
            this.Text = "Data Barang";
            this.Load += new System.EventHandler(this.frmBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtNamaBarang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKodeBarang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSatuan;
        private System.Windows.Forms.ComboBox cboPabrik;
        private System.Windows.Forms.TextBox txtHargaJual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPricelist;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnEdit;
    }
}