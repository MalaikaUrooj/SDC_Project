using Domain;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly string connectionString;

        public GenericRepository(string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuctionDatabase;Integrated Security=True;")
        {
            this.connectionString = connectionString;
        }

        public async Task UpdateAsync(TEntity entity, int id)
        {
            var tableName = typeof(TEntity).Name;
            var primaryKey = "ID";
            var properties = typeof(TEntity).GetProperties().Where(x => (x.Name == "Name" || x.Name == "Price") && x.Name != primaryKey);
            var setClause = string.Join(",", properties.Select(a => $"{a.Name}=@{a.Name}"));

            var query = $"UPDATE {tableName} SET {setClause} WHERE {primaryKey} = @id";
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(query, entity); // Using Dapper's async method
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var properties = typeof(TEntity).GetProperties().Where(p => p.Name != "ID");

            var columnName = string.Join(",", properties.Select(p => p.Name));
            var parameterNames = string.Join(",", properties.Select(y => "@" + y.Name));

            var query = $"INSERT INTO {tableName} ({columnName}) VALUES ({parameterNames})";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(query, entity); // Using Dapper's async method
            }
        }

        public async Task DeleteAsync(TEntity entity, int id)
        {
            var tableName = typeof(TEntity).Name;
            var primaryKey = "ID";
            var query = $"DELETE FROM {tableName} WHERE {primaryKey} = @id";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(query, new { Id = id                                 /*entity.GetType().GetProperty(primaryKey).GetValue(entity) */}); // Using Dapper's async method
            }
        }

        public async Task<TEntity> SearchAsync(int id)
        {
            var tableName = typeof(TEntity).Name;
            var query = $"SELECT * FROM {tableName} WHERE Id = @id";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<TEntity>(query, new { Id = id }); // Using Dapper's async method
            }
        }

        public async Task<List<TEntity>> SearchByNameAsync(string name)
        {
            var tableName = typeof(TEntity).Name;
            var query = $"SELECT * FROM {tableName} WHERE Name LIKE @Name";
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var resultList = await connection.QueryAsync<TEntity>(query, new { Name = "%" + name + "%" }); // Using Dapper's async method
                return resultList.ToList();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = $"SELECT * FROM {typeof(TEntity).Name}";
                var resultList = await connection.QueryAsync<TEntity>(query); // Using Dapper's async method
                return resultList.ToList();
            }
        }
    }
}
