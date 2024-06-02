using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Searching
{
    internal class koneksiContext
    {
        public List<koneksi> ListKoneksi = new List<koneksi>();
        string conStr = "Server=localhost;Port=5432;User Id=posgres;Password=010105;Database=CoffeSharp;CommandTimeout=10";

        public void Read()
        {
            string query = "Select id_produk,nama_produk from produk";

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
        }
    }
}
