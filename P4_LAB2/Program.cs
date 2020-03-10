using System;
using Dapper;
using System.Data.SqlClient;
namespace P4_LAB2
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using var connection = new SqlConnection(connectionString);
            var db = new DB();
            
            db.Delete(connection, 103);
            db.Select(connection);
            var region = new Region()
            {
                RegionDescription = "dapper obiekt",
                RegionId = 103
            };
            db.Insert(connection, region);
            //db.Insert(connection, region);
            //db.Insert(connection, 103, "Wilkowyje");
            db.Select(connection);
            //db.SelectOrder(connection, 10231);
        }
    }
}
