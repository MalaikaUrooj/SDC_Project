using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UseCases
{
    internal class PaintingUseCase
    {
        private readonly IRepository<Painting> _paintingRepository;

        public PaintingUseCase(IRepository<Painting> paintingRepository)
        {
            _paintingRepository = paintingRepository;
        }

        public async Task AddPaintingAsync(Painting painting)
        {
            await _paintingRepository.AddAsync(painting);
        }

        public async Task RemovePaintingAsync(Painting painting, int id)
        {
            await _paintingRepository.DeleteAsync(painting, id);
        }

        public async Task<Painting> SearchPaintingAsync(int id)
        {
            return await _paintingRepository.SearchAsync(id);
        }

        public async Task<List<Painting>> GetAllPaintingAsync()
        {
            return await _paintingRepository.GetAllAsync();
        }

        public async Task UpdatePaintingAsync(Painting painting, int id)
        {
            await _paintingRepository.UpdateAsync(painting, id);
        }

        public async Task<List<Painting>> SearchPaintingByNameAsync(string name)
        {
            return await _paintingRepository.SearchByNameAsync(name);
        }
    }
}
