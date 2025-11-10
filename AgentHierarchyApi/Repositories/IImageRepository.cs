using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image?> GetByIdAsync(int id);
        Task<Image?> GetByImageCodeAsync(string imageCode);
        Task<IEnumerable<Image>> GetByRefIdAsync(string refId);
        Task<Image> CreateAsync(Image image);
        Task<Image> UpdateAsync(Image image);
        Task<bool> DeleteAsync(int id);
        Task<bool> ImageCodeExistsAsync(string imageCode);
    }
}
