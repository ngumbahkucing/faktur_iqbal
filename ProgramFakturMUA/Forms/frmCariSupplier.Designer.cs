namespace ProgramFakturMUA
{
    partial class frmCariSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCariSupplier));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnPilih = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama Mitra Bisnis";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(150, 13);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(163, 22);
            this.txtNama.TabIndex = 2;
            // 
            // btnCari
            // 
            this.btnCari.Image = ((System.Drawing.Image)(resources.GetObject("btnCari.Image")));
            this.btnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCari.Location = new System.Drawing.Point(319, 7);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(108, 34);
            this.btnCari.TabIndex = 3;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnPilih
            // 
            this.btnPilih.Image = ((System.Drawing.Image)(resources.GetObject("btnPilih.Image")));
            this.btnPilih.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPilih.Location = new System.Drawing.Point(589, 7);
            this.btnPilih.Name = "btnPilih";
            this.btnPilih.Size = new System.Drawing.Size(108, 34);
            this.btnPilih.TabIndex = 4;
            this.btnPilih.Text = "Pilih";
            this.btnPilih.UseVisualStyleBackColor = true;
            this.btnPilih.Click += new System.EventHandler(this.btnPilih_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 47);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(672, 469);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // frmCariSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 528);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPilih);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.Name = "frmCariSupplier";
            this.Text = "Cari Mitra Bisnis";
            this.Load += new System.EventHandler(this.frmCariSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnPilih;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}