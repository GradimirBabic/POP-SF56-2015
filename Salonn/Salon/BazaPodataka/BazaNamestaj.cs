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
    public class BazaNamestaj
    {
        private static string connString = "Server=GRADIMIR-PC\\BB; Database=salonnamestaja; Integrated Security=True;";

        public static void UcitajNamestaj()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                DataSet ds = new DataSet();

                SqlCommand namestajCommand = connection.CreateCommand();
                namestajCommand.CommandText = @"SELECT * FROM Namestaj";

                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = namestajCommand;
                sqlda.Fill(ds, "Namestaj");



                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    Namestaj n = new Namestaj();
                    n.Id = (int)row["id"];
                    n.Naziv = (string)row["naziv"];
                    n.IdTipaNamestaja = (int)row["idTipaNamestaja"];
                    n.Sifra = (string)row["sifra"];
                    n.Cena = Convert.ToDouble(row["cena"]);
                    n.KolicinaUMagacinu = (int)row["kolicinaUMagacinu"];
                    n.Obrisan = (bool)row["obrisan"];

                    ListePodataka.Instance.listaNamestaja.Add(n);

                }
            }
        }

        /*
         *         private int id;
        private string naziv;
        private int idTipaNamestaja;
        private string sifra;
        private double cena;
        private int kolicinaUMagacinu;
        private bool obrisan;
         
             */

        public static void NamestajDodaj(Namestaj n)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO Namestaj (id, naziv, idTipaNamestaja, sifra,  cena, kolicinaUMagacinu, obrisan) 
                                        VALUES (@Id, @Naziv, @IdTipaNamestaja, @Sifra, @Cena, @KolicinaUMagacinu, @Obrisan)";

                command.Parameters.Add(new SqlParameter("@Id", n.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", n.Naziv));
                command.Parameters.Add(new SqlParameter("@IdTipaNamestaja", n.IdTipaNamestaja));
                command.Parameters.Add(new SqlParameter("@Sifra", n.Sifra));
                command.Parameters.Add(new SqlParameter("@Cena", n.Cena));
                command.Parameters.Add(new SqlParameter("@KolicinaUMagacinu", n.KolicinaUMagacinu));
                command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));

                command.ExecuteNonQuery();
            }
        }
        //@Id, @Naziv, @IdTipaNamestaja, @Sifra, @Cena, @KolicinaUMagacinu, @Obrisan)
        public static void NamestajIzmeni(Namestaj n)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Namestaj 
                                        SET naziv=@Naziv, idTipaNamestaja=@IdTipaNamestaja, sifra=@Sifra, cena=@Cena, kolicinaUMagacinu=@KolicinaUMagacinu, 
                                        obrisan=@Obrisan WHERE id=@Id";

                command.Parameters.Add(new SqlParameter("@Id", n.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", n.Naziv));
                command.Parameters.Add(new SqlParameter("@IdTipaNamestaja", n.IdTipaNamestaja));
                command.Parameters.Add(new SqlParameter("@Sifra", n.Sifra));
                command.Parameters.Add(new SqlParameter("@Cena", n.Cena));
                command.Parameters.Add(new SqlParameter("@KolicinaUMagacinu", n.KolicinaUMagacinu));
                command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void NamestajIzbrisi(Namestaj n)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"UPDATE Namestaj SET obrisan=@Obrisan WHERE id=@Id";

                command.Parameters.Add(new SqlParameter("@Id", n.Id));
                command.Parameters.Add(new SqlParameter("@Obrisan", 1));

                command.ExecuteNonQuery();
            }
        }

       
    }
}
