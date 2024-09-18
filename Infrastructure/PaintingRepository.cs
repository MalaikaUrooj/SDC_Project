using Domain;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PaintingRepository : IRepository<Painting>
    {
        private readonly IRepository<Painting> _repository;

        public PaintingRepository(IRepository<Painting> repository)
        {
            _repository = repository;
        }

        public async Task<Painting> SearchAsync(int id)
        {
            return await _repository.SearchAsync(id);
        }

        public async Task<List<Painting>> SearchByNameAsync(string name)
        {
            return await _repository.SearchByNameAsync(name);
        }

        public async Task DeleteAsync(Painting entity, int id)
        {
            await _repository.DeleteAsync(entity, id);
        }

        public async Task UpdateAsync(Painting entity, int id)
        {
            await _repository.UpdateAsync(entity, id);
        }

        public async Task AddAsync(Painting entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<List<Painting>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<Painting>> GetItemsByCategoryAsync(string category)
        {
            var resultList = new List<Painting>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuctionDatabase;Integrated Security=True;";

            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = $"SELECT * FROM {typeof(Painting).Name} WHERE Category LIKE @Category"; // Ensure the column name matches your database schema
                resultList = (await conn.QueryAsync<Painting>(query, new { Category = "%" + category + "%" })).ToList();
            }

            return resultList;
        }
    }
}
