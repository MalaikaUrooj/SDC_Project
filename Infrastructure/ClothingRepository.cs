using Domain;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ClothingRepository : IRepository<Clothing>
    {
        private readonly IRepository<Clothing> _repository;

        public ClothingRepository(IRepository<Clothing> repository)
        {
            _repository = repository;
        }

        public async Task<Clothing> SearchAsync(int id)
        {
            return await _repository.SearchAsync(id);
        }

        public async Task<List<Clothing>> SearchByNameAsync(string name)
        {
            return await _repository.SearchByNameAsync(name);
        }

        public async Task DeleteAsync(Clothing entity, int id)
        {
            await _repository.DeleteAsync(entity, id);
        }

        public async Task UpdateAsync(Clothing entity, int id)
        {
            await _repository.UpdateAsync(entity, id);
        }

        public async Task AddAsync(Clothing entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<List<Clothing>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<Clothing>> GetItemsByCategoryAsync(string category)
        {
            var resultList = new List<Clothing>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuctionDatabase;Integrated Security=True;";

            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = $"SELECT * FROM {typeof(Clothing).Name} WHERE Category = @Category";
                resultList = (await conn.QueryAsync<Clothing>(query, new { Category = category })).ToList();
            }

            return resultList;
        }
    }
}
