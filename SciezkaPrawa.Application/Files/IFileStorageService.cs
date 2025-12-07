namespace SciezkaPrawa.Application.Files
{
    public interface IFileStorageService
    {
        Task<string> SavePdfAsync(Stream fileStream, string fileName, Guid actId, Guid versionId);
    }
}
