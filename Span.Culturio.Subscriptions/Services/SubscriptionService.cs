using AutoMapper;
using Span.Culturio.Core.Models.Package;
using Span.Culturio.Core.Models.Subscription;
using Span.Culturio.Subscriptions.Data;
using Span.Culturio.Subscriptions.Data.Entities;

namespace Span.Culturio.Subscriptions.Services {
    public class SubscriptionService : ISubscriptionService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SubscriptionService(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> Activate(ActivateDto activateDto, int valiDays) {
            var subsription = await _context.Subscriptions.FindAsync(activateDto.SubscriptionId);
            if (subsription is null) {
                return null;
            }
            if (subsription.State == "Active") {
                return "Subsription already active";
            }
            subsription.ActiveFrom = DateTime.Now;
            subsription.State = "Active";
            _context.Subscriptions.Update(subsription);
            await _context.SaveChangesAsync();

            return "Subscription activated";
        }

        public async Task<SubscriptionDto> CreateAsync(CreateSubscriptionDto createSubscriptionDto) {
            var subscription = _mapper.Map<Subscription>(createSubscriptionDto);

            subscription.ActiveFrom = null;
            subscription.ActiveTO = null;
            subscription.State = "Inactive";
            subscription.RecordedVisits = 0;

            await _context.AddAsync(subscription);
            await _context.SaveChangesAsync();

            var subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
        }

        public Task<SubscriptionDto> GetAsync(int userId) {
            throw new NotImplementedException();
        }

        public Task<string> TrackVisit(TrackVisitDto trackVisitDto) {
            throw new NotImplementedException();
        }
        public async Task<int> GetPackageId(int subscriptionId) {
            var packageId = (await _context.Subscriptions.FindAsync(subscriptionId)).PackageId;
            return packageId;
        }
        /*public async Task<string> SetVisits(int subscriptionId, IEnumerable<PackageItemDto> packageItems) {
            packageItems.ToList().ForEach(async x => {
                var Visit = new Visits() {
                    Id = 0,
                    AvailableVisits = x.AvailableVisits,
                    SubscriptionId = subscriptionId,
                    CultureObjectId = 
                };
            });
        }*/
    }
}
