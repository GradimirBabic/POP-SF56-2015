using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Salon.Model;

namespace Salon.BazaPodataka
{
    public class BazaTipNamestaja
    {
        private static string connString = "Server=GRADIMIR-PC\\BB; Database=salonnamestaja; Integrated Security=True;";

        public static void UcitajTipoveNamestaja()
        {
            

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                DataSet ds = new DataSet();

                SqlCommand tipNamestajaCommand = connection.CreateCommand();
                tipNamestajaCommand.CommandText = @"SELECT * FROM TipNamestaja";

                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = tipNamestajaCommand;
                sqlda.Fill(ds, "TipNamestaja");

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    TipNamestaja tn = new TipNamestaja();
                    tn.ID = (int)row["id"];
                    tn.Naziv = (string)row["naziv"];
                    tn.Obrisan = (bool)row["obrisan"];

                    ListePodataka.Instance.listaTipovaNamestaja.Add(tn);

                }
            }
        }

        public static void TipNamestajaDodaj(TipNamestaja tn)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO TipNamestaja (id, naziv, obrisan) 
                                        VALUES (@Id, @Naziv, @Obrisan)";

                command.Parameters.Add(new SqlParameter("@Id", tn.ID));
                command.Parameters.Add(new SqlParameter("@Naziv", tn.Naziv));
                command.Parameters.Add(new SqlParameter("@Obrisan", tn.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void TipNamestajaIzmeni(TipNamestaja tn)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE TipNamestaja 
                                        SET naziv=@Naziv, obrisan=@Obrisan WHERE id=@Id";

                command.Parameters.Add(new SqlParameter("@Id", tn.ID));
                command.Parameters.Add(new SqlParameter("@Naziv", tn.Naziv));
                command.Parameters.Add(new SqlParameter("@Obrisan", tn.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void TipNamestajaIzbrisi(TipNamestaja tn)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE TipNamestaja SET obrisan=@Obrisan WHERE id=@Id";

                command.Parameters.Add(new SqlParameter("@Id", tn.ID));
                command.Parameters.Add(new SqlParameter("@Obrisan", 1));

                command.ExecuteNonQuery();
            }
        }


    }
}
