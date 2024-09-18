using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UseCases
{
    public class ClothingUseCase
    {
        private readonly IRepository<Clothing> _clothingRepository;

        public ClothingUseCase(IRepository<Clothing> clothingRepository)
        {
            _clothingRepository = clothingRepository;
        }

        public async Task AddClothingAsync(Clothing clothing)
        {
            await _clothingRepository.AddAsync(clothing);
        }

        public async Task RemoveClothingAsync(Clothing clothing, int id)
        {
            await _clothingRepository.DeleteAsync(clothing, id);
        }

        public async Task<Clothing> SearchClothingAsync(int id)
        {
            return await _clothingRepository.SearchAsync(id);
        }

        public async Task<List<Clothing>> GetAllClothingAsync()
        {
            return await _clothingRepository.GetAllAsync();
        }

        public async Task UpdateClothingAsync(Clothing clothing, int id)
        {
            await _clothingRepository.UpdateAsync(clothing, id);
        }

        public async Task<List<Clothing>> SearchClothingByNameAsync(string name)
        {
            return await _clothingRepository.SearchByNameAsync(name);
        }
    }
}
