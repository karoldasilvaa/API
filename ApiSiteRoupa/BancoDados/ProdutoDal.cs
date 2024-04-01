using ApiSiteRoupa.Model;
using System.Data.SqlClient;

namespace ApiSiteRoupa.BancoDados
{
    public class ProdutoDal
    {
        public List<Produto> Listar()
        {
            try
            {
                Conexao conexao = new Conexao();
                List<Produto> produtos = new List<Produto>();

                var connection = conexao.GetConnection();
                connection.Open();

                var query = "select id_produto, id_cor, nome, descricao, preco, imagem from Produto";
                var command = new SqlCommand(query, connection);
                
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Produto produto = new Produto();
                            produto.IdProduto = Convert.ToInt32(reader["id_produto"]);
                            produto.IdCor = Convert.ToInt32(reader["id_cor"]);
                            produto.Nome = (string)reader["nome"];
                            produto.Descricao = (string)reader["descricao"];
                            produto.Preco = Convert.ToDecimal(reader["preco"]);
                            produto.Imagem = (string)reader["imagem"];

                            produtos.Add(produto);
                        }
                       
                    }
                }
                connection.Close();

                return produtos;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string Salvar(Produto produto)
        {
            try {
                Conexao conexao = new Conexao();
                var connection = conexao.GetConnection();
                connection.Open();

                var query = @"Insert into Produto (id_cor, nome, descricao, preco, imagem) 
                            values (@id_cor, @nome, @descricao, @preco, @imagem)";

                var command = new SqlCommand(query,connection);

                command.Parameters.AddWithValue("@id_cor", produto.IdCor);
                command.Parameters.AddWithValue("@nome", produto.Nome);
                command.Parameters.AddWithValue("@descricao", produto.Descricao);
                command.Parameters.AddWithValue("@preco", produto.Preco);
                command.Parameters.AddWithValue("@imagem", produto.Imagem);

                command.ExecuteNonQuery();

                connection.Close();

                return "Dados inseridos com sucesso.";
            }
            catch(Exception ex)
            {
                return "Falha ao inserir dados. Erro" + ex.Message;
            }

        }

        public string Excluir(int id)
        {
            try
            {
                Conexao conexao = new Conexao();
                var connection = conexao.GetConnection();
                connection.Open();

                var query = "delete from Produto Where id_produto = @id_produto";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id_produto", id);

                command.ExecuteNonQuery();

                connection.Close ();

                return "Produto excluido com sucesso";

            }
            catch (Exception ex)
            {
                return "Falha ao exluir produto" + ex.Message;
            }

        }

        public string Atualizar(Produto produto)
        {
            try
            {
                Conexao conexao = new Conexao();
                var connection = conexao.GetConnection();
                connection.Open();

                var query = "update Produto SET id_cor = @id_cor, nome = @nome, descricao = @descricao, preco = @preco, imagem = @imagem where id_produto = @id_produto";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id_produto", produto.IdProduto);
                command.Parameters.AddWithValue("@id_cor", produto.IdCor);
                command.Parameters.AddWithValue("@nome", produto.Nome);
                command.Parameters.AddWithValue("@descricao", produto.Descricao);
                command.Parameters.AddWithValue("@preco", produto.Preco);
                command.Parameters.AddWithValue("@imagem", produto.Imagem);

                command.ExecuteNonQuery();

                connection.Close();

                return "Produto atualizado com sucesso";
            }
            catch (Exception ex)
            {
                return "Falha ao atualizar produto" + ex.Message;
            }
        }
      
    }
}
