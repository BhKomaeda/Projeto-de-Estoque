using Npgsql;

namespace ProjetoEstoque.Data
{
    public static class DatabaseConnection
    {
        private static string connectionString =
            "Host=localhost;Port=5432;Database=controle_estoque;Username=postgres;Password=Settmain65*";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}