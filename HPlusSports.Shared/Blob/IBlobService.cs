namespace HPlusSports.Shared.Blob
{
    public interface IBlobService
    {
        Task<string> UploadBlobImageAsync(string containerName, string blobName, Stream imageStream);
    }
}
