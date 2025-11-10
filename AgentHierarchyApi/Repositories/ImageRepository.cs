using AgentHierarchyApi.Data;
using AgentHierarchyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentHierarchyApi.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _context.Images
                .OrderByDescending(i => i.CreatedDate)
                .ToListAsync();
        }

        public async Task<Image?> GetByIdAsync(int id)
        {
            return await _context.Images
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Image?> GetByImageCodeAsync(string imageCode)
        {
            return await _context.Images
                .FirstOrDefaultAsync(i => i.ImageCode == imageCode);
        }

        public async Task<IEnumerable<Image>> GetByRefIdAsync(string refId)
        {
            return await _context.Images
                .Where(i => i.RefId == refId && i.IsActive)
                .OrderByDescending(i => i.CreatedDate)
                .ToListAsync();
        }

        public async Task<Image> CreateAsync(Image image)
        {
            image.CreatedDate = DateTime.UtcNow;
            image.UpdatedDate = DateTime.UtcNow;
            image.Uuid = Guid.NewGuid();

            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> UpdateAsync(Image image)
        {
            image.UpdatedDate = DateTime.UtcNow;
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var image = await GetByIdAsync(id);
            if (image == null)
                return false;

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ImageCodeExistsAsync(string imageCode)
        {
            return await _context.Images
                .AnyAsync(i => i.ImageCode == imageCode);
        }
    }
}
