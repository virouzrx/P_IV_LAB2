using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
namespace P4_LAB2
{
    class DB
    {
        public void SelectOrder(IDbConnection connection, int id)
        {
            var sql = "SELECT * " +
                "      FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID " +
                "      WHERE o.OrderId = @id";
            var resultOrder = default(Order);
            var result = connection.Query<Order, OrderDetails, Order>
                (
                sql,
                (order, OrderDetails) =>
                {
                    resultOrder ??= order;
                    if (resultOrder == null)
                        {
                            resultOrder = order;
                        }
                    var foundOrder = order;
                    foundOrder.Details.Add(OrderDetails);
                    return resultOrder;
                }, 
                new { id }, 
                splitOn: "OrderID"
                );
        }

        public void Select(IDbConnection connection)
        {
            var sql = "SELECT * FROM region";
            var regions = connection.Query<Region>(sql);
            foreach (var item in regions)
            {
                Console.WriteLine($"{item.RegionId}: {item.RegionDescription}");
            }
        }

        public int Insert(IDbConnection connection, Region region)
        {
            var insertSql = "INSERT INTO REGION (regionId, regionDescription) VALUES (@RegionID, @RegionDescription)";
            return connection.Execute(insertSql, region);
        }
        public int Insert(IDbConnection connection, int id, string description)
        {
            var insertSql = "INSERT INTO Region(regionId, regionDescription) VALUES(@RegionID, @RegionDescription)";
            return connection.Execute(insertSql,
                    new { id = 0, desc = "" }
                );
        }

        public int Delete(IDbConnection connection, int id)
        {
            var sql = "DELETE FROM Region WHERE regionId = @id";
            return connection.Execute(sql, new { id = id });
        }
    }
}
