using Npgsql;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

    
        }
        public NpgsqlConnection con;
        public void MyLoad()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.con = new NpgsqlConnection("Server=localhost; port=5432;UserId=postgres;Password=postpass;Database=FuturaKrizhLab");
            this.con.Open();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyLoad();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProduct fp = new FormProduct(con);
            fp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormClient fc = new FormClient(con);
            fc.ShowDialog();
        }
    }
   
}