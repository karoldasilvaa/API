using System.Data.SqlClient;

namespace ApiSiteRoupa.BancoDados
{
    public class Conexao
    {

        private string ConnStr = @"Server=LAPTOP-H4CSN0AS\SQLEXPRESS;Database=LojaRoupa;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
            var conexao = new SqlConnection(ConnStr);
            return conexao;
        }
    }
}
