using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramFakturMUA
{
    public partial class frmMitrabisnis : Form
    {
        Functions fungsi = new Functions();
        MitraBisnis mitrabisnis = new MitraBisnis();
        string id_edit = "";

        public frmMitrabisnis()
        {
            InitializeComponent();
        }

        private void frmMitrabisnis_Load(object sender, EventArgs e)
        {
            loadKota();
            loadData();
        }

        private void loadKota()
        {
            DataTable dt = fungsi.getKota();
            cboKota.DisplayMember = "nama_kota";
            cboKota.ValueMember = "kota_id";
             
            cboKota.DataSource = dt;
        }

        private void loadData()
        {

            dataGridView1.DataSource =  mitrabisnis.getData(txtNama.Text);

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            if (txtNamaPerusahaan.Text != "")
            {
                if (id_edit == "")
                {
                    mitrabisnis.insert(txtNamaPerusahaan.Text, txtAlamat.Text, ((int)cboKota.SelectedValue).ToString(), txtKTP.Text, txtNPWP.Text);
                }
                else
                {
                    mitrabisnis.update(txtNamaPerusahaan.Text, txtAlamat.Text, ((int)cboKota.SelectedValue).ToString(), txtKTP.Text, txtNPWP.Text, id_edit);
                }

                loadData();
                fungsi.showSuccess("Data berhasil disimpan");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtNamaPerusahaan.Text = dataGridView1.SelectedRows[0].Cells["nama_supplier"].Value.ToString();
                txtAlamat.Text = dataGridView1.SelectedRows[0].Cells["alamat"].Value.ToString();
                txtKTP.Text = dataGridView1.SelectedRows[0].Cells["ktp"].Value.ToString();
                txtNPWP.Text = dataGridView1.SelectedRows[0].Cells["npwp"].Value.ToString();
                cboKota.Text = dataGridView1.SelectedRows[0].Cells["nama_kota"].Value.ToString();
                 
                id_edit = dataGridView1.SelectedRows[0].Cells["supplier_id"].ToString();


            }
        }


    }
}
