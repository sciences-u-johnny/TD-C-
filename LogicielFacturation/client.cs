using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicielFacturation
{
    public class client
    {
        private Guid _id;
        private string nom;
        private string prenom;
        private string telephone;
        private string adresse;

        public Guid Id { get => _id; set => _id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Adresse { get => adresse; set => adresse = value; }

        public client()
        {

        }
        public client(string nom,string prenom,string telephone,string adresse)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Telephone = telephone;
            this.Adresse = adresse;
        }


        public static void  addClient(client monClient)
        {
            monClient.Id = Guid.NewGuid();

            SqlConnection sqlConnection1 = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=app_etohub;Initial Catalog=facturation;Data Source=AI499921");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO [dbo].[CLIENT] VALUES ('" + monClient.Id + "','" + monClient.Nom + "','" + monClient.Prenom +"','"+ monClient.Telephone+"','"+monClient.Adresse + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;



            sqlConnection1.Open();

            reader = cmd.ExecuteReader();


            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();
        }

        public static List<client> getClient()
        {
            List<client> maliste = new List<client>();

            SqlConnection sqlConnection1 = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=app_etohub;Initial Catalog=facturation;Data Source=AI499921");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from [dbo].[client] ORDER BY client_nom";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                client monClient = new client();
                monClient.Id = (Guid)reader[0];
                monClient.Nom = reader[1].ToString();
                monClient.Prenom = reader[2].ToString();
                monClient.Telephone = reader[3].ToString();
                monClient.Adresse = reader[4].ToString();
                maliste.Add(monClient);
            }

            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();


            return maliste;
        }

        public static List<client> rechercheClient(string recherche)
        {

            List<client> maliste = new List<client>();
            SqlConnection sqlConnection1 = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=app_etohub;Initial Catalog=facturation;Data Source=AI499921");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from [dbo].[client] WHERE client_nom ='" + recherche + "' OR client_prenom = '"+recherche+"'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            client monUser = new client();
            while (reader.Read())
            {
                client monClient = new client();
                monClient.Id = (Guid)reader[0];
                monClient.Nom = reader[1].ToString();
                monClient.Prenom = reader[2].ToString();
                monClient.Telephone = reader[3].ToString();
                monClient.Adresse = reader[4].ToString();
                maliste.Add(monClient);
            }

            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();
            return maliste;
        }

        public static void delClient(client monClient)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=app_etohub;Initial Catalog=facturation;Data Source=AI499921");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "DELETE from CLIENT WHERE client_id ='" + monClient.Id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();
        }

        public static void modClient(client monClient)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=app_etohub;Initial Catalog=facturation;Data Source=AI499921");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "UPDATE [dbo].[client]" + " SET client_telephone ='" + monClient.Telephone + "', client_nom = '" + monClient.Nom + "',client_prenom = '" + monClient.Prenom + "',client_adresse = '" + monClient.Adresse+"' WHERE client_id ='" + monClient.Id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();
        }
    }
}
