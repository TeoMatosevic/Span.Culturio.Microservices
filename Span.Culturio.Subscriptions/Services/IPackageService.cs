using Span.Culturio.Core.Models.Package;

namespace Span.Culturio.Subscriptions.Services {
    public interface IPackageService {
        Task<PackageDto> GetPackage(int packageId);
        Task<IEnumerable<PackageItemDto>> GetPackageItems(int packageId);
        Task<int?> GetValidDays(int packageId);
    }
}
