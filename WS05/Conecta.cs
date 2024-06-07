using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WS05
{
    public class Conecta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Data_Nascimento { get; set; }
        public string Idade { get; set; }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\Desktop\\WS\\WS05\\WS05\\DbPessoa.mdf;Integrated Security=True");


        public List<Conecta> ListaPessoa()
        {
            
            List<Conecta> li = new List<Conecta>();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            string sql = "SELECT * FROM Pessoa";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Conecta conecta = new Conecta();
                conecta.Id = (int)dr["id"];
                conecta.Nome = dr["nome"].ToString();
                conecta.CPF = dr["CPF"].ToString();
                conecta.Data_Nascimento = dr["Data_Nascimento"].ToString();
                conecta.Idade = dr["Idade"].ToString();
                li.Add(conecta);
            }
            conn.Close();
            return li;

        }

        public void Inserir(string Nome, string CPF, string Data_Nascimento, string Idade)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                string sql = "INSERT INTO Pessoa(Nome,CPF,Data_Nascimento,Idade) VALUES('" + Nome + "','" + CPF + "','" + Data_Nascimento + "','" + Idade + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro");
            }

        }
        public void Excluir(int Id)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                string sql = "DELETE FROM Pessoa WHERE Id='" + Id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "erro");
            }
        }
        public void Atualizar(int Id, string Nome, string CPF, string Data_Nascimento, string Idade)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                string sql = "UPDATE Pessoa SET Nome='" + Nome + "',CPF='" + CPF + "',Data_Nascimento='" + Data_Nascimento + "',Idade='" + Idade + "' WHERE='" + Id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "erro");
            }

        }

        public void Localizar(int Id)
        {
            
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                string sql = "SELECT * FROM Pessoa WHERE Id='" + Id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (sql != null) 
                {
                    while (dr.Read())
                    {

                        Id = (int)dr["id"];
                        Nome = dr["nome"].ToString();
                        CPF = dr["CPF"].ToString();
                        Data_Nascimento = dr["Data_Nascimento"].ToString();
                        Idade = dr["Idade"].ToString();
                    }

                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Pessoa Não encontrada", "erro");
                }
                
            
        }

        public bool RegistroRepetido(string CPF)
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            string sql = "SELECT CPF From Pessoa WHERE CPF='" + CPF + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);

            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;


        }


    }
}
