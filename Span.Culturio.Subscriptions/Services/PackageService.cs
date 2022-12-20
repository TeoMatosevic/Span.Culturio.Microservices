using Microsoft.Net.Http.Headers;
using Span.Culturio.Core.Models.Package;

namespace Span.Culturio.Subscriptions.Services {
    public class PackageService : IPackageService {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public PackageService(IHttpClientFactory httpClientFactory, IConfiguration configuration) {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<PackageDto> GetPackage(int packageId) {
            var httpClient = _httpClientFactory.CreateClient("api");
            var httpResponseMessage = await httpClient.GetAsync($"{_configuration["Endpoints:Packages"]}packages");
            if (httpResponseMessage.IsSuccessStatusCode) {
                var result = await httpResponseMessage.Content.ReadFromJsonAsync<List<PackageDto>>();
                var package = result.Where(x => x.Id == packageId).First();
                return package;
            }
            return null;
        }
        public async Task<int?> GetValidDays(int packageId) {
            var package = await GetPackage(packageId);
            if (package == null) {
                return null;
            }
            var validDays = package.ValidDays;
            return validDays;
        }
        public async Task<IEnumerable<PackageItemDto>> GetPackageItems(int packageId) {
            var package = await GetPackage(packageId);
            if (package == null) return null;
            var packageItems = package.CultureObjects;
            return packageItems;
        }
    }
}
