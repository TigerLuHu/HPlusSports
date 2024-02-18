using HPlusSports.Shared.Blob;

using Microsoft.Extensions.Options;

namespace HPlusSportsAPI.Services.Domain
{
    public class ImageService : IImageService
    {
        private readonly IBlobService _blobService;
        private readonly ImageOptions _options;

        public ImageService(IBlobService blobService, IOptions<ImageOptions> options) 
        {
            _blobService = blobService;
            _options = options.Value;
        }

        public async Task<string> UploadImageAsync(string imageName, Stream imageStream)
        {
            return await _blobService.UploadBlobImageAsync(_options.BlobContainer, imageName, imageStream);
        }
    }
}
