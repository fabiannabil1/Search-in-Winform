using Npgsql;

namespace Searching
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string conStr = "Server=localhost;Port=5432;Username=postgres;Password=010105;Database=CoffeSharp;CommandTimeout=10";
            string query = $"Select id_produk,nama_produk from produk where nama_produk ilike '{textBox1.Text}%'";
            List<koneksi> ListKoneksi = new List<koneksi>();

            using (NpgsqlConnection conn = new NpgsqlConnection(conStr))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.CommandText = query;
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    ListKoneksi.Clear();
                    while (reader.Read())
                    {
                        koneksi produk = new koneksi();
                        produk.id_produk = (int)reader["id_produk"];
                        produk.nama_produk = (string)reader["nama_produk"];
                        //person.username = (string)reader["username"];
                        //person.password = (strg)reader["password"];
                        ListKoneksi.Add(produk);
                    }
                }
            }
            dataGridView1.DataSource = ListKoneksi;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conStr = "Server=localhost;Port=5432;Username=postgres;Password=010105;Database=CoffeSharp;CommandTimeout=10";
            string query = "Select id_produk,nama_produk from produk";
            List<koneksi> ListKoneksi = new List<koneksi>();

            using (NpgsqlConnection conn = new NpgsqlConnection(conStr))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.CommandText = query;
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    ListKoneksi.Clear();
                    while (reader.Read())
                    {
                        koneksi produk = new koneksi();
                        produk.id_produk = (int)reader["id_produk"];
                            produk.nama_produk = (string)reader["nama_produk"];
                            //person.username = (string)reader["username"];
                            //person.password = (strg)reader["password"];
                        ListKoneksi.Add(produk);
                    }
                }
            }
            dataGridView1.DataSource = ListKoneksi;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
