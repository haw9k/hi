using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    public partial class FormClient : Form
    {
        public NpgsqlConnection con;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public FormClient(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            Update();
        }

        public void Update()
        {
            String sql = "Select * from client";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Адрес";
            dataGridView1.Columns[3].HeaderText = "Телефон";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddClient f = new FormAddClient(con, -1);
            f.ShowDialog();
            Update();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
            NpgsqlCommand command = new NpgsqlCommand("Delete from Client where ID =:id", con);
            command.Parameters.AddWithValue("id", id);
            command.ExecuteNonQuery();
            Update();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
            string name = (string)dataGridView1.CurrentRow.Cells["name"].Value;
            string address = (string)dataGridView1.CurrentRow.Cells["address"].Value;
            string phone = (string)dataGridView1.CurrentRow.Cells["phone"].Value;
            FormAddClient f = new FormAddClient(con, id, name, address, phone);
            f.ShowDialog();
            Update();
        }
    }
}
