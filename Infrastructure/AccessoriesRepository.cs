using Domain;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AccessoriesRepository : IRepository<Accessories>
    {
        private readonly IRepository<Accessories> _repository;

        public AccessoriesRepository(IRepository<Accessories> repository)
        {
            _repository = repository;
        }

        public async Task<Accessories> SearchAsync(int id)
        {
            return await _repository.SearchAsync(id);
        }

        public async Task<List<Accessories>> SearchByNameAsync(string name)
        {
            return await _repository.SearchByNameAsync(name);
        }

        public async Task DeleteAsync(Accessories entity, int id)
        {
            await _repository.DeleteAsync(entity, id);
        }

        public async Task UpdateAsync(Accessories entity, int id)
        {
            await _repository.UpdateAsync(entity, id);
        }

        public async Task AddAsync(Accessories entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<List<Accessories>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<Accessories>> GetItemsByCategoryAsync(string category)
        {
            var resultList = new List<Accessories>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuctionDatabase;Integrated Security=True;";

            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = $"SELECT * FROM {typeof(Accessories).Name} WHERE Category LIKE @Category"; // Ensure the column name matches your database schema
                resultList = (await conn.QueryAsync<Accessories>(query, new { Category = "%" + category + "%" })).ToList();
            }

            return resultList;
        }
    }
}
