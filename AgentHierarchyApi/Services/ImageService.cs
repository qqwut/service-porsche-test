using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Models;
using AgentHierarchyApi.Repositories;

namespace AgentHierarchyApi.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<ImageDto>> GetAllImagesAsync()
        {
            var images = await _imageRepository.GetAllAsync();
            return images.Select(MapToDto);
        }

        public async Task<ImageDto?> GetImageByIdAsync(int id)
        {
            var image = await _imageRepository.GetByIdAsync(id);
            return image != null ? MapToDto(image) : null;
        }

        public async Task<ImageDto?> GetImageByImageCodeAsync(string imageCode)
        {
            var image = await _imageRepository.GetByImageCodeAsync(imageCode);
            return image != null ? MapToDto(image) : null;
        }

        public async Task<IEnumerable<ImageDto>> GetImagesByRefIdAsync(string refId)
        {
            var images = await _imageRepository.GetByRefIdAsync(refId);
            return images.Select(MapToDto);
        }

        public async Task<ImageDto> CreateImageAsync(CreateImageDto createDto)
        {
            // Validate ImageCode uniqueness
            if (await _imageRepository.ImageCodeExistsAsync(createDto.ImageCode))
            {
                throw new InvalidOperationException($"Image code '{createDto.ImageCode}' already exists.");
            }

            // Convert base64 to byte array
            byte[] imageData;
            try
            {
                imageData = Convert.FromBase64String(createDto.ImageBase64);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid base64 image data.");
            }

            // Convert thumbnail if provided
            byte[]? thumbnailData = null;
            if (!string.IsNullOrEmpty(createDto.ThumbnailBase64))
            {
                try
                {
                    thumbnailData = Convert.FromBase64String(createDto.ThumbnailBase64);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Invalid base64 thumbnail data.");
                }
            }

            var image = new Image
            {
                ImageCode = createDto.ImageCode,
                RefId = createDto.RefId,
                ImageTypeCode = createDto.ImageTypeCode,
                ImageCategory = createDto.ImageCategory,
                FileName = createDto.FileName,
                ImageData = imageData,
                ContentType = createDto.ContentType,
                FileSize = imageData.Length,
                Width = createDto.Width,
                Height = createDto.Height,
                ThumbnailData = thumbnailData,
                IsPrimary = createDto.IsPrimary,
                DisplayOrder = createDto.DisplayOrder,
                IsActive = createDto.IsActive,
                Remark = createDto.Remark,
                CreatedBy = createDto.CreatedBy
            };

            var createdImage = await _imageRepository.CreateAsync(image);
            return MapToDto(createdImage);
        }

        public async Task<ImageDto?> UpdateImageAsync(int id, UpdateImageDto updateDto)
        {
            var image = await _imageRepository.GetByIdAsync(id);
            if (image == null)
                return null;

            // Update fields
            if (updateDto.FileName != null)
                image.FileName = updateDto.FileName;

            if (updateDto.ImageTypeCode != null)
                image.ImageTypeCode = updateDto.ImageTypeCode;

            if (updateDto.ImageCategory != null)
                image.ImageCategory = updateDto.ImageCategory;

            if (updateDto.ImageBase64 != null)
            {
                try
                {
                    image.ImageData = Convert.FromBase64String(updateDto.ImageBase64);
                    image.FileSize = image.ImageData.Length;
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Invalid base64 image data.");
                }
            }

            if (updateDto.ThumbnailBase64 != null)
            {
                try
                {
                    image.ThumbnailData = Convert.FromBase64String(updateDto.ThumbnailBase64);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Invalid base64 thumbnail data.");
                }
            }

            if (updateDto.ContentType != null)
                image.ContentType = updateDto.ContentType;

            if (updateDto.Width.HasValue)
                image.Width = updateDto.Width;

            if (updateDto.Height.HasValue)
                image.Height = updateDto.Height;

            if (updateDto.IsPrimary.HasValue)
                image.IsPrimary = updateDto.IsPrimary.Value;

            if (updateDto.DisplayOrder.HasValue)
                image.DisplayOrder = updateDto.DisplayOrder;

            if (updateDto.IsActive.HasValue)
                image.IsActive = updateDto.IsActive.Value;

            if (updateDto.Remark != null)
                image.Remark = updateDto.Remark;

            if (updateDto.UpdatedBy != null)
                image.UpdatedBy = updateDto.UpdatedBy;

            var updatedImage = await _imageRepository.UpdateAsync(image);
            return MapToDto(updatedImage);
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            return await _imageRepository.DeleteAsync(id);
        }

        private ImageDto MapToDto(Image image)
        {
            return new ImageDto
            {
                Id = image.Id,
                ImageCode = image.ImageCode,
                RefId = image.RefId ?? string.Empty,
                ImageTypeCode = image.ImageTypeCode,
                ImageCategory = image.ImageCategory,
                FileName = image.FileName,
                ImageBase64 = image.ImageData != null ? Convert.ToBase64String(image.ImageData) : null,
                ContentType = image.ContentType,
                FileSize = image.FileSize,
                Width = image.Width,
                Height = image.Height,
                ThumbnailBase64 = image.ThumbnailData != null ? Convert.ToBase64String(image.ThumbnailData) : null,
                IsPrimary = image.IsPrimary,
                DisplayOrder = image.DisplayOrder,
                IsActive = image.IsActive,
                Remark = image.Remark,
                CreatedDate = image.CreatedDate,
                UpdatedDate = image.UpdatedDate
            };
        }
    }
}
