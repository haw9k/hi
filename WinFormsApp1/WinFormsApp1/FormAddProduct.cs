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
    public partial class FormAddProduct : Form
    {
        public NpgsqlConnection con;
        int id;
        public FormAddProduct(NpgsqlConnection con, int id)
        {
            InitializeComponent();
            this.con = con;
            this.id = id;
        }
        public FormAddProduct(NpgsqlConnection con, int id, string nameP, string ed)
        {
            InitializeComponent();
            textBox1.Text = nameP;
            textBox2.Text = ed;
            this.con = con;
            this.id = id;
            
        }
        

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("INSERT INTO product(name, ed) VALUES(:name, :ed)", con);
                    command.Parameters.AddWithValue("name", textBox1.Text);
                    command.Parameters.AddWithValue("ed", textBox2.Text);
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
                    NpgsqlCommand command = new NpgsqlCommand("UPDATE product SET name=:name, ed=:ed WHERE id=:id", con);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("name", textBox1.Text);
                    command.Parameters.AddWithValue("ed", textBox2.Text);
                    command.ExecuteNonQuery();
                    Close();
                }
                catch{ }
            }
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }
}
