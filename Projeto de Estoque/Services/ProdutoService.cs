using Npgsql;
using ProjetoEstoque.Data;
using ProjetoEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjetoEstoque.Services
{
    public class ProdutoService
    {
        public List<Produto> Listar()
        {
            var produtos = new List<Produto>();

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string sql = "SELECT id, nome, preco, quantidade FROM produtos ORDER BY nome";

                    using (var command = new NpgsqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var produto = new Produto
                            {
                                Id = reader.GetInt32("id"),
                                Nome = reader.GetString("nome"),
                                Preco = reader.GetDecimal("preco"),
                                Quantidade = reader.GetInt32("quantidade")
                            };
                            produtos.Add(produto);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Retorna lista vazia se houver erro
            }

            return produtos;
        }

        public void Adicionar(Produto produto)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string sql = "INSERT INTO produtos (nome, preco, quantidade) VALUES (@nome, @preco, @quantidade)";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nome", produto.Nome ?? "");
                    command.Parameters.AddWithValue("@preco", produto.Preco);
                    command.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Incrementar(int id, int quantidade)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string sql = "UPDATE produtos SET quantidade = quantidade + @quantidade WHERE id = @id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@quantidade", quantidade);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Decrementar(int id, int quantidade)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string sql = "UPDATE produtos SET quantidade = GREATEST(quantidade - @quantidade, 0) WHERE id = @id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@quantidade", quantidade);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}