using AgentHierarchyApi.DTOs;

namespace AgentHierarchyApi.Services
{
    public interface IImageService
    {
        Task<IEnumerable<ImageDto>> GetAllImagesAsync();
        Task<ImageDto?> GetImageByIdAsync(int id);
        Task<ImageDto?> GetImageByImageCodeAsync(string imageCode);
        Task<IEnumerable<ImageDto>> GetImagesByRefIdAsync(string refId);
        Task<ImageDto> CreateImageAsync(CreateImageDto createDto);
        Task<ImageDto?> UpdateImageAsync(int id, UpdateImageDto updateDto);
        Task<bool> DeleteImageAsync(int id);
    }
}
