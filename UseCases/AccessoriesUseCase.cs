using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UseCases
{
    public class AccessoriesUseCase
    {
        private readonly IRepository<Accessories> _accessoriesRepository;

        public AccessoriesUseCase(IRepository<Accessories> accessoriesRepository)
        {
            _accessoriesRepository = accessoriesRepository;
        }

        public async Task AddAccessoriesAsync(Accessories accessories)
        {
            await _accessoriesRepository.AddAsync(accessories);
        }

        public async Task RemoveAccessoriesAsync(Accessories accessories, int id)
        {
            await _accessoriesRepository.DeleteAsync(accessories, id);
        }

        public async Task<Accessories> SearchAccessoriesAsync(int id)
        {
            return await _accessoriesRepository.SearchAsync(id);
        }

        public async Task<List<Accessories>> GetAllAccessoriesAsync()
        {
            return await _accessoriesRepository.GetAllAsync();
        }

        public async Task UpdateAccessoriesAsync(Accessories accessories, int id)
        {
            await _accessoriesRepository.UpdateAsync(accessories, id);
        }

        public async Task<List<Accessories>> SearchAccessoriesByNameAsync(string name)
        {
            return await _accessoriesRepository.SearchByNameAsync(name);
        }
    }
}
