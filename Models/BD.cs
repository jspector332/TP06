namespace tp06.Models;
using Dapper;
using Microsoft.Data.SqlClient;

public class BD{
    private string _connectionString = @"Server=localhost;DataBase = TP06;integrated Security = True;TrustServerCertificate=True;";

    public string mensajeCodigo()
    {
        string codigo = null;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT mensaje FROM CodigoCesar WHERE id = 1";
            codigo = connection.QueryFirstOrDefault<string>(query, new {id = 1});
        }
        return codigo.ToUpper();
    }
}