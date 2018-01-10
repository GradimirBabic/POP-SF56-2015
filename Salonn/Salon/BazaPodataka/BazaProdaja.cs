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
    public class BazaProdaja
    {
        private static string connString = "Server=GRADIMIR-PC\\BB; Database=salonnamestaja; Integrated Security=True;";

        public static void UcitajProdaje()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                DataSet ds = new DataSet();

                SqlCommand prodajaCommand = connection.CreateCommand();
                prodajaCommand.CommandText = @"SELECT * FROM Prodaja";

                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = prodajaCommand;
                sqlda.Fill(ds, "Prodaja");

                
                foreach (DataRow row in ds.Tables["Prodaja"].Rows)
                {
                    Prodaja p = new Prodaja();
                    p.ID = (int)row["id"];
                    p.IdNamestaja = (int)row["idNamestaja"];
                    p.Kolicina = (int)row["kolicina"];
                    p.DatumProdaje = (DateTime)row["datumProdaje"];
                    p.Kupac = (string)row["kupac"];
                    p.BrojRacuna = (string)row["brojRacuna"];
                    p.UkupnaCena = Convert.ToDouble(row["ukupnaCena"]);
                    p.Obrisan = (bool)row["obrisan"];

                    ListePodataka.Instance.listaProdaja.Add(p);
                }
            }
        }

        public static void ProdajaDodaj(Prodaja p)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // Prodaja(int iD, int idNamestaja, int kolicina, DateTime datumProdaje, string kupac, string brojRacuna, double ukupnaCena, bool obrisan)
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Prodaja (id, idNamestaja, kolicina, datumProdaje, kupac, brojRacuna, ukupnaCena, obrisan) 
                                        VALUES (@Id, @IdNamestaja, @Kolicina, @DatumProdaje, @Kupac, @BrojRacuna, @UkupnaCena, @Obrisan)";

                command.Parameters.Add(new SqlParameter("@Id", p.ID));
                command.Parameters.Add(new SqlParameter("@IdNamestaja", p.IdNamestaja));
                command.Parameters.Add(new SqlParameter("@Kolicina", p.Kolicina));
                command.Parameters.Add(new SqlParameter("@DatumProdaje", p.DatumProdaje));
                command.Parameters.Add(new SqlParameter("@Kupac", p.Kupac));
                command.Parameters.Add(new SqlParameter("@BrojRacuna", p.BrojRacuna));
                command.Parameters.Add(new SqlParameter("@UkupnaCena", p.UkupnaCena));
                command.Parameters.Add(new SqlParameter("@Obrisan", p.Obrisan));

                command.ExecuteNonQuery();
            }
        }
    }
}
