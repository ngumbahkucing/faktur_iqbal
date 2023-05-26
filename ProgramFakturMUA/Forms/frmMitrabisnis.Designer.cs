namespace ProgramFakturMUA
{
    partial class frmMitrabisnis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMitrabisnis));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtNPWP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboKota = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamaPerusahaan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKTP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(900, 377);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(127, 39);
            this.btnEdit.TabIndex = 78;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimpan.Location = new System.Drawing.Point(149, 531);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(138, 39);
            this.btnSimpan.TabIndex = 77;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtNPWP
            // 
            this.txtNPWP.Location = new System.Drawing.Point(149, 503);
            this.txtNPWP.Name = "txtNPWP";
            this.txtNPWP.Size = new System.Drawing.Size(163, 22);
            this.txtNPWP.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 506);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 73;
            this.label6.Text = "NPWP";
            // 
            // cboKota
            // 
            this.cboKota.FormattingEnabled = true;
            this.cboKota.Items.AddRange(new object[] {
            "Diambil",
            "Paket",
            "Sales",
            "Driver",
            "TBT"});
            this.cboKota.Location = new System.Drawing.Point(149, 441);
            this.cboKota.Name = "cboKota";
            this.cboKota.Size = new System.Drawing.Size(163, 24);
            this.cboKota.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 70;
            this.label5.Text = "KTP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 69;
            this.label4.Text = "Kota";
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(149, 413);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(163, 22);
            this.txtAlamat.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 67;
            this.label3.Text = "Alamat";
            // 
            // txtNamaPerusahaan
            // 
            this.txtNamaPerusahaan.Location = new System.Drawing.Point(149, 385);
            this.txtNamaPerusahaan.Name = "txtNamaPerusahaan";
            this.txtNamaPerusahaan.Size = new System.Drawing.Size(163, 22);
            this.txtNamaPerusahaan.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 65;
            this.label2.Text = "Nama Perusahaan";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(858, 10);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(169, 35);
            this.btnExcel.TabIndex = 64;
            this.btnExcel.Text = "Export Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1015, 318);
            this.dataGridView1.TabIndex = 63;
            // 
            // btnCari
            // 
            this.btnCari.Image = ((System.Drawing.Image)(resources.GetObject("btnCari.Image")));
            this.btnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCari.Location = new System.Drawing.Point(310, 8);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(108, 34);
            this.btnCari.TabIndex = 62;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(141, 14);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(163, 22);
            this.txtNama.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "Nama Perusahaan";
            // 
            // txtKTP
            // 
            this.txtKTP.Location = new System.Drawing.Point(149, 473);
            this.txtKTP.Name = "txtKTP";
            this.txtKTP.Size = new System.Drawing.Size(163, 22);
            this.txtKTP.TabIndex = 79;
            // 
            // frmMitrabisnis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 608);
            this.Controls.Add(this.txtKTP);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtNPWP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboKota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNamaPerusahaan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.Name = "frmMitrabisnis";
            this.Text = "Data Mitra Bisnis";
            this.Load += new System.EventHandler(this.frmMitrabisnis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.TextBox txtNPWP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboKota;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamaPerusahaan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKTP;
    }
}