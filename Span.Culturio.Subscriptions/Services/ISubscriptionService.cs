using Span.Culturio.Core.Models.Subscription;

namespace Span.Culturio.Subscriptions.Services {
    public interface ISubscriptionService {
        Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto createSubscriptionDto);
        Task<SubscriptionDto> GetAsync(int userId);
        Task<string> TrackVisit(TrackVisitDto trackVisitDto);
        Task<string> Activate(ActivateDto activateDto, int valiDays);
        Task<int> GetPackageId(int subscriptionId);
    }
}
