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
    public partial class FormAddClient : Form
    {
        public NpgsqlConnection con;
        int id;
        public FormAddClient(NpgsqlConnection con, int id)
        {
            InitializeComponent();
            this.con = con;
            this.id = id;
        }
        public FormAddClient(NpgsqlConnection con, int id, string nameC, string address, string phone)
        {
            InitializeComponent();
            textBox1.Text = nameC;
            textBox2.Text = address;
            textBox3.Text = phone;
            this.con = con;
            this.id = id;
        }
        private void buttonYes_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO client(name, address, phone) VALUES(:name, :address, :phone)", con);
                    command.Parameters.AddWithValue("name", textBox1.Text);
                    command.Parameters.AddWithValue("address", textBox2.Text);
                    command.Parameters.AddWithValue("phone", textBox3.Text);
                    command.ExecuteNonQuery();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("UPDATE client SET name=:name, address=:address, phone=:phone WHERE id=:id", con);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("name", textBox1.Text);
                    command.Parameters.AddWithValue("address", textBox2.Text);
                    command.Parameters.AddWithValue("phone", textBox3.Text);
                    command.ExecuteNonQuery();
                    Close();
                }
                catch { }
            }
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
