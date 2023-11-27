using HelperStockBeta.Application.DTOs;

namespace HelperStockBeta.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int id);
        Task Add(CategoryDTO CategoryDTO);
        Task Update(CategoryDTO CategoryDTO);
        Task Remove(int? id);
    }
}
