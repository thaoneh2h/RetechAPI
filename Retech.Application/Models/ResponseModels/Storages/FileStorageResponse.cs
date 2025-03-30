namespace Retech.Application.Models.ResponeModels.Storages;

public class FileStorageResponse : BaseResponseModel
{
    public string StoragePath { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string? FileType { get; set; }
}
