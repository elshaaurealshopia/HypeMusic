using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Coba1
{
    public partial class Form1 : Form
    {
        //koneksi database
        MySqlConnection connection = new MySqlConnection("server = localhost; uid = root; database = dbekskul;");
        DataTable dataTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillDataEkskul();

            //membuat form edit tidak bisa dijalankan saat form input aktif
            tbId.Enabled = false;
            tbNamaEdit.Enabled = false;
            tbLahirEdit.Enabled = false;
            tbTeleponEdit.Enabled = false;
            tbKelasEdit.Enabled = false;
            tbJabatanEdit.Enabled = false;
            tbAngkatanEdit.Enabled = false;
            tbStatusEdit.Enabled = false;
        }

        public DataTable getDataEkskul()
        {
            //read data
            dataTable.Reset();
            dataTable = new DataTable();
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM tbanggota", connection))
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }
            return dataTable;
        }

        public void fillDataEkskul()
        {
            dgEkskul.DataSource = getDataEkskul();

            //tombol edit dan delete di tabel
            DataGridViewButtonColumn editData = new DataGridViewButtonColumn();
            editData.UseColumnTextForButtonValue = true;
            editData.Text = "Edit";
            editData.Name = "";
            dgEkskul.Columns.Add(editData);

            DataGridViewButtonColumn deleteData = new DataGridViewButtonColumn();
            deleteData.UseColumnTextForButtonValue = true;
            deleteData.Text = "Delete";
            deleteData.Name = "";
            dgEkskul.Columns.Add(deleteData);

            connection.Close();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            connection.Open();

            try
            {
                //memasukkan data ke dalam database
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO tbanggota (" +
                    "nama, " +
                    "tanggal_lahir, " +
                    "nomor_telepon, " +
                    "kelas, " +
                    "jabatan, " +
                    "angkatan, " +
                    "status" +
                    ") VALUE (" +
                        "@nama, " +
                        "@lahir, " +
                        "@telepon, " +
                        "@kelas, " +
                        "@jabatan, " +
                        "@angkatan, " +
                        "@status)";

                cmd.Parameters.AddWithValue("@nama", tbNama.Text);
                cmd.Parameters.AddWithValue("@lahir", tbLahir.Text);
                cmd.Parameters.AddWithValue("@telepon", tbTelepon.Text);
                cmd.Parameters.AddWithValue("@kelas", tbKelas.Text);
                cmd.Parameters.AddWithValue("@jabatan", tbJabatan.Text);
                cmd.Parameters.AddWithValue("@angkatan", tbAngkatan.Text);
                cmd.Parameters.AddWithValue("@status", tbStatus.Text);
                cmd.ExecuteNonQuery();

                connection.Close();
                dgEkskul.Columns.Clear();
                dataTable.Clear();
                fillDataEkskul();
            } catch (Exception)
            {

            }
        }

        private void dgEkskul_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 8)
            {
                //mengambil id untuk melakukan edit pada data
                int id = Convert.ToInt32(dgEkskul.CurrentCell.RowIndex.ToString());
                tbId.Text = dgEkskul.Rows[id].Cells[0].Value.ToString(); 
                tbNamaEdit.Text = dgEkskul.Rows[id].Cells[1].Value.ToString();
                tbLahirEdit.Text = dgEkskul.Rows[id].Cells[2].Value.ToString();
                tbTeleponEdit.Text = dgEkskul.Rows[id].Cells[3].Value.ToString();
                tbKelasEdit.Text = dgEkskul.Rows[id].Cells[4].Value.ToString();
                tbJabatanEdit.Text = dgEkskul.Rows[id].Cells[5].Value.ToString();
                tbAngkatanEdit.Text = dgEkskul.Rows[id].Cells[6].Value.ToString();
                tbStatusEdit.Text = dgEkskul.Rows[id].Cells[7].Value.ToString();

                //form edit aktif saat diklik edit pada data yang dikehendaki
                tbNamaEdit.Enabled = true;
                tbLahirEdit.Enabled = true;
                tbTeleponEdit.Enabled = true;
                tbKelasEdit.Enabled = true;
                tbJabatanEdit.Enabled = true;
                tbAngkatanEdit.Enabled = true;
                tbStatusEdit.Enabled = true;

                //form input tidak aktif saat form edit aktif
                tbNama.Enabled = false;
                tbLahir.Enabled = false;
                tbTelepon.Enabled = false;
                tbKelas.Enabled = false;
                tbJabatan.Enabled = false;
                tbAngkatan.Enabled = false;
                tbStatus.Enabled = false;
            }

            if (e.ColumnIndex == 9)
            {
                int id = Convert.ToInt32(dgEkskul.CurrentCell.RowIndex.ToString());

                MySqlCommand cmd;
                connection.Open();

                try
                {
                    //detele data berdasarkan id
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM tbanggota WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", dgEkskul.Rows[id].Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    dgEkskul.Columns.Clear();
                    dataTable.Clear();
                    fillDataEkskul();
                } catch (Exception)
                {

                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            connection.Open();

            try
            {
                //tombol save data yang telah di edit
                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE tbanggota SET " +
                    "nama = @nama, " +
                    "tanggal_lahir = @lahir," +
                    "nomor_telepon = @telepon, " +
                    "kelas = @kelas, " +
                    "jabatan = @jabatan, " +
                    "angkatan = @angkatan, " +
                    "status = @status " +
                        "WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", tbId.Text);
                cmd.Parameters.AddWithValue("@nama", tbNamaEdit.Text);
                cmd.Parameters.AddWithValue("@lahir", tbLahirEdit.Text);
                cmd.Parameters.AddWithValue("@telepon", tbTeleponEdit.Text);
                cmd.Parameters.AddWithValue("@kelas", tbKelasEdit.Text);
                cmd.Parameters.AddWithValue("@jabatan", tbJabatanEdit.Text);
                cmd.Parameters.AddWithValue("@angkatan", tbAngkatanEdit.Text);
                cmd.Parameters.AddWithValue("@status", tbStatusEdit.Text);
                cmd.ExecuteNonQuery();

                //mengaktifkan kembali form tambah data
                tbNama.Enabled = true;
                tbLahir.Enabled = true;
                tbTelepon.Enabled = true;
                tbKelas.Enabled = true;
                tbJabatan.Enabled = true;
                tbAngkatan.Enabled = true;
                tbStatus.Enabled = true;

                //menonaktifkan kembali form edit data
                tbId.Enabled = false;
                tbNamaEdit.Enabled = false;
                tbLahirEdit.Enabled = false;
                tbTeleponEdit.Enabled = false;
                tbKelasEdit.Enabled = false;
                tbJabatanEdit.Enabled = false;
                tbAngkatanEdit.Enabled = false;
                tbStatusEdit.Enabled = false;

                connection.Close();
                dgEkskul.Columns.Clear();
                dataTable.Clear();
                fillDataEkskul();
            }
            catch (Exception)
            {

            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            //tombol reset atau batal pada form input
            tbNama.Text = "";
            tbLahir.Text = "";
            tbTelepon.Text = "";
            tbKelas.Text = "";
            tbJabatan.Text = "";
            tbAngkatan.Text = "";
            tbStatus.Text = "";
        }

        private void btnClearEdit_Click(object sender, EventArgs e)
        {
            //tombol reset atau batal pada form edit
            tbId.Text = "";
            tbNamaEdit.Text = "";
            tbLahirEdit.Text = "";
            tbTeleponEdit.Text = "";
            tbKelasEdit.Text = "";
            tbJabatanEdit.Text = "";
            tbAngkatanEdit.Text = "";
            tbStatusEdit.Text = "";
        }
    }
}
