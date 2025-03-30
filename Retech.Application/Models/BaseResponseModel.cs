using Retech.Application.Models.ResponeModels.Storages;

namespace Retech.Application.Models;

public class BaseResponseModel
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}

public class BaseServiceResponseModel : BaseResponseModel
{
    /// <summary>
    /// Service is avalaible or not
    /// </summary>
    public bool IsServed { get; set; } = true;
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public ICollection<FileStorageResponse>? Images { get; set; }
}
