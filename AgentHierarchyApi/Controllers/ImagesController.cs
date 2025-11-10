using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgentHierarchyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly ILogger<ImagesController> _logger;

        public ImagesController(IImageService imageService, ILogger<ImagesController> logger)
        {
            _imageService = imageService;
            _logger = logger;
        }

        /// <summary>
        /// Get all images
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetAllImages()
        {
            try
            {
                var images = await _imageService.GetAllImagesAsync();
                return Ok(images);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all images");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Get image by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDto>> GetImageById(int id)
        {
            try
            {
                var image = await _imageService.GetImageByIdAsync(id);
                if (image == null)
                    return NotFound($"Image with ID {id} not found");

                return Ok(image);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting image by ID {ImageId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Get image by image code
        /// </summary>
        [HttpGet("code/{imageCode}")]
        public async Task<ActionResult<ImageDto>> GetImageByCode(string imageCode)
        {
            try
            {
                var image = await _imageService.GetImageByImageCodeAsync(imageCode);
                if (image == null)
                    return NotFound($"Image with code {imageCode} not found");

                return Ok(image);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting image by code {ImageCode}", imageCode);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Get all images by reference ID (e.g., ClientCode)
        /// </summary>
        [HttpGet("ref/{refId}")]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetImagesByRefId(string refId)
        {
            try
            {
                var images = await _imageService.GetImagesByRefIdAsync(refId);
                return Ok(images);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting images by RefId {RefId}", refId);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Create a new image
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ImageDto>> CreateImage([FromBody] CreateImageDto createDto)
        {
            try
            {
                var image = await _imageService.CreateImageAsync(createDto);
                return CreatedAtAction(nameof(GetImageById), new { id = image.Id }, image);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Invalid operation when creating image");
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when creating image");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating image");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Update an existing image
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<ImageDto>> UpdateImage(int id, [FromBody] UpdateImageDto updateDto)
        {
            try
            {
                var image = await _imageService.UpdateImageAsync(id, updateDto);
                if (image == null)
                    return NotFound($"Image with ID {id} not found");

                return Ok(image);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid argument when updating image");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating image with ID {ImageId}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Delete an image
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            try
            {
                var result = await _imageService.DeleteImageAsync(id);
                if (!result)
                    return NotFound($"Image with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting image with ID {ImageId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
