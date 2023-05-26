namespace ProgramFakturMUA
{
    partial class frmEditStok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditStok));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtPabrik = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSatuan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.cboDitambah = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama Barang";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(114, 9);
            this.txtNama.Name = "txtNama";
            this.txtNama.ReadOnly = true;
            this.txtNama.Size = new System.Drawing.Size(214, 22);
            this.txtNama.TabIndex = 1;
            // 
            // txtPabrik
            // 
            this.txtPabrik.Location = new System.Drawing.Point(114, 37);
            this.txtPabrik.Name = "txtPabrik";
            this.txtPabrik.ReadOnly = true;
            this.txtPabrik.Size = new System.Drawing.Size(214, 22);
            this.txtPabrik.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pabrik";
            // 
            // txtSatuan
            // 
            this.txtSatuan.Location = new System.Drawing.Point(114, 65);
            this.txtSatuan.Name = "txtSatuan";
            this.txtSatuan.ReadOnly = true;
            this.txtSatuan.Size = new System.Drawing.Size(214, 22);
            this.txtSatuan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Satuan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSimpan);
            this.groupBox1.Controls.Add(this.cboDitambah);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.txtStok);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 96);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtStok
            // 
            this.txtStok.Location = new System.Drawing.Point(65, 32);
            this.txtStok.Name = "txtStok";
            this.txtStok.ReadOnly = true;
            this.txtStok.Size = new System.Drawing.Size(100, 22);
            this.txtStok.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stok";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(298, 32);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(96, 22);
            this.txtQty.TabIndex = 10;
            // 
            // cboDitambah
            // 
            this.cboDitambah.FormattingEnabled = true;
            this.cboDitambah.Items.AddRange(new object[] {
            "DITAMBAH",
            "DIKURANGI"});
            this.cboDitambah.Location = new System.Drawing.Point(171, 32);
            this.cboDitambah.Name = "cboDitambah";
            this.cboDitambah.Size = new System.Drawing.Size(121, 24);
            this.cboDitambah.TabIndex = 11;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSimpan.Location = new System.Drawing.Point(400, 26);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(138, 39);
            this.btnSimpan.TabIndex = 50;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // frmEditStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 213);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSatuan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPabrik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.Name = "frmEditStok";
            this.Text = "Edit Stok";
            this.Load += new System.EventHandler(this.frmEditStok_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtPabrik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSatuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDitambah;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSimpan;
    }
}