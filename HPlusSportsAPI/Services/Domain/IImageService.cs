namespace HPlusSportsAPI.Services.Domain
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(string imageName, Stream imageStream); 
    }
}
